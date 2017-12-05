using System;
using System.Collections.Generic;
using System.Linq;
using grupoesparza.Models;
using System.Web;
using System.Web.Mvc;
using grupoesparza.Areas.Administrator.Models;

namespace grupoesparza.Areas.Administrator.Controllers
{
    public class UniversidadesController : Controller
    {
        private readonly esparza_dbEntities _dbContext;


        public UniversidadesController()
        {
            _dbContext = new esparza_dbEntities();
        }

        // GET: Administrator/Universidades
        public ActionResult Index()
        {
            var universidades = _dbContext.universidades.Where(m => m.estatus != 0).ToList();
            return View(universidades);
        }

        [ActionName("nueva")]
        public ActionResult Nueva()
        {
            return PartialView("_FormUniversities");
        }

        [ActionName("edit")]
        public ActionResult EditUniversidad(int id)
        {
            var universidad = _dbContext.universidades.FirstOrDefault(m => m.id_universidad == id);

            if (universidad == null)
                return Content("University does not exist");

            Universidades uniModel = new Universidades(universidad); 

            return PartialView("_FormUniversities", uniModel);
        }


        //Guardar universidad
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[RequireHttps]
        public ActionResult Save(universidades infoUni)
        {
            if (ModelState.IsValid)
            {
                    //Save University.
                if (infoUni.id_universidad == 0)
                {
                    infoUni.estatus = 1;
                    _dbContext.universidades.Add(infoUni);
                    _dbContext.SaveChanges();

                }
                else //Update University.
                {
                    var _universidad = _dbContext.universidades.FirstOrDefault(m => m.id_universidad == infoUni.id_universidad);

                    _universidad.NombreUniversidad = infoUni.NombreUniversidad;
                    _dbContext.SaveChanges();

                }

                return View("Index");
            }

            return View("Index", ModelState);
        }
        //-------------------------------------------

         
        [ActionName("delete")]
        [HttpPost]
        public JsonResult DeleteUniversidad(int id)
        {
            var universidad = _dbContext.universidades.FirstOrDefault(m => m.id_universidad == id);

            if (universidad == null)
                return Json(new { response = false, msg = "The university Id could not be found." }, JsonRequestBehavior.AllowGet);

            universidad.estatus = 0;
            _dbContext.SaveChanges();

            return Json(new { response = true, msg = "El registro de universidad se inhabilitó correctamente." }, JsonRequestBehavior.AllowGet);
        }
    }
}