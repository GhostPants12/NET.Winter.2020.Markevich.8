using System;
using System.Collections.Generic;
using System.Text;

namespace FilterArray
{
    public class FilterArrayByKey : FilterArrayBy
    {
        private int key;

        public FilterArrayByKey(int key)
        {
            this.Key = key;
        }

        public int Key
        {
            get
            {
                return this.key;
            }

            private set
            {
                if (value < 0 || value > 9)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Key is less than zero or more than 9");
                }

                this.key = value;
            }
        }

        public override bool Validate(int number)
        {
            do
            {
                if (Math.Abs(number % 10) == this.key)
                {
                    return true;
                }

                number /= 10;
            }
            while (number != 0);
            return false;
        }
    }
}
