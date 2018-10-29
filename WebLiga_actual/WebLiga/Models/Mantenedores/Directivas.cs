using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLiga.Models.Mantenedores
{
    public class Directivas
    {
        public int IdDirectiva { get; set; }
        public string Descripcion { get; set; }
        public int DirigenteId { get; set; }
        public string Observacion { get; set; }

        public string UsuarioCrea { get; set; }
        public DateTime? FechaCrea { get; set; }
        public string UsuarioElimina { get; set; }
        public DateTime? FechaElimina { get; set; }
    }
}
