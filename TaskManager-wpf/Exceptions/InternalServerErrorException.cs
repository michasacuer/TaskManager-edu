namespace TaskManager.WPF.Exceptions
{
    using System;

    public class InternalServerErrorException : Exception
    {
        public InternalServerErrorException()
        {
        }

        public InternalServerErrorException(string message)
            : base(message)
        {
        }
    }
}
