using Microsoft.EntityFrameworkCore;
using CRD.Domain.Models;
namespace CRD.InfraData.Context
{
    public partial class CooperaDBContext : DbContext
    {
        public CooperaDBContext()
        {
        }

        public CooperaDBContext(DbContextOptions<CooperaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Barrio> Barrio { get; set; }
        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<DistritoMunicipal> DistritoMunicipal { get; set; }
        public virtual DbSet<EntidadMunicipal> EntidadMunicipal { get; set; }
        public virtual DbSet<Incidencia> Incidencia { get; set; }
        public virtual DbSet<IncidenciaUsuario> IncidenciaUsuario { get; set; }
        public virtual DbSet<IntegranteJdV> IntegranteJdV { get; set; }
        public virtual DbSet<JuntaDeVecinos> JuntaDeVecinos { get; set; }
        public virtual DbSet<Municipio> Municipio { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Seccion> Seccion { get; set; }
        public virtual DbSet<Sector> Sector { get; set; }
        public virtual DbSet<StatusIncidencia> StatusIncidencia { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumento { get; set; }
        public virtual DbSet<TipoIncidencia> TipoIncidencia { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barrio>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.Barrio)
                    .HasForeignKey(d => d.SectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Barrio__SectorId__2A363CC5");
            });

            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.Property(e => e.Descripccion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DistritoMunicipal>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Municipio)
                    .WithMany(p => p.DistritoMunicipal)
                    .HasForeignKey(d => d.MunicipioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DistritoM__Munic__21A0F6C4");
            });

            modelBuilder.Entity<EntidadMunicipal>(entity =>
            {
                entity.HasIndex(e => e.Documento)
                    .HasName("UQ__EntidadM__AF73706D1A52ACA4")
                    .IsUnique();

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cargo)
                    .WithMany(p => p.EntidadMunicipal)
                    .HasForeignKey(d => d.CargoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EntidadMu__Cargo__542C7691");

                entity.HasOne(d => d.Municipio)
                    .WithMany(p => p.EntidadMunicipal)
                    .HasForeignKey(d => d.MunicipioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EntidadMu__Munic__5614BF03");

                entity.HasOne(d => d.TipoDocumento)
                    .WithMany(p => p.EntidadMunicipal)
                    .HasForeignKey(d => d.TipoDocumentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EntidadMu__TipoD__55209ACA");
            });

            modelBuilder.Entity<Incidencia>(entity =>
            {
                entity.Property(e => e.Descripccion)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.FechaCreado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TituloImagen)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Barrio)
                    .WithMany(p => p.Incidencia)
                    .HasForeignKey(d => d.BarrioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Incidenci__Barri__3F3159AB");

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.IncidenciaEmpleado)
                    .HasForeignKey(d => d.EmpleadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Incidenci__Emple__3B60C8C7");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Incidencia)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Incidenci__Statu__3D491139");

                entity.HasOne(d => d.Tipo)
                    .WithMany(p => p.Incidencia)
                    .HasForeignKey(d => d.TipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Incidenci__TipoI__3E3D3572");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.IncidenciaUsuario)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Incidenci__Usuar__3C54ED00");
            });

            modelBuilder.Entity<IncidenciaUsuario>(entity =>
            {
                entity.HasOne(d => d.Incidencia)
                    .WithMany(p => p.IncidenciaUsuario)
                    .HasForeignKey(d => d.IncidenciaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Incidenci__Incid__43F60EC8");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.IncidenciaUsuarioNavigation)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Incidenci__Usuar__4301EA8F");
            });

            modelBuilder.Entity<IntegranteJdV>(entity =>
            {
                entity.HasKey(e => e.IntegranteId)
                    .HasName("PK__Integran__56C94B27855A9C69");

                entity.HasIndex(e => e.UsuarioId)
                    .HasName("UQ__Integran__2B3DE7B935C8AD32")
                    .IsUnique();

                entity.HasOne(d => d.JuntaDeVecinos)
                    .WithMany(p => p.IntegranteJdV)
                    .HasForeignKey(d => d.JuntaDeVecinosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Integrant__Junta__4D7F7902");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.IntegranteJdV)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Integrant__RolId__4E739D3B");

                entity.HasOne(d => d.Usuario)
                    .WithOne(p => p.IntegranteJdV)
                    .HasForeignKey<IntegranteJdV>(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Integrant__Usuar__4C8B54C9");
            });

            modelBuilder.Entity<JuntaDeVecinos>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Barrio)
                    .WithMany(p => p.JuntaDeVecinos)
                    .HasForeignKey(d => d.BarrioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__JuntaDeVe__Barri__48BAC3E5");
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Provincia)
                    .WithMany(p => p.Municipio)
                    .HasForeignKey(d => d.ProvinciaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Municipio__Provi__1EC48A19");
            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.Property(e => e.Descripccion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Seccion>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.DistritoMunicipal)
                    .WithMany(p => p.Seccion)
                    .HasForeignKey(d => d.DistritoMunicipalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Seccion__Distrit__247D636F");
            });

            modelBuilder.Entity<Sector>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Seccion)
                    .WithMany(p => p.Sector)
                    .HasForeignKey(d => d.SeccionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sector__SeccionI__2759D01A");
            });

            modelBuilder.Entity<StatusIncidencia>(entity =>
            {
                entity.Property(e => e.Descripccion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.Property(e => e.Descripccion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoIncidencia>(entity =>
            {
                entity.Property(e => e.Descripccion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.Property(e => e.Descripccion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(e => e.Documento)
                    .HasName("UQ__Usuario__AF73706DD93AA1F9")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuario__A9D105342F2E7809")
                    .IsUnique();

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.HashPassword)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Barrio)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.BarrioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuario__BarrioI__33BFA6FF");

                entity.HasOne(d => d.TipoDocumento)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.TipoDocumentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuario__TipoDoc__34B3CB38");

                entity.HasOne(d => d.TipoUsuario)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.TipoUsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuario__TipoUsu__32CB82C6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
