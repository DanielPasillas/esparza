using System;
using grupoesparza.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace grupoesparza.Models
{
    public class SliderModel
    {
        public int idSlider { get; set; }

        public string ImageSlider { get; set; }

        public string TituloSlider { get; set; }

        public string TextoSlider { get; set; }

        public int? IsLink{ get; set; }

        public string URL { get; set; }

        public int Presentar { get; set; }

        public SliderModel()
        {
            //Empty constructor.
        }

        public SliderModel(slider _slider)
        {
            this.idSlider = _slider.id;
            this.ImageSlider = _slider.image;
            this.TituloSlider = _slider.titulo;
            this.TextoSlider = _slider.texto;
            this.IsLink = _slider.isHyperLink;
            this.URL = _slider.LinkURL;
            this.Presentar = _slider.presentar;
        }
    }
}