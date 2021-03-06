﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using grupoesparza.utilerias;
using grupoesparza.Models;
using System.Web.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using grupoesparza.App_Start;
using System.Data.Entity.Validation;
using System.Security.Cryptography;
using System.Security.Claims;
using System.Net;

namespace grupoesparza.Controllers
{
    public class AccountController : Controller
    {
        private readonly esparza_db_fe _dbContext;
        /*
        public AccountController()
        {
            _dbContext = new esparza_db_fe();
        }
        //----------------------------------------------------------

        [ActionName("log-in")]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            Session["re-captcha-attempts"] = 0;
            return View("Login");
        }
        //----------------------------------------------------------

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(Login userLogin, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                var user = await _dbContext.admin_user_table.FirstOrDefaultAsync(m => m.Email == userLogin.Email);

                if (user == null)
                {
                    Session["re-captcha-attempts"] = Session["re-captcha-attempts"] == null ? 0 : (int)Session["re-captcha-attempts"] + 1;
                    
                    ViewBag.ErrorMsg = "El correo electronico o la contraseña son incorrectos.";
                    return View("Login");
                }
                else
                {
                    MD5 _hash = MD5.Create();

                    var _hasPass = Utilerias.GetMd5Hash(_hash, userLogin.Password);

                    user = await _dbContext.admin_user_table.FirstOrDefaultAsync(m => m.Password == _hasPass);

                    if (user == null)
                    {
                        Session["re-captcha-attempts"] = Session["re-captcha-attempts"] == null ? 0 : (int)Session["re-captcha-attempts"] + 1;
                        ViewBag.ErrorMsg = "El correo electronico o la contraseña son incorrectos.";
                       return View("Login");
                    }
                    else
                    {
                        //Validate re-captcha
                        if((int)Session["re-captcha-attempts"] > 5)
                        {
                            Utilerias util = new Utilerias();

                            bool response = util.ValidRecaptcha(Request["g-recaptcha-response"]);

                            if(!response)
                            {
                                ViewBag.ErrorMsg = "Confirme el componente reCaptcha.";
                                return View("Login");
                            }
                        }

                        var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
                        var authManager = HttpContext.GetOwinContext().Authentication;

                        //Set authentication.
                        var ident = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, userLogin.Email), }, DefaultAuthenticationTypes.ApplicationCookie);
                        authManager.SignIn(new AuthenticationProperties { IsPersistent = userLogin.RememberMe }, ident);

                        //Check if there is an URL in the request.
                        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("index","panel");
                        }
                        

                    }
                }
            }
            else
            {
                return RedirectToAction("log-in", ModelState);
            }
        }
        //----------------------------------------------------------

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [ActionName("log-off")]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("log-in", "account");
        }



        [ActionName("register")]
        public ActionResult Registro()
        {
            return View("Registro");
        }
        //----------------------------------------------------------

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SaveUser(Register user)
        {
            if(ModelState.IsValid)
            {
                try
                {

                    MD5 _hash = MD5.Create();

                    //Hash password.
                    user.Password = Utilerias.GetMd5Hash(_hash, user.Password);

                    var userDTO = Mapper.Map<Register, admin_user_table>(user);

                    _dbContext.admin_user_table.Add(userDTO);

                    if (await _dbContext.SaveChangesAsync() != 1) 
                        return Content("An error ocurred while registering the user."); //Here we will show a custom error page.

                    return RedirectToAction("index", "home");
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }

            return View("Registro", user);
        }
        //----------------------------------------------------------

    */
    }
}