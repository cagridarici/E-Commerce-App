
using E_Commerce.Infrastructure;
using E_Commerce.Domain.Entities;
using Microsoft.Extensions.Configuration;
using E_Commerce.Infrastructure.Repositories;
using E_Commerce.Application;
using E_Commerce.Infrastructure.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Scoped Repository Services
builder.Services.AddScoped(typeof(ApplicationRepository<Order>));
builder.Services.AddScoped(typeof(ApplicationRepository<Customer>));
builder.Services.AddScoped(typeof(ApplicationRepository<CustomerAddress>));
builder.Services.AddScoped(typeof(ApplicationRepository<Product>));
builder.Services.AddScoped(typeof(ApplicationRepository<ProductCategory>));
builder.Services.AddScoped(typeof(ApplicationRepository<Invoice>));

builder.Services.AddScoped(typeof(OrderAppService));
builder.Services.AddScoped(typeof(InvoiceAppService));
builder.Services.AddScoped(typeof(MailSenderService));

// Her Request basina Ayri RabbitMQ Connection Acmasin Diye Singleton Tanimladim. 
builder.Services.AddSingleton(typeof(RabbitMQMailSenderService));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Configure Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();
app.Run();
