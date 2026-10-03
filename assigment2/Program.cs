using assigment2.Data;
using assigment2.GenaricRepos;
using assigment2.Models;
using assigment2.Repos;
using assigment2.Repos.InterFaces;
using assigment2.Work;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(d => d.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped(typeof(IGenriacRepo<>), typeof(GenriacRepo<>));
builder.Services.AddScoped<IUnitOfWork , UnitOfWork>();
builder.Services.AddScoped<IBook , BookRepo>();
builder.Services.AddScoped<ICustomer , CustomerRepo>();
builder.Services.AddScoped<IMovie, MovieRepo>();
builder.Services.AddScoped<IGenre , GenreRepo>();


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
