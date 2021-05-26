using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Sistema_de_Registro_de_Estudiantes.Models
{
    public partial class RegistroEstudiantesContext : DbContext
    {
        public RegistroEstudiantesContext()
        {
        }

        public RegistroEstudiantesContext(DbContextOptions<RegistroEstudiantesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumnos { get; set; }
        public virtual DbSet<Localizacion> Localizacions { get; set; }
        public virtual DbSet<MisDocumento> MisDocumentos { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;Initial Catalog=SRE_BD;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.HasKey(e => e.Matricula)
                    .HasName("PK__ALUMNO__46A2F689436D64CC");

                entity.ToTable("ALUMNO");

                entity.HasIndex(e => e.Telefono, "UQ__ALUMNO__D6F16945FE19B0CC")
                    .IsUnique();

                entity.Property(e => e.Matricula)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("MATRICULA")
                    .IsFixedLength(true);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Amaterno)
                    .HasMaxLength(30)
                    .HasColumnName("AMATERNO");

                entity.Property(e => e.Apaterno)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("APATERNO");

                entity.Property(e => e.Carrera)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("CARRERA");

                entity.Property(e => e.Foto)
                    .HasColumnName("FOTO");

                entity.Property(e => e.Grupo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRUPO")
                    .IsFixedLength(true);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.Semestre).HasColumnName("SEMESTRE");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TELEFONO")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Localizacion>(entity =>
            {
                entity.HasKey(e => new { e.Matricula, e.IdLoc })
                    .HasName("PK__LOCALIZA__447915F14E4BA82F");

                entity.ToTable("LOCALIZACION");

                entity.Property(e => e.Matricula)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("MATRICULA")
                    .IsFixedLength(true);

                entity.Property(e => e.IdLoc).HasColumnName("ID_LOC");

                entity.Property(e => e.Calle)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("CALLE");

                entity.Property(e => e.CiudadOrigen)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("CIUDAD_ORIGEN");

                entity.Property(e => e.CodigoPostal)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CODIGO_POSTAL")
                    .IsFixedLength(true);

                entity.Property(e => e.Colonia)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("COLONIA");

                entity.Property(e => e.Localidad)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("LOCALIDAD");

                entity.HasOne(d => d.MatriculaNavigation)
                    .WithMany(p => p.Localizacions)
                    .HasForeignKey(d => d.Matricula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LOCALIZAC__MATRI__2C3393D0");
            });

            modelBuilder.Entity<MisDocumento>(entity =>
            {
                entity.HasKey(e => new { e.Matricula, e.IdDocs })
                    .HasName("PK__MIS_DOCU__83FE26C026434F67");

                entity.ToTable("MIS_DOCUMENTOS");

                entity.Property(e => e.Matricula)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("MATRICULA")
                    .IsFixedLength(true);

                entity.Property(e => e.IdDocs).HasColumnName("ID_DOCS");

                entity.Property(e => e.ActaNacimiento)
                    .IsRequired()
                    .HasColumnName("ACTA_NACIMIENTO");

                entity.Property(e => e.Curp)
                    .IsRequired()
                    .HasColumnName("CURP");

                entity.Property(e => e.Rfc)
                    .IsRequired()
                    .HasColumnName("RFC");

                entity.HasOne(d => d.MatriculaNavigation)
                    .WithMany(p => p.MisDocumentos)
                    .HasForeignKey(d => d.Matricula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MIS_DOCUM__MATRI__2F10007B");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TIPO_USU__85A05968EBFAFB0C");

                entity.ToTable("TIPO_USUARIO");

                entity.Property(e => e.IdTipoUsuario)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_TIPO_USUARIO");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("ESTADO");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__USUARIOS__91136B905C695911");

                entity.ToTable("USUARIOS");

                entity.HasIndex(e => e.Nomusuario, "UQ__USUARIOS__EC0C1624428FC520")
                    .IsUnique();

                entity.Property(e => e.IdUsuario)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_USUARIO");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("ESTADO");

                entity.Property(e => e.Nomusuario)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("NOMUSUARIO");

                entity.Property(e => e.Passusuario)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("PASSUSUARIO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
