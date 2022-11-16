using System;

namespace Exceptions
{
    public class PainterDataException : Exception
    {
        public PainterDataException() : base() { }
        public PainterDataException(string msg) : base(msg) { }
    }
}
