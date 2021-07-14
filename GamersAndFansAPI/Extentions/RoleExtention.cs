using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamersAndFansAPI.Extentions
{
    public class RoleExtention : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    // Admin
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    // GAMER
                    Name = "Gamer",
                    NormalizedName = "GAMER"
                },
                new IdentityRole
                {
                    // FAN
                    Name = "Fan",
                    NormalizedName = "FAN"
                });
        }


    }
}
