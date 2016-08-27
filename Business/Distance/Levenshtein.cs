/*
Levenshtein. In 1965 Vladmir Levenshtein created a distance algorithm.
This tells us the number of edits needed to turn one string into another. 
With Levenshtein distance, we measure similarity and match approximate strings with fuzzy logic.

Info: Returns the number of character edits (removals, inserts, replacements) that must occur 
to get from string A to string B.

Levenshtein distance may also be referred to as edit distance, 
although that may also denote a larger family of distance metrics.[2]:32 
It is closely related to pairwise string alignments.

Source: https://en.wikipedia.org/wiki/Levenshtein_distance
*/

using System;

namespace _cInsights.Business.Distance
{
    /// <summary>
    /// Contains approximate string matching
    /// </summary>
    static class Levenshtein
    {
        /// <summary>
        /// Compute the distance between two strings.
        /// </summary>
        public static int Compute(string right, string left)
        {
            if (right == null) throw new ArgumentNullException("right");
            if (right.Trim() == String.Empty) throw new ArgumentException("Input cannot be empty", "right");

            if (left == null) throw new ArgumentNullException("left");
            if (left.Trim() == String.Empty) throw new ArgumentException("Input cannot be empty", "left");

            int r = right.Length;
            int l = left.Length;
            int[,] d = new int[r + 1, l + 1];

            if (r == 0) return l;
            if (l == 0) return r;

            for (int i = 0; i <= r; d[i, 0] = i++) { }
            for (int j = 0; j <= l; d[0, j] = j++) { }

            for (int i = 1; i <= r; i++)
            {
                for (int j = 1; j <= l; j++)
                {
                    int cost = (left[j - 1] == right[i - 1]) ? 0 : 1;

                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            return d[r, l];
        }
    }
}