using FindMyGym.Models.ViewModels;
using FindMyGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Login.Permisos;

namespace FindMyGym.Controllers
{
    //[ValidarSesion]
    public class ClienteController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            List<tablaViewModel1> lst;
            using (BD_FindMyGymEntities db = new BD_FindMyGymEntities())
            {
                lst = (from d in db.CLIENTEs
                       select new tablaViewModel1
                       {
                           ID_CLIENTE = d.ID_CLIENTE,
                           CI_CLIENTE = d.CI_CLIENTE,
                           ID_LOGIN = d.ID_LOGIN,
                           NOMBRE_CLI = d.NOMBRE_CLI,
                           APELLIDO_CLI = d.APELLIDO_CLI,
                           DIRECCION_CLI = d.DIRECCION_CLI,
                           EDAD_CLI = d.EDAD_CLI,
                           TELF_CLI = d.TELF_CLI,
                           GENERO_CLI = d.GENERO_CLI,
                           SECTOR_CLI = d.SECTOR_CLI,

                       }).ToList();

                foreach (var item in lst)
                {
                    item.NOMBRE_USUARIO = db.ACCESOes.Where(d => d.ID_LOGIN == item.ID_LOGIN).SingleOrDefault().CORREO;
                }
                
            }
            return View(lst);
          
        }
        public ActionResult Nuevo(TablaCliente model, string nouso)
        {
          
            return View();
        }


        [HttpPost]
        public ActionResult Nuevo(TablaCliente model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    using (BD_FindMyGymEntities db = new BD_FindMyGymEntities())
                    {
                        var tabla = new CLIENTE();
                        tabla.CI_CLIENTE = model.CI_CLIENTE;                      
                        tabla.ID_LOGIN = model.ID_LOGIN;
                        tabla.NOMBRE_CLI = model.NOMBRE_CLI;
                        tabla.APELLIDO_CLI = model.APELLIDO_CLI;
                        tabla.DIRECCION_CLI = model.DIRECCION_CLI;
                        tabla.EDAD_CLI = model.EDAD_CLI;
                        tabla.TELF_CLI = model.TELF_CLI;
                        tabla.GENERO_CLI = model.GENERO_CLI;
                        tabla.SECTOR_CLI = model.SECTOR_CLI;
                    
  
                        db.CLIENTEs.Add(tabla);
                        db.SaveChanges();

                    }
                    return Redirect("~/Cliente/");
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
            TablaCliente model = new TablaCliente();
            using (BD_FindMyGymEntities db = new BD_FindMyGymEntities())
            {
                var tabla = db.CLIENTEs.Find(Id);
                model.ID_CLIENTE = tabla.ID_CLIENTE;
                model.CI_CLIENTE = tabla.CI_CLIENTE;
                model.ID_LOGIN = tabla.ID_LOGIN;
                model.NOMBRE_CLI = tabla.NOMBRE_CLI;
                model.APELLIDO_CLI = tabla.APELLIDO_CLI;
                model.DIRECCION_CLI = tabla.DIRECCION_CLI;
                model.EDAD_CLI = tabla.EDAD_CLI;
                model.TELF_CLI = tabla.TELF_CLI;
                model.GENERO_CLI = tabla.GENERO_CLI;
                model.SECTOR_CLI = tabla.SECTOR_CLI;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(TablaCliente model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (BD_FindMyGymEntities db = new BD_FindMyGymEntities())
                    {
                        var tabla = db.CLIENTEs.Find(model.ID_CLIENTE);
                        tabla.ID_CLIENTE = model.ID_CLIENTE;
                        tabla.CI_CLIENTE = model.CI_CLIENTE;
                        tabla.ID_LOGIN = model.ID_LOGIN;
                        tabla.NOMBRE_CLI = model.NOMBRE_CLI;
                        tabla.APELLIDO_CLI = model.APELLIDO_CLI;
                        tabla.DIRECCION_CLI = model.DIRECCION_CLI;
                        tabla.EDAD_CLI = model.EDAD_CLI;
                        tabla.TELF_CLI = model.TELF_CLI;
                        tabla.GENERO_CLI = model.GENERO_CLI;
                        tabla.SECTOR_CLI = model.SECTOR_CLI;

                        db.Entry(tabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Cliente/");
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
                var tabla = db.CLIENTEs.Find(Id);
                int idLogin = tabla.ID_LOGIN;
                var tablaL = db.ACCESOes.Find(idLogin);
                db.CLIENTEs.Remove(tabla);
                db.ACCESOes.Remove(tablaL);
                db.SaveChanges();
            }
            return Redirect("~/Cliente/"); 
        }


    }
}
