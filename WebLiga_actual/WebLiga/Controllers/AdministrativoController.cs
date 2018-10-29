using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebLiga.Business;
using WebLiga.Models;
using WebLiga.Models.Administrativo;
using WebLiga.Models.Mantenedores;
using static WebLiga.Startup;

namespace WebLiga.Controllers
{
    public class AdministrativoController : Controller
    {
        const string SessionKeyLogin = "_Login";
        const string SessionKeyNombreCompleto = "_NombreCompleto";
        const string SessionKeyPerfil = "_Perfil";
        const string SessionKeyNombrePerfil = "_NombrePerfil";
        const string SessionKeyClubId = "_ClubId";

        GeneralBusiness generalBusiness = new GeneralBusiness();
        UsuarioBusiness usuarioBusiness = new UsuarioBusiness();
        AdministrativoBusiness administrativoBusiness = new AdministrativoBusiness();
        MantenedoresBusiness mantenedorBusiness = new MantenedoresBusiness();
        public ISession Session => HttpContext.Session;
        private readonly IHostingEnvironment _env;

        string mensajeError = string.Empty;
        string[] mensajeErrorUsuario = new string[2];

        public AdministrativoController(IHostingEnvironment env)
        {
            _env = env;
        }

        public List<Accesos> compruebaAccesos()
        {
            string perfilId = Session.GetString(SessionKeyPerfil);
            var lstAccesos = usuarioBusiness.ObtenerAccesosSegunPerfilUsuario(perfilId);
            return lstAccesos;
        }

        public IActionResult IngresoFicha()
        {            
            ViewData["Title"] = "Ingreso de Ficha";
            try
            {
                if (String.IsNullOrEmpty(Request.Cookies[SessionKeyLogin])) {
                    return RedirectToAction("Login", "Home");
                }

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

                ViewBag.Clubes = mantenedorBusiness.ListarClubes();
                //Agregar filtro de campeonato al business
                ViewBag.Fichas = administrativoBusiness.ListarFechasJugadas();
                ViewBag.Jugadores = mantenedorBusiness.ListarJugadoresValidados();
                ViewBag.Campeonatos = mantenedorBusiness.ListarCampeonatos();
                FechaJugada ficha = new FechaJugada();

                return View(ficha);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        public string GrabarIngresoFicha(FechaJugada oFicha)
        {
            try
            {
                string response = string.Empty;
                Int64 id = 0;
                int goles = 0;

                if (ModelState.IsValid) {
                    if (!string.IsNullOrEmpty(Request.Form["UsuarioCrea"])) {
                        oFicha.UsuarioCrea = Request.Form["UsuarioCrea"];
                    }

                    id = generalBusiness.IsNumeric(Request.Form["Folio"]) ? Int64.Parse(Request.Form["Folio"]) : 0;
                    goles = generalBusiness.IsNumeric(Request.Form["Goles"]) ? int.Parse(Request.Form["Goles"]) : 0;

                    if (!string.IsNullOrEmpty(Request.Form["UsuarioCrea"])) {
                        oFicha.UsuarioCrea = Request.Form["UsuarioCrea"];
                    }

                    oFicha.Id = id;
                    oFicha.Goles = goles;

                    id = administrativoBusiness.GrabarFicha(oFicha);
                    if (id > 0) {
                        response = "Todo bien,ok";
                    } else {
                        response = "Error en la aplicación!,";
                        response += "Se produjo un error no controlador (business)... Revisar!!";
                    }

                } else {
                    mensajeError = "Faltan datos:,";
                    mensajeError += string.Join("; ", ModelState.Values
                                                            .SelectMany(x => x.Errors)
                                                            .Select(x => x.ErrorMessage));
                    response = mensajeError;
                }
                return response;
            }
            catch (Exception ex)
            {
                mensajeError = "Error grave,";
                mensajeError += "Ups! algo salió realmente mal... Error: " + ex.Message;
                return mensajeError;
            }
        }

        public IActionResult Inscripciones()
        {            
            ViewData["Title"] = "Inscripciones";
            try
            {
                if (String.IsNullOrEmpty(Request.Cookies[SessionKeyLogin])) {
                    return RedirectToAction("Login", "Home");
                }

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

                ViewBag.Clubes = mantenedorBusiness.ListarClubes();
                //Agregar filtro de campeonato al business
                ViewBag.Fichas = administrativoBusiness.ListarFechasJugadas();
                ViewBag.Jugadores = mantenedorBusiness.ListarJugadoresNoValidados();
                ViewBag.Campeonatos = mantenedorBusiness.ListarCampeonatos();
                FechaJugada ficha = new FechaJugada();

                return View(ficha);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        public string ValidarInscripcionJugador()
        {
            try
            {
                string response = string.Empty;
                Int64 idJugador = 0;

                if (ModelState.IsValid) {
                    idJugador = generalBusiness.IsNumeric(Request.Form["IdJugador"]) ? Int64.Parse(Request.Form["IdJugador"]) : 0;
                    Jugadores oJugador = new Jugadores();
                    oJugador.IdJugador = idJugador;
                    idJugador = mantenedorBusiness.ValidarJugador(oJugador);
                    if (idJugador > 0) {
                        response = "Todo bien,ok";
                    } else {
                        response = "Error en la aplicación!,";
                        response += "Se produjo un error no controlado (business)... Revisar!!";
                    }

                } else {
                    mensajeError = "Faltan datos:,";
                    mensajeError += string.Join("; ", ModelState.Values
                                                            .SelectMany(x => x.Errors)
                                                            .Select(x => x.ErrorMessage));
                    response = mensajeError;
                }
                return response;
            }
            catch (Exception ex)
            {
                mensajeError = "Error grave,";
                mensajeError += "Ups! algo salió realmente mal... Error: " + ex.Message;
                return mensajeError;
            }
        }
    }
}
