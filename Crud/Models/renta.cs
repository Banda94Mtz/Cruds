//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Crud.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class renta
    {
        public int idRenta { get; set; }
        public int idCliente { get; set; }
        public int idPeliculas { get; set; }
        public System.DateTime fecha { get; set; }
    
        public virtual clientes clientes { get; set; }
        public virtual peliculas peliculas { get; set; }
    }
}