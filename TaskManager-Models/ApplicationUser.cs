namespace TaskManager.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string SecondName { get; set; }
    }
}
