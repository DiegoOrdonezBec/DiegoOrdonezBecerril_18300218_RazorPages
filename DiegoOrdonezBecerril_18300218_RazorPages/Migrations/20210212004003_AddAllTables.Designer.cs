﻿// <auto-generated />
using DiegoOrdonezBecerril_18300218_RazorPages.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DiegoOrdonezBecerril_18300218_RazorPages.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210212004003_AddAllTables")]
    partial class AddAllTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DiegoOrdonezBecerril_18300218_RazorPages.Models.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("DiegoOrdonezBecerril_18300218_RazorPages.Models.Profesor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Profesor");
                });

            modelBuilder.Entity("DiegoOrdonezBecerril_18300218_RazorPages.Models.ProfesorToCurso", b =>
                {
                    b.Property<int>("ProfesorId")
                        .HasColumnType("int");

                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.HasKey("ProfesorId", "CursoId");

                    b.HasIndex("CursoId");

                    b.ToTable("ProfesorToCurso");
                });

            modelBuilder.Entity("DiegoOrdonezBecerril_18300218_RazorPages.Models.ProfesorToCurso", b =>
                {
                    b.HasOne("DiegoOrdonezBecerril_18300218_RazorPages.Models.Curso", "Curso")
                        .WithMany("ProfesorToCursos")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiegoOrdonezBecerril_18300218_RazorPages.Models.Profesor", "Profesor")
                        .WithMany("ProfesorToCursos")
                        .HasForeignKey("ProfesorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");

                    b.Navigation("Profesor");
                });

            modelBuilder.Entity("DiegoOrdonezBecerril_18300218_RazorPages.Models.Curso", b =>
                {
                    b.Navigation("ProfesorToCursos");
                });

            modelBuilder.Entity("DiegoOrdonezBecerril_18300218_RazorPages.Models.Profesor", b =>
                {
                    b.Navigation("ProfesorToCursos");
                });
#pragma warning restore 612, 618
        }
    }
}
