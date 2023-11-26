using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class ToDoContext 
{
    public ToDoContext(ToDoContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Todo> Todos { get; set; }
    public DbSet<Project> Projects { get; set; }
}
}
