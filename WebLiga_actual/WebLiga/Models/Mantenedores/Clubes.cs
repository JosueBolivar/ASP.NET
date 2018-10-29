using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLiga.Models.Mantenedores
{
    public class Clubes
    {
        public Int64 IdClub { get; set; }
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string NumeroPersonalidadJuridica { get; set; }
        public string NumeroRegistroCivil { get; set; }
        public string Logo { get; set; }
        public int DirectivaId { get; set; }

        public string UsuarioCrea { get; set; }
        public DateTime? FechaCrea { get; set; }
        public string UsuarioElimina { get; set; }
        public DateTime? FechaElimina { get; set; }
    }
}
