using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TDD_Kata_String_Calculator
{
    public class Calculator
    {
        /// <summary>
        /// This method verifies that the number string passed to
        /// the Add method is valid or not. Exceptions will be throw for
        /// invalid input.
        /// 
        /// </summary>
        /// <param name="numbers"></param>
        /// <exception cref="InvalidDelimiterSequenceException"/>
        public void ValidateAddInput(string numbers)
        {
            var success = !Regex.Match(numbers, @"(,\n|\n,)+").Success;
            if(!success)
            {
                throw new InvalidDelimiterSequenceException();
            }

        }

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

            ValidateAddInput(numbers);

            int result = 0;
            var list = numbers.Split(new char[] { ',', '\n' }).Select(x => Int32.Parse(x));

            foreach (var number in list)
            {
                result += number;
            }

            return result;
        }

    }
}
