using System.Threading.Tasks;
using Abp.Application.Services;
using Sedion.SimpleTask.Users.Dto;

namespace Sedion.SimpleTask.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task ProhibitPermission(ProhibitPermissionInput input);

        Task RemoveFromRole(long userId, string roleName);
    }
}