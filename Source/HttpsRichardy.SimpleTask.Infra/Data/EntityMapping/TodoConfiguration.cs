using HttpsRichardy.SimpleTask.Domain.Models;
using HttpsRichardy.SimpleTask.Infra.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HttpsRichardy.SimpleTask.Infra.EntityMapping;

public class TodoConfiguration : IEntityTypeConfiguration<ToDo>
{
    public void Configure(EntityTypeBuilder<ToDo> builder)
    {
        builder.HasKey(t => t.Id);

        builder.HasOne<ApplicationUser>(t => (ApplicationUser) t.User)
            .WithMany(u => u.Todos)
            .HasForeignKey(t => t.User.Id);
    }
}