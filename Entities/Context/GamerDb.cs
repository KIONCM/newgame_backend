using Entities.Extentions;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entities.Context
{
    public class GamerDb : IdentityDbContext<User>
    {
        public GamerDb(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Score> Scores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleExtention());
        }
    }
}
