using grupoesparza.Models;
using System;
using grupoesparza.Areas.Administrator.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace grupoesparza.Areas.Administrator.Controllers
{
    public class CarrerasController : Controller
    {
        private readonly esparza_dbEntities _dbContext;

        public CarrerasController()
        {
            _dbContext = new esparza_dbEntities();
        }
        //----------------------------------------------------------

        // GET: Administrator/Carreras
        public ActionResult Index()
        {
            var _carreras = (from c in _dbContext.carreras
                             join p in _dbContext.universidades
                             on c.id_universidad equals p.id_universidad
                             where c.estatus == 1
                             select new Carreras
                             {
                                 id_carrera = c.id_carrera,
                                 Universidad = p.NombreUniversidad,
                                 Carrera = c.NombreCarrera,
                                 Generacion = c.Generacion
                             });

            return View(_carreras);
        }
        //----------------------------------------------------------

        [ActionName("nueva")]
        public ActionResult Nueva()
        {

            var list = new SelectList(_dbContext.universidades.Where(m => m.estatus == 1).ToList(), "id_universidad", "NombreUniversidad");
            ViewBag.Universidades = list;
            return View();
        }
        //----------------------------------------------------------

        [ActionName("editar")]
        public ActionResult Editar(long id)
        {

            var carrera = _dbContext.carreras.FirstOrDefault(m => m.id_carrera == id);

            if (carrera == null)
                return Content("The carreer does not exist.");

            //List for universities.
            var list = new SelectList(_dbContext.universidades.Where(m => m.estatus == 1).ToList(), "id_universidad", "NombreUniversidad");
            ViewBag.Universidades = list;

            Carreras _carrera = new Carreras()
            {
                id_carrera      = carrera.id_carrera,
                id_universidad  = carrera.id_universidad,
                Carrera         = carrera.NombreCarrera,
                Generacion      = carrera.Generacion
            };
               
            return View("Editar", _carrera);
        }
        //----------------------------------------------------------

        [ActionName("detail")]
        public ActionResult Detalle(long id)
        {
            //We will access only by using ajax requests.
            if (Request.IsAjaxRequest())
            {
                var carrera = _dbContext.carreras.FirstOrDefault(m => m.id_carrera == id);

                if (carrera == null)
                    return Content("The carreer does not exist.");

                //List for universities.
                var list = new SelectList(_dbContext.universidades.Where(m => m.estatus == 1).ToList(), "id_universidad", "NombreUniversidad");
                ViewBag.Universidades = list;

                Carreras _carrera = new Carreras()
                {
                    id_universidad = carrera.id_universidad,
                    Carrera = carrera.NombreCarrera,
                    Generacion = carrera.Generacion
                };

                return PartialView("_Detalle", _carrera);
            }
            else
            {
                return Content("Bad Request Dude.");
            }
            
        }
        //----------------------------------------------------------

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Carreras _carreras)
        {
            if(ModelState.IsValid)
            {
                if(_carreras.id_carrera == 0) //Registro
                {
                    var carrera = new carreras()
                    {
                        id_universidad = _carreras.id_universidad,
                        NombreCarrera = _carreras.Carrera,
                        Generacion = _carreras.Generacion,
                        estatus = 1
                    };

                    try
                    {
                        _dbContext.carreras.Add(carrera);
                        _dbContext.SaveChanges();
                        return RedirectToAction("editar", "carreras", new { id = carrera.id_carrera});
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }
                else                         //Actualización
                {
                    var carrera = _dbContext.carreras.FirstOrDefault(m => m.id_carrera == _carreras.id_carrera);

                    if (carrera == null)
                        return Content("The carreer does not exist");

                    carrera.id_universidad = _carreras.id_universidad;
                    carrera.NombreCarrera  = _carreras.Carrera;
                    carrera.Generacion     = _carreras.Generacion;

                    _dbContext.SaveChanges();

                    return RedirectToAction("Index");
                }

            }

            return RedirectToAction("Nueva", ModelState);
        }
        //----------------------------------------------------------

        [HttpPost]
        public JsonResult Delete(long id)
        {
            var carrera = _dbContext.carreras.FirstOrDefault(m => m.id_carrera == id);

            if(carrera == null)
                return Json(new { status = false, msg = "The carreer does not exist." }, JsonRequestBehavior.AllowGet);

            try
            {
                carrera.estatus = 0;
                _dbContext.SaveChanges();

                return Json(new { status = true, msg = "La carrera se deshabilitó correctamente." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //----------------------------------------------------------

    }
}