using System;
using System.Collections.Generic;
using System.Text;

namespace TDD_Kata_String_Calculator
{
    [Serializable]
    public class InvalidDelimiterSequenceException : Exception
    {
        public InvalidDelimiterSequenceException()
            : base("Invalid delimiter sequence.")
        {

        }
    }
}
