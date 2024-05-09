using System.Drawing.Imaging;
using System.Text;

public class ImagePhash
{
    // Computes the perceptual hash of an image.
    public static string ComputePhash(string imagePath)
    {
        using (Bitmap original = new Bitmap(imagePath))
        {
            // Resize the image to 8x8 pixels to simplify the hash computation.
            using (Bitmap resized = new Bitmap(original, new Size(8, 8)))
            {
                // Convert the resized image to grayscale.
                using (Bitmap grayScaled = ConvertToGrayscale(resized))
                {
                    // Compute the average color value of the grayscale image.
                    double average = ComputeAverageColor(grayScaled);

                    // Create the hash based on the pixels being above or below the average color.
                    StringBuilder hash = new StringBuilder();
                    for (int i = 0; i < grayScaled.Height; i++)
                    {
                        for (int j = 0; j < grayScaled.Width; j++)
                        {
                            Color pixel = grayScaled.GetPixel(j, i);
                            hash.Append(pixel.R < average ? '0' : '1');
                        }
                    }

                    return hash.ToString();
                }
            }
        }
    }

    // Converts an image to grayscale.
    private static Bitmap ConvertToGrayscale(Bitmap image)
    {
        Bitmap grayscale = new Bitmap(image.Width, image.Height);
        using (Graphics g = Graphics.FromImage(grayscale))
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
            g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
        }
        return grayscale;
    }

    // Computes the average color value of a grayscale image.
    private static double ComputeAverageColor(Bitmap image)
    {
        double total = 0;
        for (int i = 0; i < image.Height; i++)
        {
            for (int j = 0; j < image.Width; j++)
            {
                Color pixel = image.GetPixel(j, i);
                total += pixel.R; // In a grayscale image, R, G, and B are equal
            }
        }
        return total / (image.Width * image.Height);
    }

    // Computes the Hamming distance between two hashes to measure similarity.
    public static int ComputeHammingDistance(string hash1, string hash2)
    {
        if (hash1.Length != hash2.Length)
        {
            throw new ArgumentException("Hashes must be of the same length.");
        }

        int distance = 0;
        for (int i = 0; i < hash1.Length; i++)
        {
            if (hash1[i] != hash2[i])
            {
                distance++;
            }
        }
        return distance;
    }
}
