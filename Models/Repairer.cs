namespace CProject.Models
{
    public class Repairer
    {
        public int Id { get; set; }
        public string RepairerName { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

        // Вычисляемое свойство для количества выполненных заказов
        public int CompletedOrdersCount =>
            Orders.Count(o => o.OrderStatus == OrderStatus.Completed);
    }
}
