﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ms.Context.SqlServer;

#nullable disable

namespace ms.Migrations
{
    [DbContext(typeof(DbVFmid))]
    [Migration("20221110232208_sv_pr1")]
    partial class sv_pr1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ms.Models.VFmid.md_busquedas", b =>
                {
                    b.Property<int?>("id_busqueda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("id_busqueda"), 1L, 1);

                    b.Property<string>("bloque")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("canal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ide_cliente")
                        .HasColumnType("int");

                    b.Property<string>("latitud")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("longitud")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("tipo_interes_Id")
                        .HasColumnType("int");

                    b.Property<string>("torre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("vendedorId")
                        .HasColumnType("int");

                    b.HasKey("id_busqueda");

                    b.ToTable("md_busquedas");
                });

            modelBuilder.Entity("ms.Models.VFmid.md_sv", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<string>("nro_doc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("md_sv");
                });

            modelBuilder.Entity("ms.Models.VFmid.md_turno_instalacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Departamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Distrito")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Provincia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tr_mañana")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tr_noche")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tr_tarde")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("md_turno_instalacion");
                });
#pragma warning restore 612, 618
        }
    }
}
