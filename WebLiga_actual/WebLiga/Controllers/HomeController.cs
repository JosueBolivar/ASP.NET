using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebLiga.Business;
using WebLiga.Models;
using WebLiga.Models.Mantenedores;
using static WebLiga.Startup;

namespace WebLiga.Controllers
{
    public class HomeController : Controller
    {
        /*
        const string SessionKeyLogin = "_Login";
        const string SessionKeyNombreCompleto = "_NombreCompleto";
        const string SessionKeyPerfil = "_Perfil";
        const string SessionKeyNombrePerfil = "_NombrePerfil";
        const string SessionKeyClubId = "_ClubId";
        */

        GeneralBusiness generalBusiness = new GeneralBusiness();
        UsuarioBusiness usuarioBusiness = new UsuarioBusiness();
        public ISession Session => HttpContext.Session;

        public IActionResult Index()
        {
            string login = Startup.ConfigSite.Login;
            string perfilId = Startup.ConfigSite.PerfilId;

            if (!string.IsNullOrEmpty(login)) {
                var lstAccesos = usuarioBusiness.ObtenerAccesosSegunPerfilUsuario(perfilId);

                ViewBag.TipoAccesos = (from c in lstAccesos
                                group c by c.Tipo into g
                                select new { g.Key });

                ViewBag.Accesos = lstAccesos;
            } else {
                ViewBag.Accesos = null;
            }
            return View();
        }

        public IActionResult Login()
        {            
            ViewData["Title"] = "Login";
            if (!string.IsNullOrEmpty(Startup.ConfigSite.Login)) {
                //string UnameDencripte = generalBusiness.DesEncriptar(Request.Cookies[SessionKeyLogin]);
                validaAcceso(Startup.ConfigSite.Login);

            }

            if (ConfigSite.StatusSite == "1") {
                return View();

            } else {
                return View("OffLine");
            }
        }

        [HttpPost]
        public IActionResult validaAcceso()
        {
            try
            {
                string login = string.Empty;
                var password = string.Empty;
                string usuplantado = string.Empty;

                Usuarios oUsuario = new Usuarios();

                login = Request.Form["login"];
                password = Request.Form["password"];
                usuplantado = Request.Form["usuplantado"];
                oUsuario = usuarioBusiness.ObtenerDatosUsuario(login, password);

                if (oUsuario != null) {

                    Int64 perfilId = generalBusiness.IsNull(oUsuario.PerfilId) ? 0 : (Int64)oUsuario.PerfilId;
                    Perfiles oPerfil = usuarioBusiness.ObtenerNombrePerfilUsuario(perfilId);

                    Startup.ConfigSite.Login = oUsuario.Login.ToString();
                    Startup.ConfigSite.NombreCompleto = oUsuario.NombreCompleto.ToString();
                    Startup.ConfigSite.PerfilId = oPerfil.IdPerfil.ToString();
                    Startup.ConfigSite.NombrePerfil = oPerfil.Descripcion.ToString();
                    Startup.ConfigSite.ClubId = oUsuario.ClubId.ToString();

                    /*
                    string loginEncriptado = generalBusiness.Encriptar(oUsuario.Login.ToString());
                    Response.Cookies.Append(SessionKeyLogin, loginEncriptado, options);
                    */

                    return RedirectToAction("Index", "Home");

                } else {

                    Startup.ConfigSite.Error = "Usuario o Contraseña no válidos";
                    return RedirectToAction("Login", "Home");

                    /*
                    if (Util.accesoMenuAdministrador(login)) {

                        var user = UsuariosBusiness.ObtenerDatosUsuario(uname);
                        string nombreCompleto = user.Nombres + " " + user.Apellidos;

                        Session.SetString(SessionKeyUname, user.Uname.ToString());
                        Session.SetString(SessionKeyNombreCompleto, nombreCompleto);

                        CookieOptions options = new CookieOptions();
                        options.Expires = DateTime.Now.AddHours(1);
                        options.Domain = ConfigSite.Cookiedomain;

                        string unaencripte = Encriptar(uname);
                        Response.Cookies.Append(SessionKeyUname, unaencripte, options);

                        return RedirectToAction("Seguimiento", "Solicitudes");

                    } else {
                        TempData["ErrorValidacion"] = "Usuario no autorizado..!";
                        return RedirectToAction("Index", "Home");
                    }
                    */
                }
            }

            catch (Exception e)
            {
                //Util.Error(DateTime.Now + "<br />" + e.Message.ToString() + "<br />" + e.Source.ToString() + "<br />" + e.StackTrace.ToString());
                return View("Login");
            }
        }

