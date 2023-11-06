using ugolekback.CoalF.Model;

namespace ugolekback.OrderF
{
    public record OrderItem
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int Weight { get; set; }
        public required Coal Coal { get; set; }
        //public Order Order { get; set; }
    }
    public class OrderItem2
    {
        int Id { get; set; }
        int Weight { get; set; }
    }
    public class OrderItem2DB
    {

    }


    public class OrderItemDB
    {
        public static List<OrderItem> _orderitems = new List<OrderItem>()
        {
            new OrderItem{ Id=1, Price = 150000, Weight=250, Coal = CoalDB._coals[0] },
            new OrderItem{ Id=2, Price = 170000, Weight=300, Coal = CoalDB._coals[1] },
            new OrderItem{ Id=3, Price = 200000, Weight=500, Coal = CoalDB._coals[2] },
            new OrderItem{ Id=4, Price = 300000, Weight=1000, Coal = CoalDB._coals[0] }

        };
    }
}
