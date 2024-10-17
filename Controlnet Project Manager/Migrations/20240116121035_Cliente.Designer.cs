﻿// <auto-generated />
using System;
using Controlnet_Project_Manager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Controlnet_Project_Manager.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240116121035_Cliente")]
    partial class Cliente
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Controlnet_Project_Manager.Areas.Identity.Data.CheckinCheckout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<ulong>("Entrada")
                        .HasColumnType("BIT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdProyecto")
                        .HasColumnType("int");

                    b.Property<string>("IdUsuario")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("IdProyecto");

                    b.HasIndex("IdUsuario");

                    b.ToTable("CheckinCheckouts");
                });

            modelBuilder.Entity("Controlnet_Project_Manager.Areas.Identity.Data.Equipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Equipos");
                });

            modelBuilder.Entity("Controlnet_Project_Manager.Areas.Identity.Data.EquiposProyecto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdEquipo")
                        .HasColumnType("int");

                    b.Property<int>("IdProyecto")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdEquipo");

                    b.HasIndex("IdProyecto");

                    b.ToTable("EquiposProyectos");
                });

            modelBuilder.Entity("Controlnet_Project_Manager.Areas.Identity.Data.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("Controlnet_Project_Manager.Areas.Identity.Data.EstadoIncidencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<ulong>("CierraIncidencia")
                        .HasColumnType("BIT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("EstadosIncidencias");
                });

            modelBuilder.Entity("Controlnet_Project_Manager.Areas.Identity.Data.EstadoProyectoUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdEstado")
                        .HasColumnType("int");

                    b.Property<string>("IdUsuario")
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("isChecked")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("IdEstado");

                    b.HasIndex("IdUsuario");

                    b.ToTable("EstadoProyectoUsuarios");
                });

            modelBuilder.Entity("Controlnet_Project_Manager.Areas.Identity.Data.Incidencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaCerrada")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Informacion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("idEstadoIncidencia")
                        .HasColumnType("int");

                    b.Property<int>("idProyecto")
                        .HasColumnType("int");

                    b.Property<string>("idUsuarioAsignado")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("idEstadoIncidencia");

                    b.HasIndex("idProyecto");

                    b.HasIndex("idUsuarioAsignado");

                    b.ToTable("Incidencias");
                });

            modelBuilder.Entity("Controlnet_Project_Manager.Areas.Identity.Data.Menu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("enlace")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("esgrupo")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("grupotitulo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("icono")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("orden")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("Controlnet_Project_Manager.Areas.Identity.Data.MenuRol", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdMenu")
                        .HasColumnType("int");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<bool>("activo")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("esAdmin")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("ID");

                    b.HasIndex("IdMenu");

                    b.HasIndex("IdRol");

                    b.ToTable("MenuRoles");
                });

            modelBuilder.Entity("Controlnet_Project_Manager.Areas.Identity.Data.ProgramadoresEquipos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdEquipo")
                        .HasColumnType("int");

                    b.Property<string>("IdUsuario")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("IdEquipo");

                    b.HasIndex("IdUsuario");

                    b.ToTable("ProgramadoresEquipos");
                });

            modelBuilder.Entity("Controlnet_Project_Manager.Areas.Identity.Data.ProgramadoresProyecto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdProyecto")
                        .HasColumnType("int");

                    b.Property<string>("IdUsuario")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("IdProyecto");

                    b.HasIndex("IdUsuario");

                    b.ToTable("ProgramadoresProyectos");
                });

            modelBuilder.Entity("Controlnet_Project_Manager.Areas.Identity.Data.Proyecto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaPrevistaContrato")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaPrevistaEntrega")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("HorasEstimadas")
                        .HasColumnType("int");

                    b.Property<int>("IdEstado")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.HasIndex("IdEstado");

                    b.ToTable("Proyectos");
                });

            modelBuilder.Entity("Controlnet_Project_Manager.Areas.Identity.Data.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("longtext");

                    b.Property<int>("Orden")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("Controlnet_Project_Manager.Data.CPMUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<bool>("Activo")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("IdEquipo")
                        .HasColumnType("int");

                    b.Property<int?>("IdRol")
                        .HasColumnType("int");

                    b.Property<string>("IdSuperior")
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("IdEquipo");

                    b.HasIndex("IdRol");

                    b.HasIndex("IdSuperior");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Controlnet_Project_Manager.Areas.Identity.Data.CheckinCheckout", b =>
                {
                    b.HasOne("Controlnet_Project_Manager.Areas.Identity.Data.Proyecto", "Proyecto")
                        .WithMany()
                        .HasForeignKey("IdProyecto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Controlnet_Project_Manager.Data.CPMUser", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario");

                    b.Navigation("Proyecto");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Controlnet_Project_Manager.Areas.Identity.Data.EquiposProyecto", b =>
                {
                    b.HasOne("Controlnet_Project_Manager.Areas.Identity.Data.Equipo", "Equipo")
                        .WithMany("Equipos")
                        .HasForeignKey("IdEquipo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Controlnet_Project_Manager.Areas.Identity.Data.Proyecto", "Proyecto")
                        .WithMany("Equipos")
                        .HasForeignKey("IdProyecto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipo");

                    b.Navigation("Proyecto");
                });

            modelBuilder.Entity("Controlnet_Project_Manager.Areas.Identity.Data.EstadoProyectoUsuario", b =>
                {
                    b.HasOne("Controlnet_Project_Manager.Areas.Identity.Data.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Controlnet_Project_Manager.Data.CPMUser", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario");

                    b.Navigation("Estado");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Controlnet_Project_Manager.Areas.Identity.Data.Incidencia", b =>
                {
                    b.HasOne("Controlnet_Project_Manager.Areas.Identity.Data.EstadoIncidencia", "EstadoIncidencia")
                        .WithMany()
                        .HasForeignKey("idEstadoIncidencia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Controlnet_Project_Manager.Areas.Identity.Data.Proyecto", "Proyecto")
                        .WithMany()
                        .HasForeignKey("idProyecto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Controlnet_Project_Manager.Data.CPMUser", "UsuarioAsignado")
                        .WithMany()
                        .HasForeignKey("idUsuarioAsignado");

                    b.Navigation("EstadoIncidencia");

                    b.Navigation("Proyecto");

                    b.Navigation("UsuarioAsignado");
                });

            modelBuilder.Entity("Controlnet_Project_Manager.Areas.Identity.Data.MenuRol", b =>
                {
                    b.HasOne("Controlnet_Project_Manager.Areas.Identity.Data.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("IdMenu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Controlnet_Project_Manager.Areas.Identity.Data.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Controlnet_Project_Manager.Areas.Identity.Data.ProgramadoresEquipos", b =>
                {
                    b.HasOne("Controlnet_Project_Manager.Areas.Identity.Data.Equipo", "Equipo")
                        .WithMany("Programadores")
                        .HasForeignKey("IdEquipo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Controlnet_Project_Manager.Data.CPMUser", "Programador")
                        .WithMany("Programadores")
                        .HasForeignKey("IdUsuario");

                    b.Navigation("Equipo");

                    b.Navigation("Programador");
                });

            modelBuilder.Entity("Controlnet_Project_Manager.Areas.Identity.Data.ProgramadoresProyecto", b =>
                {
                    b.HasOne("Controlnet_Project_Manager.Areas.Identity.Data.Proyecto", "Proyecto")
                        .WithMany()
                        .HasForeignKey("IdProyecto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Controlnet_Project_Manager.Data.CPMUser", "Programador")
                        .WithMany()
                        .HasForeignKey("IdUsuario");

                    b.Navigation("Programador");

                    b.Navigation("Proyecto");
                });

            modelBuilder.Entity("Controlnet_Project_Manager.Areas.Identity.Data.Proyecto", b =>
                {
                    b.HasOne("Controlnet_Project_Manager.Areas.Identity.Data.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("Controlnet_Project_Manager.Data.CPMUser", b =>
                {
                    b.HasOne("Controlnet_Project_Manager.Areas.Identity.Data.Equipo", "Equipo")
                        .WithMany()
                        .HasForeignKey("IdEquipo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Controlnet_Project_Manager.Areas.Identity.Data.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("IdRol");

                    b.HasOne("Controlnet_Project_Manager.Data.CPMUser", "Superior")
                        .WithMany()
                        .HasForeignKey("IdSuperior");

                    b.Navigation("Equipo");

                    b.Navigation("Rol");

                    b.Navigation("Superior");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Controlnet_Project_Manager.Data.CPMUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Controlnet_Project_Manager.Data.CPMUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Controlnet_Project_Manager.Data.CPMUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Controlnet_Project_Manager.Data.CPMUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Controlnet_Project_Manager.Areas.Identity.Data.Equipo", b =>
                {
                    b.Navigation("Equipos");

                    b.Navigation("Programadores");
                });

            modelBuilder.Entity("Controlnet_Project_Manager.Areas.Identity.Data.Proyecto", b =>
                {
                    b.Navigation("Equipos");
                });

            modelBuilder.Entity("Controlnet_Project_Manager.Data.CPMUser", b =>
                {
                    b.Navigation("Programadores");
                });
#pragma warning restore 612, 618
        }
    }
}
