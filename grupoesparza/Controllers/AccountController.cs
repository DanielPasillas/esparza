using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using grupoesparza.Models;
using System.Web.Mvc;

namespace grupoesparza.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        //public ActionResult Index()
        //{
          //  return View();
        //}

        [ActionName("log-in")]
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login)
        {
            return Content("");
        }
    }
}