using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.MultiTenancy;
using Abp.Web.Mvc.Authorization;
using Sedion.SimpleTask.Authorization;
using Sedion.SimpleTask.Web.Controllers;

namespace Sedion.SimpleTask.Web.Areas.Mpa.Controllers
{
    public class HomeController : SimpleTaskControllerBase
    {
        // GET: Mpa/Home
        public async Task< ActionResult> Index()
        {
            if (AbpSession.MultiTenancySide == MultiTenancySides.Host)
            {
                if (await IsGrantedAsync(PermissionNames.Pages_Tenants))
                {
                    return RedirectToAction("Index", "Tenants");
                }
            }
            else if(AbpSession.MultiTenancySide==MultiTenancySides.Tenant)
            {
                if (await IsGrantedAsync(PermissionNames.Pages_Tenant_Dashboard))
                {
                    return RedirectToAction("Index", "Dashboard");
                }
            }

            //Default page if no permission to the pages above
            return RedirectToAction("Index", "Welcome");
            
        }
    }
}