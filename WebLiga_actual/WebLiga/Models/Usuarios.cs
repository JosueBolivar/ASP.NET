using System;

namespace WebLiga.Models
{
    public class Usuarios
    {
        public Int64 IdUsuario { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string NombreCompleto { get; set; }
        public string Foto { get; set; }
        public Int64? PerfilId { get; set; }
        public Int64? ClubId { get; set; }
        public string UsuarioCrea { get; set; }
        public DateTime? FechaCrea { get; set; }
        public string UsuarioElimina { get; set; }
        public DateTime? FechaElimina { get; set; }
    }
}
