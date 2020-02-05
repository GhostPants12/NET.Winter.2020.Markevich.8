using System;
using System.Collections.Generic;
using System.Text;

namespace FilterArray
{
    public class FilterArrayByKey : FilterArrayBy
    {
        private int key;

        /// <summary>Initializes a new instance of the <see cref="FilterArrayByKey"/> class.</summary>
        /// <param name="key">The key.</param>
        public FilterArrayByKey(int key)
        {
            this.Key = key;
        }

        /// <summary> Gets the key.</summary>
        /// <value>The key.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">value - Key is less than zero or more than 9.</exception>
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

        /// <summary>Validates the specified number.</summary>
        /// <param name="number">The number.</param>
        /// <returns>True if number is correct, false if not.</returns>
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
