using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using grupoesparza.Models;
using System.Web.Security;
using grupoesparza.utilerias;
using grupoesparza.Areas.Administrator.Models;
using System.Web;
using System.Web.Mvc;
using grupoesparza.Areas.Administrator.HandlerClasses;

namespace grupoesparza.Areas.Administrator.Controllers
{
    public class AdmonController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }


        [ActionName("admin-login")]
        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
                return RedirectToAction("Index", "Account");

            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Auth loginModel)
        {
            if(ModelState.IsValid)
            {
                using (esparza_dbEntities _db = new esparza_dbEntities())
                {
                    var _email =  _db.admin_auth_table.FirstOrDefault(m => m.Email == loginModel.Email);

                    if (_email == null)
                        return View("Login", loginModel);

                    using (MD5 _hash = MD5.Create())
                    {

                        string _pass = Utilerias.GetMd5Hash(_hash, loginModel.Password);

                        var _password = _db.admin_auth_table.FirstOrDefault(m => m.Password == _pass);

                        if (_password == null)
                            return View("Login", loginModel);

                        //If everything is OK, we will create the cookies and sessions.
                        FormsAuthentication.SetAuthCookie(loginModel.Email, false);

                        var authTicket = new FormsAuthenticationTicket(1, loginModel.Email, DateTime.Now, DateTime.Now.AddMinutes(20), false, null);
                        string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                        var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                        HttpContext.Response.Cookies.Add(authCookie);

                        return RedirectToAction("Index", "account");

                    }

                }
            }

            return View("Login", loginModel);
                
        }
        //--------------------------------------------------------


    }
}