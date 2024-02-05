using Book_Project.Services.Data;
using Book_Project.Services.Repository;
using Book_Project.Services.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
string cs = builder.Configuration.GetConnectionString("ConStr");
 builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(cs));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICoverTypeRepository, CoverTypeRepository>();
//builder.Services.AddScoped<I>
builder.Services.AddSwaggerGen();

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
