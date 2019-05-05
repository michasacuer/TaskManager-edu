namespace TaskManager.WPF.Exceptions
{
    using System;

    public class FormValidationException : Exception
    {
        public FormValidationException()
        {
        }

        public FormValidationException(string message)
            : base(message)
        {
        }
    }
}
