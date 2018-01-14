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
using Microsoft.AspNet.Identity.Owin;
using grupoesparza.App_Start;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace grupoesparza.Areas.Administrator.Controllers
{
    public class AdmonController : Controller
    {
        private readonly esparza_dbEntities _dbContext;

        public AdmonController()
        {
            _dbContext = new esparza_dbEntities();
        }

        [ActionName("admin-login")]
        public ActionResult Login()
        {
            return View("Login");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Auth loginModel)
        {
            if(ModelState.IsValid)
            {
                var user = _dbContext.admin_auth_table.FirstOrDefault(m => m.Email == loginModel.Email);

                if (user == null)
                {
                    ViewBag.ErrorMsg = "El correo electronico o la contraseña son incorrectos.";
                    return View("Login");
                }
                else
                {
                    MD5 _hash = MD5.Create();

                    var _hasPass = Utilerias.GetMd5Hash(_hash, loginModel.Password);

                    user = _dbContext.admin_auth_table.FirstOrDefault(m => m.Password == _hasPass);

                    if (user == null)
                    {
                        ViewBag.ErrorMsg = "El correo electronico o la contraseña son incorrectos.";
                        return View("Login");
                    }
                    else
                    {

                        var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
                        var authManager = HttpContext.GetOwinContext().Authentication;

                        //Set authentication.
                        var ident = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, loginModel.Email), }, DefaultAuthenticationTypes.ApplicationCookie);
                        authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, ident);

                        //Check if there is an URL in the request.
                        return RedirectToAction("index", "main");

                    }
                }
            }
            else
            {
                return View("Login", loginModel);
            }
                
        }
        //--------------------------------------------------------


    }
}