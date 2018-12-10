using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ebus.Authorization.Roles;
using ebus.Authorization.Users;
using ebus.MultiTenancy;

namespace ebus.EntityFrameworkCore
{
    public class ebusDbContext : AbpZeroDbContext<Tenant, Role, User, ebusDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public ebusDbContext(DbContextOptions<ebusDbContext> options)
            : base(options)
        {
        }
    }
}
