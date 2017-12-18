using grupoesparza.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace grupoesparza.Areas.Administrator.Controllers
{
    public class ResourcesController : Controller
    {

        private readonly esparza_dbEntities _dbContext;

        public ResourcesController()
        {
            _dbContext = new esparza_dbEntities();
            _dbContext.Configuration.ProxyCreationEnabled = false;
        }
        //----------------------------------------------------------

        // GET: Administrator/Resources
        [HttpPost]
        [OutputCache(Duration = 60, VaryByParam = "none")]
        public async Task<JsonResult> GetUniversities()
        {
            var _universities = await _dbContext.universidades
                .Where(m => m.estatus == 1)
                .Select(m => new {m.id_universidad, m.NombreUniversidad}).ToListAsync();
            return Json(_universities);
        }
        //----------------------------------------------------------

        [HttpPost]
        [OutputCache(Duration = 60, VaryByParam = "none")]
        public async Task<JsonResult> GetCarreersByUniversity(long id)
        {
            Thread.Sleep(1000);
            var _carreras = await _dbContext.carreras
                .Where(m => m.id_universidad == id)
                .Where(m => m.estatus == 1)
                .Select(m => new { m.id_carrera, m.NombreCarrera }).ToListAsync();

            return Json(_carreras);
        }
        //----------------------------------------------------------

        [HttpPost]
        [OutputCache(Duration = 60, VaryByParam = "none")]
        public async Task<JsonResult> GetGroupsByCarreer(long id)
        {
            Thread.Sleep(1000);
            var _universities = await _dbContext.grupos.Where(m => m.id_carrera == id)
                .Where(m => m.estatus == 1).Select(m => new {m.id_grupo, m.grado, m.grupo }).ToListAsync();
            return Json(new { groups = _universities }, JsonRequestBehavior.AllowGet);
        }
        //----------------------------------------------------------
    }
}