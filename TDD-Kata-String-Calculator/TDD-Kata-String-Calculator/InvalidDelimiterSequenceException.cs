using System;

namespace TDD_Kata_String_Calculator
{
    [Serializable]
    public class InvalidDelimiterSequenceException : Exception
    {
        public InvalidDelimiterSequenceException()
            : base("invalid delimiter sequence")
        {

        }
    }
}
