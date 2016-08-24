/*
    Longest Common Subsequence – Diff Algortithm
    This is the divide-and-conquer implementation of the longes common-subsequence algorithm.

    The longest common subsequence (LCS) problem is the problem of finding the longest subsequence common to all sequences in a set of sequences
    (often just two sequences). It differs from problems of finding common substrings: unlike substrings, subsequences are not required to 
    occupy consecutive positions within the original sequences. 
    
    The longest common subsequence problem is a classic computer science problem, 
    the basis of data comparison programs such as the diff utility, and has applications in bioinformatics. 
    It is also widely used by revision control systems such as Git for reconciling multiple changes made to a revision-controlled collection of files.

    Source: https://en.wikipedia.org/wiki/Longest_common_subsequence_problem
*/
namespace _cInsights.Business.Distance
{
    public static class LCS
    {
        static int[,] c;

        static int max(int a, int b)
        {
            return (a > b) ? a : b;
        }
        public static int Result(string s1, string s2)
        {
            c = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 1; i <= s1.Length; i++) c[i, 0] = 0;
            for (int i = 1; i <= s2.Length; i++) c[0, i] = 0;

            for (int i = 1; i <= s1.Length; i++)
                for (int j = 1; j <= s2.Length; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                        c[i, j] = c[i - 1, j - 1] + 1;
                    else
                    {
                        c[i, j] = max(c[i - 1, j], c[i, j - 1]);
                    }
                }
            return c[s1.Length, s2.Length];
        }
    }
}
