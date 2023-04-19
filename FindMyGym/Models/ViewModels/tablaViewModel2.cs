using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace FindMyGym.Models.ViewModels
{
    public class tablaViewModel2
    {
        public int ID_COMENTARIO { get; set; }


        public int ID_GIMNASIO { get; set; }
       
        public int ID_CLIENTE { get; set; }
       
     
        public string TITULO_COMEN { get; set; }
    
        public string DESCRIPCION_COMEN { get; set; }

        public string nombreCliente { get; set; }
        public string nombreGimnasio { get; set; }

        public SelectList listaCLientes { get; set; }
        public SelectList listaGimnasios { get; set; }
    }
}
