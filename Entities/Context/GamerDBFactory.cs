using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace Entities.Context
{
    public class GamerDBFactory : IDesignTimeDbContextFactory<GamerDb>
    {
        public GamerDb CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GamerDb>();
            optionsBuilder.UseSqlServer("server=.;Database=GamerDB;User Id=sa;password=MSSQL2019@");
            return new GamerDb(optionsBuilder.Options);
        }
    }
}
