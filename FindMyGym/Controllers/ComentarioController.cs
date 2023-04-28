using FindMyGym.Models.ViewModels;
using FindMyGym.Models;
//using Login.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindMyGym.Controllers
{
    public class ComentarioController : Controller
    {
        //[ValidarSesion]
        // GET: Comentario
        public ActionResult Index()
        {
            List<TablaComentario> lst;
            using (BD_FindMyGymEntities db = new BD_FindMyGymEntities())
            {
                lst = (from d in db.COMENTARIOs
                       select new TablaComentario
                       {
                           ID_COMENTARIO= d.ID_COMENTARIO,
                           ID_GIMNASIO = d.ID_GIMNASIO,
                           ID_CLIENTE = d.ID_CLIENTE,
                           TITULO_COMEN= d.TITULO_COMEN,
                           DESCRIPCION_COMEN = d.DESCRIPCION_COMEN                           


                       }).ToList();

                foreach (var item in lst)
                {

                    item.nombreCliente = db.CLIENTEs.Where(d => d.ID_CLIENTE == item.ID_CLIENTE).SingleOrDefault().NOMBRE_CLI;
                    item.nombreGimnasio = db.GIMNASIOs.Where(d => d.ID_GIMNASIO == item.ID_GIMNASIO).SingleOrDefault().NOMBRE_GIMNASIO;
                }
            }
            return View(lst);
        }
        public ActionResult Nuevo(TablaComentario model, string nouso)
        {
            using (BD_FindMyGymEntities db = new BD_FindMyGymEntities())
            {
                var QueryClientes = db.CLIENTEs.Select(c => new { c.ID_CLIENTE, NombreCompleto = c.NOMBRE_CLI + " " + c.APELLIDO_CLI });
                model.listaCLientes = new SelectList(QueryClientes.ToList(), "ID_CLIENTE", "NombreCompleto");
                var QueryGimnasio = db.GIMNASIOs.Select(c => c);
                model.listaGimnasios = new SelectList(QueryGimnasio.ToList(), "ID_GIMNASIO", "NOMBRE_GIMNASIO");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo(TablaComentario model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (BD_FindMyGymEntities db = new BD_FindMyGymEntities())
                    {


                        var tabla = new COMENTARIO();
                        tabla.ID_COMENTARIO = model.ID_COMENTARIO;
                        tabla.ID_CLIENTE = model.ID_CLIENTE;
                        tabla.ID_GIMNASIO = model.ID_GIMNASIO;
                        tabla.TITULO_COMEN = model.TITULO_COMEN;
                        tabla.DESCRIPCION_COMEN = model.DESCRIPCION_COMEN;
                     

                        db.COMENTARIOs.Add(tabla);
                        db.SaveChanges();

                    }
                    return Redirect("~/Comentario/");
                }
                return View(model);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        public ActionResult Editar(int Id)
        {
            TablaComentario model = new TablaComentario();
            using (BD_FindMyGymEntities db = new BD_FindMyGymEntities())
            {
                var tabla = db.COMENTARIOs.Find(Id);
                model.ID_COMENTARIO = tabla.ID_COMENTARIO;
                model.ID_CLIENTE = tabla.ID_CLIENTE;
                model.ID_GIMNASIO = tabla.ID_GIMNASIO;
                model.TITULO_COMEN = tabla.TITULO_COMEN;
                model.DESCRIPCION_COMEN = tabla.DESCRIPCION_COMEN;

                var QueryClientes = db.CLIENTEs.Select(c => new { c.ID_CLIENTE, NombreCompleto = c.NOMBRE_CLI + " " + c.APELLIDO_CLI });
                model.listaCLientes = new SelectList(QueryClientes.ToList(), "ID_CLIENTE", "NombreCompleto");
                var QueryGimnasio = db.GIMNASIOs.Select(c => c);
                model.listaGimnasios = new SelectList(QueryGimnasio.ToList(), "ID_GIMNASIO", "NOMBRE_GIMNASIO");

            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(TablaComentario model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (BD_FindMyGymEntities db = new BD_FindMyGymEntities())
                    {
                        var tabla = db.COMENTARIOs.Find(model.ID_COMENTARIO);
                        tabla.ID_COMENTARIO = model.ID_COMENTARIO;
                        tabla.ID_CLIENTE = model.ID_CLIENTE;
                        tabla.ID_GIMNASIO = model.ID_GIMNASIO;
                        tabla.TITULO_COMEN = model.TITULO_COMEN;
                        tabla.DESCRIPCION_COMEN = model.DESCRIPCION_COMEN;

                        db.Entry(tabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                    }
                    return Redirect("~/Comentario/");
                }
                return View(model);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
        [HttpGet]
        public ActionResult Eliminar(int Id)
        {

            using (BD_FindMyGymEntities db = new BD_FindMyGymEntities())
            {
                var tabla = db.COMENTARIOs.Find(Id);
                db.COMENTARIOs.Remove(tabla);

                db.SaveChanges();
            }
            return Redirect("~/Comentario/"); ;
        }

    }
}