﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sistema_de_Registro_de_Estudiantes.Models;

namespace Sistema_de_Registro_de_Estudiantes.Migrations
{
    [DbContext(typeof(RegistroEstudiantesContext))]
    partial class RegistroEstudiantesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sistema_de_Registro_de_Estudiantes.Models.Alumno", b =>
                {
                    b.Property<string>("Matricula")
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("char(8)")
                        .HasColumnName("MATRICULA")
                        .IsFixedLength(true);

                    b.Property<string>("Amaterno")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("AMATERNO");

                    b.Property<string>("Apaterno")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("APATERNO");

                    b.Property<string>("Carrera")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("CARRERA");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("FOTO");

                    b.Property<string>("Grupo")
                        .IsRequired()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .HasColumnName("GRUPO")
                        .IsFixedLength(true);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("NOMBRE");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("PASSWORD");

                    b.Property<int>("Semestre")
                        .HasColumnType("int")
                        .HasColumnName("SEMESTRE");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("char(10)")
                        .HasColumnName("TELEFONO")
                        .IsFixedLength(true);

                    b.HasKey("Matricula")
                        .HasName("PK__ALUMNO__46A2F689436D64CC");

                    b.HasIndex(new[] { "Telefono" }, "UQ__ALUMNO__D6F16945FE19B0CC")
                        .IsUnique();

                    b.ToTable("ALUMNO");
                });

            modelBuilder.Entity("Sistema_de_Registro_de_Estudiantes.Models.Localizacion", b =>
                {
                    b.Property<string>("Matricula")
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("char(8)")
                        .HasColumnName("MATRICULA")
                        .IsFixedLength(true);

                    b.Property<int>("IdLoc")
                        .HasColumnType("int")
                        .HasColumnName("ID_LOC");

                    b.Property<string>("Calle")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("CALLE");

                    b.Property<string>("CiudadOrigen")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("CIUDAD_ORIGEN");

                    b.Property<string>("CodigoPostal")
                        .IsRequired()
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("char(5)")
                        .HasColumnName("CODIGO_POSTAL")
                        .IsFixedLength(true);

                    b.Property<string>("Colonia")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("COLONIA");

                    b.Property<string>("Localidad")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("LOCALIDAD");

                    b.HasKey("Matricula", "IdLoc")
                        .HasName("PK__LOCALIZA__447915F14E4BA82F");

                    b.ToTable("LOCALIZACION");
                });

            modelBuilder.Entity("Sistema_de_Registro_de_Estudiantes.Models.MisDocumento", b =>
                {
                    b.Property<string>("Matricula")
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("char(8)")
                        .HasColumnName("MATRICULA")
                        .IsFixedLength(true);

                    b.Property<int>("IdDocs")
                        .HasColumnType("int")
                        .HasColumnName("ID_DOCS");

                    b.Property<byte[]>("ActaNacimiento")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("ACTA_NACIMIENTO");

                    b.Property<byte[]>("Curp")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("CURP");

                    b.Property<byte[]>("Rfc")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("RFC");

                    b.HasKey("Matricula", "IdDocs")
                        .HasName("PK__MIS_DOCU__83FE26C026434F67");

                    b.ToTable("MIS_DOCUMENTOS");
                });

            modelBuilder.Entity("Sistema_de_Registro_de_Estudiantes.Models.TipoUsuario", b =>
                {
                    b.Property<int>("IdTipoUsuario")
                        .HasColumnType("int")
                        .HasColumnName("ID_TIPO_USUARIO");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("DESCRIPCION");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)")
                        .HasColumnName("ESTADO");

                    b.HasKey("IdTipoUsuario")
                        .HasName("PK__TIPO_USU__85A05968EBFAFB0C");

                    b.ToTable("TIPO_USUARIO");
                });

            modelBuilder.Entity("Sistema_de_Registro_de_Estudiantes.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .HasColumnType("int")
                        .HasColumnName("ID_USUARIO");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)")
                        .HasColumnName("ESTADO");

                    b.Property<string>("Nomusuario")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("NOMUSUARIO");

                    b.Property<string>("Passusuario")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("PASSUSUARIO");

                    b.HasKey("IdUsuario")
                        .HasName("PK__USUARIOS__91136B905C695911");

                    b.HasIndex(new[] { "Nomusuario" }, "UQ__USUARIOS__EC0C1624428FC520")
                        .IsUnique();

                    b.ToTable("USUARIOS");
                });

            modelBuilder.Entity("Sistema_de_Registro_de_Estudiantes.Models.Localizacion", b =>
                {
                    b.HasOne("Sistema_de_Registro_de_Estudiantes.Models.Alumno", "MatriculaNavigation")
                        .WithMany("Localizacions")
                        .HasForeignKey("Matricula")
                        .HasConstraintName("FK__LOCALIZAC__MATRI__2C3393D0")
                        .IsRequired();

                    b.Navigation("MatriculaNavigation");
                });

            modelBuilder.Entity("Sistema_de_Registro_de_Estudiantes.Models.MisDocumento", b =>
                {
                    b.HasOne("Sistema_de_Registro_de_Estudiantes.Models.Alumno", "MatriculaNavigation")
                        .WithMany("MisDocumentos")
                        .HasForeignKey("Matricula")
                        .HasConstraintName("FK__MIS_DOCUM__MATRI__2F10007B")
                        .IsRequired();

                    b.Navigation("MatriculaNavigation");
                });

            modelBuilder.Entity("Sistema_de_Registro_de_Estudiantes.Models.Alumno", b =>
                {
                    b.Navigation("Localizacions");

                    b.Navigation("MisDocumentos");
                });
#pragma warning restore 612, 618
        }
    }
}
