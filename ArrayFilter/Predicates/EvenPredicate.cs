using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayFilter.Predicates
{
    public class EvenPredicate : IPredicate
    {
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
