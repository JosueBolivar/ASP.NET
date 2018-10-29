using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLiga.Models.Mantenedores
{
    public class Accesos
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Nombre { get; set; }
        public Int64? PerfilId { get; set; }
        public int? Concedido { get; set; }
        public string UsuarioConcede { get; set; }
        public DateTime? FechaConcede { get; set; }
        public string UsuarioDenega { get; set; }
        public DateTime? FechaDenega { get; set; }
    }
}
