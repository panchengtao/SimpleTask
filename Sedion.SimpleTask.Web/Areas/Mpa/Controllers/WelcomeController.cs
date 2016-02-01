using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using Sedion.SimpleTask.Web.Controllers;

namespace Sedion.SimpleTask.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize]
    public class WelcomeController : SimpleTaskControllerBase
    {
        // GET: Mpa/Welcome
        public ActionResult Index()
        {
            return View();
        }
    }
}