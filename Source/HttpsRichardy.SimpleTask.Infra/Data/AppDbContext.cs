using HttpsRichardy.SimpleTask.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HttpsRichardy.SimpleTask.Infra.Data;

public class AppDbContext : IdentityDbContext
{
    public DbSet<ToDo> ToDos { get; set; }

    public AppDbContext(DbContextOptions options)
        : base(options) {  }
}