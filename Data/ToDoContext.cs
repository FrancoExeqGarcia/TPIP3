using System.Data.Entity;
using TODOLIST.Data.Entites;
using Microsoft.EntityFrameworkCore;
using EFCoreDbContext = Microsoft.EntityFrameworkCore.DbContext;
using EFCoreDbSet = Microsoft.EntityFrameworkCore.DbSet<TODOLIST.Data.Entites.ToDo>;
using SystemDataDbContext = System.Data.Entity.DbContext;
using SystemDataDbSet = System.Data.Entity.DbSet<TODOLIST.Data.Entites.ToDo>;


public class ToDoContext : EFCoreDbContext
{
    public EFCoreDbSet Tasks { get; set; }

    public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
    {

    }

}
