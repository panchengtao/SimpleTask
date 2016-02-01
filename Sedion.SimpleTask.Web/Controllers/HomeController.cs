using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace Sedion.SimpleTask.Web.Controllers
{
    //[AbpMvcAuthorize]
    public class HomeController : SimpleTaskControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}