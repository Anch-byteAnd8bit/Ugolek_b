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

    //public class OrderItemDB
    //{
    //    private static List<OrderItem> _orderitems = new List<OrderItem>()
    //    {
    //        new OrderItem{ Id=1, Name="ДМСШ 0-25", Price = 150000, Supplier="Кемуглесбыт" },
    //        new OrderItem{ Id=2, Name="ДО 25-50", Price = 210000, Supplier="СУЭК-Хакасия"},
    //        new OrderItem{ Id=3, Name="TДПК 50-200", Price = 230000, Supplier="Разрез Изыхский"}
    //    };
    //}
}
