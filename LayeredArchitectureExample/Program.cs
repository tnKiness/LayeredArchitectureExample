using LayeredArchitectureExample.Business;
using LayeredArchitectureExample.Domain.Interfaces;
using LayeredArchitectureExample.Persistence;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<MongoDbContext>(builder.Configuration);
builder.Services.AddSingleton<MongoDbContext>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<CustomerService>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
