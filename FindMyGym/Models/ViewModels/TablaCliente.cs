using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.EnterpriseServices.Internal;
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
        [Display(Name = "Cédula")]
        public string CI_CLIENTE { get; set; }
        [Required]
        [Display(Name = "Nombre de Usuario")]
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
        [Display(Name = "Dirección")]
        public string DIRECCION_CLI { get; set; }
        [Required]
        [Range(0, 101, ErrorMessage = "La edad debe estar entre 0 y 101")]
        [Display(Name = "Edad")]
        public int EDAD_CLI { get; set; }
        [Required]
        [StringLength(10)]
        [Display(Name = "Teléfono")]
        public string TELF_CLI { get; set; }
        [Required]
        [StringLength(9)]
        [Display(Name = "Género")]
        public string GENERO_CLI { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Sector")]
        
        public string SECTOR_CLI { get; set; }
       

        
    }
}