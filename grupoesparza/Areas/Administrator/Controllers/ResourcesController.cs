﻿using grupoesparza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        public JsonResult GetUniversities()
        {
            var _universities = _dbContext.universidades
                .Where(m => m.estatus == 1)
                .Select(m => new {m.id_universidad, m.NombreUniversidad}).ToList();
            return Json(_universities);
        }
        //----------------------------------------------------------

        [HttpPost]
        [OutputCache(Duration = 60, VaryByParam = "none")]
        public JsonResult GetCarreersByUniversity(long id)
        {
            Thread.Sleep(1000);
            var _carreras = _dbContext.carreras
                .Where(m => m.id_universidad == id)
                .Where(m => m.estatus == 1)
                .Select(m => new { m.id_carrera, m.NombreCarrera }).ToList();

            return Json(_carreras);
        }
        //----------------------------------------------------------

        [HttpPost]
        [OutputCache(Duration = 60, VaryByParam = "none")]
        public JsonResult GetGroupsByCarreer(long id)
        {
            Thread.Sleep(1000);
            var _universities = _dbContext.grupos.Where(m => m.id_carrera == id)
                .Where(m => m.estatus == 1).Select(m => new {m.id_grupo, m.grado, m.grupo }).ToList();
            return Json(new { groups = _universities }, JsonRequestBehavior.AllowGet);
        }
        //----------------------------------------------------------
    }
}