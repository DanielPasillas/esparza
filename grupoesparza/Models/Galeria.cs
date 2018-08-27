using System;
using grupoesparza.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace grupoesparza.Models
{
    public class Galeria
    {
        public long IdImg { get; set; }
        public string Imagen { get; set; }
        public string Comment { get; set; }
        public int Tipo { get; set; }
        public string Class { get; set; }
        public int Estatus { get; set; }
        public System.DateTime FechaAlta { get; set; }

        public Galeria()
        {
            //Empty constructor
        }
        //--------------

        public Galeria(gallery _galeria)
        {
            this.IdImg = _galeria.id_img;
            this.Imagen = _galeria.imagen;
            this.Comment = _galeria.comentario;
            this.Tipo = _galeria.tipo;
            this.Class = _galeria.@class;
            this.Estatus = _galeria.status;
            this.FechaAlta = _galeria.fecha_alta;
        }
        //--------------
    }
}