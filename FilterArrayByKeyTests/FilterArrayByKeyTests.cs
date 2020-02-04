using System;
using FilterArray;
using NUnit.Framework;

namespace FilterArrayByKeyTests
{
    public class FilterArrayByKeyTests
    {
        #region FilterArrayByKeyTests
        [TestCase(new[] { 2212332, 1405644, -1236674 }, 0, ExpectedResult = new[] { 1405644 })]
        [TestCase(new[] { 53, 71, -24, 1001, 32, 1005 }, 2, ExpectedResult = new[] { -24, 32 })]
        [TestCase(new[] { -27, 173, 371132, 7556, 7243, 10017 }, 7, ExpectedResult = new[] { -27, 173, 371132, 7556, 7243, 10017 })]
        [TestCase(new[] { 7, 2, 5, 5, -1, -1, 2 }, 9, ExpectedResult = new int[0])]
        [TestCase(new[] { 15, 25, 60, 74, 189, int.MinValue, 32 }, 2, ExpectedResult = new[] { 25, int.MinValue, 32 })]
        public static int[] FilterArrayByKey_WithAllValidParameters(int[] arr, int key)
        {
            FilterArrayByKey filterArray=new FilterArrayByKey(key);
            return filterArray.FilterArray(arr);
        }

        [TestCase(new[] { 101, 1551, 82028, 100, 1890, 1570 }, ExpectedResult = new[] { 101, 1551, 82028 })]
        [TestCase(new[] { 100, 200, 300, 400 }, ExpectedResult = new int[] { })]
        public static int[] FilterArrayByKey_WithAllValidParameters_Palindrome(int[] arr)
        {
            FilterArrayByKeyPalindrome filterArray = new FilterArrayByKeyPalindrome();
            return filterArray.FilterArray(arr);
        }

        [Test]
        public static void FilterArrayByKey_WithEmptyArray()
        {
            FilterArrayByKey testFilterArray = new FilterArrayByKey(0);
            Assert.Throws<ArgumentException>(() => testFilterArray.FilterArray(new int[0]));
        }

        [Test]
        public static void FilterArrayByKey_WithNegativeKey()
        {
            FilterArrayByKey testFilterArray;
            Assert.Throws<ArgumentOutOfRangeException>(() => testFilterArray = new FilterArrayByKey(-1));
        }
        [Test]
        public static void FilterArrayByKey_KeyMoreThanNine()
        {
            FilterArrayByKey testFilterArray;
            Assert.Throws<ArgumentOutOfRangeException>(() => testFilterArray = new FilterArrayByKey(100));
        }
        [Test]
        public static void FilterArrayByKey_WithNullArray()
        {
            FilterArrayByKey testFilterArray = new FilterArrayByKey(0);
            Assert.Throws<ArgumentNullException>(() => testFilterArray.FilterArray(null));
        }
        //5 sec
        [Test]
        public static void FilterArrayByKey_WithAllValidParameters_BigArray_ForTwoMethods()
        {
            int[] arr = new int[100_000_000];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = 10;
            }
            for (int i = 0; i < arr.Length; i += 20_000_000)
            {
                arr[i] = 8;
            }
            FilterArrayByKey keyArrayFilter = new FilterArrayByKey(8);
            FilterArrayByKeyPalindrome palindromeArrayFilter = new FilterArrayByKeyPalindrome();
            int[] result =palindromeArrayFilter.FilterArray(arr);
            int[] resultForKey = keyArrayFilter.FilterArray(arr);
            int[] expected = { 8, 8, 8, 8, 8 };
            Assert.AreEqual(expected, result);
            Assert.AreEqual(expected, resultForKey);
        }
        #endregion
    }
}