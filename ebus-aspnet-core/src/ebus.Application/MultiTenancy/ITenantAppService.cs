using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ebus.MultiTenancy.Dto;

namespace ebus.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
