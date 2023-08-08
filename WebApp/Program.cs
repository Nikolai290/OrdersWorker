using Microsoft.EntityFrameworkCore;
using OrdersWorker.Business.Implements.BackgroundServices;
using OrdersWorker.Domain.Implements;
using OrderWorker.Business.Implements.Handler;
using WebApp.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRepositories().AddRServices();
var connectionString = builder.Configuration.GetConnectionString("MsSqlServer");
builder.Services.AddDbContext<MsSqlContext>(options => options
    .UseSnakeCaseNamingConvention()
    .UseSqlServer(connectionString));
builder.Services.AddHostedService<OrderHandlerBackgroundService>();
HandlersLoader.LoadHandlers();
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

app.Run();