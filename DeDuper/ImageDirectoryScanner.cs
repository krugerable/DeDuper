using DeDuper;
using System.ComponentModel;

public class ImageDirectoryScanner
{
    public int Threshold { get; set; }
    public BindingList<DuplicateImage> DuplicateImages { get; private set; }

    public ImageDirectoryScanner(int threshold)
    {
        if (threshold < 1 || threshold > 100)
        {
            throw new ArgumentException("Threshold must be between 1 and 100.");
        }
        this.Threshold = threshold;
        this.DuplicateImages = new BindingList<DuplicateImage>();
    }

    public void ScanForDuplicates(string directoryPath)
    {
        if (!Directory.Exists(directoryPath))
        {
            throw new ArgumentException("Directory does not exist.");
        }

        Dictionary<string, List<string>> hashGroups = new Dictionary<string, List<string>>();
        Dictionary<string, int> groupIds = new Dictionary<string, int>();
        int groupId = 0;

        foreach (string file in Directory.GetFiles(directoryPath, "*.jpg"))
        {
            try
            {
                string hash = ImagePhash.ComputePhash(file);
                bool foundGroup = false;

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

                if (!foundGroup)
                {
                    groupId++;
                    hashGroups[hash] = new List<string> { file };
                    groupIds[hash] = groupId;
                    DuplicateImages.Add(new DuplicateImage { GroupId = groupId, ImagePath = file, SimilarityScore = 0 });  // No similarity score as it's the first in the group
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing file {file}: {ex.Message}");
            }
        }
    }
}
