using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TDD_Kata_String_Calculator
{
    public class Calculator
    {
        /// <summary>
        /// This method parses the input string of the Add method and tests for the format pattern 
        /// as specified in the Kata exercise.  If the pattern is detected, a list of delimiters and
        /// the addition string is returned.
        /// 
        /// It would be better to split the detection and processing of the input into two methods.
        /// But, this implementation uses Regex that does both. It would take alot of refactoring 
        /// to change this with a peformance hit.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="delimiters">List of delimiters found in the input string.</param>
        /// <param name="numbers">Addition string found in the input string.</param>
        /// <returns></returns>
        private bool ProcessDelimiterFormatPattern(in string input, out IList<string> delimiters, out string numbers)
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
        /// This method verifies whether the addition string passed to
        /// the Add method is valid or not. 
        /// 
        /// Exceptions will be thrown for invalid input.
        /// 
        /// </summary>
        /// <param name="numbers"></param>
        /// <exception cref="InvalidDelimiterSequenceException"/>
        private void ValidateInput(string numbers)                    
        {
            var success = !Regex.Match(numbers, @"(,\n|\n,)+").Success;
            if(!success)
            {
                throw new InvalidDelimiterSequenceException();
            }
        }

        /// <summary>
        /// Process the addition string and returns a result.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="FormatException"/>
        /// <exception cref="OverflowException"/>
        /// <exception cref="InvalidDelimiterSequenceException"/>
        /// <exception cref="NegativesNotAllowedException"/>
        public int Add(string numbers)
        {
            if(!numbers.Any())
            {
                return 0;
            }

            var delimiters = new List<string>() { ",", "\n" };
            if(ProcessDelimiterFormatPattern(in numbers, out IList<string> delimitersTemp, out string numbersTemp))
            {
                delimitersTemp.Add("\n");
                delimiters = new List<string>(delimitersTemp);
                numbers = numbersTemp;
            }

            ValidateInput(numbers);

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
