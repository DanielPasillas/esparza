//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace grupoesparza.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class placa_escultura
    {
        public placa_escultura()
        {
            this.pedido_agradecimiento = new HashSet<pedido_agradecimiento>();
            this.pedido_panoramica = new HashSet<pedido_panoramica>();
        }
    
        public long id_registro { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public int tipo { get; set; }
        public int estatus { get; set; }
    
        public virtual ICollection<pedido_agradecimiento> pedido_agradecimiento { get; set; }
        public virtual ICollection<pedido_panoramica> pedido_panoramica { get; set; }
    }
}
