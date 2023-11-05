using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.OpenApi.Models;
using ugolekback;
using ugolekback.CoalF.Model;
using ugolekback.CustomerF.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddTransient<ModelsService>();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ugolek API", Description = "Закажи уголь", Version = "v1" });
});

builder.Services.AddDistributedMemoryCache();

//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromSeconds(10);
//    options.Cookie.HttpOnly = true;
//    options.Cookie.IsEssential = true;
//});

builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".AdventureWorks.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoalStore API V1");
});



app.UseHttpsRedirection();
app.UseSession();



app.MapGet("/coals/{id}", CoalDB.GetCoal);    
app.MapGet("/coals",  CoalDB.GetCoals);
//app.MapPost("/coals", (Coal coal) => CoalDB.CreateCoal(coal));
//app.MapPut("/coals", (Coal coal) => CoalDB.UpdateCoal(coal));
//app.MapDelete("/coals/{id}", (int id) => CoalDB.RemoveCoal(id));

app.MapPost("/address", (string city, string street, string house) => CustomerDB.AddAddress(city, street, house));

app.MapPut("/customers", (string email) => { CustomerDB.AddEmail(email); });

app.MapGet("/customers", () => CustomerDB.GetCustomer());

app.Run();

