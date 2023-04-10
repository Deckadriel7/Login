using FindMyGym.Models.ViewModels;
using FindMyGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindMyGym.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
          
        }
        public ActionResult Nuevo()
        {


            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(TablaGimnasio model)
        {

            return View();
        }

        public ActionResult Editar(int Id)
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Editar(TablaGimnasio model)
        {
            return Redirect("~/Gimnasio/"); ;
        }
        [HttpGet]
        public ActionResult Eliminar(int Id)
        {

           
            return Redirect("~/Gimnasio/"); 
        }


    }
}
