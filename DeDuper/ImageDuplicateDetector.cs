using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Threading.Tasks;
using ImageMagick;

namespace DeDuper
{
    public class ImageDuplicateDetector
    {
        /// <summary>
        /// Calculates the Hamming distance between two binary strings.
        /// </summary>
        /// <param name="hash1">First binary hash string.</param>
        /// <param name="hash2">Second binary hash string.</param>
        /// <returns>The Hamming distance.</returns>
        private int CalculateHammingDistance(string hash1, string hash2)
        {
            if (hash1.Length != hash2.Length)
                throw new ArgumentException("Hashes must be of equal length");

            int distance = 0;
            for (int i = 0; i < hash1.Length; i++)
            {
                if (hash1[i] != hash2[i])
                    distance++;
            }
            return distance;
        }

        /// <summary>
        /// Computes the average hash of an image.
        /// </summary>
        /// <param name="image">Bitmap of the image.</param>
        /// <returns>A binary string representing the hash.</returns>
        private string ComputeAverageHash(Bitmap image)
        {
            try
            {
                using (var resized = new Bitmap(image, new Size(8, 8)))
                using (var gray = new Bitmap(resized.Width, resized.Height, PixelFormat.Format16bppGrayScale))
                using (Graphics g = Graphics.FromImage(gray))
                {
                    g.DrawImage(resized, new Rectangle(0, 0, resized.Width, resized.Height));
                    long sum = 0;
                    for (int i = 0; i < gray.Width; i++)
                    {
                        for (int j = 0; j < gray.Height; j++)
                        {
                            sum += gray.GetPixel(i, j).R;
                        }
                    }
                    long avg = sum / (gray.Width * gray.Height);
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < gray.Width; i++)
                    {
                        for (int j = 0; j < gray.Height; j++)
                        {
                            sb.Append(gray.GetPixel(i, j).R >= avg ? '1' : '0');
                        }
                    }
                    return sb.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to compute average hash.", ex);
            }
        }

        /// <summary>
        /// Determines if two images are duplicates based on average hash.
        /// </summary>
        /// <param name="image1">First image to compare.</param>
        /// <param name="image2">Second image to compare.</param>
        /// <param name="threshold">Threshold for Hamming distance to consider images as duplicates.</param>
        /// <returns>True if images are considered duplicates.</returns>
        public bool AreDuplicates_AverageHash(Bitmap image1, Bitmap image2, int threshold = 10)
        {
            try
            {
                string hash1 = ComputeAverageHash(image1);
                string hash2 = ComputeAverageHash(image2);
                return CalculateHammingDistance(hash1, hash2) <= threshold;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error checking duplicates using average hash.", ex);
            }
        }

        /// <summary>
        /// Asynchronously determines if two images are duplicates using average hash.
        /// </summary>
        /// <param name="image1">First image to compare.</param>
        /// <param name="image2">Second image to compare.</param>
        /// <param name="threshold">Threshold for Hamming distance to consider images as duplicates.</param>
        /// <returns>Task that returns true if images are considered duplicates.</returns>
        public async Task<bool> AreDuplicates_AverageHashAsync(Bitmap image1, Bitmap image2, int threshold = 10)
        {
            return await Task.Run(() => AreDuplicates_AverageHash(image1, image2, threshold));
        }

        /// <summary>
        /// Computes the perceptual hash of an image using simplified DCT-like features.
        /// </summary>
        /// <param name="imagePath">Path to the image file.</param>
        /// <returns>A binary string representing the perceptual hash.</returns>
        private string ComputePerceptualHash(string imagePath)
        {
            try
            {
                using (var image = new MagickImage(imagePath))
                {
                    image.ColorType = ColorType.Bilevel;
                    image.Resize(32, 32);

                    // Simplify the process by focusing on major color averages
                    var pixels = image.GetPixels();
                    long sum = 0;
                    foreach (var pixel in pixels)
                    {
                        sum += pixel.GetChannel(0); // Assuming grayscale, so just read one channel
                    }
                    long avg = sum / (32 * 32);

                    var sb = new StringBuilder();
                    foreach (var pixel in pixels)
                    {
                        sb.Append(pixel.GetChannel(0) >= avg ? '1' : '0');
                    }
                    return sb.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to compute perceptual hash.", ex);
            }
        }

        /// <summary>
        /// Determines if two images are duplicates based on perceptual hash.
        /// </summary>
        /// <param name="imagePath1">First image file path.</param>
        /// <param name="imagePath2">Second image file path.</param>
        /// <param name="threshold">Threshold for Hamming distance to consider images as duplicates.</param>
        /// <returns>True if images are considered duplicates.</returns>
        public bool AreDuplicates_PerceptualHash(string imagePath1, string imagePath2, int threshold = 10)
        {
            try
            {
                string hash1 = ComputePerceptualHash(imagePath1);
                string hash2 = ComputePerceptualHash(imagePath2);
                int distance = CalculateHammingDistance(hash1, hash2);
                return distance <= threshold;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error checking duplicates using perceptual hash.", ex);
            }
        }

        /// <summary>
        /// Asynchronously determines if two images are duplicates using perceptual hash.
        /// </summary>
        /// <param name="imagePath1">First image file path.</param>
        /// <param name="imagePath2">Second image file path.</param>
        /// <param name="threshold">Threshold for Hamming distance to consider images as duplicates.</param>
        /// <returns>Task that returns true if images are considered duplicates.</returns>
        public async Task<bool> AreDuplicates_PerceptualHashAsync(string imagePath1, string imagePath2, int threshold = 10)
        {
            return await Task.Run(() => AreDuplicates_PerceptualHash(imagePath1, imagePath2, threshold));
        }


        // Additional methods for pHash, dHash, Pixel Comparison, and Feature Based are omitted for brevity
        // but would follow similar patterns of error handling, asynchronous execution, and documentation.
    }
}
