using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FindMyGym.Controllers;
using FindMyGym.Models;
using FindMyGym.Models.ViewModels;
//using Login.Permisos;

namespace FindMyGym.Controllers
{
    public class ContactoController : Controller
    {
        //[ValidarSesion]
        // GET: Contactoa
        public ActionResult Index()
        {
            List<TablaContacto> lst;
            using (BD_FindMyGymEntities db = new BD_FindMyGymEntities())
            {
                lst = (from d in db.CONTACTOes
                          select new TablaContacto
                          {
                              ID_CONTACTO = d.ID_CONTACTO,
                              ID_GIMNASIO = d.ID_GIMNASIO,
                              ID_CLIENTE = d.ID_CLIENTE,
                              FECHA = d.FECHA.ToString(),
                              MENSAJE = d.MENSAJE
                          }).ToList();


                foreach (var item in lst)
                {
                    item.NombreGimnasio = db.GIMNASIOs.Where(d => d.ID_GIMNASIO == item.ID_GIMNASIO).SingleOrDefault().NOMBRE_GIMNASIO;
                    item.NombreCliente = db.CLIENTEs.Where(d => d.ID_CLIENTE == item.ID_CLIENTE).SingleOrDefault().NOMBRE_CLI;
                    item.NombreApellido = db.CLIENTEs.Where(d => d.ID_CLIENTE == item.ID_CLIENTE).SingleOrDefault().APELLIDO_CLI;
                }

            }
            return View(lst);

        }

        public ActionResult Nuevo(TablaContacto model,string MOUSE )
        {

            using (BD_FindMyGymEntities db = new BD_FindMyGymEntities())
            {
                var QueryGimnasio = db.GIMNASIOs.Select(c => c);
                model.ListaGimnasio = new SelectList(QueryGimnasio.ToList(), "ID_GIMNASIO", "NOMBRE_GIMNASIO");

                var QueryCliente = db.CLIENTEs.Select(c => new { c.ID_CLIENTE, NombreCompleto = c.NOMBRE_CLI + " " + c.APELLIDO_CLI });
                model.ListaCliente = new SelectList(QueryCliente.ToList(), "ID_CLIENTE", "NombreCompleto");

            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo(TablaContacto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (BD_FindMyGymEntities db = new BD_FindMyGymEntities())
                    {

                        var tabla = new CONTACTO();
                        tabla.ID_CONTACTO = model.ID_CONTACTO;
                        tabla.ID_CLIENTE = model.ID_CLIENTE;
                        tabla.ID_GIMNASIO = model.ID_GIMNASIO;
                        tabla.MENSAJE = model.MENSAJE;
                        tabla.FECHA = Convert.ToDateTime(model.FECHA);

                        db.CONTACTOes.Add(tabla);
                        db.SaveChanges();

                    }
                    return Redirect("~/Contacto/");
                }
                return View(model);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }



    }
}