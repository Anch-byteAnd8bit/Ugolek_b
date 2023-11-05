using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ugolekback.CoalF.Model;
using ugolekback.EmailF;
using ugolekback.OrderF;

namespace ugolekback.CustomerF.Model
{
    public record Customer
    {
        public int Id { get; set; } 
        [EmailAddress]
        public required string Email { get; set; }
        public required string City { get; set; }
        public required string Street { get; set; }
        public required string House { get; set; }
        public string Code { get; set; } 
        //public bool IsRegistered { get; set; } = false;
        public List<Order> Orders { get; set; }
    }


    public class CustomerDB
    {
        private static List<Customer> _customers = new List<Customer>()
        {
            new Customer{ Id=1, Email="sample1@foo.bar", City = "Абакан", Street="Кирова", House="120", Code="1234" },
            new Customer{ Id=2, Email="sample2@foo.bar", City = "Абаза", Street="Кирова", House="112", Code="4321"},
            new Customer{ Id=3, Email="sample3@foo.bar", City = "Сорск", Street="Кирова", House="1", Code="3214"}
        };

        public static async Task<Customer> AddAddress(string city, string street, string house, HttpContext context)
        {
            int idC = _customers.Last().Id + 1;
            Customer customer = new Customer { Id = idC, Email = "", City = city, Street = street, House = house, Code = "" };
            _customers.Add(customer);
            context.Session.SetInt32("_id", idC);

            return customer;
        }


        //регистрация
        public static void AddEmail(string email, IEmailSender emailSender, ICode code, HttpContext context)
        {
            int? idC = context.Session.GetInt32("_id");

            // Нашли ID.
            if (idC.HasValue)
            {
                Customer? customer = _customers.SingleOrDefault(customer => customer.Id == idC);
                // Нашли пользователя по ID.
                if (customer != null)
                {
                    // Сохраняем его адрес.
                    customer.Email = email;
                    // Отправляем ему письмо с кодом подтверждения.
                    string emailcode = code.GetCode();
                    emailSender.SendEmailAsync(email, emailcode);
                    customer.Code = emailcode;
                }
            }
            // Не нашли ID.
            else
            {
                Console.WriteLine("Bad");
            }
           
        }


        //вход
        public static void EnterEmail(string email, IEmailSender emailSender, ICode code)
        {
            
                Customer? customer = _customers.SingleOrDefault(customer => customer.Email == email);
                // Нашли пользователя по ID.
                if (customer != null)
                {
                    // Отправляем ему письмо с кодом подтверждения.
                    string emailcode = code.GetCode();
                    emailSender.SendEmailAsync(email, emailcode);
                    customer.Code = emailcode;
                }
            
        }





        public static string CompareCode(string code, HttpContext context)
        {
            string verif = "";
            int? idC = context.Session.GetInt32("_id");
            if (idC.HasValue)
            {
                Customer? customer = _customers.SingleOrDefault(customer => customer.Id == idC);
                // Нашли пользователя по ID.
                if (customer != null)
                {
                    if (customer.Code == code)
                    {
                        verif = "ok";
                    }
                    else
                    {
                        verif = "not";
                    }
                    
                }

            }
            else
            {
                Console.WriteLine("Bad");
            }
            return verif;

        }
        


        public static List<Customer> GetCustomer()
        {
            return _customers;
        }

        //public static Customer? GetCoal(int id)
        //{
        //    return _coals.SingleOrDefault(coal => coal.Id == id);
        //}

        //public static Customer CreateCoal(Customer coal)
        //{
        //    _coals.Add(coal);
        //    return coal;
        //}

        //public static Customer UpdateCoal(Customer update)
        //{
        //    _coals = _coals.Select(coal =>
        //    {
        //        if (coal.Id == update.Id)
        //        {
        //            coal.Name = update.Name;
        //        }
        //        return coal;
        //    }).ToList();
        //    return update;
        //}

        //public static void RemoveCustomer(int id)
        //{
        //    _coals = _coals.FindAll(coal => coal.Id != id).ToList();
        //}
    }
}
