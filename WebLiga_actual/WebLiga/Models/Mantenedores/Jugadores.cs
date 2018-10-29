using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLiga.Models.Mantenedores
{
    public class Jugadores
    {
        public Int64 IdJugador { get; set; }
        public string Rut { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string Foto { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public Int64 SerieId { get; set; }
        public Int64 ClubId { get; set; }
        public string UsuarioCrea { get; set; }
        public DateTime? FechaCrea { get; set; }
        public string UsuarioElimina { get; set; }
        public DateTime? FechaElimina { get; set; }
        public int Validado { get; set; }
        public int Inscrito { get; set; }
    }
}
