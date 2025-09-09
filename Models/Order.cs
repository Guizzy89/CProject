using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CProject.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? CloseDate { get; set; }

        [Required(ErrorMessage = "Необходимо ввести название оборудования")]
        public string Equipment { get; set; }

        [Required(ErrorMessage = "Необходимо ввести описание проблемы/неисправности")]
        public string Description { get; set; }

        [ForeignKey("CustomerId")]
        public int? CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }

        [ForeignKey("RepairerId")]
        public int? RepairerId { get; set; }
        public virtual Repairer? Repairer { get; set; }

        public string? Comment { get; set; }

        public OrderStatus OrderStatus { get; set; } = OrderStatus.InWaiting;
              

        // Метод для назначения исполнителя
        public void AssignCustomer(Repairer repairer)
        {
            Repairer = repairer;
            RepairerId = repairer.Id;
            OrderStatus = OrderStatus.InWork;
        }

        // Метод для завершения заказа
        public void CompleteOrder()
        {
            OrderStatus = OrderStatus.Completed;
            CloseDate = DateTime.Now;
        }

        // Свойство для вычисления времени выполнения
        public TimeSpan? ExecutionTime =>
            CloseDate.HasValue ? CloseDate.Value - CreatedDate : null;
    }
}
