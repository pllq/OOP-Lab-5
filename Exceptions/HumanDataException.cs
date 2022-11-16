using System;

namespace Exceptions
{
    public class HumanDataException : Exception
    {
        public HumanDataException() : base() { }
        public HumanDataException(string msg) : base(msg) { }
    }
}
