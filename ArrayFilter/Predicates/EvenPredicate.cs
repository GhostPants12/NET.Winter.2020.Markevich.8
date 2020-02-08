using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayFilter.Predicates
{
    public class EvenPredicate : IPredicate
    {
        /// <summary>Predicate for even numbers.</summary>
        /// <param name="value">The value to check.</param>
        /// <returns>True when the value is even or zero, false when odd.</returns>
        public bool Predicate(int value)
        {
            if (value % 2 == 0)
            {
                return true;
            }

            return false;
        }
    }
}
