using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ebus.Configuration;
using ebus.Web;

namespace ebus.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ebusDbContextFactory : IDesignTimeDbContextFactory<ebusDbContext>
    {
        public ebusDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ebusDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ebusDbContextConfigurer.Configure(builder, configuration.GetConnectionString(ebusConsts.ConnectionStringName));

            return new ebusDbContext(builder.Options);
        }
    }
}
