using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
    public class User : IdentityUser
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }

    }
}
