using System.Threading.Tasks;
using ebus.Configuration.Dto;

namespace ebus.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
