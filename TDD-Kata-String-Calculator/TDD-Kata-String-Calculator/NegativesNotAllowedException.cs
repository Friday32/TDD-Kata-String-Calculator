using System;

namespace TDD_Kata_String_Calculator
{
    [Serializable]
    public class NegativesNotAllowedException : Exception
    {
        public NegativesNotAllowedException()
            : base("negatives not allowed")
        {

        }
    }
}
