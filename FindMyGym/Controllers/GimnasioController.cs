using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FindMyGym.Models;
using FindMyGym.Models.ViewModels;
//using Login.Permisos;
using WebGrease;

namespace FindMyGym.Controllers
{
    [Authorize(Roles = "admin")]
    public class GimnasioController : Controller
    {
        //[ValidarSesion]
        // GET: Gimnasio
        public ActionResult Index(string mensaje)
        {
            List<TablaViewModel> lst;
            using (BD_FindMyGymEntities db = new BD_FindMyGymEntities())
            {
                lst = (from d in db.GIMNASIOs
                        select new TablaViewModel
                        {
                            ID_GIMNASIO = d.ID_GIMNASIO,
                            ID_CATEGORIA = d.ID_CATEGORIA,
                            NOMBRE_GIMNASIO = d.NOMBRE_GIMNASIO,
                            DIRECCION_GIMNASIO = d.DIRECCION_GIMANSIO,
                            DESCRIPCION_GIMNASIO = d.DESCRIPCION_GIMASIO,
                            PRECIO_ANUAL = d.PRECIO_ANUAL,
                            PRECIO_MENSUAL = d.PRECIO_MENSUAL,
                            TELF_GIMNASIO = d.TELF_GIMNASIO,
                            SECTOR_GIMNASIO = d.SECTOR_GIMNASIO,
                            IMAGEN_GIMNASIO = d.IMAGEN_GIMNASIO,
                            

                        }).ToList();

                foreach (var item in lst)
                {

                    item.NOMBRE_CATEGORIA = db.CATEGORIAs.Where(d => d.ID_CATEGORIA == item.ID_CATEGORIA).SingleOrDefault().NOMBRE_CAT;
                }
            }
            ViewData["Mensaje"] = mensaje;
                return View(lst);
        }
        public ActionResult Nuevo(TablaGimnasio model, string nouso)
        {
            using (BD_FindMyGymEntities db = new BD_FindMyGymEntities())
            {
                var QueryCategorias = db.CATEGORIAs.Select(c => c);
                model.listaCategorias = new SelectList(QueryCategorias.ToList(), "ID_CATEGORIA", "NOMBRE_CAT");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo(TablaGimnasio model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (BD_FindMyGymEntities db = new BD_FindMyGymEntities())
                    {
                       

                        var tabla = new GIMNASIO();
                        tabla.ID_CATEGORIA = model.ID_CATEGORIA;
                        tabla.NOMBRE_GIMNASIO = model.NOMBRE_GIMNASIO;
                        tabla.DIRECCION_GIMANSIO = model.DIRECCION_GIMNASIO;
                        tabla.DESCRIPCION_GIMASIO = model.DESCRIPCION_GIMNASIO;
                        tabla.PRECIO_ANUAL = model.PRECIO_ANUAL;
                        tabla.PRECIO_MENSUAL = model.PRECIO_MENSUAL;
                        tabla.TELF_GIMNASIO = model.TELF_GIMNASIO;
                        tabla.SECTOR_GIMNASIO = model.SECTOR_GIMNASIO;
                        tabla.IMAGEN_GIMNASIO = model.IMAGEN_GIMNASIO;

                        db.GIMNASIOs.Add(tabla);
                        db.SaveChanges();

                    }
                    return Redirect("~/Gimnasio/");
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
            TablaGimnasio model = new TablaGimnasio();  
            using ( BD_FindMyGymEntities db = new BD_FindMyGymEntities())
            {
                var tabla = db.GIMNASIOs.Find(Id);
                model.ID_GIMNASIO = tabla.ID_GIMNASIO;
                model.ID_CATEGORIA = tabla.ID_CATEGORIA;
                model.NOMBRE_GIMNASIO = tabla.NOMBRE_GIMNASIO;
                model.DIRECCION_GIMNASIO = tabla.DIRECCION_GIMANSIO;
                model.DESCRIPCION_GIMNASIO = tabla.DESCRIPCION_GIMASIO;        
                model.PRECIO_ANUAL = tabla.PRECIO_ANUAL;        
                model.PRECIO_MENSUAL = tabla.PRECIO_MENSUAL;        
                model.TELF_GIMNASIO = tabla.TELF_GIMNASIO;        
                model.SECTOR_GIMNASIO = tabla.SECTOR_GIMNASIO;        
                model.IMAGEN_GIMNASIO = tabla.IMAGEN_GIMNASIO;        
            }
            using (BD_FindMyGymEntities db = new BD_FindMyGymEntities())
            {
                var QueryCategorias = db.CATEGORIAs.Select(c => c);
                model.listaCategorias = new SelectList(QueryCategorias.ToList(), "ID_CATEGORIA", "NOMBRE_CAT");
            }
          
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(TablaGimnasio model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (BD_FindMyGymEntities db = new BD_FindMyGymEntities())
                    {
                        var tabla = db.GIMNASIOs.Find(model.ID_GIMNASIO);
                        tabla.ID_CATEGORIA = model.ID_CATEGORIA;
                        tabla.NOMBRE_GIMNASIO = model.NOMBRE_GIMNASIO;
                        tabla.DIRECCION_GIMANSIO = model.DIRECCION_GIMNASIO;
                        tabla.DESCRIPCION_GIMASIO = model.DESCRIPCION_GIMNASIO;
                        tabla.PRECIO_ANUAL = model.PRECIO_ANUAL;
                        tabla.PRECIO_MENSUAL = model.PRECIO_MENSUAL;
                        tabla.TELF_GIMNASIO = model.TELF_GIMNASIO;
                        tabla.SECTOR_GIMNASIO = model.SECTOR_GIMNASIO;
                        tabla.IMAGEN_GIMNASIO = model.IMAGEN_GIMNASIO;

                        db.Entry(tabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                    }
                    return Redirect("~/Gimnasio/");
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
                try
                {
                    var tabla = db.GIMNASIOs.Find(Id);
                    db.GIMNASIOs.Remove(tabla);
                    db.SaveChanges();

                }
                catch (Exception)
                {

                    string mensaje = "Error al eliminar el Gimnasio, revise dependencias";
                    return RedirectToAction("Index","Gimnasio",new { mensaje });
                }
            }
            return Redirect("~/Gimnasio/"); 
        }

       
    }
}
