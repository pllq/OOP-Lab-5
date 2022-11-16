using System;

namespace Exceptions
{
    public class StudentDataException : Exception
    {
        public StudentDataException() : base() { }
        public StudentDataException(string msg) : base(msg) { }
    }
}
