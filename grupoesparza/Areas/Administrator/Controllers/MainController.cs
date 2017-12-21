using grupoesparza.Areas.Administrator.HandlerClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace grupoesparza.Areas.Administrator.Controllers
{
    public class MainController : Controller
    {
        // GET: Administrator/Home
        [AuthAdmin]
        public ActionResult Index()
        {
            return View();
        }
    }
}