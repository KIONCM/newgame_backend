using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Entities.Models;
namespace GamersAndFansAPI.Persistance.Context
{
    public class GamerDb:IdentityDbContext<User>
    { 
    }
}
