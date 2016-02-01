using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using Sedion.SimpleTask.Authorization.Roles;
using Sedion.SimpleTask.Editions;
using Sedion.SimpleTask.Users;

namespace Sedion.SimpleTask.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, Role, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager
            )
        {
        }
    }
}