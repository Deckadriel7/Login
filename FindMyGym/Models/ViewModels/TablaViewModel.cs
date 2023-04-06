using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FindMyGym.Models.ViewModels
{
    public class TablaViewModel
    {
        public int ID_GIMNASIO { get; set; } 
        public int ID_CATEGORIA { get; set; } 
        public string NOMBRE_GIMNASIO { get; set; } 
        public string DIRECCION_GIMNASIO { get; set; } 
        public string DESCRIPCION_GIMNASIO { get; set; } 
        public decimal PRECIO_ANUAL{ get; set; } 
        public decimal PRECIO_MENSUAL { get; set; } 
        public string TELF_GIMNASIO{ get; set; } 
        public string SECTOR_GIMNASIO { get; set; } 
        public string IMAGEN_GIMNASIO { get; set; }
        public string NOMBRE_CATEGORIA { get; set; }

        
    }
}