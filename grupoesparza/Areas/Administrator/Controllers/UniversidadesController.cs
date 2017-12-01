using System;
using System.Collections.Generic;
using System.Linq;
using grupoesparza.Models;
using grupoesparza.Areas.Classes;
using System.Web;
using System.Web.Mvc;

namespace grupoesparza.Areas.Administrator.Controllers
{
    public class UniversidadesController : Controller
    {
        private readonly esparza_dbEntities _dbContext;

        public UniversidadesController(esparza_dbEntities dbContext)
        {
            _dbContext = dbContext;
        }

        //Methods Section.
        public List<universidades> GetUsers()
        {
            return _dbContext.universidades.ToList();
        }


        // GET: Administrator/Universidades
        public ActionResult Index()
        {
            var users = GetUsers();
            return View("Index", users);
        }
    }
}