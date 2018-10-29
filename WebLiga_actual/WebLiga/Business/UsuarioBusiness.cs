using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLiga.DataAcces;
using WebLiga.Models;
using WebLiga.Models.Mantenedores;

namespace WebLiga.Business
{
    public class UsuarioBusiness
    {
        LigaContext dbLiga = new LigaContext();

        public List<Usuarios> ListarUsuarios()
        {
            try
            {
                using (LigaContext dbLiga = new LigaContext())
                {
                    var oUsuarios = (from usu in dbLiga.Usuarios.Where(x => string.IsNullOrEmpty(x.UsuarioElimina))
                                select new Usuarios
                                {
                                    IdUsuario = usu.IdUsuario,
                                    Login = usu.Login,
                                    Password = usu.Password,
                                    Foto = usu.Foto,
                                    PerfilId = usu.PerfilId,
                                    ClubId = usu.ClubId,
                                    NombreCompleto = usu.NombreCompleto,
                                    UsuarioCrea = usu.UsuarioCrea,
                                    FechaCrea = usu.FechaCrea,
                                    UsuarioElimina = usu.UsuarioElimina,
                                    FechaElimina = usu.FechaElimina
                                }).ToList();
                    return oUsuarios;
                }
            }
            catch (Exception e)
            {
                //Util.Error(e.ToString());
                Startup.ConfigSite.Error = e.Message;
                return null;
            }
        }

        public Int64 GrabarUsuarios(Usuarios pObjUsuario)
        {
            try
            {
                using (LigaContext dbLiga = new LigaContext())
                {
                    if (pObjUsuario.IdUsuario > 0) {

                        //Editar
                        var v = dbLiga.Usuarios.Where(a => a.IdUsuario == pObjUsuario.IdUsuario).FirstOrDefault();
                        if (v != null) {
                            v.Login = pObjUsuario.Login;
                            v.Password = pObjUsuario.Password;
                            v.NombreCompleto = pObjUsuario.NombreCompleto;
                            v.Foto = pObjUsuario.Foto;
                            v.PerfilId = pObjUsuario.PerfilId;
                            v.ClubId = pObjUsuario.ClubId;
                            v.UsuarioElimina = pObjUsuario.UsuarioElimina;
                            v.FechaElimina = pObjUsuario.FechaElimina;
                            dbLiga.Usuarios.Update(v);
                        }
                    } else {

                        //grabar
                        dbLiga.Usuarios.Add(pObjUsuario);
                    }
                    dbLiga.SaveChanges();
                    return pObjUsuario.IdUsuario;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public Usuarios ObtenerDatosUsuario(string pLogin, string pPassword)
        {
            try
            {
                Usuarios oUsuario = new Usuarios();
                using (LigaContext dbLiga = new LigaContext())
                {
                    oUsuario = (from usu in dbLiga.Usuarios.Where(x => x.Login.Equals(pLogin) && x.Password.Equals(pPassword))
                           select new Usuarios
                           {
                               IdUsuario = usu.IdUsuario,
                               Login = usu.Login,
                               Password = usu.Password,
                               NombreCompleto = usu.NombreCompleto,
                               Foto = usu.Foto,
                               PerfilId = usu.PerfilId,
                               ClubId = usu.ClubId,
                               UsuarioCrea = usu.UsuarioCrea,
                               FechaCrea = usu.FechaCrea,
                               UsuarioElimina = usu.UsuarioElimina
                           }).FirstOrDefault();
                }
                return oUsuario;
            }
            catch (Exception e)
            {
                //Util.Error(e.ToString());
                Startup.ConfigSite.Error = e.Message;
                return null;
            }
        }

        public Usuarios ObtenerDatosUsuario(string pLogin)
        {
            try
            {
                Usuarios oUsuario = new Usuarios();
                using (LigaContext dbLiga = new LigaContext())
                {
                    oUsuario = (from usu in dbLiga.Usuarios.Where(x => x.Login.Equals(pLogin))
                           select new Usuarios
                           {
                               IdUsuario = usu.IdUsuario,
                               Login = usu.Login,
                               Password = usu.Password,
                               NombreCompleto = usu.NombreCompleto,
                               Foto = usu.Foto,
                               PerfilId = usu.PerfilId,
                               ClubId = usu.ClubId,
                               UsuarioCrea = usu.UsuarioCrea,
                               FechaCrea = usu.FechaCrea,
                               UsuarioElimina = usu.UsuarioElimina
                           }).FirstOrDefault();
                }
                return oUsuario;
            }
            catch (Exception e)
            {
                //Util.Error(e.ToString());
                Startup.ConfigSite.Error = e.Message;
                return null;
            }
        }

        public Perfiles ObtenerNombrePerfilUsuario(Int64 pPerfilId)
        {
            try
            {
                Perfiles perfil = new Perfiles();
                using (LigaContext dbLiga = new LigaContext())
                {
                    perfil = (from p in dbLiga.Perfiles.Where(x => x.IdPerfil.Equals(pPerfilId))
                           select new Perfiles
                           {
                               IdPerfil = p.IdPerfil,
                               Descripcion = p.Descripcion
                           }).FirstOrDefault();
                }
                return perfil;
            }
            catch (Exception e)
            {
                //Util.Error(e.ToString());
                Startup.ConfigSite.Error = e.Message;
                return null;
            }
        }

        public List<Accesos> ObtenerAccesosSegunPerfilUsuario(string pPerfilId)
        {
            try
            {
                List<Accesos> accesos = new List<Accesos>();
                Int64 perfil = Int64.Parse(pPerfilId);

                using (LigaContext dbLiga = new LigaContext())
                {
                    accesos = (from acc in dbLiga.Accesos.Where(x => x.PerfilId.Equals(perfil) && x.Concedido == 1)
                              select new Accesos
                              {
                                  Id = acc.Id,
                                  Tipo = acc.Tipo,
                                  Nombre = acc.Nombre,
                                  PerfilId = acc.PerfilId,
                                  Concedido = acc.Concedido,
                                  UsuarioConcede = acc.UsuarioConcede,
                                  FechaConcede = acc.FechaConcede,
                                  UsuarioDenega = acc.UsuarioDenega,
                                  FechaDenega = acc.FechaDenega
                              }).ToList();
                }
                return accesos;
            }
            catch (Exception e)
            {
                //Util.Error(e.ToString());
                Startup.ConfigSite.Error = e.Message;
                return null;
            }
        }
    }
}
