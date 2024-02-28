using HttpsRichardy.SimpleTask.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace HttpsRichardy.SimpleTask.Infra.Identity;

# pragma warning disable CS8618
public class ApplicationUser : IdentityUser, IUser
{
    public ICollection<ToDo> Todos { get; set; }
}