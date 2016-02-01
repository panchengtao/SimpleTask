using Abp.Authorization.Roles;
using Sedion.SimpleTask.MultiTenancy;
using Sedion.SimpleTask.Users;

namespace Sedion.SimpleTask.Authorization.Roles
{
    public class Role : AbpRole<Tenant, User>
    {

    }
}