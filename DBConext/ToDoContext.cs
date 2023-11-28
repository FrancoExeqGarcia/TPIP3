using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using TODOLIST.Data.Entites;

namespace TODOLIST.DBContext
{
    public class ToDoContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<SuperAdministrator> Superadministrators { get; set; }
        public DbSet<ToDo> ToDos { get; set; }

        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasDiscriminator<string>("Role")
                .HasValue<User>("user")
                .HasValue<Administrator>("admin")
                .HasValue<SuperAdministrator>("superadmin");

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "User1", Password = "password1", Email = "user1@example.com", Role = "user" },
                new Administrator { Id = 2, Name = "Admin1", Password = "adminpassword1", Email = "admin1@example.com", Role = "admin" },
                new SuperAdministrator { Id = 3, Name = "Superadmin1", Password = "superadminpassword1", Email = "superadmin1@example.com", Role = "superadmin" }
            );

            modelBuilder.Entity<ToDo>().HasData(
                new ToDo { Id = 1, Name = "Task1", StartDate = "2023-01-01", EndDate = "2023-01-10" },
                new ToDo { Id = 2, Name = "Task2", StartDate = "2023-02-01", EndDate = "2023-02-15" }
            );

            modelBuilder.Entity<Administrator>().HasData(
                new Administrator { Id = 4, Name = "Admin2", Password = "adminpassword2", Email = "admin2@example.com", Role = "admin" }
            );

            modelBuilder.Entity<SuperAdministrator>().HasData(
                new SuperAdministrator { Id = 5, Name = "Superadmin2", Password = "superadminpassword2", Email = "superadmin2@example.com", Role = "superadmin" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
