using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DataAccess.Contexts;

namespace DataAccess.Contexts
{
    public class DbFactory : IDesignTimeDbContextFactory<Db>
    {
        public Db CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Db>();

            optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb;database=moviectis479;trusted_connection=true;");
            return new Db(optionsBuilder.Options);
        }
    }
}
