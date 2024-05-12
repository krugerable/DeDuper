using System.ComponentModel;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace DeDuper
{
    public class ImageDirectoryScanner
    {
        // Threshold for determining when two images are considered duplicates.
        public int Threshold { get; set; }

        // List to hold identified duplicate images.
        public BindingList<DuplicateImage> DuplicateImages { get; private set; }

        // Constructor that sets the similarity threshold for duplicates.
        public ImageDirectoryScanner(int threshold)
        {
            if (threshold < 1 || threshold > 100)
            {
                throw new ArgumentException("Threshold must be between 1 and 100.");
            }
            this.Threshold = threshold;
            this.DuplicateImages = new BindingList<DuplicateImage>();
        }

        // Scans the specified directory for duplicate images.
        public void ScanForDuplicates(string directoryPath, IProgress<int>? progress = null)
        {
            if (!Directory.Exists(directoryPath))
            {
                throw new ArgumentException("Directory does not exist.");
            }

            // Retrieves all JPEG files in the directory.
            string[] files = Directory.GetFiles(directoryPath, "*.jpg");
            int totalFiles = files.Length;
            int processedFiles = 0;

            // Used to group similar images together.
            Dictionary<string, List<string>> hashGroups = new Dictionary<string, List<string>>();
            Dictionary<string, int> groupIds = new Dictionary<string, int>();
            int groupId = 0;

            // Process each file in the directory.
            foreach (string file in files)
            {
                try
                {
                    // Compute the perceptual hash of the image.
                    string hash = ImagePhash.ComputePhash(file);
                    bool foundGroup = false;

                    // Check against existing groups for a match within the threshold.
                    foreach (var key in hashGroups.Keys.ToList())
                    {
                        int hammingDistance = ImagePhash.ComputeHammingDistance(key, hash);
                        if (hammingDistance <= Threshold)
                        {
                            hashGroups[key].Add(file);
                            DuplicateImages.Add(new DuplicateImage { GroupId = groupIds[key], ImagePath = file, SimilarityScore = hammingDistance });
                            foundGroup = true;
                            break;
                        }
                    }

                    // Create a new group if no existing group matches.
                    if (!foundGroup)
                    {
                        groupId++;
                        hashGroups[hash] = new List<string> { file };
                        groupIds[hash] = groupId;
                        DuplicateImages.Add(new DuplicateImage { GroupId = groupId, ImagePath = file, SimilarityScore = 0 });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing file {file}: {ex.Message}");
                }
                finally
                {
                    processedFiles++;
                    // Update progress.
                    progress?.Report((processedFiles * 100) / totalFiles);
                }
            }
        }
    }
}
