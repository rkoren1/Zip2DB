﻿// <auto-generated />
using System;
using DownloadZIP.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Zip2DB.Migrations
{
    [DbContext(typeof(ZavezanciContext))]
    [Migration("20230807141432_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.20");

            modelBuilder.Entity("DownloadZIP.Data.ZavezanecEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DatumRegistracije")
                        .HasColumnType("TEXT");

                    b.Property<string>("Davcna")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FinancniUrad")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImeZavezanca")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Maticna")
                        .HasColumnType("TEXT");

                    b.Property<string>("Naslov")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SifraDejavnosti")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<char?>("Ureditev")
                        .HasColumnType("TEXT");

                    b.Property<char?>("ZavezanostZaDDV")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Zavezanci");
                });
#pragma warning restore 612, 618
        }
    }
}