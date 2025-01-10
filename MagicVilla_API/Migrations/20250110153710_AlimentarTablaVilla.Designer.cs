﻿// <auto-generated />
using System;
using MagicVilla_API.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicVilla_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250110153710_AlimentarTablaVilla")]
    partial class AlimentarTablaVilla
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MagicVilla_API.Modelos.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detalle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagenUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MetrosCuadrados")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Tarifa")
                        .HasColumnType("float");

                    b.Property<int>("ocupantes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Villas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenidad = "",
                            Detalle = "Detalle de la Villa...",
                            FechaActualizacion = new DateTime(2025, 1, 10, 10, 37, 9, 969, DateTimeKind.Local).AddTicks(2831),
                            FechaCreacion = new DateTime(2025, 1, 10, 10, 37, 9, 969, DateTimeKind.Local).AddTicks(2821),
                            ImagenUrl = "",
                            MetrosCuadrados = 50,
                            Nombre = "Vista Real",
                            Tarifa = 200.0,
                            ocupantes = 5
                        },
                        new
                        {
                            Id = 2,
                            Amenidad = "",
                            Detalle = "Detalle de la Villa...",
                            FechaActualizacion = new DateTime(2025, 1, 10, 10, 37, 9, 969, DateTimeKind.Local).AddTicks(2834),
                            FechaCreacion = new DateTime(2025, 1, 10, 10, 37, 9, 969, DateTimeKind.Local).AddTicks(2834),
                            ImagenUrl = "",
                            MetrosCuadrados = 40,
                            Nombre = "Vista a la Piscibna",
                            Tarifa = 150.0,
                            ocupantes = 4
                        });
                });
#pragma warning restore 612, 618
        }
    }
}