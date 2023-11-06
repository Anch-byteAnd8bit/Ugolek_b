using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ugolekback;
using ugolekback.CoalF.Model;
using ugolekback.CustomerF.Model;
using ugolekback.EmailF;
using ugolekback.OrderF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ugolek API", Description = "Закажи уголь", Version = "v1" });
});

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.Cookie.Name = "MySession";
    options.IdleTimeout = TimeSpan.FromSeconds(2000);
    options.Cookie.IsEssential = true;
});

// для отправки email
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<ICode, Code>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoalStore API V1");
});



app.UseHttpsRedirection();
app.UseSession();




app.MapGet("/coals", () => CoalDB.GetCoals()); //получить угли

app.MapPost("/address", (string city, string street, string house, HttpContext context) 
    => CustomerDB.AddAddress(city, street, house, context)); //ввести адрес

app.MapPost("/customers/email", (string email, IEmailSender emailSender, ICode code, HttpContext context) 
    => CustomerDB.AddEmail(email, emailSender, code, context)); //ввод емейл в первый раз

app.MapPost("/customers/emailsecond", (string email, IEmailSender emailSender, ICode code, HttpContext context)
    => CustomerDB.EnterEmail(email, emailSender, code, context)); //ввод емейл в другие разы

app.MapPost("/customers/verification", (string code, HttpContext context)
    => CustomerDB.CompareCode(code, context)); //проверка введенного кода

app.MapPost("/orders", (List <ItemTemp> orders, HttpContext context)
    => OrderDB.AddOrder(orders, context)); //ввод заказа

app.MapGet("/customer/order", (HttpContext context) => OrderDB.GetCustomerOrders(context)); //получить заказы пользователя




app.Run();

