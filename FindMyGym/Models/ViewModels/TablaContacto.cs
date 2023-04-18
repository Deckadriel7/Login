using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace FindMyGym.Models.ViewModels
{
    public class TablaContacto
    {

        public int ID_CONTACTO { get; set; }

        [Required]
        [Display(Name = "Nombre del Gimnasio")]
        public int ID_GIMNASIO { get; set; }
        [Required]
        [Display(Name = "Nombre del Cliente")]
        public int ID_CLIENTE { get; set; }
        [Required]
        [StringLength(500)]
        [Display(Name = "Mensaje")]
        public string MENSAJE { get; set; }
        [Required]
        [Display(Name = "Fecha")]
        public string FECHA { get; set; }


        //REFERIENCIAS 

        public string NombreGimnasio
        { get; set; }

        public string NombreCliente
        { get; set; }

        public string NombreApellido
        { get; set; }

        public SelectList ListaGimnasio { get; set; }

        public SelectList ListaCliente { get; set; }




    }
}