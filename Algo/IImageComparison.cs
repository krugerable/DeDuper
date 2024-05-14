using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel;

namespace Algo
{
    public enum ComparisonMethod
    {
        PerceptualHash,
        AverageHash,
        DifferenceHash,
        ColorHistogram
    }

    internal interface IImageComparison
    {
        Task<string?> CompareImagesAsync(string path1, string path2, int threshold, ComparisonMethod method);

    }


}
