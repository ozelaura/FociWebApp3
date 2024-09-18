﻿// <auto-generated />
using FociWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FociWebApp.Migrations
{
    [DbContext(typeof(FociDbContext))]
    [Migration("20240918085302_sqlite.local_migration_476")]
    partial class sqlitelocal_migration_476
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("FociWebApp.Models.Meccs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Fordulo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("HazaiCsapat")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("HazaiFelido")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HazaiVeg")
                        .HasColumnType("INTEGER");

                    b.Property<string>("VendegCsapat")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("VendegFelido")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VendegVeg")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Meccsek");
                });
#pragma warning restore 612, 618
        }
    }
}
