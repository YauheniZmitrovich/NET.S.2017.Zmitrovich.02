using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Logic.IntArraySearcher;

namespace Logic.Tests
{
    [TestClass]
    public class IntArraySearcherTests
    {

        #region TestContextDeclaring
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
        #endregion


        #region GoodArrayTests
        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\GoodArrays.xml",
            "TestCase",
            DataAccessMethod.Sequential)]
        [DeploymentItem("Logic.Tests\\GoodArrays.xml")]
        [TestMethod]
        public void GetIndexLRSumEquals_GoodArray_ReturnsExpectedIndex()
        {
            // arrange  
            int[] arr = TestContext.DataRow["array"].ToString().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            int expectedIndex = Convert.ToInt32(TestContext.DataRow["expectedIndex"]);


            // act  
            int resIndex = GetIndexLRSumEquals(arr);

            // assert 
            Assert.AreEqual(expectedIndex, resIndex);
        }

        #endregion


        [TestMethod]
        public void GetIndexLRSumEquals_IndexNotFounded_ReturnsMinus1()
        {
            // arrange  
            int[] arr = { 0, 6, 2, 3, 4 };
            int expectedIndex = -1;

            // act  
            int resIndex = GetIndexLRSumEquals(arr);

            // assert 
            Assert.AreEqual(expectedIndex, resIndex);
        }


        #region ExcArrayTests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetIndexLRSumEquals_NullArray_ShouldThrowArgumentNullException()
        {
            // arrange  
            int[] arr = null;

            // act  
            GetIndexLRSumEquals(arr);

            // assert is handled by ExpectedException  
        }


        #region ArgExceptionTests
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetIndexLRSumEquals_ArrayLengthMoreThen999_ShouldThrowArgumentException()
        {
            // arrange  
            int[] arr = new int[1000];
            for (int i = 0; i < 1000; i++)
                arr[i] = i;
            // act  
            GetIndexLRSumEquals(arr);

            // assert is handled by ExpectedException  
        }

        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\ArgExcArrays.xml",
            "TestCase",
            DataAccessMethod.Sequential)]
        [DeploymentItem("Logic.Tests\\ArgExcArrays.xml")]
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetIndexLRSumEquals_IncorrectLengthOfArray_ShouldThrowArgumenException()
        {
            // arrange  
            int[] arr = TestContext.DataRow["array"].ToString().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            // act  
            GetIndexLRSumEquals(arr);

            // assert is handled by ExpectedException  
        }
        #endregion
        #endregion
    }
}