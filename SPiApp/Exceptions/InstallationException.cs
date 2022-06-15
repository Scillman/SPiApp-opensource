using System;

namespace SPiApp.Exceptions
{
    public class InstallationException : Exception
    {
        public InstallationException(string message) :
            base(message)
        {
            ; // Do nothing...
        }
    }
}
