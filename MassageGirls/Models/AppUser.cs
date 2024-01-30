using Microsoft.AspNetCore.Identity;

namespace MassageGirls.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; } 
    }
}
