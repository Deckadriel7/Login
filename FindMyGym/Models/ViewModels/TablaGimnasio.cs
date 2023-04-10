using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindMyGym.Models.ViewModels
{
    public class TablaGimnasio
    {
        public int ID_GIMNASIO { get; set; }
        
        [Required]
        [Display(Name = "Nombre de Categoria")]
        public int ID_CATEGORIA { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre")]
        public string NOMBRE_GIMNASIO { get; set; }
        [Required]
        [StringLength(300)]
        [Display(Name = "Dirección")]
        public string DIRECCION_GIMNASIO { get; set; }
        [Required]
        [StringLength(500)]
        [Display(Name = "Descripción")]
        public string DESCRIPCION_GIMNASIO { get; set; }
        [Required]
        [Display(Name = "Precio Anual")]
        public decimal PRECIO_ANUAL { get; set; }
        [Required]
        [Display(Name = "Precio Mensual")]
        public decimal PRECIO_MENSUAL { get; set; }
        [Required]
        [StringLength(10)]
        [Display(Name = "Teléfono")]
        public string TELF_GIMNASIO { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Sector")]
        public string SECTOR_GIMNASIO { get; set; }
        [Required]
        [StringLength(300)]
        [Display(Name = "Imagen")]
        public string IMAGEN_GIMNASIO { get; set; }

        public SelectList listaCategorias { get; set; }
    }
}