using System;

namespace SPiApp.Exceptions
{
    public class InvalidGameException : Exception
    {
        public InvalidGameException(string message) :
            base(message)
        {
            ; // Do nothing...
        }
    }
}
