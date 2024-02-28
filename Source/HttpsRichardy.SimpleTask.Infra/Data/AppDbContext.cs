using System.Reflection;
using HttpsRichardy.SimpleTask.Domain.Models;
using HttpsRichardy.SimpleTask.Infra.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HttpsRichardy.SimpleTask.Infra.Data;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<ToDo> ToDos { get; set; }

    public AppDbContext(DbContextOptions options)
        : base(options) {  }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}