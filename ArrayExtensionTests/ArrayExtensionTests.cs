using System;
using ArrayFilter;
using ArrayFilter.Predicates;
using NUnit.Framework;

namespace ArrayExtensionTests
{
    public class Tests
    {
        [Test]
        public void ArrayExtensionTest_WithValidArray()
        {
            EvenPredicate evenPredicate = new EvenPredicate();
            int[] arr = {2,4,6,8,9};
            int[] expectedResult = {2, 4, 6, 8};
            int[] result = arr.FilterBy(evenPredicate);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ArrayExtensionTest_WithNullArray()
        {
            EvenPredicate evenPredicate = new EvenPredicate();
            int[] arr = null;
            Assert.Throws<ArgumentNullException>(() => arr.FilterBy(evenPredicate));
        }

        [Test]
        public void ArrayExtensionTest_WithEmptyArray()
        {
            EvenPredicate evenPredicate = new EvenPredicate();
            int[] arr = {};
            Assert.Throws<ArgumentException>(() => arr.FilterBy(evenPredicate));
        }

        [Test]
        public void ArrayExtensionTest_WithNullPredicate()
        {
            IPredicate predicate = null;
            int[] arr = {1, 2, 3, 4};
            Assert.Throws<ArgumentNullException>(() => arr.FilterBy(predicate));
        }
    }
}