using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using grupoesparza.Models;
using grupoesparza.utilerias;
using System.Web.Mvc;

namespace grupoesparza.Controllers
{
    public class EventosController : Controller
    {

        // GET: Eventos => Bodas
        [ActionName("bodas")]
        public ActionResult Bodas()
        {
            //var _gallery = GaleriaLista().Where(m => m.Categoria == 1).ToList();
            ViewBag.ImgCover = "contact-background.jpg";
            ViewBag.Evento = "Bodas";
            ViewBag.Descripcion = "Tu boda!!. Una ocasión especial  merece ser capturada para siempre. Un momento tan especial que no solo quedará en tu memoria, sino también un album memorable con calidad Grupo Esparza...";
            return View("Bodas");
        }

        // GET: Eventos => XV Años
        [ActionName("xv-anos")]
        public ActionResult XVa()
        {
            return View("XVa");
        }

        // GET: Eventos => Bautizos
        [ActionName("bautizos")]
        public ActionResult Bautizos()
        {
            ViewBag.ImgCover    = "contact-background.jpg";
            ViewBag.Evento      = "Bautizos";
            ViewBag.Descripcion = "Te ayudamos a guardar ese momento tan especial que durará por siempre. Agregamos el toque especial que hará de este momento algo inolvidable...";
            return View("Bautizos");
        }

        // GET: Eventos => Primera comunión
        [ActionName("primera-comunion")]
        public ActionResult Comunion()
        {
            return View("Comunion");
        }

        [ActionName("black-white")]
        public ActionResult BlancoYNegro()
        {
            return View("BlancoYNegro");
        }

        [ActionName("tematica")]
        public ActionResult Tematica()
        {
            return View();
        }
    }
}