using System.Threading.Tasks;
using Abp.Application.Services;
using Sedion.SimpleTask.Roles.Dto;

namespace Sedion.SimpleTask.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
