using MassTransit;
using AutoMapper;
using Kweet_Service.Services;
using Kweet_Service.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<KweetService>();
builder.Services.AddSingleton<IDBContext, DBContext>();

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((cxt, cfg) =>
    {
        cfg.Host(new Uri("amqps://ckgicxje:3GxKLqpiE0FSyqfHALy-ch1iYx5TeJ0E@kangaroo.rmq.cloudamqp.com/ckgicxje"), h =>
        {
            h.Username("ckgicxje");
            h.Password("3GxKLqpiE0FSyqfHALy-ch1iYx5TeJ0E");
        });
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

