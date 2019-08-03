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

            int result = 0;
            var index = numbers.IndexOf(',');
            if(-1 == index)
            {
                result = Int32.Parse(numbers);
            }
            else
            {
                result += Int32.Parse(numbers.Substring(0, index));
                result += Int32.Parse(numbers.Substring(index+1, numbers.Length- (index + 1)));
            }

            return result;
        }

    }
}
