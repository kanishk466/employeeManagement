using ems.Models;
using ems.Models.Service;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.Configure<EmsDatabaseSetting>(
    builder.Configuration.GetSection(nameof(EmsDatabaseSetting)));


builder.Services.AddSingleton<IEmsDatabaseSetting>(
    sp => sp.GetRequiredService<IOptions<EmsDatabaseSetting>>().Value);

builder.Services.AddSingleton<IMongoClient>(
    s => new MongoClient(builder.Configuration.GetValue<string>("EmsDatabaseSetting:ConnectionString")));


builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();




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
