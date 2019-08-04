using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TDD_Kata_String_Calculator
{

    public class Calculator
    {
        public bool UsesDelimiterFormatPattern(in string input, out IList<string> delimiters, out string numbers)
        {
            delimiters = new List<string>();
            numbers = "";

            var pattern = @"^//(\[(?<delimiter>[^\]]+)\])+\n(?<numbers>.+)$";
            var matches = Regex.Matches(input, pattern, RegexOptions.Singleline);

            if(1 != matches.Count())
            {
                return false;
            }

            foreach(var delimiterCapture in matches[0].Groups["delimiter"].Captures)
            {
                delimiters.Add(delimiterCapture.ToString());
            }
            numbers = matches[0].Groups["numbers"].Value;
            return true;
        }
    
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

            var delimiters = new List<string>() { ",", "\n" };
            if(UsesDelimiterFormatPattern(in numbers, out IList<string> delimitersTemp, out string numbersTemp))
            {
                delimitersTemp.Add("\n");
                delimiters = new List<string>(delimitersTemp);
                numbers = numbersTemp;
            }

            ValidateAddInput(numbers);

            int result = 0;
            var list = numbers
                .Split(delimiters.ToArray(), StringSplitOptions.None)
                .Select(x => {
                    var temp = Int32.Parse(x);
                    if(temp < 0)
                    {
                        throw new NegativesNotAllowedException();
                    } 
                    else if (temp > 1000)
                    {
                        return 0;
                    }

                    return temp;
                }); ;

            foreach (var number in list)
            {
                result += number;
            }

            return result;
        }

    }
}
