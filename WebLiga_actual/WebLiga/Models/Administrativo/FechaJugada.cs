using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebLiga.Models.Administrativo
{
    [Table("RegistroFechaJugada")]
    public class FechaJugada
    {
        public Int64 Id { get; set; }
        public Int64 CampeonatoId { get; set; }
        public Int64 ClubId { get; set; }
        public Int64 JugadorId { get; set; }
        public int? Jugo { get; set; }
        public int? Goles { get; set; }
        public int? Expulsado { get; set; }
        public int? Lesionado { get; set; }

        public string UsuarioCrea { get; set; }
        public DateTime? FechaCrea { get; set; }
        public string UsuarioElimina { get; set; }
        public DateTime? FechaElimina { get; set; }
    }
}
