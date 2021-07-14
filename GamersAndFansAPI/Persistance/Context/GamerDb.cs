using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace GamersAndFansAPI.Persistance.Context
{
    public class GamerDb : IdentityDbContext<User>
    {
        public GamerDb(DbContextOptions options):base(options)
        {

        }

        public virtual DbSet<Score> Scores { get; set; }
    }
}
