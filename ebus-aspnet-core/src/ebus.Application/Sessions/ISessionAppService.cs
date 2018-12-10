using System.Threading.Tasks;
using Abp.Application.Services;
using ebus.Sessions.Dto;

namespace ebus.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
