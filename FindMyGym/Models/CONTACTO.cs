//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FindMyGym.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CONTACTO
    {
        public int ID_CLIENTE { get; set; }
        public int ID_GIMNASIO { get; set; }
        public int ID_CONTACTO { get; set; }
        public System.DateTime FECHA { get; set; }
        public string MENSAJE { get; set; }
    
        public virtual CLIENTE CLIENTE { get; set; }
        public virtual GIMNASIO GIMNASIO { get; set; }
    }
}
