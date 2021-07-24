using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace Entities.Context
{
    public class GamerDBFactory : IDesignTimeDbContextFactory<GamerDb>
    {
        public GamerDb CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GamerDb>();
            optionsBuilder.UseSqlServer("Data Source = tcp:kiongamerapi.database.windows.net, 1433; Initial Catalog = gamerdb; User Id = osama@kiongamerapi; Password = 01149279494@Yas");
            return new GamerDb(optionsBuilder.Options);
        }
    }
}
