using System.Threading.Tasks;
using Abp.Application.Services;
using ebus.Authorization.Accounts.Dto;

namespace ebus.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
