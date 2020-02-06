using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayFilter
{
    public interface IPredicate
    {
        bool Predicate(int value);
    }
}
