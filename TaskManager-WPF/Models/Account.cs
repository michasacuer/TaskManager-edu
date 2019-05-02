namespace TaskManager.WPF.Models
{
    using TaskManager.WPF.Enums;

    public class Account
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Role Role { get; set; }

        public string Bearer { get; set; }
    }
}
