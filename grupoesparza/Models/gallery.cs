//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace grupoesparza.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class gallery
    {
        public long id_img { get; set; }
        public string imagen { get; set; }
        public string comentario { get; set; }
        public int tipo { get; set; }
        public string @class { get; set; }
        public int status { get; set; }
        public System.DateTime fecha_alta { get; set; }
    }
}