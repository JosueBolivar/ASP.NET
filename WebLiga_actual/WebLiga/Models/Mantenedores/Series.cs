using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLiga.Models.Mantenedores
{
    public class Series
    {
        public Int64 IdSerie { get; set; }
        public string Descripcion { get; set; }
        public int EdadDesde { get; set; }
        public int EdadHasta { get; set; }
        public string UsuarioCrea { get; set; }
        public DateTime? FechaCrea { get; set; }
        public string UsuarioElimina { get; set; }
        public DateTime? FechaElimina { get; set; }
    }
}
