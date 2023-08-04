using Employee_Info.api.Data;
using Employee_Info.api.Interfaces;
using Employee_Info.api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecifications = "_myAllowSpecification";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecifications,
        policy =>
        {
            policy.WithOrigins("https://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
        });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IEmployeeService, EmployeeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(MyAllowSpecifications);

app.MapControllers();

app.Run();
