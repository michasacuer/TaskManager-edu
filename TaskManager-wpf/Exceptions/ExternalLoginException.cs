namespace TaskManager.WPF.Exceptions
{
    using System;

    public class ExternalLoginException : Exception
    {
        public ExternalLoginException()
        {
        }

        public ExternalLoginException(string message)
            : base(message)
        {
        }
    }
}
