using HttpsRichardy.SimpleTask.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace HttpsRichardy.SimpleTask.Infra.Identity;

public class ApplicationUser : IdentityUser, IUser
{
    public ICollection<ToDo> Todos { get; set; } = new List<ToDo>();
}