using System.ComponentModel.DataAnnotations;

namespace BuildUCPU.Models
{
    public class EmailModel
    {
        [Required, EmailAddress, Display(Name = "Recipient Email")]
        public string ToEmail { get; set; }

        [Required, Display(Name = "Subject")]
        public string Subject { get; set; }

        [Required, Display(Name = "Message")]
        public string Message { get; set; }
    }
}
