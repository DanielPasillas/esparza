using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using grupoesparza.Models;
using System.Web.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using grupoesparza.App_Start;
using System.Data.Entity.Validation;

namespace grupoesparza.Controllers
{
    public class AccountController : Controller
    {
        private readonly esparza_dbEntities _dbContext;

        public AccountController()
        {
            _dbContext = new esparza_dbEntities();
        }
        //----------------------------------------------------------

        [ActionName("log-in")]
        public ActionResult Login()
        {
            return View("Login");
        }
        //----------------------------------------------------------


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

            return View("Registro", ModelState);
        }
        //----------------------------------------------------------
    }
}