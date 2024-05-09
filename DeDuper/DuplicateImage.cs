using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeDuper
{
    // Represents an image that has been identified as a duplicate.
    public class DuplicateImage
    {
        // Group identifier for duplicates, images in the same group are considered duplicates.
        public int GroupId { get; set; }

        // Path to the image file.
        public string? ImagePath { get; set; }

        // Similarity score indicating how closely this image matches other duplicates, based on the Hamming distance.
        public int SimilarityScore { get; set; }
    }
}
