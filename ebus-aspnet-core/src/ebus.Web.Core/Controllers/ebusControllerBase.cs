using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ebus.Controllers
{
    public abstract class ebusControllerBase: AbpController
    {
        protected ebusControllerBase()
        {
            LocalizationSourceName = ebusConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
