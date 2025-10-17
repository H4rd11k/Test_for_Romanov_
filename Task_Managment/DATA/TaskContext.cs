using Microsoft.EntityFrameworkCore;
using Task_Managment.Models;

public class TaskContext : DbContext
{
     public TaskContext(DbContextOptions<TaskContext> options) : base(options){}
     public DbSet<TaskItem> TaskItems { get; set; }
     
     
     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
          base.OnModelCreating(modelBuilder);
          
          modelBuilder.Entity<TaskItem>(entity =>
          {
               entity.HasKey(e => e.Id);
               entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
               entity.Property(e => e.Description).HasMaxLength(1000);
               entity.Property(e => e.IsCompleted).HasDefaultValue(false);
          });

          // Тестовые данные
          modelBuilder.Entity<TaskItem>().HasData(
               new TaskItem
               {
                    Id = 1,
                    Title = "Изучить ASP.NET Core",
                    Description = "Ознакомиться с основами создания REST API",
                    IsCompleted = false,
                    CreatedAt = DateTime.UtcNow
               },
               new TaskItem
               {
                    Id = 2,
                    Title = "Настроить Entity Framework",
                    Description = "Создать миграции и подключить базу данных",
                    IsCompleted = true,
                    CreatedAt = DateTime.UtcNow
               }
          );
     }
}