        public IActionResult validaAcceso(string pLogin)
        {
            try
            {
                string uname = string.Empty;
                var password = string.Empty;
                string usuplantado = string.Empty;

                Usuarios oUsuario = new Usuarios();
                oUsuario = usuarioBusiness.ObtenerDatosUsuario(pLogin);

                if (oUsuario != null) {

                    Int64 perfilId = generalBusiness.IsNull(oUsuario.PerfilId) ? 0 : (Int64)oUsuario.PerfilId;
                    Perfiles oPerfil = usuarioBusiness.ObtenerNombrePerfilUsuario(perfilId);

                    Startup.ConfigSite.Login = oUsuario.Login.ToString();
                    Startup.ConfigSite.NombreCompleto = oUsuario.NombreCompleto.ToString();
                    Startup.ConfigSite.PerfilId = oPerfil.IdPerfil.ToString();
                    Startup.ConfigSite.NombrePerfil = oPerfil.Descripcion.ToString();
                    Startup.ConfigSite.ClubId = oUsuario.ClubId.ToString();

                    /*
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.Now.AddHours(1);
                    options.Domain = ConfigSite.Cookiedomain;
                    */

                    /*
                    string loginEncriptado = generalBusiness.Encriptar(oUsuario.Login.ToString());
                    Response.Cookies.Append(SessionKeyLogin, loginEncriptado, options);
                    */

                    return RedirectToAction("Index", "Home");

                } else {

                    Startup.ConfigSite.Error = "Usuario o Contraseña no válidos";
                    return RedirectToAction("Login", "Home");

                    /*
                    if (string.IsNullOrEmpty(uname)) {
                        uname = Usuario;
                    }

                    if (Util.accesoMenuAdministrador(uname)) {

                        var user = UsuariosBusiness.ObtenerDatosUsuario(uname);
                        string nombreCompleto = user.Nombres + " " + user.Apellidos;

                        Session.SetString(SessionKeyUname, user.Uname.ToString());
                        Session.SetString(SessionKeyNombreCompleto, nombreCompleto);

                        CookieOptions options = new CookieOptions();
                        options.Expires = DateTime.Now.AddHours(1);
                        options.Domain = ConfigSite.Cookiedomain;

                        string unaencripte = Encriptar(uname);
                        Response.Cookies.Append(SessionKeyUname, unaencripte, options);

                        //return RedirectToAction("Seguimiento", "Solicitudes");
                        return Redirect("~/Solicitudes/Seguimiento");
                    }
                    else {
                        TempData["ErrorValidacion"] = "Usuario no autorizado..!";
                        return RedirectToAction("Index", "Home");
                    }
                    */
                }
            }

            catch (Exception e)
            {
                //Util.Error(DateTime.Now + "<br />" + e.Message.ToString() + "<br />" + e.Source.ToString() + "<br />" + e.StackTrace.ToString());
                return View("Login");
            }
        }

        public IActionResult Menu()
        {
            string login = Startup.ConfigSite.Login;
            string perfilId = Startup.ConfigSite.PerfilId;
            if (!string.IsNullOrEmpty(login)) {

                var lstAccesos = usuarioBusiness.ObtenerAccesosSegunPerfilUsuario(perfilId);

                ViewBag.TipoAccesos = (from c in lstAccesos
                                group c by c.Tipo into g
                                select new { g.Key });

                ViewBag.Accesos = lstAccesos;
            } else {
                ViewBag.Accesos = null;
            }

            return PartialView();
        }
    }
}
