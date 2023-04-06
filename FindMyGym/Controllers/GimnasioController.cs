﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FindMyGym.Models;
using FindMyGym.Models.ViewModels;

namespace FindMyGym.Controllers
{
    public class GimnasioController : Controller
    {
        // GET: Gimnasio
        public ActionResult Index()
        {
            List<TablaViewModel> lst;
            using (BD_FindMyGymEntities db = new BD_FindMyGymEntities())
            {
                 lst = (from d in db.GIMNASIO
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
                              IMAGEN_GIMNASIO = d.IMAGEN_GIMNASIO
                          }).ToList();
            }
                return View(lst);
        }
        public ActionResult Nuevo()
        {
            return View();
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

                        db.GIMNASIO.Add(tabla);
                        db.SaveChanges();

                    }
                    return Redirect("Gimnasio/");
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