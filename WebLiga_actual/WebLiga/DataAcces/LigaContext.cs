using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebLiga.Models;
using WebLiga.Models.Mantenedores;
using WebLiga.Models.Administrativo;

namespace WebLiga.DataAcces
{
    public class LigaContext : DbContext
    {
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Clubes> Clubes { get; set; }
        public virtual DbSet<Jugadores> Jugadores { get; set; }
        public virtual DbSet<Series> Series { get; set; }
        public virtual DbSet<Perfiles> Perfiles { get; set; }
        public virtual DbSet<Accesos> Accesos { get; set; }
        public virtual DbSet<Campeonatos> Campeonatos { get; set; }
        public virtual DbSet<Dirigentes> Dirigentes { get; set; }
        public virtual DbSet<Directivas> Directivas { get; set; }
        public virtual DbSet<TiposMovimiento> TiposMovimiento { get; set; }
        public virtual DbSet<FechaJugada> FechaJugada { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var Configuracion = Startup.StrConexion;
            string str = Configuracion.GetConnectionString("Liga");
            optionsBuilder.UseSqlServer(@str);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region MANTENEDORES
            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario).HasName("IdUsuario");
                entity.Property(e => e.IdUsuario).HasColumnType("bigint");
                entity.Property(e => e.Login).HasColumnType("varchar(50)");
                entity.Property(e => e.Password).HasColumnType("varchar(10)");
                entity.Property(e => e.NombreCompleto).HasColumnType("varchar(150)");
                entity.Property(e => e.Foto).HasColumnType("varchar(200)");
                entity.Property(e => e.PerfilId).HasColumnType("bigint");
                entity.Property(e => e.ClubId).HasColumnType("bigint");
                entity.Property(e => e.UsuarioCrea).HasColumnType("varchar(50)");
                entity.Property(e => e.FechaCrea).HasColumnType("datetime").HasDefaultValueSql("getdate()");
                entity.Property(e => e.UsuarioElimina).HasColumnType("varchar(50)");
                entity.Property(e => e.FechaElimina).HasColumnType("datetime");

            });
            
            modelBuilder.Entity<Clubes>(entity =>
            {
                entity.HasKey(e => e.IdClub).HasName("IdClub");
                entity.Property(e => e.IdClub).HasColumnType("bigint");
                entity.Property(e => e.Rut).HasColumnType("varchar(10)");
                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");
                entity.Property(e => e.Direccion).HasColumnType("varchar(200)");
                entity.Property(e => e.Telefono).HasColumnType("varchar(20)");
                entity.Property(e => e.Email).HasColumnType("varchar(200)");
                entity.Property(e => e.NumeroPersonalidadJuridica).HasColumnType("varchar(50)");
                entity.Property(e => e.NumeroRegistroCivil).HasColumnType("varchar(50)");
                entity.Property(e => e.Logo).HasColumnType("varchar(200)");
                entity.Property(e => e.DirectivaId).HasColumnType("int");
                entity.Property(e => e.UsuarioCrea).HasColumnType("varchar(50)");
                entity.Property(e => e.FechaCrea).HasColumnType("datetime").HasDefaultValueSql("getdate()");
                entity.Property(e => e.UsuarioElimina).HasColumnType("varchar(50)");
                entity.Property(e => e.FechaElimina).HasColumnType("datetime");
            });

            modelBuilder.Entity<Jugadores>(entity =>
            {
                entity.HasKey(e => e.IdJugador).HasName("IdJugador");
                entity.Property(e => e.IdJugador).HasColumnType("bigint");
                entity.Property(e => e.Rut).HasColumnType("varchar(10)");
                entity.Property(e => e.Apellidos).HasColumnType("varchar(200)");
                entity.Property(e => e.Nombres).HasColumnType("varchar(200)");
                entity.Property(e => e.Foto).HasColumnType("varchar(200)");
                entity.Property(e => e.FechaNacimiento).HasColumnType("date");
                entity.Property(e => e.SerieId).HasColumnType("bigint");
                entity.Property(e => e.ClubId).HasColumnType("bigint");
                entity.Property(e => e.UsuarioCrea).HasColumnType("varchar(50)");
                entity.Property(e => e.FechaCrea).HasColumnType("datetime").HasDefaultValueSql("getdate()");
                entity.Property(e => e.UsuarioElimina).HasColumnType("varchar(50)");
                entity.Property(e => e.FechaElimina).HasColumnType("datetime");
                entity.Property(e => e.Validado).HasColumnType("int");
                entity.Property(e => e.Inscrito).HasColumnType("int");
            });

            modelBuilder.Entity<Series>(entity =>
            {
                entity.HasKey(e => e.IdSerie).HasName("IdSerie");
                entity.Property(e => e.IdSerie).HasColumnType("bigint");
                entity.Property(e => e.Descripcion).HasColumnType("varchar(100)");
                entity.Property(e => e.EdadDesde).HasColumnType("int)");
                entity.Property(e => e.EdadHasta).HasColumnType("int)");
                entity.Property(e => e.UsuarioCrea).HasColumnType("varchar(50)");
                entity.Property(e => e.FechaCrea).HasColumnType("datetime").HasDefaultValueSql("getdate()");
                entity.Property(e => e.UsuarioElimina).HasColumnType("varchar(50)");
                entity.Property(e => e.FechaElimina).HasColumnType("datetime");
            });

            modelBuilder.Entity<Perfiles>(entity =>
            {
                entity.HasKey(e => e.IdPerfil).HasName("IdPerfil");
                entity.Property(e => e.IdPerfil).HasColumnType("bigint");
                entity.Property(e => e.Descripcion).HasColumnType("varchar(100)");
                entity.Property(e => e.UsuarioCrea).HasColumnType("varchar(50)");
                entity.Property(e => e.FechaCrea).HasColumnType("datetime").HasDefaultValueSql("getdate()");
                entity.Property(e => e.UsuarioElimina).HasColumnType("varchar(50)");
                entity.Property(e => e.FechaElimina).HasColumnType("datetime");
            });

            modelBuilder.Entity<Accesos>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Id");
                entity.Property(e => e.Id).HasColumnType("int");
                entity.Property(e => e.Tipo).HasColumnType("varchar(100)");
                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");
                entity.Property(e => e.PerfilId).HasColumnType("bigint)");
                entity.Property(e => e.Concedido).HasColumnType("int)");
                entity.Property(e => e.UsuarioConcede).HasColumnType("varchar(50)");
                entity.Property(e => e.FechaConcede).HasColumnType("datetime").HasDefaultValueSql("getdate()");
                entity.Property(e => e.FechaDenega).HasColumnType("varchar(50)");
                entity.Property(e => e.FechaDenega).HasColumnType("datetime");
            });

            modelBuilder.Entity<Campeonatos>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Id");
                entity.Property(e => e.Id).HasColumnType("bigint");
                entity.Property(e => e.NombreCampeonato).HasColumnType("varchar(200)");
                entity.Property(e => e.FechaInicio).HasColumnType("date");
                entity.Property(e => e.FechaTermino).HasColumnType("date");
                entity.Property(e => e.UsuarioCrea).HasColumnType("varchar(50)");
                entity.Property(e => e.FechaCrea).HasColumnType("datetime").HasDefaultValueSql("getdate()");
                entity.Property(e => e.UsuarioElimina).HasColumnType("varchar(50)");
                entity.Property(e => e.FechaElimina).HasColumnType("datetime");
            });

            modelBuilder.Entity<Dirigentes>(entity =>
            {
                entity.HasKey(e => e.IdDirigente).HasName("IdDirigente");
                entity.Property(e => e.IdDirigente).HasColumnType("int");
                entity.Property(e => e.Rut).HasColumnType("varchar(10)");
                entity.Property(e => e.Nombres).HasColumnType("varchar(100)");
                entity.Property(e => e.Apellidos).HasColumnType("varchar(100)");
                entity.Property(e => e.Telefono).HasColumnType("varchar(25)");
                entity.Property(e => e.Domicilio).HasColumnType("varchar(200)");
                entity.Property(e => e.Cargo).HasColumnType("varchar(50)");
                entity.Property(e => e.Email).HasColumnType("varchar(100)");
                entity.Property(e => e.UsuarioCrea).HasColumnType("varchar(50)");
                entity.Property(e => e.FechaCrea).HasColumnType("datetime").HasDefaultValueSql("getdate()");
                entity.Property(e => e.UsuarioElimina).HasColumnType("varchar(50)");
                entity.Property(e => e.FechaElimina).HasColumnType("datetime");
            });

            modelBuilder.Entity<Directivas>(entity =>
            {
                entity.HasKey(e => e.IdDirectiva).HasName("IdDirectiva");
                entity.Property(e => e.IdDirectiva).HasColumnType("int");
                entity.Property(e => e.Descripcion).HasColumnType("varchar(50)");
                entity.Property(e => e.DirigenteId).HasColumnType("int");
                entity.Property(e => e.Observacion).HasColumnType("varchar(200)");
                entity.Property(e => e.UsuarioCrea).HasColumnType("varchar(50)");
                entity.Property(e => e.FechaCrea).HasColumnType("datetime").HasDefaultValueSql("getdate()");
                entity.Property(e => e.UsuarioElimina).HasColumnType("varchar(50)");
                entity.Property(e => e.FechaElimina).HasColumnType("datetime");
            });

            modelBuilder.Entity<TiposMovimiento>(entity =>
            {
                entity.HasKey(e => e.IdTipoMovimiento).HasName("IdTipoMovimiento");
                entity.Property(e => e.IdTipoMovimiento).HasColumnType("bigint");
                entity.Property(e => e.Descripcion).HasColumnType("varchar(200)");
                entity.Property(e => e.Monto).HasColumnType("int");
                entity.Property(e => e.PartidosSuspencion).HasColumnType("int");
                entity.Property(e => e.UsuarioCrea).HasColumnType("varchar(50)");
                entity.Property(e => e.FechaCrea).HasColumnType("datetime").HasDefaultValueSql("getdate()");
                entity.Property(e => e.UsuarioElimina).HasColumnType("varchar(50)");
                entity.Property(e => e.FechaElimina).HasColumnType("datetime");
            });
            #endregion

            #region ADMINISTRATIVO
            modelBuilder.Entity<FechaJugada>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Id");
                entity.Property(e => e.Id).HasColumnType("bigint");
                entity.Property(e => e.CampeonatoId).HasColumnType("bigint");
                entity.Property(e => e.ClubId).HasColumnType("bigint");
                entity.Property(e => e.JugadorId).HasColumnType("bigint");
                entity.Property(e => e.Jugo).HasColumnType("int");
                entity.Property(e => e.Goles).HasColumnType("int");
                entity.Property(e => e.Expulsado).HasColumnType("int");
                entity.Property(e => e.Lesionado).HasColumnType("int");
                entity.Property(e => e.UsuarioCrea).HasColumnType("varchar(50)");
                entity.Property(e => e.FechaCrea).HasColumnType("datetime").HasDefaultValueSql("getdate()");
                entity.Property(e => e.UsuarioElimina).HasColumnType("varchar(50)");
                entity.Property(e => e.FechaElimina).HasColumnType("datetime");
            });
            #endregion
        }
    }
}
