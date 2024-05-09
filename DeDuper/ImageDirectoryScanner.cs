using DeDuper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

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

    public void ScanForDuplicates(string directoryPath, IProgress<int>? progress = null)
    {
        if (!Directory.Exists(directoryPath))
        {
            throw new ArgumentException("Directory does not exist.");
        }

        string[] files = Directory.GetFiles(directoryPath, "*.jpg");
        int totalFiles = files.Length;
        int processedFiles = 0;

        Dictionary<string, List<string>> hashGroups = new Dictionary<string, List<string>>();
        Dictionary<string, int> groupIds = new Dictionary<string, int>();
        int groupId = 0;

        foreach (string file in files)
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
                progress?.Report((processedFiles * 100) / totalFiles);
            }
        }
    }
}
