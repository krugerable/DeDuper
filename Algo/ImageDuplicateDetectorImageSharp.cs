using SixLabors.ImageSharp; // Include ImageSharp namespace
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.PixelFormats;
using System.Text;

namespace Algo
{
    public class ImageDuplicateDetectorImageSharp
    {
        public async Task<bool> AreDuplicates_AverageHashAsync(string imagePath1, string imagePath2, int threshold = 10)
        {
            using (var image1 = Image.Load<Rgba32>(imagePath1))
            using (var image2 = Image.Load<Rgba32>(imagePath2))
            {
                string hash1 = ComputeAverageHash(image1);
                string hash2 = ComputeAverageHash(image2);
                int distance = CalculateHammingDistance(hash1, hash2);
                return distance <= threshold;
            }
        }

        private string ComputeAverageHash(Image<Rgba32> image)
        {
            image.Mutate(x => x.Resize(8, 8).Grayscale());
            long sum = 0;
            image.ProcessPixelRows(accessor =>
            {
                for (int y = 0; y < accessor.Height; y++)
                {
                    var pixelRow = accessor.GetRowSpan(y);
                    for (int x = 0; x < pixelRow.Length; x++)
                    {
                        sum += pixelRow[x].R;
                    }
                }
            });

            long avg = sum / (64); // Total pixels 8*8
            StringBuilder sb = new StringBuilder();
            image.ProcessPixelRows(accessor =>
            {
                for (int y = 0; y < accessor.Height; y++)
                {
                    var pixelRow = accessor.GetRowSpan(y);
                    for (int x = 0; x < pixelRow.Length; x++)
                    {
                        sb.Append(pixelRow[x].R >= avg ? '1' : '0');
                    }
                }
            });
            return sb.ToString();
        }

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

        // Add other methods (pHash, dHash, etc.) here following the same pattern...
    }
}
