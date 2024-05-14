using System.ComponentModel;
using System.Drawing.Imaging;
using System.Drawing;

namespace Algo
{

    public class ImageDuplicateFinder : INotifyPropertyChanged, IImageComparison
    {
        private List<string>? _duplicateFiles;
        private int _progress;
        public event PropertyChangedEventHandler? PropertyChanged;

        public List<string>? DuplicateFiles
        {
            get { return _duplicateFiles; }
            private set
            {
                _duplicateFiles = value;
                OnPropertyChanged(nameof(DuplicateFiles));
            }
        }

        public int Progress
        {
            get { return _progress; }
            private set
            {
                _progress = value;
                OnPropertyChanged(nameof(Progress));
            }
        }

        public ImageDuplicateFinder()
        {
            DuplicateFiles = new List<string>();
        }

        public async Task<string?> CompareImagesAsync(string path1, string path2, int threshold, ComparisonMethod method)
        {
            Func<string, string, int, Task<bool>> comparisonFunction = GetComparisonFunction(method);
            bool isDuplicate = await comparisonFunction(path1, path2, threshold);
            return isDuplicate ? $"{path1} is a duplicate of {path2}" : null;
        }

        private Func<string, string, int, Task<bool>> GetComparisonFunction(ComparisonMethod method)
        {
            switch (method)
            {
                case ComparisonMethod.PerceptualHash:
                    return ImageComparison.CompareUsingPHashAsync;
                case ComparisonMethod.AverageHash:
                    return ImageComparison.CompareUsingAHashAsync;
                case ComparisonMethod.DifferenceHash:
                    return ImageComparison.CompareUsingDHashAsync;
                case ComparisonMethod.ColorHistogram:
                    return ImageComparison.CompareUsingColorHistogramAsync;
                default:
                    throw new ArgumentException("Invalid comparison method specified.");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Assuming these are implemented somewhere in your project
    public static class ImageComparison
    {
        #region PHash
        public static async Task<bool> CompareUsingPHashAsync(string path1, string path2, int threshold)
        {
            ulong hash1 = await ComputePHashAsync(path1);
            ulong hash2 = await ComputePHashAsync(path2);

            // Calculate the Hamming distance
            int distance = HammingDistance(hash1, hash2);

            // Compare to threshold
            return distance <= threshold;
        }

        private static async Task<ulong> ComputePHashAsync(string imagePath)
        {
            return await Task.Run(() =>
            {
                using (Image img = Image.FromFile(imagePath))
                {
                    using (Image resized = ResizeImage(img, 8, 8))
                    using (Bitmap gray = ConvertToGrayscale(resized))
                    {
                        ulong hash = 0;
                        double total = 0;
                        for (int y = 0; y < gray.Height; y++)
                        {
                            for (int x = 0; x < gray.Width; x++)
                            {
                                total += gray.GetPixel(x, y).R;
                            }
                        }

                        double average = total / 64;

                        for (int y = 0; y < gray.Height; y++)
                        {
                            for (int x = 0; x < gray.Width; x++)
                            {
                                hash |= ((gray.GetPixel(x, y).R < average) ? 0UL : (1UL << (x + y * 8)));
                            }
                        }

                        return hash;
                    }
                }
            });
        }

        private static Image ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private static Bitmap ConvertToGrayscale(Image image)
        {
            var bmp = new Bitmap(image.Width, image.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                ColorMatrix colorMatrix = new ColorMatrix(
                    new float[][]
                    {
                    new float[] {0.3f, 0.3f, 0.3f, 0, 0},
                    new float[] {0.59f, 0.59f, 0.59f, 0, 0},
                    new float[] {0.11f, 0.11f, 0.11f, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                    });
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(colorMatrix);
                g.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
            }

            return bmp;
        }

        private static int HammingDistance(ulong hash1, ulong hash2)
        {
            ulong diff = hash1 ^ hash2;
            int count = 0;
            while (diff != 0)
            {
                count++;
                diff &= diff - 1;
            }
            return count;
        }
        #endregion

        #region AHash
        public static async Task<bool> CompareUsingAHashAsync(string path1, string path2, int threshold)
        {
            ulong hash1 = await ComputeAHashAsync(path1);
            ulong hash2 = await ComputeAHashAsync(path2);

            // Calculate the Hamming distance
            int distance = HammingDistance(hash1, hash2);

            // Compare to threshold
            return distance <= threshold;
        }

        private static async Task<ulong> ComputeAHashAsync(string imagePath)
        {
            return await Task.Run(() =>
            {
                using (var img = Image.FromFile(imagePath))
                {
                    using (var resized = ResizeImage(img, 8, 8))
                    using (var gray = ConvertToGrayscale(resized))
                    {
                        ulong hash = 0;
                        int pixelIndex = 0;
                        int[] values = new int[64];

                        for (int y = 0; y < gray.Height; y++)
                        {
                            for (int x = 0; x < gray.Width; x++)
                            {
                                Color pixel = gray.GetPixel(x, y);
                                values[pixelIndex] = pixel.R;  // R is the same as G and B in grayscale
                                pixelIndex++;
                            }
                        }

                        int average = (int)values.Average();

                        for (int i = 0; i < values.Length; i++)
                        {
                            if (values[i] >= average)
                            {
                                hash |= (1UL << i);
                            }
                        }

                        return hash;
                    }
                }
            });
        }
        #endregion

        #region DHash
        public static async Task<bool> CompareUsingDHashAsync(string path1, string path2, int threshold)
        {
            ulong hash1 = await ComputeDHashAsync(path1);
            ulong hash2 = await ComputeDHashAsync(path2);

            // Calculate the Hamming distance
            int distance = HammingDistance(hash1, hash2);

            // Compare to threshold
            return distance <= threshold;
        }

        private static async Task<ulong> ComputeDHashAsync(string imagePath)
        {
            return await Task.Run(() =>
            {
                using (var img = Image.FromFile(imagePath))
                {
                    using (var resized = ResizeImage(img, 9, 8)) // Notice width is 9 for dHash
                    using (var gray = ConvertToGrayscale(resized))
                    {
                        ulong hash = 0;
                        for (int y = 0; y < gray.Height; y++)
                        {
                            for (int x = 0; x < gray.Width - 1; x++)
                            {
                                Color pixelLeft = gray.GetPixel(x, y);
                                Color pixelRight = gray.GetPixel(x + 1, y);
                                hash |= (pixelLeft.R < pixelRight.R ? 1UL : 0UL) << (y * 8 + x);
                            }
                        }
                        return hash;
                    }
                }
            });
        }
        #endregion

        #region ColorHistogram
        public static async Task<bool> CompareUsingColorHistogramAsync(string path1, string path2, double threshold)
        {
            var histogram1 = await ComputeColorHistogramAsync(path1);
            var histogram2 = await ComputeColorHistogramAsync(path2);

            // Calculate the similarity measure
            double similarity = CompareHistograms(histogram1, histogram2);

            // Check if the similarity is above the threshold
            return similarity >= threshold;
        }

        private static async Task<int[][]> ComputeColorHistogramAsync(string imagePath)
        {
            return await Task.Run(() =>
            {
                using (var img = Image.FromFile(imagePath))
                {
                    int[][] histogram = new int[3][]; // RGB channels
                    histogram[0] = new int[256]; // Red
                    histogram[1] = new int[256]; // Green
                    histogram[2] = new int[256]; // Blue

                    Bitmap bmp = new Bitmap(img);
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        for (int x = 0; x < bmp.Width; x++)
                        {
                            Color pixel = bmp.GetPixel(x, y);
                            histogram[0][pixel.R]++;
                            histogram[1][pixel.G]++;
                            histogram[2][pixel.B]++;
                        }
                    }
                    bmp.Dispose();
                    return histogram;
                }
            });
        }

        private static double CompareHistograms(int[][] histogram1, int[][] histogram2)
        {
            // Calculate the Bhattacharyya coefficient for the histograms
            double coefficient = 0;

            for (int i = 0; i < 3; i++) // for each channel R, G, B
            {
                double sum1 = 0, sum2 = 0, sum3 = 0;
                for (int j = 0; j < 256; j++)
                {
                    sum1 += Math.Sqrt(histogram1[i][j] * histogram2[i][j]);
                    sum2 += histogram1[i][j];
                    sum3 += histogram2[i][j];
                }
                coefficient += (sum1 / Math.Sqrt(sum2 * sum3));
            }

            // The coefficient ranges from 0 to 1, where 1 means identical
            return coefficient / 3; // Normalize by number of channels
        }
        #endregion
    }
}
