using HttpsRichardy.SimpleTask.Domain.TodoContext.Models;
using Microsoft.AspNetCore.Identity;

namespace HttpsRichardy.SimpleTask.Infra.Identity;

public class ApplicationUser : IdentityUser
{
    public ICollection<ToDo> Todos { get; set; } = new List<ToDo>();
}