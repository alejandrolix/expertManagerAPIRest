﻿// <auto-generated />
using System;
using APIRest.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APIRest.Migrations
{
    [DbContext(typeof(ExpertManagerContext))]
    [Migration("20210926100350_CreadaClaseTipoArchivo")]
    partial class CreadaClaseTipoArchivo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APIRest.Models.Aseguradora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Aseguradoras");
                });

            modelBuilder.Entity("APIRest.Models.Danio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Danios");
                });

            modelBuilder.Entity("APIRest.Models.Documentacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SiniestroId")
                        .HasColumnType("int");

                    b.Property<string>("UrlArchivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SiniestroId");

                    b.ToTable("Documentaciones");
                });

            modelBuilder.Entity("APIRest.Models.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("APIRest.Models.Imagen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SiniestroId")
                        .HasColumnType("int");

                    b.Property<string>("UrlArchivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SiniestroId");

                    b.ToTable("Imagenes");
                });

            modelBuilder.Entity("APIRest.Models.Mensaje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SiniestroId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SiniestroId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Mensajes");
                });

            modelBuilder.Entity("APIRest.Models.Permiso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Permisos");
                });

            modelBuilder.Entity("APIRest.Models.Siniestro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AseguradoraId")
                        .HasColumnType("int");

                    b.Property<int?>("DanioId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaHoraAlta")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ImpValoracionDanios")
                        .HasColumnType("decimal(7,2)");

                    b.Property<int>("PeritoId")
                        .HasColumnType("int");

                    b.Property<int>("SujetoAfectado")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioCreadoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AseguradoraId");

                    b.HasIndex("DanioId");

                    b.HasIndex("EstadoId");

                    b.HasIndex("PeritoId");

                    b.HasIndex("UsuarioCreadoId");

                    b.ToTable("Siniestros");
                });

            modelBuilder.Entity("APIRest.Models.TipoArchivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TiposArchivo");
                });

            modelBuilder.Entity("APIRest.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contrasenia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ImpRepacionDanios")
                        .HasColumnType("decimal(5,2)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PermisoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PermisoId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("APIRest.Models.Documentacion", b =>
                {
                    b.HasOne("APIRest.Models.Siniestro", "Siniestro")
                        .WithMany("Documentaciones")
                        .HasForeignKey("SiniestroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Siniestro");
                });

            modelBuilder.Entity("APIRest.Models.Imagen", b =>
                {
                    b.HasOne("APIRest.Models.Siniestro", "Siniestro")
                        .WithMany()
                        .HasForeignKey("SiniestroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Siniestro");
                });

            modelBuilder.Entity("APIRest.Models.Mensaje", b =>
                {
                    b.HasOne("APIRest.Models.Siniestro", "Siniestro")
                        .WithMany()
                        .HasForeignKey("SiniestroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIRest.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Siniestro");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("APIRest.Models.Siniestro", b =>
                {
                    b.HasOne("APIRest.Models.Aseguradora", "Aseguradora")
                        .WithMany()
                        .HasForeignKey("AseguradoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIRest.Models.Danio", "Danio")
                        .WithMany()
                        .HasForeignKey("DanioId");

                    b.HasOne("APIRest.Models.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIRest.Models.Usuario", "Perito")
                        .WithMany()
                        .HasForeignKey("PeritoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIRest.Models.Usuario", "UsuarioCreado")
                        .WithMany()
                        .HasForeignKey("UsuarioCreadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aseguradora");

                    b.Navigation("Danio");

                    b.Navigation("Estado");

                    b.Navigation("Perito");

                    b.Navigation("UsuarioCreado");
                });

            modelBuilder.Entity("APIRest.Models.Usuario", b =>
                {
                    b.HasOne("APIRest.Models.Permiso", "Permiso")
                        .WithMany()
                        .HasForeignKey("PermisoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permiso");
                });

            modelBuilder.Entity("APIRest.Models.Siniestro", b =>
                {
                    b.Navigation("Documentaciones");
                });
#pragma warning restore 612, 618
        }
    }
}
