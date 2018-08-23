using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using grupoesparza.Models;
using grupoesparza.ViewModels;
using System.Web.Mvc;
using System.Web.Helpers;
using grupoesparza.utilerias;
using System.Threading.Tasks;

namespace grupoesparza.Controllers
{
    public class HomeController : Controller
    {
        private esparza_dbEntities _dbContext;

        public HomeController()
        {
            _dbContext = new esparza_dbEntities();
        }
        //---------------------------------------------

        /*
         *  Home => Index 
         */
        public async Task<ActionResult> Index()
        {
            //Show only the items with "presentar" status with 1.
            var _sliderItems = await _dbContext.slider.Where(m => m.presentar == 1).ToListAsync();

            List<SliderModel> _sliderModel = new List<SliderModel>();

            foreach (var _slider in _sliderItems)
            {
                _sliderModel.Add(new SliderModel(_slider));
            }

            IndexViewModel viewModel = new IndexViewModel()
            {
                Gallery = await _dbContext.galerias.ToListAsync(),
                Carousel = _sliderModel
            };

            return View(viewModel);           
        }
        //---------------------------------------------


        /*
         *  Home => Contacto
         */
        [ActionName("contacto")]
        public ActionResult Contact()
        {
            return View("Contact");
        }
        //---------------------------------------------

        /*
         *  Home => Gallery
         */
        [ActionName("gallery")]
        public ActionResult Galeria()
        {
            return View("Galeria");
        }
        //---------------------------------------------
    }
}
