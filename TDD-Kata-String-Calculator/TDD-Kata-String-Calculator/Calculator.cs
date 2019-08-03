using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDD_Kata_String_Calculator
{
    public class Calculator
    {
        /// <summary>
        /// The method adds numbers in a string.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="FormatException"/>
        /// <exception cref="OverflowException"/>
        public int Add(string numbers)
        {
            if(!numbers.Any())
            {
                return 0;
            }

            var result = Int32.Parse(numbers);
            return result;
        }

    }
}
