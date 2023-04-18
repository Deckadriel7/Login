using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace FindMyGym.Models.ViewModels
{
    public class TablaCliente
    {
        //s
        public int ID_CLIENTE { get; set; }
        [Required]
        [StringLength(10)]
        [Display(Name = "Cedula")]
        public string CI_CLIENTE { get; set; }
        [Required]
        [Display(Name = "Ingreso")]
        public int ID_LOGIN { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre")]
        public string NOMBRE_CLI { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Apellido")]
        public string APELLIDO_CLI { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Direccion")]
        public string DIRECCION_CLI { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Edad")]
        public int EDAD_CLI { get; set; }
        [Required]
        [StringLength(10)]
        [Display(Name = "Telefono")]
        public string TELF_CLI { get; set; }
        [Required]
        [StringLength(9)]
        [Display(Name = "Genero")]
        public string GENERO_CLI { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Sector")]
        public string SECTOR_CLI { get; set; }
    }
}