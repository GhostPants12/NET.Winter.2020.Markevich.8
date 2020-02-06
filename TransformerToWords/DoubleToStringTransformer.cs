using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TransformerToWords
{
    public class DoubleToStringTransformer : AbstractTransformer
    {
        /// <summary>  Dictionary that contains word match for a exceptional double value.</summary>
        private readonly Dictionary<double, string> doubleToWord = new Dictionary<double, string>()
        {
            { double.Epsilon, "Epsilon" },
            { double.NaN, "Not a number" },
            { double.NegativeInfinity, "Negative infinity" },
            { double.PositiveInfinity, "Positive infinity" },
            { 0, "zero" },
        };

        /// <summary>Dictionary that contains word match for a character.</summary>
        private readonly Dictionary<char, string> characterToWord = new Dictionary<char, string>
        {
            { '+', "plus" },
            { '-', "minus" },
            { '.', "point" },
            { '0', "zero" },
            { '1', "one" },
            { '2', "two" },
            { '3', "three" },
            { '4', "four" },
            { '5', "five" },
            { '6', "six" },
            { '7', "seven" },
            { '8', "eight" },
            { '9', "nine" },
            { 'E', "E" },
        };

        /// <summary>Initializes a new instance of the <see cref="DoubleToStringTransformer"/> class.</summary>
        /// <param name="doubleNumber">The double number.</param>
        public DoubleToStringTransformer(double doubleNumber)
        {
            this.Value = doubleNumber;
        }

        /// <summary>Gets or sets the value.</summary>
        /// <value>The double value to be transformed to words.</value>
        private double Value { get; set; }

        /// <summary>Checks the value.</summary>
        /// <param name="result">The string value.</param>
        protected override void CheckValue(ref string result)
        {
            foreach (KeyValuePair<double, string> keyValue in this.doubleToWord)
            {
                if (this.Value.Equals(keyValue.Key))
                {
                    result = keyValue.Value;
                }
            }
        }

        /// <summary>Converts to word.</summary>
        /// <param name="resultStringBuilder">The result string builder.</param>
        /// <exception cref="System.ArgumentNullException">resultStringBuilder - Parameter is null.</exception>
        /// <exception cref="System.Exception">Value contains unpredictable symbols.</exception>
        /// <returns>Converted to StringBuilder format value.</returns>
        protected override StringBuilder ConvertToWord()
        {
            StringBuilder resultStringBuilder = new StringBuilder(string.Empty);

            int inconsistencyCount;
            string valueAsString = this.Value.ToString(CultureInfo.InvariantCulture);
            foreach (char ch in valueAsString)
            {
                inconsistencyCount = 0;
                foreach (KeyValuePair<char, string> keyValue in this.characterToWord)
                {
                    if (ch == keyValue.Key)
                    {
                        resultStringBuilder.Append($"{keyValue.Value} ");
                    }
                    else
                    {
                        inconsistencyCount++;
                    }
                }

                if (inconsistencyCount == this.characterToWord.Count)
                {
                    throw new Exception("Value contains unpredictable symbols.");
                }
            }

            resultStringBuilder.Remove(resultStringBuilder.Length - 1, 1);
            return resultStringBuilder;
        }
    }
}
