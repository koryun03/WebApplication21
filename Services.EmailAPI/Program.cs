using AutoMapper;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using WebApp21.Services.EmailAPI;
using WebApp21.Services.EmailAPI.Consumers;
using WebApp21.Services.EmailAPI.Data;
using WebApp21.Services.EmailAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<ApplicationContext>(p => p.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var optionBuilder = new DbContextOptionsBuilder<ApplicationContext>();
optionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddSingleton(new EmailService(optionBuilder.Options));

builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var host = builder.Configuration.GetConnectionString("RabbitMQ");

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<EmailCartConsumer>();
    x.AddConsumer<UserRegisterConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(host, h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        //cfg.ReceiveEndpoint("cart_queue", e =>
        //{
        //    e.ConfigureConsumer<EmailCartConsumer>(context);

        //    e.Bind("cart_exchange", x =>
        //    {
        //        x.RoutingKey = "cart_routing_key";
        //        x.ExchangeType = "direct";
        //    });
        //});//test

        cfg.ConfigureEndpoints(context);
    });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
ApplyMigration();
app.Run();

void ApplyMigration()
{
    using (var scope = app.Services.CreateScope())
    {
        var _db = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
        if (_db.Database.GetPendingMigrations().Count() > 0)
        {
            _db.Database.Migrate();
        }
    }
}
