using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebLiga.Business;
using WebLiga.Models;
using WebLiga.Models.Mantenedores;
using static WebLiga.Startup;

namespace WebLiga.Controllers
{
    public class MantenedoresController : Controller
    {
        const string SessionKeyLogin = "_Login";
        const string SessionKeyPerfil = "_Perfil";
        const string SessionKeyNombreCompleto = "_NombreCompleto";
        const string SessionKeyClubId = "_ClubId";

        GeneralBusiness generalBusiness = new GeneralBusiness();
        UsuarioBusiness usuarioBusiness = new UsuarioBusiness();
        MantenedoresBusiness mantenedorBusiness = new MantenedoresBusiness();

        public ISession Session => HttpContext.Session;
        private readonly IHostingEnvironment _env;

        string mensajeError = string.Empty;
        string[] mensajeErrorUsuario = new string[2];

        public MantenedoresController(IHostingEnvironment env)
        {
            _env = env;
        }

        public List<Accesos> compruebaAccesos()
        {
            string perfilId = Startup.ConfigSite.PerfilId;
            var lstAccesos = usuarioBusiness.ObtenerAccesosSegunPerfilUsuario(perfilId);
            return lstAccesos;
        }

        #region USUARIOS
        [HttpGet]
        public IActionResult Usuarios()
        {
            ViewData["Title"] = "Usuarios";
            if (String.IsNullOrEmpty(Startup.ConfigSite.Login)) {
                return RedirectToAction("Login", "Home");
            }
             
            ViewBag.Usuarios = usuarioBusiness.ListarUsuarios();
            ViewBag.Perfiles = mantenedorBusiness.ListarPerfiles();
            ViewBag.Clubes = mantenedorBusiness.ListarClubes();

            var lstAccesos = compruebaAccesos();
            ViewBag.Accesos = lstAccesos;
            ViewBag.TipoAccesos = (from c in lstAccesos
                                   group c by c.Tipo into g
                                   select new { g.Key });

            Usuarios oUsuario = new Usuarios();
            return View(oUsuario);
        }

