using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using Sedion.SimpleTask.Authorization;
using Sedion.SimpleTask.MultiTenancy;

namespace Sedion.SimpleTask.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantsController : SimpleTaskControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public TenantsController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        public ActionResult Index()
        {
            var output = _tenantAppService.GetTenants();
            return View(output);
        }
    }
}