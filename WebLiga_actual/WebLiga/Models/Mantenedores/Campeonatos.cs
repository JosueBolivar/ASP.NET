using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLiga.Models.Mantenedores
{
    public class Campeonatos
    {
        public Int64 Id { get; set; }
        public string NombreCampeonato { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaTermino { get; set; }
        public string UsuarioCrea { get; set; }
        public DateTime? FechaCrea { get; set; }
        public string UsuarioElimina { get; set; }
        public DateTime? FechaElimina { get; set; }
    }
}
