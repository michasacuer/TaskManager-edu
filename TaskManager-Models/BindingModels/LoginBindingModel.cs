namespace TaskManager.Models.BingindModels
{
    using System.ComponentModel.DataAnnotations;

    public class LoginBindingModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
