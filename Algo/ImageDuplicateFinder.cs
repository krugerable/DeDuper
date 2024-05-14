using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    internal class ImageDuplicateFinder
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
                switch (method)
                {
                    case ComparisonMethod.PerceptualHash:
                        return await CheckDuplicateAsync(path1, path2, threshold, ImageComparison.CompareUsingPHash);
                    case ComparisonMethod.AverageHash:
                        return await CheckDuplicateAsync(path1, path2, threshold, ImageComparison.CompareUsingAHash);
                    case ComparisonMethod.DifferenceHash:
                        // Implement this method similar to CompareUsingAHash
                        break;
                    case ComparisonMethod.ColorHistogram:
                        // Implement this method similar to CompareUsingAHash
                        break;
                    default:
                        throw new ArgumentException("Invalid comparison method specified.");
                }
                return null;
            }

            private async Task<string?> CheckDuplicateAsync(string path1, string path2, int threshold, Func<string, string, int, bool> comparisonFunc)
            {
                bool isDuplicate = await Task.Run(() => comparisonFunc(path1, path2, threshold));
                return isDuplicate ? $"{path1} is a duplicate of {path2}" : null;
            }

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
