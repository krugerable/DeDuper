using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace Algo
{
    public class ImageDirectoryScannerOptions
    {
        private ImageDuplicateDetector detector;

        public ImageDirectoryScannerOptions() => detector = new ImageDuplicateDetector();

        /// <summary>
        /// Scans the specified directory for image duplicates using a selected duplication detection method.
        /// </summary>
        /// <param name="directoryPath">Path to the directory containing images.</param>
        /// <param name="dupMethod">The duplication detection method as an integer (1-5).</param>
        /// <returns>A list of tuples where each tuple contains paths of duplicate images.</returns>
        public async Task<List<Tuple<string, string>>> ScanForDuplicates(string directoryPath, int dupMethod = 1)
        {
            List<Tuple<string, string>> duplicates = new List<Tuple<string, string>>();
            string[] files = Directory.GetFiles(directoryPath, "*.jpg"); // Assuming JPEG images, adjust if needed.

            // Compare each file with every other file in the directory
            for (int i = 0; i < files.Length; i++)
            {
                for (int j = i + 1; j < files.Length; j++)
                {
                    bool areDuplicates = false;
                    switch (dupMethod)
                    {
                        case 1: // Average Hash
                            areDuplicates = await detector.AreDuplicates_AverageHashAsync(new Bitmap(files[i]), new Bitmap(files[j]));
                            break;
                        case 2: // Perceptual Hash
                            areDuplicates = await detector.AreDuplicatesPerceptualHashAsync(files[i], files[j]);
                            break;
                        case 3: // Difference Hash
                            areDuplicates = await detector.AreDuplicates_DifferenceHashAsync(new Bitmap(files[i]), new Bitmap(files[j]));
                            break;
                        case 4: // Pixel Comparison
                            areDuplicates = await detector.AreDuplicates_PixelComparisonAsync(new Bitmap(files[i]), new Bitmap(files[j]));
                            break;
                        case 5: // Feature-Based Comparison
                            areDuplicates = await detector.AreDuplicatesFeatureBasedAsync(files[i], files[j]);
                            break;
                        default:
                            throw new ArgumentException("Invalid duplication method selected.");
                    }

                    if (areDuplicates)
                    {
                        duplicates.Add(new Tuple<string, string>(files[i], files[j]));
                    }
                }
            }

            return duplicates;
        }
    }
}
