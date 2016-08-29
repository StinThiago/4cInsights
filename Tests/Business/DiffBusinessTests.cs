using System;
using System.Collections.Generic;
using System.Text;
using _cInsights.Business;
using _cInsights.Business.Enum;
using _cInsights.Model;
using Xunit;

namespace _cInsights.Tests
{
    public class DiffBusinessTests
    {
        Diff getDefaultDiff()
        {
            return new Diff() { id = "id", left = "left", right = "right" };
        }

        [Fact]
        public void PassingLeftDirectionTest()
        {
            DiffBusiness.AddToStorage("id", "value", EnumDirection.Left);
            var left = DiffBusiness.First("id").left;
            Assert.Equal("value", left);
        }

        [Fact]
        public void PassingRightDirectionTest()
        {
            DiffBusiness.AddToStorage("id", "value", EnumDirection.Right);
            var right = DiffBusiness.First("id").right;
            Assert.Equal("value", right);
        }

        [Fact]
        public void PassingLeftDirectionNullValueTest()
        {
            DiffBusiness.AddToStorage("id", null, EnumDirection.Left);
            var left = DiffBusiness.First("id").left;
            Assert.Equal(null, left);
        }

        [Fact]
        public void PassingRightDirectionNullValueTest()
        {
            DiffBusiness.AddToStorage("id", null, EnumDirection.Right);
            var right = DiffBusiness.First("id").right;
            Assert.Equal(null, right);
        }
        [Fact]
        public void PassingLeftDirectionEmptyValueTest()
        {
            DiffBusiness.AddToStorage("id", "", EnumDirection.Left);
            var left = DiffBusiness.First("id").left;
            Assert.Equal("", left);
        }

        [Fact]
        public void PassingRightDirectionEmptyValueTest()
        {
            DiffBusiness.AddToStorage("id", "", EnumDirection.Right);
            var right = DiffBusiness.First("id").right;
            Assert.Equal("", right);
        }

        [Fact]
        public void PassingDecodeBase64StringTest()
        {
            var stringToDecode = "Zm9yIHN1cmUgWW91IFdJTEw=";
            var result = Encoding.UTF8.GetString(Convert.FromBase64String(stringToDecode));
            var decodedResult = "for sure You WILL";
            Assert.Equal(decodedResult, result);
        }

        [Fact]
        public void PassingDecodeBase64String2Test()
        {
            var stringToDecode = "eWVzIGknbGwgcmVhY2ggdGhlIEdvYWw=";
            var result = Encoding.UTF8.GetString(Convert.FromBase64String(stringToDecode));
            var decodedResult = "yes i'll reach the Goal";
            Assert.Equal(decodedResult, result);
        }

        [Fact]
        public void PassingIsTheSameLengthTest()
        {
            Diff diff = getDefaultDiff();
            DiffBusiness.AddToStorage(diff.id, diff.right, EnumDirection.Right);
            DiffBusiness.AddToStorage(diff.id, diff.right, EnumDirection.Left);
            var result = DiffBusiness.First("id").right.Length.Equals(DiffBusiness.First("id").left.Length);
            Assert.True(result);
        }

        [Fact]
        public void PassingNotIsTheSameLengthTest()
        {
            Diff diff = getDefaultDiff();
            DiffBusiness.AddToStorage(diff.id, diff.right, EnumDirection.Right);
            DiffBusiness.AddToStorage(diff.id, diff.left, EnumDirection.Left);
            var result = DiffBusiness.First("id").right.Length.Equals(DiffBusiness.First("id").left.Length);
            Assert.False(result);
        }

        [Fact]
        public void PassingGetResultNotEqualDiferenceTest()
        {
            Diff diff = getDefaultDiff();
            DiffBusiness.AddToStorage(diff.id, diff.right, EnumDirection.Right);
            DiffBusiness.AddToStorage(diff.id, diff.left, EnumDirection.Left);
            var result = DiffBusiness.GetResult("id");

            Assert.Equal(result.diference, EnumDiff.NotEqual.ToString());
        }

        [Fact]
        public void PassingGetResultSameSizeDiferenceTest()
        {
            Diff diff = getDefaultDiff();
            DiffBusiness.AddToStorage(diff.id, diff.right, EnumDirection.Right);
            DiffBusiness.AddToStorage(diff.id, "left1", EnumDirection.Left);
            var result = DiffBusiness.GetResult("id");

            Assert.Equal(result.diference, EnumDiff.SameSize.ToString());
        }


        [Fact]
        public void PassingGetResultSameSizeOffSetTest()
        {
            Diff diff = getDefaultDiff();
            DiffBusiness.AddToStorage(diff.id, diff.right, EnumDirection.Right);
            DiffBusiness.AddToStorage(diff.id, diff.left, EnumDirection.Left);
            var result = DiffBusiness.GetResult("id");

            Assert.Equal(result.offsets, 4);
        }
        [Fact]
        public void PassingGetResultSameSizeLengthTest()
        {
            Diff diff = getDefaultDiff();
            DiffBusiness.AddToStorage(diff.id, diff.right, EnumDirection.Right);
            DiffBusiness.AddToStorage(diff.id, diff.left, EnumDirection.Left);
            var result = DiffBusiness.GetResult("id");

            Assert.Equal(result.length, 5);
        }

        [Fact]
        public void PassingGetResultSameSizeTest()
        {
            DiffBusiness.AddToStorage("id", "Zm9yIHN1cmUgWW91IFdJTEw=", EnumDirection.Right);
            DiffBusiness.AddToStorage("id", "Zm9yIHN1cmUgWW91IFdJTEw=", EnumDirection.Left);
            var result = DiffBusiness.GetResult("id");

            Assert.Equal(result.diference, EnumDiff.Equal.ToString());
        }
    }
}