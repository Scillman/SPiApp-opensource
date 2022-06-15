using System;

namespace SPiApp2.Components.Exceptions
{
    [Serializable]
    public class InstallationException : Exception
    {
        public InstallationException(string message) :
            base(message)
        {
            ; // Do nothing...
        }
    }
}
