using System;

namespace Exceptions
{
    public class FarmerDataException : Exception
    {
        public FarmerDataException() : base() { }
        public FarmerDataException(string msg) : base(msg) { }
    }
}
