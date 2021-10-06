﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UCR.App.Persistencia;

namespace UCR.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("UCR.App.Dominio.Persona", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Restauranteid")
                        .HasColumnType("int");

                    b.Property<string>("appellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("edad")
                        .HasColumnType("int");

                    b.Property<bool>("estadoCovid")
                        .HasColumnType("bit");

                    b.Property<int>("identificacion")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Restauranteid");

                    b.ToTable("Personas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("UCR.App.Dominio.Restaurante", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("aforo")
                        .HasColumnType("int");

                    b.Property<int>("numeroMesas")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Restaurante");
                });

            modelBuilder.Entity("UCR.App.Dominio.Turno", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Horario")
                        .HasColumnType("datetime2");

                    b.Property<string>("Menu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonaId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("PersonaId")
                        .IsUnique();

                    b.ToTable("Turnos");
                });

            modelBuilder.Entity("UCR.App.Dominio.Administrativo", b =>
                {
                    b.HasBaseType("UCR.App.Dominio.Persona");

                    b.Property<string>("dependencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("oficina")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Administrativo");
                });

            modelBuilder.Entity("UCR.App.Dominio.Docente", b =>
                {
                    b.HasBaseType("UCR.App.Dominio.Persona");

                    b.Property<string>("cubiculo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("facultad")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Docente");
                });

            modelBuilder.Entity("UCR.App.Dominio.Estudiante", b =>
                {
                    b.HasBaseType("UCR.App.Dominio.Persona");

                    b.Property<string>("programa")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Estudiante");
                });

            modelBuilder.Entity("UCR.App.Dominio.PersonalAseo", b =>
                {
                    b.HasBaseType("UCR.App.Dominio.Persona");

                    b.Property<int>("TurnoTrabajo")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("PersonalAseo");
                });

            modelBuilder.Entity("UCR.App.Dominio.PersonalCocina", b =>
                {
                    b.HasBaseType("UCR.App.Dominio.Persona");

                    b.Property<int>("TurnoTrabajo")
                        .HasColumnType("int")
                        .HasColumnName("PersonalCocina_TurnoTrabajo");

                    b.HasDiscriminator().HasValue("PersonalCocina");
                });

            modelBuilder.Entity("UCR.App.Dominio.Persona", b =>
                {
                    b.HasOne("UCR.App.Dominio.Restaurante", null)
                        .WithMany("comensales")
                        .HasForeignKey("Restauranteid");
                });

            modelBuilder.Entity("UCR.App.Dominio.Turno", b =>
                {
                    b.HasOne("UCR.App.Dominio.Persona", "Persona")
                        .WithOne("turno")
                        .HasForeignKey("UCR.App.Dominio.Turno", "PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("UCR.App.Dominio.Persona", b =>
                {
                    b.Navigation("turno");
                });

            modelBuilder.Entity("UCR.App.Dominio.Restaurante", b =>
                {
                    b.Navigation("comensales");
                });
#pragma warning restore 612, 618
        }
    }
}
