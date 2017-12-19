using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using grupoesparza.Models;
using System.Web.Mvc;
using System.Threading.Tasks;
using AutoMapper;

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SaveUser(Register user)
        {
            if(ModelState.IsValid)
            {
                var userDTO = Mapper.Map<Register, admin_user_table>(user);
                _dbContext.admin_user_table.Add(userDTO);

                if(await _dbContext.SaveChangesAsync() != 1)
                    return Content("An error ocurred while registering the user."); //Here we will show a custom error page.
               
                //Create cookies and sessions for user

            }

            return View("Registro", ModelState);
        }
    }
}