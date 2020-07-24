using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BackOfficeApp.Models;

namespace BackOfficeApp.DatabaseContext
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

        public virtual DbSet<Archivo> Archivo { get; set; }
        public virtual DbSet<Barrio> Barrio { get; set; }
        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<DistritoMunicipal> DistritoMunicipal { get; set; }
        public virtual DbSet<EntidadMunicipal> EntidadMunicipal { get; set; }
        public virtual DbSet<ExtensionArchivo> ExtensionArchivo { get; set; }
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
        public virtual DbSet<TipoArchivo> TipoArchivo { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumento { get; set; }
        public virtual DbSet<TipoIncidencia> TipoIncidencia { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-ANQ649B\\MSSQLSERVER01;Database=CooperaDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Archivo>(entity =>
            {
                entity.Property(e => e.FechaCreado)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Extension)
                    .WithMany(p => p.Archivo)
                    .HasForeignKey(d => d.ExtensionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Archivo__Extensi__4D94879B");

                entity.HasOne(d => d.Incidencia)
                    .WithMany(p => p.Archivo)
                    .HasForeignKey(d => d.IncidenciaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Archivo__Inciden__4E88ABD4");

                entity.HasOne(d => d.Tipo)
                    .WithMany(p => p.Archivo)
                    .HasForeignKey(d => d.TipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Archivo__TipoId__4F7CD00D");
            });

            modelBuilder.Entity<Barrio>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.Barrio)
                    .HasForeignKey(d => d.SectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Barrio__SectorId__31EC6D26");
            });

            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.Property(e => e.Descripccion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DistritoMunicipal>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Municipio)
                    .WithMany(p => p.DistritoMunicipal)
                    .HasForeignKey(d => d.MunicipioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DistritoM__Munic__29572725");
            });

            modelBuilder.Entity<EntidadMunicipal>(entity =>
            {
                entity.HasIndex(e => e.Documento)
                    .HasName("UQ__EntidadM__AF73706D1405F5E0")
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
                    .HasConstraintName("FK__EntidadMu__Cargo__6477ECF3");

                entity.HasOne(d => d.Municipio)
                    .WithMany(p => p.EntidadMunicipal)
                    .HasForeignKey(d => d.MunicipioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EntidadMu__Munic__66603565");

                entity.HasOne(d => d.TipoDocumento)
                    .WithMany(p => p.EntidadMunicipal)
                    .HasForeignKey(d => d.TipoDocumentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EntidadMu__TipoD__656C112C");
            });

            modelBuilder.Entity<ExtensionArchivo>(entity =>
            {
                entity.Property(e => e.Descripccion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Incidencia>(entity =>
            {
                entity.Property(e => e.Descripccion)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Barrio)
                    .WithMany(p => p.Incidencia)
                    .HasForeignKey(d => d.BarrioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Incidenci__Barri__4AB81AF0");

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.IncidenciaEmpleado)
                    .HasForeignKey(d => d.EmpleadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Incidenci__Emple__46E78A0C");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Incidencia)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Incidenci__Statu__48CFD27E");

                entity.HasOne(d => d.Tipo)
                    .WithMany(p => p.Incidencia)
                    .HasForeignKey(d => d.TipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Incidenci__TipoI__49C3F6B7");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.IncidenciaUsuario)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Incidenci__Usuar__47DBAE45");
            });

            modelBuilder.Entity<IncidenciaUsuario>(entity =>
            {
                entity.HasOne(d => d.Incidencia)
                    .WithMany(p => p.IncidenciaUsuario)
                    .HasForeignKey(d => d.IncidenciaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Incidenci__Incid__5441852A");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.IncidenciaUsuarioNavigation)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Incidenci__Usuar__534D60F1");
            });

            modelBuilder.Entity<IntegranteJdV>(entity =>
            {
                entity.HasKey(e => e.IntegranteId)
                    .HasName("PK__Integran__56C94B2794ADFA57");

                entity.HasIndex(e => e.UsuarioId)
                    .HasName("UQ__Integran__2B3DE7B9A0E17FDC")
                    .IsUnique();

                entity.HasOne(d => d.JuntaDeVecinos)
                    .WithMany(p => p.IntegranteJdV)
                    .HasForeignKey(d => d.JuntaDeVecinosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Integrant__Junta__5DCAEF64");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.IntegranteJdV)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Integrant__RolId__5EBF139D");

                entity.HasOne(d => d.Usuario)
                    .WithOne(p => p.IntegranteJdV)
                    .HasForeignKey<IntegranteJdV>(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Integrant__Usuar__5CD6CB2B");
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
                    .HasConstraintName("FK__JuntaDeVe__Barri__59063A47");
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Provincia)
                    .WithMany(p => p.Municipio)
                    .HasForeignKey(d => d.ProvinciaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Municipio__Provi__267ABA7A");
            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.Property(e => e.Descripccion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Seccion>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.DistritoMunicipal)
                    .WithMany(p => p.Seccion)
                    .HasForeignKey(d => d.DistritoMunicipalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Seccion__Distrit__2C3393D0");
            });

            modelBuilder.Entity<Sector>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Seccion)
                    .WithMany(p => p.Sector)
                    .HasForeignKey(d => d.SeccionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sector__SeccionI__2F10007B");
            });

            modelBuilder.Entity<StatusIncidencia>(entity =>
            {
                entity.Property(e => e.Descripccion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoArchivo>(entity =>
            {
                entity.Property(e => e.Descripccion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.Property(e => e.Descripccion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoIncidencia>(entity =>
            {
                entity.Property(e => e.Descripccion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.Property(e => e.Descripccion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(e => e.Documento)
                    .HasName("UQ__Usuario__AF73706D8687D3A8")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuario__A9D10534FF8AF5F9")
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
                    .HasConstraintName("FK__Usuario__BarrioI__3B75D760");

                entity.HasOne(d => d.TipoDocumento)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.TipoDocumentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuario__TipoDoc__3C69FB99");

                entity.HasOne(d => d.TipoUsuario)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.TipoUsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuario__TipoUsu__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
