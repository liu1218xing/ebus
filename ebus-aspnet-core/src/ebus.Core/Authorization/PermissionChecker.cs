using Abp.Authorization;
using ebus.Authorization.Roles;
using ebus.Authorization.Users;

namespace ebus.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
