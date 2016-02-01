using Abp.Authorization;
using Sedion.SimpleTask.Authorization.Roles;
using Sedion.SimpleTask.MultiTenancy;
using Sedion.SimpleTask.Users;

namespace Sedion.SimpleTask.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
