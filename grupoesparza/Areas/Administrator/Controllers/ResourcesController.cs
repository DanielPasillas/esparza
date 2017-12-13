﻿using grupoesparza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public JsonResult GetUniversities()
        {
            var _universities = _dbContext.universidades.Where(m => m.estatus == 1).Select(m => new {m.id_universidad, m.NombreUniversidad}).ToList();
            return Json(_universities);
        }
        //----------------------------------------------------------

        [HttpPost]
        public JsonResult GetCarreersByUniversity(long id)
        {
            var _universities = _dbContext.carreras.Where(m => m.id_universidad == id).ToList();
            return Json(new { carreers = _universities }, JsonRequestBehavior.AllowGet);
        }
        //----------------------------------------------------------

        [HttpPost]
        public JsonResult GetGroupsByCarreer(long id)
        {
            var _universities = _dbContext.grupos.Where(m => m.id_carrera == id).ToList();
            return Json(new { groups = _universities }, JsonRequestBehavior.AllowGet);
        }
        //----------------------------------------------------------
    }
}