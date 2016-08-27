using _cInsights.Business.Distance;
using Xunit;

namespace _cInsights.Tests
{
    public class LevenshteinßTests
    {
        [Fact]
        public void PassingEqualStringsComputeTest()
        {
            var result = Levenshtein.Compute("right", "right");
            Assert.Equal(result, 0);
        }

        /// <summary>
        /// Needed two movements to re-write the word to be equals each other.
        /// </summary>
        [Fact]
        public void PassingOneChangeStringComputeTest()
        {
            var result = Levenshtein.Compute("rigth", "right");
            Assert.Equal(result, 2);

        }

        /// <summary>
        ///  Needed three movements to re-write the word to be equals each other.
        /// </summary>
        [Fact]
        public void PassingTwoChangeStringComputeTest()
        {
            var result = Levenshtein.Compute("rixxh", "right");
            Assert.Equal(result, 3);
        }

        /// <summary>
        ///  Needed nine movements to re-write the word to be equals each other.
        ///  Nine is the number of the characters in the first word, so need to change all the word.
        /// </summary>
        [Fact]
        public void PassingAllChangeStringComputeTest()
        {
            var result = Levenshtein.Compute("2132DSAss", "right");
            Assert.Equal(result, 9);
        }

        /// <summary>
        ///  Needed eleven movements to re-write the word to be equals each other.
        ///  Eleven is the number of the characters in the first word, so need to change all the word.
        /// </summary>
        [Theory]
        [InlineData("2981yu398hf", "sddss")]
        public void PassingTwoDiferenceStringComputeTest(string s1, string s2)
        {
            var result = Levenshtein.Compute(s1, s2);
            Assert.NotEqual(s1, s2);
            Assert.Equal(result, 11);
        }

        /// <summary>
        ///  Testing null first parameter that throws an exception
        /// </summary>
        [Fact]
        public void PassingNullFirstStringComputeTest()
        {
            System.ArgumentNullException ex =
            Assert.Throws<System.ArgumentNullException>(() => Levenshtein.Compute(null, "sddss"));

            Assert.Contains("Value cannot be null.", ex.Message);
        }

        /// <summary>
        ///  Testing null first parameter that throws an exception
        /// </summary>
        [Fact]
        public void PassingEmptyFirstStringComputeTest()
        {
            System.ArgumentException ex =
            Assert.Throws<System.ArgumentException>(() => Levenshtein.Compute(string.Empty, "sddss"));

            Assert.Contains("Input cannot be empty", ex.Message);
        }

        /// <summary>
        ///  Testing null second parameter that throws an  exception
        /// </summary>
        [Fact]
        public void PassingNullSecondStringComputeTest()
        {
            System.ArgumentNullException ex =
            Assert.Throws<System.ArgumentNullException>(() => Levenshtein.Compute("sddss", null));

            Assert.Contains("Value cannot be null.", ex.Message);
        }

        /// <summary>
        ///  Testing null second parameter that throws an  exception
        /// </summary>
        [Fact]
        public void PassingEmptySecondStringComputeTest()
        {
            System.ArgumentException ex =
            Assert.Throws<System.ArgumentException>(() => Levenshtein.Compute("sddss", string.Empty));

            Assert.Contains("Input cannot be empty", ex.Message);
        }
    }
}