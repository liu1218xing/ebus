using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ebus.EntityFrameworkCore
{
    public static class ebusDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ebusDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ebusDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