        [HttpPost]
        public async Task<string> GrabarUsuarios(Usuarios oUsuario, ICollection<IFormFile> files)
        {
            try
            {
                string response = string.Empty;
                Int64 id = 0;
                string login = string.Empty;

                if (ModelState.IsValid) {

                    if (files.Count > 0) {
                        //Grabar documentos adjuntos
                        string path = @ConfigSite.photos;
                        string Foto = string.Empty;
                        login = Request.Form["Login"];

                        foreach (var file in files)
                        {
                            if (file.Length > 0) {

                                string nuevonombre = login + Path.GetExtension(file.FileName); //generalBusiness.QuitaAcentos(file.FileName);

                                Foto = _env.WebRootPath  + path;
                                using (var fileStream = new FileStream(Path.Combine(Foto, nuevonombre), FileMode.Create))
                                {
                                    await file.CopyToAsync(fileStream);
                                    Foto = path + nuevonombre;
                                }
                            }
                        }
                        oUsuario.Foto = Foto;                        
                    }                    

                    if (!string.IsNullOrEmpty(Request.Form["UsuarioCrea"])) {
                        oUsuario.UsuarioCrea = Request.Form["UsuarioCrea"];
                    }

                    if (!string.IsNullOrEmpty(Request.Form["UsuarioElimina"])) {
                        oUsuario.UsuarioElimina = Request.Form["UsuarioElimina"];
                        oUsuario.FechaElimina = Convert.ToDateTime(Request.Form["FechaElimina"]);
                    }

                    id = usuarioBusiness.GrabarUsuarios(oUsuario);
                    if (id > 0) {
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
        #endregion

        #region PERFILES
        [HttpGet]
        public IActionResult Perfiles()
        {
            ViewData["Title"] = "Perfiles";
            if (String.IsNullOrEmpty(Startup.ConfigSite.Login)) {
                return RedirectToAction("Login", "Home");
            }

            ViewBag.Perfiles = mantenedorBusiness.ListarPerfiles();

            var lstAccesos = compruebaAccesos();
            ViewBag.Accesos = lstAccesos;
            ViewBag.TipoAccesos = (from c in lstAccesos
                                   group c by c.Tipo into g
                                   select new { g.Key });

            Perfiles oPerfil = new Perfiles();
            return View(oPerfil);
        }

        [HttpPost]
        public string GrabarPerfiles(Perfiles oPerfil)
        {
            try
            {
                string response = string.Empty;
                Int64 id = 0;

                if (ModelState.IsValid) {
                    if (!string.IsNullOrEmpty(Request.Form["UsuarioCrea"])) {
                        oPerfil.UsuarioCrea = Request.Form["UsuarioCrea"];
                    }

                    if (!string.IsNullOrEmpty(Request.Form["UsuarioElimina"])) {
                        oPerfil.UsuarioElimina = Request.Form["UsuarioElimina"];
                        oPerfil.FechaElimina = Convert.ToDateTime(Request.Form["FechaElimina"]);
                    }

                    id = mantenedorBusiness.GrabarPerfil(oPerfil);
                    if (id > 0) {
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
        #endregion

        #region ACCESOS
        [HttpGet]
        public IActionResult Accesos()
        {
            ViewData["Title"] = "Accesos";
            if (String.IsNullOrEmpty(Startup.ConfigSite.Login)) {
                return RedirectToAction("Login", "Home");
            }

            ViewBag.Accesos = mantenedorBusiness.ListarAcesos();
            ViewBag.Perfiles = mantenedorBusiness.ListarPerfiles();

            Accesos oAcceso = new Accesos();
            return View(oAcceso);
        }

        [HttpPost]
        public string GrabarAccesos(Accesos oAcceso)
        {
            try
            {
                string response = string.Empty;
                int id = 0;
                string accesoConcedido = string.Empty;

                if (ModelState.IsValid) {
                    if (!string.IsNullOrEmpty(Request.Form["UsuarioConcede"])) {
                        oAcceso.UsuarioConcede = Request.Form["UsuarioConcede"];
                    }

                    if (!string.IsNullOrEmpty(Request.Form["UsuarioDenega"])) {
                        oAcceso.UsuarioDenega = Request.Form["UsuarioDenega"];
                        oAcceso.FechaDenega = Convert.ToDateTime(Request.Form["FechaDenega"]);
                    }

                    accesoConcedido = Request.Form["Concedido"];
                    if (accesoConcedido == "1") {
                        oAcceso.Concedido = 1;
                    } else {
                        oAcceso.Concedido = 0;
                    }

                    id = mantenedorBusiness.GrabarAcceso(oAcceso);
                    if (id > 0) {
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
        #endregion

        #region CLUBES
        [HttpGet]
        public IActionResult Clubes()
        {
            ViewData["Title"] = "Clubes";

            if (String.IsNullOrEmpty(Startup.ConfigSite.Login)) {
                return RedirectToAction("Login", "Home");
            }
            
            ViewBag.Clubes = mantenedorBusiness.ListarClubes();
            ViewBag.Directivas = mantenedorBusiness.ListarDirectivas();

            var lstAccesos = compruebaAccesos();
            ViewBag.Accesos = lstAccesos;
            ViewBag.TipoAccesos = (from c in lstAccesos
                                   group c by c.Tipo into g
                                   select new { g.Key });

            return View();
        }        

        [HttpPost]
        public async Task<string> GrabarClubes(Clubes oClub, ICollection<IFormFile> files)
        {
            try
            {
                string response = string.Empty;
                Int64 idClub = 0;
                string Rut = string.Empty;
                string Nombre = string.Empty;
                string Direccion = string.Empty;
                string Telefono = string.Empty;
                string Logo = string.Empty;
                string UsuarioCrea = string.Empty;                

                if (ModelState.IsValid) {
                    idClub = generalBusiness.IsNumeric(Request.Form["IdClub"]) ? Int64.Parse(Request.Form["IdClub"]) : 0;
                    Rut = Request.Form["Rut"];

                    bool rutValido = generalBusiness.validarRut(Rut);

                    if (!rutValido) {
                        response = "Error en el Rut ,";
                        response += "El rut no es válido... Por favor revise y vuelva a intentar";

                    } else {
                        Nombre = Request.Form["Nombre"];
                        UsuarioCrea = Request.Form["UsuarioCrea"];
                        Direccion = Request.Form["Direccion"];
                        Telefono = Request.Form["Telefono"];

                        //Grabar documentos adjuntos
                        string path = @ConfigSite.logosClub;

                        foreach (var file in files)
                        {
                            if (file.Length > 0) {

                                string nuevonombre = generalBusiness.QuitaAcentos(file.FileName);
                                Logo = _env.WebRootPath  + path;
                                using (var fileStream = new FileStream(Path.Combine(Logo, nuevonombre), FileMode.Create))
                                {
                                    await file.CopyToAsync(fileStream);
                                    //Logo = _env.WebRootPath + path + nuevonombre;
                                    Logo = path + nuevonombre;
                                }
                            }
                        }
                        oClub.Logo = Logo;

                        if (!string.IsNullOrEmpty(Request.Form["UsuarioCrea"])) {
                            oClub.UsuarioCrea = Request.Form["UsuarioCrea"];
                        }

                        if (!string.IsNullOrEmpty(Request.Form["UsuarioElimina"])) {
                            oClub.UsuarioElimina = Request.Form["UsuarioElimina"];
                            oClub.FechaElimina = Convert.ToDateTime(Request.Form["FechaElimina"]);
                        }

                        idClub = mantenedorBusiness.GrabarClub(oClub);
                        if (idClub > 0) {
                            response = "Todo bien,ok";
                        } else {
                            response = "Error en la aplicación!,";
                            response += "Se produjo un error no controlado (business)... Revisar!!";
                        }
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
        #endregion

        #region JUGADORES
        [HttpGet]
        public IActionResult Jugadores()
        {
            ViewData["Title"] = "Jugadores";

            if (String.IsNullOrEmpty(Startup.ConfigSite.Login)) {
                return RedirectToAction("Login", "Home");
            }

            int clubID = int.Parse(Session.GetString(SessionKeyClubId));
            ViewBag.Jugadores = mantenedorBusiness.ListarTodosLosJugadores(clubID);
            ViewBag.Series = mantenedorBusiness.ListarSeries();
            ViewBag.Clubes = mantenedorBusiness.ListarClubes(clubID);

            var lstAccesos = compruebaAccesos();
            ViewBag.Accesos = lstAccesos;
            ViewBag.TipoAccesos = (from c in lstAccesos
                                   group c by c.Tipo into g
                                   select new { g.Key });

            Jugadores oJugador = new Jugadores();
            return View(oJugador);
        }

        [HttpPost]
        public string ObtenerJugador(string pRut)
        {
            try
            {
                string response = mantenedorBusiness.BuscarJugadorPorRut(pRut);
                if (string.IsNullOrEmpty(response)) {
                    response = "Ok";                    
                } else {
                    response = "Ya existe";
                }
                return response;
            }
            catch (Exception ex)
            {
                return "Error " + ex.Message;
            }
        }

        [HttpPost]
        public async Task<string> GrabarJugadores(Jugadores oJugador, ICollection<IFormFile> files)
        {
            try
            {
                string response = string.Empty;
                Int64 idJugador = 0;
                string Rut = string.Empty;
                string Nombres = string.Empty;
                string Apellidos = string.Empty;
                string Foto = string.Empty;
                Int64 SerieId = 0;
                Int64 ClubId = 0;
                string UsuarioCrea = string.Empty;                

                if (ModelState.IsValid) {
                    idJugador = generalBusiness.IsNumeric(Request.Form["IdJugador"]) ? Int64.Parse(Request.Form["IdJugador"]) : 0;
                    Rut = Request.Form["Rut"];

                    bool rutValido = generalBusiness.validarRut(Rut);
                    string jugadorExiste = mantenedorBusiness.BuscarJugadorPorRut(Rut);

                    if (!rutValido) {
                        response = "Error en el Rut ,";
                        response += "El rut no es válido... Por favor revise y vuelva a intentar";

                    } else {
                        if (string.IsNullOrEmpty(jugadorExiste)) {

                            Nombres = Request.Form["Nombres"];
                            Apellidos = Request.Form["Apellidos"];
                            UsuarioCrea = Request.Form["UsuarioCrea"];

                            if (files.Count > 0) {
                                //Grabar documentos adjuntos
                                string path = @ConfigSite.fotosJugadores;

                                foreach (var file in files)
                                {
                                    if (file.Length > 0) {

                                        string nuevonombre = generalBusiness.QuitaAcentos(file.FileName);
                                        Foto = _env.WebRootPath  + path;
                                        using (var fileStream = new FileStream(Path.Combine(Foto, nuevonombre), FileMode.Create))
                                        {
                                            await file.CopyToAsync(fileStream);
                                            Foto = path + nuevonombre;
                                        }
                                    }
                                }
                                oJugador.Foto = Foto;
                            }

                            if (!string.IsNullOrEmpty(Request.Form["UsuarioCrea"])) {
                                oJugador.UsuarioCrea = Request.Form["UsuarioCrea"];
                            }

                            if (!string.IsNullOrEmpty(Request.Form["UsuarioElimina"])) {
                                oJugador.UsuarioElimina = Request.Form["UsuarioElimina"];
                                oJugador.FechaElimina = Convert.ToDateTime(Request.Form["FechaElimina"]);
                            }

                            idJugador = mantenedorBusiness.GrabarJugador(oJugador);
                            if (idJugador > 0) {
                                response = "Todo bien,ok";
                            } else {
                                response = "Error en la aplicación!,";
                                response += "Se produjo un error no controlado (business)... Revisar!!";
                            }
                        } else {
                            mensajeError = "Jugadores,";
                            mensajeError += "Ups! El jugador ya ha sido inscrito anteriormente.";
                            return mensajeError;
                        }
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
        #endregion

        #region SERIES
        [HttpGet]
        public IActionResult Series()
        {
            ViewData["Title"] = "Series";
            if (String.IsNullOrEmpty(Startup.ConfigSite.Login)) {
                return RedirectToAction("Login", "Home");
            }

            ViewBag.Series = mantenedorBusiness.ListarSeries();
            ViewBag.Accesos = mantenedorBusiness.ListarAcesos();
            Series oSerie = new Series();
            return View(oSerie);
        }

        [HttpPost]
        public string GrabarSeries(Series oSerie)
        {
            try
            {
                string response = string.Empty;
                Int64 id = 0;

                if (ModelState.IsValid) {
                    if (!string.IsNullOrEmpty(Request.Form["UsuarioCrea"])) {
                        oSerie.UsuarioCrea = Request.Form["UsuarioCrea"];
                    }

                    if (!string.IsNullOrEmpty(Request.Form["UsuarioElimina"])) {
                        oSerie.UsuarioElimina = Request.Form["UsuarioElimina"];
                        oSerie.FechaElimina = Convert.ToDateTime(Request.Form["FechaElimina"]);
                    }

                    id = mantenedorBusiness.GrabarSerie(oSerie);
                    if (id > 0) {
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
        #endregion

        #region CAMPEONATOS
        [HttpGet]
        public IActionResult Campeonatos()
        {
            ViewData["Title"] = "Campeonatos";
            if (String.IsNullOrEmpty(Startup.ConfigSite.Login)) {
                return RedirectToAction("Login", "Home");
            }

            ViewBag.Campeonatos = mantenedorBusiness.ListarCampeonatos();
            var lstAccesos = compruebaAccesos();
            ViewBag.Accesos = lstAccesos;
            ViewBag.TipoAccesos = (from c in lstAccesos
                                   group c by c.Tipo into g
                                   select new { g.Key });

            Campeonatos oCampeonato = new Campeonatos();
            return View(oCampeonato);
        }

        [HttpPost]
        public string GrabarCampeonatos(Campeonatos oCampeonato)
        {
            try
            {
                string response = string.Empty;
                Int64 id = 0;

                if (ModelState.IsValid) {
                    if (!string.IsNullOrEmpty(Request.Form["UsuarioCrea"])) {
                        oCampeonato.UsuarioCrea = Request.Form["UsuarioCrea"];
                    }

                    if (!string.IsNullOrEmpty(Request.Form["UsuarioElimina"])) {
                        oCampeonato.UsuarioElimina = Request.Form["UsuarioElimina"];
                        oCampeonato.FechaElimina = Convert.ToDateTime(Request.Form["FechaElimina"]);
                    }

                    id = mantenedorBusiness.GrabarCampeonatos(oCampeonato);
                    if (id > 0) {
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
        #endregion

        #region DIRIGENTES
        [HttpGet]
        public IActionResult Dirigentes()
        {
            ViewData["Title"] = "Dirigentes";
            if (String.IsNullOrEmpty(Startup.ConfigSite.Login)) {
                return RedirectToAction("Login", "Home");
            }

            ViewBag.Dirigentes = mantenedorBusiness.ListarDirigentes();
            var lstAccesos = compruebaAccesos();
            ViewBag.Accesos = lstAccesos;
            ViewBag.TipoAccesos = (from c in lstAccesos
                                   group c by c.Tipo into g
                                   select new { g.Key });

            Dirigentes oDirigentes = new Dirigentes();
            return View(oDirigentes);
        }

        [HttpPost]
        public string GrabarDirigente(Dirigentes oDirigente)
        {
            try
            {
                string response = string.Empty;
                Int64 id = 0;

                if (ModelState.IsValid) {
                    if (!string.IsNullOrEmpty(Request.Form["UsuarioCrea"])) {
                        oDirigente.UsuarioCrea = Request.Form["UsuarioCrea"];
                    }

                    if (!string.IsNullOrEmpty(Request.Form["UsuarioElimina"])) {
                        oDirigente.UsuarioElimina = Request.Form["UsuarioElimina"];
                        oDirigente.FechaElimina = Convert.ToDateTime(Request.Form["FechaElimina"]);
                    }

                    id = mantenedorBusiness.GrabarDirigente(oDirigente);
                    if (id > 0) {
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
        #endregion

        #region DIRECTIVAS
        [HttpGet]
        public IActionResult Directivas()
        {
            ViewData["Title"] = "Directivas";
            if (String.IsNullOrEmpty(Startup.ConfigSite.Login)) {
                return RedirectToAction("Login", "Home");
            }

            ViewBag.Directivas = mantenedorBusiness.ListarDirectivas();
            var lstAccesos = compruebaAccesos();
            ViewBag.Accesos = lstAccesos;
            ViewBag.TipoAccesos = (from c in lstAccesos
                                   group c by c.Tipo into g
                                   select new { g.Key });

            ViewBag.Dirigentes = mantenedorBusiness.ListarDirigentes();
            Directivas oDirectiva = new Directivas();
            return View(oDirectiva);
        }

        [HttpPost]
        public string GrabarDirectiva(Directivas oDirectiva)
        {
            try
            {
                string response = string.Empty;
                Int64 id = 0;

                if (ModelState.IsValid) {
                    if (!string.IsNullOrEmpty(Request.Form["UsuarioCrea"])) {
                        oDirectiva.UsuarioCrea = Request.Form["UsuarioCrea"];
                    }

                    if (!string.IsNullOrEmpty(Request.Form["UsuarioElimina"])) {
                        oDirectiva.UsuarioElimina = Request.Form["UsuarioElimina"];
                        oDirectiva.FechaElimina = Convert.ToDateTime(Request.Form["FechaElimina"]);
                    }

                    id = mantenedorBusiness.GrabarDirectiva(oDirectiva);
                    if (id > 0) {
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
        #endregion

        #region TIPOS_MOVIMIENTO
        [HttpGet]
        public IActionResult TiposMovimiento()
        {
            ViewData["Title"] = "Tipos Movimiento";

            if (String.IsNullOrEmpty(Startup.ConfigSite.Login)) {
                return RedirectToAction("Login", "Home");
            }
            
            ViewBag.TiposMovimiento = mantenedorBusiness.ListarTiposMovimiento();

            var lstAccesos = compruebaAccesos();
            ViewBag.Accesos = lstAccesos;
            ViewBag.TipoAccesos = (from c in lstAccesos
                                   group c by c.Tipo into g
                                   select new { g.Key });

            return View();
        }        

        [HttpPost]
        public string GrabarTipoMovimiento(TiposMovimiento oTipoMovimiento)
        {
            try
            {
                string response = string.Empty;
                Int64 idTipoMovimiento = 0;
                string Descripcion = string.Empty;
                string UsuarioCrea = string.Empty;
                int Monto = 0;
                int PartidosSuspencion = 0;

                if (ModelState.IsValid) {
                    idTipoMovimiento = generalBusiness.IsNumeric(Request.Form["IdTipoMovimiento"]) ? Int64.Parse(Request.Form["IdTipoMovimiento"]) : 0;
                    Descripcion = Request.Form["Descripcion"];
                    Monto = int.Parse(Request.Form["Monto"]);
                    PartidosSuspencion = int.Parse(Request.Form["PartidosSuspencion"]);

                    if (!string.IsNullOrEmpty(Request.Form["UsuarioCrea"])) {
                        oTipoMovimiento.UsuarioCrea = Request.Form["UsuarioCrea"];
                    }

                    if (!string.IsNullOrEmpty(Request.Form["UsuarioElimina"])) {
                        oTipoMovimiento.UsuarioElimina = Request.Form["UsuarioElimina"];
                        oTipoMovimiento.FechaElimina = Convert.ToDateTime(Request.Form["FechaElimina"]);
                    }

                    idTipoMovimiento = mantenedorBusiness.GrabarTipoMovimiento(oTipoMovimiento);
                    if (idTipoMovimiento > 0) {
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
        #endregion
    }
}
