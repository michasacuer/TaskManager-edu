namespace TaskManager.WPF.Exceptions
{
    using System;

    public class AddNewTaskException : Exception
    {
        public AddNewTaskException()
        {
        }

        public AddNewTaskException(string message)
            : base(message)
        {
        }
    }
}