﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MonitoringAPI.Models;

#nullable disable

namespace MonitoringAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240410145029_inital")]
    partial class inital
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MonitoringAPI.Models.MonitoringData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Humidity")
                        .HasColumnType("real");

                    b.Property<float>("Rainfall")
                        .HasColumnType("real");

                    b.Property<Guid>("StationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Temperature")
                        .HasColumnType("real");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("StationId");

                    b.ToTable("MonitoringData");
                });

            modelBuilder.Entity("MonitoringAPI.Models.MonitoringStation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MonitoringStations");
                });

            modelBuilder.Entity("MonitoringAPI.Models.MonitoringData", b =>
                {
                    b.HasOne("MonitoringAPI.Models.MonitoringStation", "Station")
                        .WithMany("Data")
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Station");
                });

            modelBuilder.Entity("MonitoringAPI.Models.MonitoringStation", b =>
                {
                    b.Navigation("Data");
                });
#pragma warning restore 612, 618
        }
    }
}
