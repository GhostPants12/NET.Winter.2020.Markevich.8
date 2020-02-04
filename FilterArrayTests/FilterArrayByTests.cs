using System.Runtime.InteropServices.ComTypes;
using System;
using FilterArray;
using NUnit.Framework;
using Moq;
using Moq.Protected;

namespace FilterArrayByTests
{
    public class FilterArrayTests
    {
        [Test]
        public void FilterArrayByStateTest()
        {
            var mockFilterArrayBy = new Mock<FilterArrayBy>();
            mockFilterArrayBy.Setup<bool>(foo => foo.Validate(It.Is<int>(i => i % 2 == 0))).Returns(true);
            FilterArrayBy filterArrayBy = mockFilterArrayBy.Object;
            int[] sourceArr = { 12, 25, 43, 149, 156, 178, 200 };
            int[] expectedResult = { 12, 156, 178, 200 };
            int[] returnedResult = filterArrayBy.FilterArray(sourceArr);
            CollectionAssert.AreEqual(expectedResult, returnedResult);
        }

        [Test]
        public void FilterArrayByBehaviourTest()
        {
            var mockFilterArrayBy = new Mock<FilterArrayBy>();
            mockFilterArrayBy.Setup<bool>(foo => foo.Validate(It.Is<int>(i => i % 2 == 0))).Returns(true);
            FilterArrayBy filterArrayBy = mockFilterArrayBy.Object;
            int[] sourceArr = { 12, 25, 43, 149, 156, 178, 200 };
            filterArrayBy.FilterArray(sourceArr);
            mockFilterArrayBy.Verify(foo => foo.Validate(It.Is<int>(i => true)), Times.Exactly(7));
        }
    }
}