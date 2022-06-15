﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GuardaVolume.Migrations
{
    [DbContext(typeof(GuardaVolumeContext))]
    [Migration("20220615174756_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GuardaVolume.Models.Armario", b =>
                {
                    b.Property<int>("ArmarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("PontoX")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PontoY")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Regiao")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ArmarioId");

                    b.ToTable("Armario");
                });

            modelBuilder.Entity("GuardaVolume.Models.Compartimento", b =>
                {
                    b.Property<int>("CompartimentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ArmarioId")
                        .HasColumnType("int");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Tamanho")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Trancado")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("CompartimentoId");

                    b.HasIndex("ArmarioId");

                    b.ToTable("Compartimento");
                });

            modelBuilder.Entity("GuardaVolume.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("GuardaVolume.Models.Compartimento", b =>
                {
                    b.HasOne("GuardaVolume.Models.Armario", "Armario")
                        .WithMany("Compartimentos")
                        .HasForeignKey("ArmarioId");
                });
#pragma warning restore 612, 618
        }
    }
}