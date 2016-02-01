using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Configuration;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Sedion.SimpleTask.MultiTenancy;

namespace Sedion.SimpleTask.Web.MultiTenancy
{
    public class SubdomainTenancyNameFinder : ITenancyNameFinder, ITransientDependency
    {
        private readonly IMultiTenancyConfig _multiTenancyConfig;

        public SubdomainTenancyNameFinder(IMultiTenancyConfig multiTenancyConfig)
        {
            _multiTenancyConfig = multiTenancyConfig;
        }

        public string GetCurrentTenancyNameOrNull()
        {
            if (!_multiTenancyConfig.IsEnabled)
            {
                return Tenant.DefaultTenantName;
            }
            else
            {
                return null;
            }

            throw new NotImplementedException();
        }
    }
}
