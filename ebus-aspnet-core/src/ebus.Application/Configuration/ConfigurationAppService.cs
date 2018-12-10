using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ebus.Configuration.Dto;

namespace ebus.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ebusAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
