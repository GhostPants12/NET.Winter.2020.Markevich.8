using System;

namespace FilterArray
{
    public abstract class FilterArrayBy
    {
        public int[] FilterArray(int[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException(nameof(arr), "Array is null.");
            }

            if (arr.Length == 0)
            {
                throw new ArgumentException("Array is empty");
            }

            int[] result = new int[arr.Length];
            int resultIndex = 0;
            int buf;
            for (int i = 0; i < arr.Length; i++)
            {
                buf = arr[i];
                if (this.Validate(buf))
                {
                    result[resultIndex] = buf;
                    resultIndex++;
                }
            }

            Array.Resize(ref result, resultIndex);
            return result;
        }

        public abstract bool Validate(int number);
    }
}
