using System;

namespace SPiApp2.Components.Exceptions
{
    [Serializable]
    public class InvalidGameException : Exception
    {
        public InvalidGameException(string message) :
            base(message)
        {
            ; // Do nothing...
        }
    }
}
