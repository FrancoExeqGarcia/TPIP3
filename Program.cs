using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TODOLIST.Data;
using TODOLIST.Services.Interfaces;
using TODOLIST.Services.Implementations;
using TODOLIST.DBContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IToDoService, TodoService>();
builder.Services.AddScoped<IUserService, UserService>();



// Configure DbContext with SQL Server connection string
builder.Services.AddDbContext<ToDoContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Configure Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TODOLIST API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TODOLIST API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
