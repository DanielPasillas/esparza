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
        private esparza_db_fe _dbContext;

        private int _takeItems = 12;

        public HomeController()
        {
            _dbContext = new esparza_db_fe();
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
                Gallery = await _dbContext.gallery.Take(9).ToListAsync(),
                Carousel = _sliderModel
            };

            return View(viewModel);           
        }
        //---------------------------------------------

        /*
        *  Home => Gallery
        */
        [ActionName("gallery")]
        public async Task<ActionResult> Galeria()
        {
            var _gallery = await _dbContext.gallery.Take(_takeItems).ToListAsync();

            List<Galeria> _listGallery = new List<Galeria>();

            foreach(var gallery in _gallery)
            {
                _listGallery.Add(new Galeria(gallery));
            }

            return View("Galeria", _listGallery);
        }
        //---------------------------------------------

        /*
         *  Home => About
         */
        [ActionName("about")]
        public ActionResult About()
        {
            return View();
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

    }
}
