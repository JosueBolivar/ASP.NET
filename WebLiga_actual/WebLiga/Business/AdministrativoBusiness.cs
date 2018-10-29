using System;
using System.Collections.Generic;
using System.Linq;
using WebLiga.DataAcces;
using WebLiga.Models.Administrativo;

namespace WebLiga.Business
{
    public class AdministrativoBusiness
    {
        LigaContext dbLiga = new LigaContext();

        #region INGRESO FICHA
        public List<FechaJugada> ListarFechasJugadas(Int64 pFicha = 1)
        {
            try
            {
                using (LigaContext dbLiga = new LigaContext())
                {
                    if (pFicha > 1) {
                        var oFichas = (from f in dbLiga.FechaJugada.Where(x => string.IsNullOrEmpty(x.UsuarioElimina) && x.Id.Equals(pFicha))
                                       select new FechaJugada
                                       {
                                           Id = f.Id,
                                           CampeonatoId = f.CampeonatoId,
                                           ClubId = f.ClubId,
                                           JugadorId = f.JugadorId,
                                           Jugo = f.Jugo,
                                           Goles = f.Goles,
                                           Expulsado = f.Expulsado,
                                           Lesionado = f.Lesionado,
                                           UsuarioCrea = f.UsuarioCrea,
                                           FechaCrea = f.FechaCrea,                                           
                                           UsuarioElimina = f.UsuarioElimina,
                                           FechaElimina = f.FechaElimina
                                       }).ToList();
                        return oFichas;
                    } else {
                        var oFichas = (from f in dbLiga.FechaJugada.Where(x => string.IsNullOrEmpty(x.UsuarioElimina))
                                       select new FechaJugada
                                       {
                                           Id = f.Id,
                                           CampeonatoId = f.CampeonatoId,
                                           ClubId = f.ClubId,
                                           JugadorId = f.JugadorId,
                                           Jugo = f.Jugo,
                                           Goles = f.Goles,
                                           Expulsado = f.Expulsado,
                                           Lesionado = f.Lesionado,
                                           UsuarioCrea = f.UsuarioCrea,
                                           FechaCrea = f.FechaCrea,
                                           UsuarioElimina = f.UsuarioElimina,
                                           FechaElimina = f.FechaElimina
                                       }).ToList();
                        return oFichas;
                    }
                }
            }
            catch (Exception e)
            {
                //Util.Error(e.ToString());
                return null;
            }
        }

        public Int64 GrabarFicha(FechaJugada pObjFechaJugada)
        {
            try
            {
                using (LigaContext dbLiga = new LigaContext())
                {
                    if (pObjFechaJugada.Id > 0) {

                        //Editar
                        var v = dbLiga.FechaJugada.Where(a => a.Id == pObjFechaJugada.Id).FirstOrDefault();
                        if (v != null) {
                            v.CampeonatoId = pObjFechaJugada.CampeonatoId;
                            v.ClubId = pObjFechaJugada.ClubId;
                            v.JugadorId = pObjFechaJugada.JugadorId;
                            v.Jugo = pObjFechaJugada.Jugo;
                            v.Goles = pObjFechaJugada.Goles;
                            v.Expulsado = pObjFechaJugada.Expulsado;
                            v.Lesionado = pObjFechaJugada.Lesionado;
                            v.UsuarioElimina = pObjFechaJugada.UsuarioElimina;
                            v.FechaElimina = pObjFechaJugada.FechaElimina;
                            dbLiga.FechaJugada.Update(v);
                        }
                    } else {

                        //grabar
                        dbLiga.FechaJugada.Add(pObjFechaJugada);
                    }
                    dbLiga.SaveChanges();
                    return pObjFechaJugada.Id;
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
