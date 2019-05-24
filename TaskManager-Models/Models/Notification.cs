namespace TaskManager.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Notification
    {
        [Key]
        public int Id { get; set; }

        public string Message { get; set; }
    }
}
