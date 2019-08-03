using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TDD_Kata_String_Calculator
{
    public class Calculator
    {
        public bool ValidateAddInput(string numbers)
        {
            var result = !Regex.Match(numbers, @"(,\n|\n,)+").Success;
            return result;

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

            int result = 0;
            var list = numbers.Split(',').Select(x => Int32.Parse(x));

            foreach (var number in list)
            {
                result += number;
            }

            return result;
        }

    }
}
