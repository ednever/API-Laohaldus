﻿// <auto-generated />
using System;
using API_Laohaldus.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_Laohaldus.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API_Laohaldus.Models.Arve", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("KasutajaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Kuupaev")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("KasutajaId");

                    b.ToTable("Arved");
                });

            modelBuilder.Entity("API_Laohaldus.Models.Kasutaja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("E_post")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kasutajanimi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Parool")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kasutajad");
                });

            modelBuilder.Entity("API_Laohaldus.Models.Kategooria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nimetus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kategooriad");
                });

            modelBuilder.Entity("API_Laohaldus.Models.Tellimus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Kogus")
                        .HasColumnType("int");

                    b.Property<int?>("ToodeId")
                        .HasColumnType("int");

                    b.Property<int>("TooteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ToodeId");

                    b.ToTable("Tellimused");
                });

            modelBuilder.Entity("API_Laohaldus.Models.TellimusArves", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArveId")
                        .HasColumnType("int");

                    b.Property<int>("TellimusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArveId");

                    b.HasIndex("TellimusId");

                    b.ToTable("TellimusedArves");
                });

            modelBuilder.Entity("API_Laohaldus.Models.Toode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Hind")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("KategooriaId")
                        .HasColumnType("int");

                    b.Property<int>("Kogus")
                        .HasColumnType("int");

                    b.Property<string>("Nimetus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uhik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KategooriaId");

                    b.ToTable("Tooted");
                });

            modelBuilder.Entity("API_Laohaldus.Models.Arve", b =>
                {
                    b.HasOne("API_Laohaldus.Models.Kasutaja", null)
                        .WithMany("Arve")
                        .HasForeignKey("KasutajaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API_Laohaldus.Models.Tellimus", b =>
                {
                    b.HasOne("API_Laohaldus.Models.Toode", null)
                        .WithMany("Tellimus")
                        .HasForeignKey("ToodeId");
                });

            modelBuilder.Entity("API_Laohaldus.Models.TellimusArves", b =>
                {
                    b.HasOne("API_Laohaldus.Models.Arve", null)
                        .WithMany("TellimusArves")
                        .HasForeignKey("ArveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_Laohaldus.Models.Tellimus", null)
                        .WithMany("TellimusArves")
                        .HasForeignKey("TellimusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API_Laohaldus.Models.Toode", b =>
                {
                    b.HasOne("API_Laohaldus.Models.Kategooria", null)
                        .WithMany("Toode")
                        .HasForeignKey("KategooriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API_Laohaldus.Models.Arve", b =>
                {
                    b.Navigation("TellimusArves");
                });

            modelBuilder.Entity("API_Laohaldus.Models.Kasutaja", b =>
                {
                    b.Navigation("Arve");
                });

            modelBuilder.Entity("API_Laohaldus.Models.Kategooria", b =>
                {
                    b.Navigation("Toode");
                });

            modelBuilder.Entity("API_Laohaldus.Models.Tellimus", b =>
                {
                    b.Navigation("TellimusArves");
                });

            modelBuilder.Entity("API_Laohaldus.Models.Toode", b =>
                {
                    b.Navigation("Tellimus");
                });
#pragma warning restore 612, 618
        }
    }
}
