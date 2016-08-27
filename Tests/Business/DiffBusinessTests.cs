using _cInsights.Business;
using _cInsights.Business.Enum;
using Xunit;

namespace _cInsights.Tests
{
    public class DiffBusinessTests
    {
        #region AddToStorage

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
        
        #endregion


        
    }
}