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
    public class TesoreroController : Controller
    {
        const string SessionKeyLogin = "_Login";
        const string SessionKeyNombreCompleto = "_NombreCompleto";
        const string SessionKeyPerfil = "_Perfil";
        const string SessionKeyNombrePerfil = "_NombrePerfil";
        const string SessionKeyClubId = "_ClubId";

        GeneralBusiness generalBusiness = new GeneralBusiness();
        UsuarioBusiness usuarioBusiness = new UsuarioBusiness();
        public ISession Session => HttpContext.Session;

        public IActionResult Index()
        {
            string login = Session.GetString(SessionKeyLogin);
            string perfilId = Session.GetString(SessionKeyPerfil);

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

        public IActionResult Ingreso()
        {            
            ViewData["Title"] = "Ingreso de Ficha";
            try
            {
                if (!string.IsNullOrEmpty(Request.Cookies[SessionKeyLogin])) {
                    string UnameDencripte = generalBusiness.DesEncriptar(Request.Cookies[SessionKeyLogin]);
                    //validaAcceso(UnameDencripte);

                } else {
                    HttpContext.Session.Remove(SessionKeyLogin);
                    HttpContext.Session.Remove(SessionKeyNombreCompleto);
                    HttpContext.Session.Remove(SessionKeyPerfil);
                    HttpContext.Session.Remove(SessionKeyNombrePerfil);
                    HttpContext.Session.Remove(SessionKeyClubId);
                    HttpContext.Session.Clear();
                }
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
