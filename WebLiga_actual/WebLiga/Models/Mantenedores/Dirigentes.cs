using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLiga.Models.Mantenedores
{
    public class Dirigentes
    {
        public int IdDirigente { get; set; }
        public string Rut { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Domicilio { get; set; }
        public string Cargo { get; set; }
        public string Email { get; set; }

        public string UsuarioCrea { get; set; }
        public DateTime? FechaCrea { get; set; }
        public string UsuarioElimina { get; set; }
        public DateTime? FechaElimina { get; set; }
    }
}
