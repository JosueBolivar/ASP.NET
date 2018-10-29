using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLiga.DataAcces;
using WebLiga.Models;
using WebLiga.Models.Mantenedores;

namespace WebLiga.Business
{
    public class MantenedoresBusiness
    {
        LigaContext dbLiga = new LigaContext();

        #region ACCESOS
        public List<Accesos> ListarAcesos()
        {
            try
            {
                using (LigaContext dbLiga = new LigaContext())
                {
                    var oAccesos = (from acc in dbLiga.Accesos.Where(x => string.IsNullOrEmpty(x.UsuarioDenega))
                                select new Accesos
                                {
                                    Id = acc.Id,
                                    Tipo = acc.Tipo,
                                    Nombre = acc.Nombre,
                                    PerfilId= acc.PerfilId,
                                    Concedido = acc.Concedido,
                                    UsuarioConcede = acc.UsuarioConcede,
                                    FechaConcede = acc.FechaConcede,
                                    UsuarioDenega = acc.UsuarioDenega,
                                    FechaDenega = acc.FechaDenega
                                }).ToList();
                    return oAccesos;
                }
            }
            catch (Exception e)
            {
                //Util.Error(e.ToString());
                return null;
            }
        }

        public int GrabarAcceso(Accesos pObjAcceso)
        {
            try
            {
                using (LigaContext dbLiga = new LigaContext())
                {
                    if (pObjAcceso.Id > 0) {

                        //Editar
                        var v = dbLiga.Accesos.Where(a => a.Id == pObjAcceso.Id).FirstOrDefault();
                        if (v != null) {
                            v.Tipo = pObjAcceso.Tipo;
                            v.Nombre = pObjAcceso.Nombre;
                            v.PerfilId = pObjAcceso.PerfilId;
                            v.Concedido = pObjAcceso.Concedido;
                            v.UsuarioConcede = pObjAcceso.UsuarioConcede;
                            v.FechaConcede = pObjAcceso.FechaConcede;
                            v.UsuarioDenega = pObjAcceso.UsuarioDenega;
                            v.FechaDenega = pObjAcceso.FechaDenega;
                            dbLiga.Accesos.Update(v);
                        }
                    } else {

                        //grabar
                        dbLiga.Accesos.Add(pObjAcceso);
                    }
                    dbLiga.SaveChanges();
                    return pObjAcceso.Id;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        #endregion

        #region PERFILES
        public List<Perfiles> ListarPerfiles()
        {
            try
            {
                using (LigaContext dbLiga = new LigaContext())
                {
                    var oPerfiles = (from perfil in dbLiga.Perfiles.Where(x => string.IsNullOrEmpty(x.UsuarioElimina))
                                select new Perfiles
                                {
                                    IdPerfil = perfil.IdPerfil,
                                    Descripcion = perfil.Descripcion,
                                    UsuarioCrea = perfil.UsuarioCrea,
                                    FechaCrea = perfil.FechaCrea,
                                    UsuarioElimina = perfil.UsuarioElimina,
                                    FechaElimina = perfil.FechaElimina
                                }).ToList();
                    return oPerfiles;
                }
            }
            catch (Exception e)
            {
                //Util.Error(e.ToString());
                return null;
            }
        }

        public Int64 GrabarPerfil(Perfiles pObjPerfil)
        {
            try
            {
                using (LigaContext dbLiga = new LigaContext())
                {
                    if (pObjPerfil.IdPerfil > 0) {

                        //Editar
                        var v = dbLiga.Perfiles.Where(a => a.IdPerfil == pObjPerfil.IdPerfil).FirstOrDefault();
                        if (v != null) {
                            v.Descripcion = pObjPerfil.Descripcion;
                            v.UsuarioElimina = pObjPerfil.UsuarioElimina;
                            v.FechaElimina = pObjPerfil.FechaElimina;
                            dbLiga.Perfiles.Update(v);
                        }
                    } else {

                        //grabar
                        dbLiga.Perfiles.Add(pObjPerfil);
                    }
                    dbLiga.SaveChanges();
                    return pObjPerfil.IdPerfil;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        #endregion

        #region CLUBES
        public List<Clubes> ListarClubes(int pClubId = 1)
        {
            try
            {
                using (LigaContext dbLiga = new LigaContext())
                {
                    if (pClubId > 1) {
                        var oClubes = (from club in dbLiga.Clubes.Where(x => string.IsNullOrEmpty(x.UsuarioElimina) && x.IdClub.Equals(pClubId))
                                       select new Clubes
                                       {
                                           IdClub = club.IdClub,
                                           Rut = club.Rut,
                                           Nombre = club.Nombre,
                                           Direccion = club.Direccion,
                                           Telefono = club.Telefono,
                                           Email = club.Email,
                                           NumeroPersonalidadJuridica = club.NumeroPersonalidadJuridica,
                                           NumeroRegistroCivil = club.NumeroRegistroCivil,
                                           DirectivaId = club.DirectivaId,
                                           Logo = club.Logo,
                                           UsuarioCrea = club.UsuarioCrea,
                                           FechaCrea = club.FechaCrea,
                                           UsuarioElimina = club.UsuarioElimina,
                                           FechaElimina = club.FechaElimina
                                       }).ToList();
                        return oClubes;
                    } else {
                        var oClubes = (from club in dbLiga.Clubes.Where(x => string.IsNullOrEmpty(x.UsuarioElimina))
                                       select new Clubes
                                       {
                                           IdClub = club.IdClub,
                                           Rut = club.Rut,
                                           Nombre = club.Nombre,
                                           Direccion = club.Direccion,
                                           Telefono = club.Telefono,
                                           Email = club.Email,
                                           NumeroPersonalidadJuridica = club.NumeroPersonalidadJuridica,
                                           NumeroRegistroCivil = club.NumeroRegistroCivil,
                                           DirectivaId = club.DirectivaId,
                                           Logo = club.Logo,
                                           UsuarioCrea = club.UsuarioCrea,
                                           FechaCrea = club.FechaCrea,
                                           UsuarioElimina = club.UsuarioElimina,
                                           FechaElimina = club.FechaElimina
                                       }).ToList();
                        return oClubes;
                    }
                }
            }
            catch (Exception e)
            {
                //Util.Error(e.ToString());
                return null;
            }
        }

        public Int64 GrabarClub(Clubes pObjClub)
        {
            try
            {
                using (LigaContext dbLiga = new LigaContext())
                {
                    if (pObjClub.IdClub > 0) {

                        //Editar
                        var v = dbLiga.Clubes.Where(a => a.IdClub == pObjClub.IdClub).FirstOrDefault();
                        if (v != null) {
                            v.Rut = pObjClub.Rut;
                            v.Nombre = pObjClub.Nombre;
                            v.Direccion = pObjClub.Direccion;
                            v.Telefono = pObjClub.Telefono;
                            v.Email = pObjClub.Email;
                            v.NumeroPersonalidadJuridica = pObjClub.NumeroPersonalidadJuridica;
                            v.NumeroRegistroCivil = pObjClub.NumeroRegistroCivil;
                            v.DirectivaId = pObjClub.DirectivaId;
                            v.Logo = pObjClub.Logo;
                            v.UsuarioElimina = pObjClub.UsuarioElimina;
                            v.FechaElimina = pObjClub.FechaElimina;
                            dbLiga.Clubes.Update(v);
                        }
                    } else {

                        //grabar
                        dbLiga.Clubes.Add(pObjClub);
                    }
                    dbLiga.SaveChanges();
                    return pObjClub.IdClub;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        #endregion

        #region JUGADORES
        public List<Jugadores> ListarTodosLosJugadores(int pClubId = 1)
        {
            try
            {
                using (LigaContext dbLiga = new LigaContext())
                {
                    if (pClubId > 1) {
                        var oJugadores = (from jugador in dbLiga.Jugadores.Where(x => string.IsNullOrEmpty(x.UsuarioElimina) && x.ClubId.Equals(pClubId))
                                    select new Jugadores
                                    {
                                        IdJugador = jugador.IdJugador,
                                        Rut = jugador.Rut,
                                        Apellidos = jugador.Apellidos,
                                        Nombres = jugador.Nombres,
                                        Foto = jugador.Foto,
                                        FechaNacimiento = Convert.ToDateTime(jugador.FechaNacimiento).Date,
                                        SerieId = jugador.SerieId,
                                        ClubId = jugador.ClubId,
                                        UsuarioCrea = jugador.UsuarioCrea,
                                        FechaCrea = jugador.FechaCrea,
                                        UsuarioElimina = jugador.UsuarioElimina,
                                        FechaElimina = jugador.FechaElimina,
                                        Validado = jugador.Validado,
                                        Inscrito = jugador.Inscrito
                                    }).ToList();
                        return oJugadores;
                    } else {
                        var oJugadores = (from jugador in dbLiga.Jugadores.Where(x => string.IsNullOrEmpty(x.UsuarioElimina))
                                          select new Jugadores
                                    {
                                        IdJugador = jugador.IdJugador,
                                        Rut = jugador.Rut,
                                        Apellidos = jugador.Apellidos,
                                        Nombres = jugador.Nombres,
                                        Foto = jugador.Foto,
                                        FechaNacimiento = Convert.ToDateTime(jugador.FechaNacimiento).Date,
                                        SerieId = jugador.SerieId,
                                        ClubId = jugador.ClubId,
                                        UsuarioCrea = jugador.UsuarioCrea,
                                        FechaCrea = jugador.FechaCrea,
                                        UsuarioElimina = jugador.UsuarioElimina,
                                        FechaElimina = jugador.FechaElimina,
                                        Validado = jugador.Validado,
                                        Inscrito = jugador.Inscrito
                                    }).ToList();
                        return oJugadores;
                    }
                }
            }
            catch (Exception e)
            {
                //Util.Error(e.ToString());
                return null;
            }
        }

        public List<Jugadores> ListarJugadoresValidados(int pClubId = 1)
        {
            try
            {
                using (LigaContext dbLiga = new LigaContext())
                {
                    if (pClubId > 1) {
                        var oJugadores = (from jugador in dbLiga.Jugadores.Where(x => string.IsNullOrEmpty(x.UsuarioElimina) && x.ClubId.Equals(pClubId) && x.Validado == 1 && x.Inscrito == 1)
                                    select new Jugadores
                                    {
                                        IdJugador = jugador.IdJugador,
                                        Rut = jugador.Rut,
                                        Apellidos = jugador.Apellidos,
                                        Nombres = jugador.Nombres,
                                        Foto = jugador.Foto,
                                        FechaNacimiento = Convert.ToDateTime(jugador.FechaNacimiento).Date,
                                        SerieId = jugador.SerieId,
                                        ClubId = jugador.ClubId,
                                        UsuarioCrea = jugador.UsuarioCrea,
                                        FechaCrea = jugador.FechaCrea,
                                        UsuarioElimina = jugador.UsuarioElimina,
                                        FechaElimina = jugador.FechaElimina,
                                        Validado = jugador.Validado,
                                        Inscrito = jugador.Inscrito
                                    }).ToList();
                        return oJugadores;
                    } else {
                        var oJugadores = (from jugador in dbLiga.Jugadores.Where(x => string.IsNullOrEmpty(x.UsuarioElimina) && x.Validado == 1 && x.Inscrito == 1)
                                          select new Jugadores
                                    {
                                        IdJugador = jugador.IdJugador,
                                        Rut = jugador.Rut,
                                        Apellidos = jugador.Apellidos,
                                        Nombres = jugador.Nombres,
                                        Foto = jugador.Foto,
                                        FechaNacimiento = Convert.ToDateTime(jugador.FechaNacimiento).Date,
                                        SerieId = jugador.SerieId,
                                        ClubId = jugador.ClubId,
                                        UsuarioCrea = jugador.UsuarioCrea,
                                        FechaCrea = jugador.FechaCrea,
                                        UsuarioElimina = jugador.UsuarioElimina,
                                        FechaElimina = jugador.FechaElimina,
                                        Validado = jugador.Validado,
                                        Inscrito = jugador.Inscrito
                                    }).ToList();
                        return oJugadores;
                    }
                }
            }
            catch (Exception e)
            {
                //Util.Error(e.ToString());
                return null;
            }
        }

        public List<Jugadores> ListarJugadoresNoValidados(int pClubId = 1)
        {
            try
            {
                using (LigaContext dbLiga = new LigaContext())
                {
                    if (pClubId > 1) {
                        var oJugadores = (from jugador in dbLiga.Jugadores.Where(x => string.IsNullOrEmpty(x.UsuarioElimina) && x.ClubId.Equals(pClubId) && x.Validado == 0 && x.Inscrito == 0)
                                    select new Jugadores
                                    {
                                        IdJugador = jugador.IdJugador,
                                        Rut = jugador.Rut,
                                        Apellidos = jugador.Apellidos,
                                        Nombres = jugador.Nombres,
                                        Foto = jugador.Foto,
                                        FechaNacimiento = Convert.ToDateTime(jugador.FechaNacimiento).Date,
                                        SerieId = jugador.SerieId,
                                        ClubId = jugador.ClubId,
                                        UsuarioCrea = jugador.UsuarioCrea,
                                        FechaCrea = jugador.FechaCrea,
                                        UsuarioElimina = jugador.UsuarioElimina,
                                        FechaElimina = jugador.FechaElimina,
                                        Validado = jugador.Validado,
                                        Inscrito = jugador.Inscrito
                                    }).ToList();
                        return oJugadores;
                    } else {
                        var oJugadores = (from jugador in dbLiga.Jugadores.Where(x => string.IsNullOrEmpty(x.UsuarioElimina) && x.Validado == 0 && x.Inscrito == 0)
                                          select new Jugadores
                                    {
                                        IdJugador = jugador.IdJugador,
                                        Rut = jugador.Rut,
                                        Apellidos = jugador.Apellidos,
                                        Nombres = jugador.Nombres,
                                        Foto = jugador.Foto,
                                        FechaNacimiento = Convert.ToDateTime(jugador.FechaNacimiento).Date,
                                        SerieId = jugador.SerieId,
                                        ClubId = jugador.ClubId,
                                        UsuarioCrea = jugador.UsuarioCrea,
                                        FechaCrea = jugador.FechaCrea,
                                        UsuarioElimina = jugador.UsuarioElimina,
                                        FechaElimina = jugador.FechaElimina,
                                        Validado = jugador.Validado,
                                        Inscrito = jugador.Inscrito
                                    }).ToList();
                        return oJugadores;
                    }
                }
            }
            catch (Exception e)
            {
                //Util.Error(e.ToString());
                return null;
            }
        }

        public string BuscarJugadorPorRut(string pRut)
        {
            try
            {
                string rutJugador = string.Empty;
                using (LigaContext dbLiga = new LigaContext())
                {
                    if (pRut.Length > 0) {
                        var RutJugador = (from jugador in dbLiga.Jugadores.Where(x => x.Rut.Equals(pRut))
                                          select new Jugadores
                                          {
                                              Rut = jugador.Rut
                                          }).FirstOrDefault();
                        rutJugador = RutJugador.Rut;
                    }
                }

                return rutJugador;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Int64 GrabarJugador(Jugadores pObjJugador)
        {
            try
            {
                using (LigaContext dbLiga = new LigaContext())
                {
                    if (pObjJugador.IdJugador > 0) {

                        //Editar
                        var v = dbLiga.Jugadores.Where(a => a.IdJugador == pObjJugador.IdJugador).FirstOrDefault();
                        if (v != null) {
                            v.Rut = pObjJugador.Rut;
                            v.Nombres = pObjJugador.Nombres;
                            v.Apellidos = pObjJugador.Apellidos;
                            if (pObjJugador.Foto != null) {
                                v.Foto = pObjJugador.Foto;
                            }
                            v.FechaNacimiento = pObjJugador.FechaNacimiento;
                            v.SerieId = pObjJugador.SerieId;
                            v.ClubId = pObjJugador.ClubId;
                            v.UsuarioElimina = pObjJugador.UsuarioElimina;
                            v.FechaElimina = pObjJugador.FechaElimina;
                            dbLiga.Jugadores.Update(v);
                        }
                    } else {

                        //grabar
                        dbLiga.Jugadores.Add(pObjJugador);
                    }
                    dbLiga.SaveChanges();
                    return pObjJugador.IdJugador;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public Int64 ValidarJugador(Jugadores pObjJugador)
        {
            try
            {
                using (LigaContext dbLiga = new LigaContext())
                {
                    if (pObjJugador.IdJugador > 0) {

                        //Editar
                        var v = dbLiga.Jugadores.Where(a => a.IdJugador == pObjJugador.IdJugador).FirstOrDefault();
                        if (v != null) {
                            v.Validado = 1;
                            dbLiga.Jugadores.Update(v);
                        }
                        dbLiga.SaveChanges();
                    }

                    return pObjJugador.IdJugador;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public Int64 InscribirJugador(Jugadores pObjJugador)
        {
            try
            {
                using (LigaContext dbLiga = new LigaContext())
                {
                    if (pObjJugador.IdJugador > 0) {

                        //Editar
                        var v = dbLiga.Jugadores.Where(a => a.IdJugador == pObjJugador.IdJugador).FirstOrDefault();
                        if (v != null) {
                            v.Validado = 1;
                            v.Inscrito = 1;
                            dbLiga.Jugadores.Update(v);
                        }
                        dbLiga.SaveChanges();
                    }

                    return pObjJugador.IdJugador;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        #endregion

        #region SERIES
        public List<Series> ListarSeries()
        {
            try
            {
                using (LigaContext dbLiga = new LigaContext())
                {
                    var oSeries = (from serie in dbLiga.Series.Where(x => string.IsNullOrEmpty(x.UsuarioElimina))
                                select new Series
                                {
                                    IdSerie = serie.IdSerie,
                                    Descripcion = serie.Descripcion,
                                    EdadDesde = serie.EdadDesde,
                                    EdadHasta = serie.EdadHasta,
                                    UsuarioCrea = serie.UsuarioCrea,
                                    FechaCrea = serie.FechaCrea,
                                    UsuarioElimina = serie.UsuarioElimina,
                                    FechaElimina = serie.FechaElimina
                                }).ToList();
                    return oSeries;
                }
            }
            catch (Exception e)
            {
                //Util.Error(e.ToString());
                return null;
            }
        }

        public Int64 GrabarSerie(Series pObjSerie)
        {
            try
            {
                using (LigaContext dbLiga = new LigaContext())
                {
                    if (pObjSerie.IdSerie > 0) {

                        //Editar
                        var v = dbLiga.Series.Where(a => a.IdSerie == pObjSerie.IdSerie).FirstOrDefault();
                        if (v != null) {
                            v.Descripcion = pObjSerie.Descripcion;
                            v.EdadDesde = pObjSerie.EdadDesde;
                            v.EdadHasta = pObjSerie.EdadHasta;
                            v.UsuarioElimina = pObjSerie.UsuarioElimina;
                            v.FechaElimina = pObjSerie.FechaElimina;
                            dbLiga.Series.Update(v);
                        }
                    } else {

                        //grabar
                        dbLiga.Series.Add(pObjSerie);
                    }
                    dbLiga.SaveChanges();
                    return pObjSerie.IdSerie;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        #endregion

        #region CAMPEONATOS
        public List<Campeonatos> ListarCampeonatos()
        {
            try
            {
                using (LigaContext dbLiga = new LigaContext())
                {
                    var oCampeonatos = (from c in dbLiga.Campeonatos.Where(x => string.IsNullOrEmpty(x.UsuarioElimina))
                                select new Campeonatos
                                {
                                    Id = c.Id,
                                    NombreCampeonato = c.NombreCampeonato,
                                    FechaInicio = c.FechaInicio,
                                    FechaTermino = c.FechaTermino,
                                    UsuarioCrea = c.UsuarioCrea,
                                    FechaCrea = c.FechaCrea,
                                    UsuarioElimina = c.UsuarioElimina,
                                    FechaElimina = c.FechaElimina
                                }).ToList();
                    return oCampeonatos;
                }
            }
            catch (Exception e)
            {
                //Util.Error(e.ToString());
                return null;
            }
        }

        public Int64 GrabarCampeonatos(Campeonatos pObjCampeonato)
        {
            try
            {
                using (LigaContext dbLiga = new LigaContext())
                {
                    if (pObjCampeonato.Id > 0) {

                        //Editar
                        var v = dbLiga.Campeonatos.Where(a => a.Id == pObjCampeonato.Id).FirstOrDefault();
                        if (v != null) {
                            v.NombreCampeonato = pObjCampeonato.NombreCampeonato;
                            v.FechaInicio = pObjCampeonato.FechaInicio;
                            v.FechaTermino = pObjCampeonato.FechaTermino;
                            v.UsuarioElimina = pObjCampeonato.UsuarioElimina;
                            v.FechaElimina = pObjCampeonato.FechaElimina;
                            dbLiga.Campeonatos.Update(v);
                        }
                    } else {

                        //grabar
                        dbLiga.Campeonatos.Add(pObjCampeonato);
                    }
                    dbLiga.SaveChanges();
                    return pObjCampeonato.Id;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        #endregion

        #region DIRIGENTES
        public List<Dirigentes> ListarDirigentes()
        {
            try
            {
                using (LigaContext dbLiga = new LigaContext())
                {
                    var oDirigentes = (from d in dbLiga.Dirigentes.Where(x => string.IsNullOrEmpty(x.UsuarioElimina))
                                select new Dirigentes
                                {
                                    IdDirigente = d.IdDirigente,
                                    Rut = d.Rut,
                                    Nombres = d.Nombres,
                                    Apellidos = d.Apellidos,
                                    Telefono = d.Telefono,
                                    Domicilio = d.Domicilio,
                                    Cargo = d.Cargo,
                                    Email = d.Email,
                                    UsuarioCrea = d.UsuarioCrea,
                                    FechaCrea = d.FechaCrea,
                                    UsuarioElimina = d.UsuarioElimina,
                                    FechaElimina = d.FechaElimina
                                }).ToList();
                    return oDirigentes;
                }
            }
            catch (Exception e)
            {
                //Util.Error(e.ToString());
                return null;
            }
        }

        public Int64 GrabarDirigente(Dirigentes pObjDirigente)
        {
            try
            {
                using (LigaContext dbLiga = new LigaContext())
                {
                    if (pObjDirigente.IdDirigente > 0) {

                        //Editar
                        var v = dbLiga.Dirigentes.Where(a => a.IdDirigente == pObjDirigente.IdDirigente).FirstOrDefault();
                        if (v != null) {
                            v.Rut = pObjDirigente.Rut;
                            v.Nombres = pObjDirigente.Nombres;
                            v.Apellidos = pObjDirigente.Apellidos;
                            v.Telefono = pObjDirigente.Telefono;
                            v.Domicilio = pObjDirigente.Domicilio;
                            v.Cargo = pObjDirigente.Cargo;
                            v.Email = pObjDirigente.Email;
                            v.UsuarioElimina = pObjDirigente.UsuarioElimina;
                            v.FechaElimina = pObjDirigente.FechaElimina;
                            dbLiga.Dirigentes.Update(v);
                        }
                    } else {

                        //grabar
                        dbLiga.Dirigentes.Add(pObjDirigente);
                    }
                    dbLiga.SaveChanges();
                    return pObjDirigente.IdDirigente;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        #endregion

        #region DIRECTIVAS
        public List<Directivas> ListarDirectivas()
        {
            try
            {
                using (LigaContext dbLiga = new LigaContext())
                {
                    var oDirectivas = (from d in dbLiga.Directivas.Where(x => string.IsNullOrEmpty(x.UsuarioElimina))
                                select new Directivas
                                {
                                    IdDirectiva = d.IdDirectiva,
                                    Descripcion = d.Descripcion,
                                    DirigenteId = d.DirigenteId,
                                    Observacion = d.Observacion,
                                    UsuarioCrea = d.UsuarioCrea,
                                    FechaCrea = d.FechaCrea,
                                    UsuarioElimina = d.UsuarioElimina,
                                    FechaElimina = d.FechaElimina
                                }).ToList();
                    return oDirectivas;
                }
            }
            catch (Exception e)
            {
                //Util.Error(e.ToString());
                return null;
            }
        }

        public Int64 GrabarDirectiva(Directivas pObjDirectiva)
        {
            try
            {
                using (LigaContext dbLiga = new LigaContext())
                {
                    if (pObjDirectiva.IdDirectiva > 0) {

                        //Editar
                        var v = dbLiga.Directivas.Where(a => a.IdDirectiva == pObjDirectiva.IdDirectiva).FirstOrDefault();
                        if (v != null) {
                            v.Descripcion = pObjDirectiva.Descripcion;
                            v.DirigenteId = pObjDirectiva.DirigenteId;
                            v.Observacion = pObjDirectiva.Observacion;
                            v.UsuarioElimina = pObjDirectiva.UsuarioElimina;
                            v.FechaElimina = pObjDirectiva.FechaElimina;
                            dbLiga.Directivas.Update(v);
                        }
                    } else {

                        //grabar
                        dbLiga.Directivas.Add(pObjDirectiva);
                    }
                    dbLiga.SaveChanges();
                    return pObjDirectiva.IdDirectiva;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        #endregion

        #region TIPOS MOVIMIENTO
        public List<TiposMovimiento> ListarTiposMovimiento(int pTipoMovimientoId = 1)
        {
            try
            {
                using (LigaContext dbLiga = new LigaContext())
                {
                    if (pTipoMovimientoId > 1) {
                        var oTiposMovimiento = (from tm in dbLiga.TiposMovimiento.Where(x => string.IsNullOrEmpty(x.UsuarioElimina) && x.IdTipoMovimiento.Equals(pTipoMovimientoId))
                                       select new TiposMovimiento
                                       {
                                           IdTipoMovimiento = tm.IdTipoMovimiento,
                                           Descripcion = tm.Descripcion,
                                           Monto = tm.Monto,
                                           PartidosSuspencion = tm.PartidosSuspencion,
                                           UsuarioCrea = tm.UsuarioCrea,
                                           FechaCrea = tm.FechaCrea,
                                           UsuarioElimina = tm.UsuarioElimina,
                                           FechaElimina = tm.FechaElimina
                                       }).ToList();
                        return oTiposMovimiento;
                    } else {
                        var oTiposMovimiento = (from tm in dbLiga.TiposMovimiento.Where(x => string.IsNullOrEmpty(x.UsuarioElimina))
                                       select new TiposMovimiento
                                       {
                                           IdTipoMovimiento = tm.IdTipoMovimiento,
                                           Descripcion = tm.Descripcion,
                                           Monto = tm.Monto,
                                           PartidosSuspencion = tm.PartidosSuspencion,
                                           UsuarioCrea = tm.UsuarioCrea,
                                           FechaCrea = tm.FechaCrea,
                                           UsuarioElimina = tm.UsuarioElimina,
                                           FechaElimina = tm.FechaElimina
                                       }).ToList();
                        return oTiposMovimiento;
                    }
                }
            }
            catch (Exception e)
            {
                //Util.Error(e.ToString());
                return null;
            }
        }

        public Int64 GrabarTipoMovimiento(TiposMovimiento pObjTipoMovimiento)
        {
            try
            {
                using (LigaContext dbLiga = new LigaContext())
                {
                    if (pObjTipoMovimiento.IdTipoMovimiento > 0) {

                        //Editar
                        var v = dbLiga.TiposMovimiento.Where(a => a.IdTipoMovimiento == pObjTipoMovimiento.IdTipoMovimiento).FirstOrDefault();
                        if (v != null) {
                            v.Descripcion = pObjTipoMovimiento.Descripcion;
                            v.Monto = pObjTipoMovimiento.Monto;
                            v.PartidosSuspencion = pObjTipoMovimiento.PartidosSuspencion;
                            v.UsuarioElimina = pObjTipoMovimiento.UsuarioElimina;
                            v.FechaElimina = pObjTipoMovimiento.FechaElimina;
                            dbLiga.TiposMovimiento.Update(v);
                        }
                    } else {

                        //grabar
                        dbLiga.TiposMovimiento.Add(pObjTipoMovimiento);
                    }
                    dbLiga.SaveChanges();
                    return pObjTipoMovimiento.IdTipoMovimiento;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        #endregion
    }
}
