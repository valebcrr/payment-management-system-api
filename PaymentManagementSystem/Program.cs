using Microsoft.EntityFrameworkCore;
using PaymentManagementSystem.Data;
using PaymentManagementSystem.Middleware;
using PaymentManagementSystem.Repositories;
using PaymentManagementSystem.Services;

var builder = WebApplication.CreateBuilder(args);

// =======================
// SERVICES
// =======================

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

builder.Services.AddScoped<IPaymentService, PaymentService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// =======================
// APP
// =======================

var app = builder.Build();

// =======================
// MIDDLEWARE
// =======================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
