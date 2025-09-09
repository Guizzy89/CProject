using System.ComponentModel.DataAnnotations;

namespace CProject.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Необходимо ввести полное имя")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Необходимо ввести почту")]
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
