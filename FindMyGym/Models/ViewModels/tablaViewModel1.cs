using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FindMyGym.Models.ViewModels
{
    public class tablaViewModel1
    {
        
        public int ID_CLIENTE { get; set; }
        public string CI_CLIENTE { get; set; }
        public int ID_LOGIN { get; set; }
        public string NOMBRE_CLI { get; set; }
        public string APELLIDO_CLI { get; set; }
        public string DIRECCION_CLI { get; set; }
        public int EDAD_CLI { get; set; }
        public string TELF_CLI { get; set; }
        public string GENERO_CLI { get; set; }
        public string SECTOR_CLI { get; set; }
        public string NOMBRE_USUARIO { get; set; }
    }
}