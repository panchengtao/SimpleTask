using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sedion.SimpleTask.Web.Controllers
{
    public class ApplicationController : Controller
    {
        // GET: Application
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home", new {area = "Mpa"});
        }
    }
}