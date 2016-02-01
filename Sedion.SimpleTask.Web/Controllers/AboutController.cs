using System.Web.Mvc;
using Sedion.SimpleTask.Web.Log4Net;

namespace Sedion.SimpleTask.Web.Controllers
{
    public class AboutController : SimpleTaskControllerBase
    {

        public ActionResult Index()
        {
            return View();
        }
    }
}