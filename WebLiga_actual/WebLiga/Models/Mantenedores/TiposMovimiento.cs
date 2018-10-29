using System;

namespace WebLiga.Models.Mantenedores
{
    public class TiposMovimiento
    {
        public Int64 IdTipoMovimiento { get; set; }
        public string Descripcion { get; set; }
        public int Monto { get; set; }
        public int PartidosSuspencion { get; set; }

        public string UsuarioCrea { get; set; }
        public DateTime? FechaCrea { get; set; }
        public string UsuarioElimina { get; set; }
        public DateTime? FechaElimina { get; set; }
    }
}
