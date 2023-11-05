using ugolekback.CustomerF.Model;

namespace ugolekback.OrderF
{
    public record Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderPrice { get; set; }
        public required Customer Customer { get; set; }

        public required List<OrderItem> OrderItems { get; set; }
    }


    public class OrderDB
    {
        //private static List<Order> _orders = new List<Order>()
        //{
        //    new Order{ Id=1, OrderDate= DateTime.Now, OrderPrice = 150000, Customer= _customers. },
        //    new Order{ Id=2, OrderDate= DateTime.Now, OrderPrice = 210000, Supplier="СУЭК-Хакасия"},
        //    new Order{ Id=3, OrderDate= DateTime.Now, OrderPrice = 230000, Supplier="Разрез Изыхский"}
        //};
    }
}
