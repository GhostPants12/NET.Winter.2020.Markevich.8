using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayFilter
{
    public interface IPredicate
    {
        /// <summary>  Bool function to check if the values is correct.</summary>
        /// <param name="value">The value.</param>
        /// <returns>True - when the value is correct. False - when the value is incorrect.</returns>
        bool Predicate(int value);
    }
}
