using ugolekback.CustomerF.Model;
using ugolekback.EmailF;

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
        public static List<Order> _orders = new List<Order>()
        {
            new Order
            {
                Id=1,
                OrderDate= DateTime.Now,
                OrderPrice = 520000,
                Customer= CustomerDB._customers[0],
                OrderItems= new List<OrderItem>() { OrderItemDB._orderitems[0], OrderItemDB._orderitems[1], OrderItemDB._orderitems[2]}
            },
            new Order
            {
                Id=2,
                OrderDate= DateTime.Now,
                OrderPrice = 300000,
                Customer= CustomerDB._customers[1],
                OrderItems= new List<OrderItem>() { OrderItemDB._orderitems[3]}
            }
        };

        public static void AddOrder(List<OrderItem2> orders, HttpContext context)
        {
            int? idC = context.Session.GetInt32("_id");

            // Нашли ID.
            //if (idC.HasValue)
            //{
            //    Customer? customer = _customers.SingleOrDefault(customer => customer.Id == idC);
            //    // Нашли пользователя по ID.
            //    if (customer != null)
            //    {
            //        // Сохраняем его адрес.
            //        customer.Email = email;
            //        // Отправляем ему письмо с кодом подтверждения.
            //        string emailcode = code.GetCode();
            //        emailSender.SendEmailAsync(email, emailcode);
            //        customer.Code = emailcode;
            //    }
            //}
            //// Не нашли ID.
            //else
            //{
            //    Console.WriteLine("Bad");
            //}

        }



    }
}
