using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

public class ImagePhash
{
    public static string ComputePhash(string imagePath)
    {
        using (Bitmap original = new Bitmap(imagePath))
        {
            // Resize the image to a smaller, fixed size
            using (Bitmap resized = new Bitmap(original, new Size(8, 8)))
            {
                // Convert to grayscale
                using (Bitmap grayScaled = ConvertToGrayscale(resized))
                {
                    // Compute average color of the grayscale image
                    double average = ComputeAverageColor(grayScaled);

                    // Create the hash
                    StringBuilder hash = new StringBuilder();
                    for (int i = 0; i < grayScaled.Height; i++)
                    {
                        for (int j = 0; j < grayScaled.Width; j++)
                        {
                            Color pixel = grayScaled.GetPixel(j, i);
                            if (pixel.R < average) // pixel.R, pixel.G, and pixel.B are the same in grayscale
                            {
                                hash.Append('0');
                            }
                            else
                            {
                                hash.Append('1');
                            }
                        }
                    }

                    return hash.ToString();
                }
            }
        }
    }

    private static Bitmap ConvertToGrayscale(Bitmap image)
    {
        Bitmap grayscale = new Bitmap(image.Width, image.Height);

        using (Graphics g = Graphics.FromImage(grayscale))
        {
            ColorMatrix colorMatrix = new ColorMatrix(
                new float[][]
                {
                    new float[] { 0.3f, 0.3f, 0.3f, 0, 0 },
                    new float[] { 0.59f, 0.59f, 0.59f, 0, 0 },
                    new float[] { 0.11f, 0.11f, 0.11f, 0, 0 },
                    new float[] { 0, 0, 0, 1, 0 },
                    new float[] { 0, 0, 0, 0, 1 }
                });

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colorMatrix);
            g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
        }

        return grayscale;
    }

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

