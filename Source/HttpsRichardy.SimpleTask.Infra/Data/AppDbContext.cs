using HttpsRichardy.SimpleTask.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HttpsRichardy.SimpleTask.Infra.Data;

public class AppDbContext : DbContext
{
    public DbSet<ToDo> ToDos { get; set; }

    public AppDbContext(DbContextOptions options)
        : base(options) {  }
}