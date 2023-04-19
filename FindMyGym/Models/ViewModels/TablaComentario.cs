using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace FindMyGym.Models.ViewModels
{
    public class TablaComentario
    {
        public int ID_COMENTARIO { get; set; }

        [Required]
        [Display(Name = "Nombre de Gimnasio")]
        public int ID_GIMNASIO { get; set; }
        [Required]
       
        [Display(Name = "Nombre del Cliente")]
        public int ID_CLIENTE { get; set; }
        [Required]
        [StringLength(300)]
        [Display(Name = "Título de Comentario")]
        public string TITULO_COMEN { get; set; }
        [Required]
        [StringLength(500)]
        [Display(Name = "Descripción")]
        public string DESCRIPCION_COMEN { get; set; }
       
        public string nombreCliente { get; set; }
        public string nombreGimnasio { get; set; }  

        public SelectList listaCLientes { get; set; }
        public SelectList listaGimnasios { get; set; }
    }
}