using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using FindMyGym.Models.ViewModels;
using FindMyGym.Models;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;
//using Login.Permisos;
using System.Web.Security;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;

namespace FindMyGym.Controllers
{

    //[ValidarSesionLogin]
    public class AccesoController : Controller
    {
        public ActionResult Login()
        {
            if (User.IsInRole("administrador"))
            {
                // mostrar todas las vistas de las gestiones de las tablas
                return View();
            }
            else if (User.IsInRole("usuario"))
            {
                // mostrar solo las vistas de home, contact us y about us
                return View("Usuario");
            }
            else
            {
                // el usuario no tiene un rol válido, mostrar un mensaje de error o redirigir a una página de error
                return View("Error");
            }
        }
        [HttpPost]
        public ActionResult Login(Usuario usuario, string returnUrl)
        {
            if (IsValid(usuario))
            {
                FormsAuthentication.SetAuthCookie(usuario.Correo, false);
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                if (User.IsInRole("admin"))
                {
                    // mostrar todas las vistas de las gestiones de las tablas
                    return RedirectToAction("Index", "Gimnasio");
                }
                else if (User.IsInRole("usuario"))
                {
                    // mostrar solo las vistas de home, contact us y about us
                    return RedirectToAction("Usuario", "Home");
                }
                else
                {
                    // el usuario no tiene un rol válido, mostrar un mensaje de error o redirigir a una página de error
                    return View("Error");
                }
            }
            else
            {
                ModelState.AddModelError("", "El correo electrónico o la contraseña son incorrectos.");
                return View(usuario);
            }
        }

        private bool IsValid(Usuario usuario)
        {
            using (var context = new BD_FindMyGymEntities())
            {
                var user = context.ACCESOes.FirstOrDefault(u => u.CORREO == usuario.Correo && u.CONTRASENIA == usuario.Clave);
                if (user != null)
                {
                    return true;
                }
            }
            return false;
        }
        /*public ActionResult Index()
        {
            if (User.IsInRole("admin"))
            {
                return View("VistaAdministrador");
            }
            else
            {
                return View("VistaCliente");
            }
        }
        
        BD_FindMyGymEntities bd = new BD_FindMyGymEntities();
        static string cadena = @"Data Source=DECKASXPS13;Initial Catalog = BD_FindMyGym; Integrated Security=true;user id=sa;password=123456;MultipleActiveResultSets=True";

        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(Usuario oUsuario,TablaCliente model)
        {
            bool registrado;
            string mensaje;

            if (oUsuario.Clave == oUsuario.ConfirmarClave)
            {
                oUsuario.Clave = ConvertirSha256(oUsuario.Clave);

            }
            else
            {
                ViewData["Mensaje"] = "Las contraseñas no coinciden";
                return View();
            }

            var sqlConnection = (SqlConnection)bd.Database.Connection;
            using (SqlConnection cn = sqlConnection)
            {
                SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", cn);
                cmd.Parameters.AddWithValue("Correo", oUsuario.Correo);
                cmd.Parameters.AddWithValue("Clave", oUsuario.Clave);
                cmd.Parameters.Add("Registrado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                cmd.ExecuteNonQuery();
                registrado = Convert.ToBoolean(cmd.Parameters["Registrado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();

            }

            try
            {
                

                using (BD_FindMyGymEntities db = new BD_FindMyGymEntities())
                {
                    var tabla = new CLIENTE();
                    tabla.CI_CLIENTE = model.CI_CLIENTE;
                    tabla.ID_LOGIN = db.ACCESO.Where(d => d.CORREO == oUsuario.Correo).SingleOrDefault().ID_LOGIN;
                    tabla.NOMBRE_CLI = model.NOMBRE_CLI;
                    tabla.APELLIDO_CLI = model.APELLIDO_CLI;
                    tabla.DIRECCION_CLI = model.DIRECCION_CLI;
                    tabla.EDAD_CLI = model.EDAD_CLI;
                    tabla.TELF_CLI = model.TELF_CLI;
                    tabla.GENERO_CLI = model.GENERO_CLI;
                    tabla.SECTOR_CLI = model.SECTOR_CLI;


                    db.CLIENTE.Add(tabla);
                    db.SaveChanges();

                }
                
                
                
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            ViewData["Mensaje"] = mensaje;

            if (registrado)
            {
                return RedirectToAction("Login", "Acceso");
            }
            else { return View(); }


        }
        [HttpPost]
        public ActionResult Login(Usuario oUsuario)
        {
            oUsuario.Clave = ConvertirSha256(oUsuario.Clave);

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", cn);
                cmd.Parameters.AddWithValue("Correo", oUsuario.Correo);
                cmd.Parameters.AddWithValue("Clave", oUsuario.Clave);

                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                oUsuario.IdUsuario = Convert.ToInt32(cmd.ExecuteScalar().ToString());


            }

            if (oUsuario.IdUsuario != 0)
            {
                Session["usuario"] = oUsuario;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["Mensaje"] = "Usuario No encontrado";
                return View();
            }
        }
       
        public static string ConvertirSha256(string texto)
        {
            //using System.Text;
            //referencia de System.Security.Cryptography

            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {

                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                {
                    Sb.Append(b.ToString("x2"));
                }
            }
            return Sb.ToString();
        }
        */
    }
}