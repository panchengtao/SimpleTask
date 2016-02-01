using Abp.Application.Features;
using Sedion.SimpleTask.Authorization.Roles;
using Sedion.SimpleTask.MultiTenancy;
using Sedion.SimpleTask.Users;

namespace Sedion.SimpleTask.Features
{
    public class FeatureValueStore : AbpFeatureValueStore<Tenant, Role, User>
    {
        public FeatureValueStore(TenantManager tenantManager)
            : base(tenantManager)
        {
        }
    }
}