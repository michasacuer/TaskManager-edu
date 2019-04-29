namespace TaskManager.Models.BingindModels
{
    using System.ComponentModel.DataAnnotations;
    using TaskManager.Models.Enums;

    public class RegistrationBindingModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public Role Role { get; set; }
    }
}
