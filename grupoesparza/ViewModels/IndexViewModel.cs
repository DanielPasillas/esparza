using System;
using grupoesparza.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace grupoesparza.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<SliderModel> Carousel { get; set; }
        public IEnumerable<galerias> Gallery { get; set; }
    }
}