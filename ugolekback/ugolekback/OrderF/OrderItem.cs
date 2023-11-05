using ugolekback.CoalF.Model;

namespace ugolekback.OrderF
{
    public record OrderItem
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int Weight { get; set; }
        public required Coal Coal { get; set; }
        public Order Order { get; set; }
    }

    public class OrderItemDB
    {
        //private static List<OrderItem> _orderitems = new List<OrderItem>()
        //{
        //    new OrderItem{ Id=1, Price = 150000, Weight=250, Coal coal },
            
        //};
    }
}
