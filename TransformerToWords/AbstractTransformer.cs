using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TransformerToWords
{
    public abstract class AbstractTransformer
    {
        /// <summary>Transforms something to words.</summary>
        /// <returns>Transformed value.</returns>
        public string TransformToWords()
        {
            string outString = string.Empty;
            this.CheckValue(ref outString);
            if (!string.IsNullOrEmpty(outString))
            {
                return outString;
            }

            outString = this.ConvertToWord().ToString();
            return outString;
        }

        /// <summary>Checks the value.</summary>
        /// <param name="result">The string value.</param>
        protected abstract void CheckValue(ref string result);

        /// <summary>Converts value to words.</summary>
        /// <param name="result"> Contains the result.</param>
        /// <returns>Converted to StringBuilder value.</returns>
        protected abstract StringBuilder ConvertToWord();
    }
}
