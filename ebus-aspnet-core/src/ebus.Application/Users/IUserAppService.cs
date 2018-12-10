using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ebus.Roles.Dto;
using ebus.Users.Dto;

namespace ebus.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
