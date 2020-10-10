﻿// <auto-generated />
using System;
using AquaLog.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AquaLog.Migrations
{
    [DbContext(typeof(AquaLogDbContext))]
    [Migration("20201010170743_gaveMeasurementAnIdKey")]
    partial class gaveMeasurementAnIdKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AquaLog.Core.Aquarium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Freshwater")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Aquariums");
                });

            modelBuilder.Entity("AquaLog.Core.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("AquaLog.Core.Measurement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AquariumId")
                        .HasColumnType("int");

                    b.Property<int>("LogId")
                        .HasColumnType("int");

                    b.Property<int>("MeasurementKeyId")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AquariumId");

                    b.HasIndex("LogId");

                    b.HasIndex("MeasurementKeyId");

                    b.ToTable("Measurements");
                });

            modelBuilder.Entity("AquaLog.Core.MeasurementKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ApplicableToFreshwater")
                        .HasColumnType("bit");

                    b.Property<bool>("ApplicableToSaltwater")
                        .HasColumnType("bit");

                    b.Property<double>("HighRange")
                        .HasColumnType("float");

                    b.Property<double>("IdealLevel")
                        .HasColumnType("float");

                    b.Property<double>("LowRange")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("MeasurementKeys");
                });

            modelBuilder.Entity("AquaLog.Core.Measurement", b =>
                {
                    b.HasOne("AquaLog.Core.Aquarium", "Aquarium")
                        .WithMany("Measurement")
                        .HasForeignKey("AquariumId")
                        .HasConstraintName("FK_Measurement_Aquarium")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AquaLog.Core.Log", "Log")
                        .WithMany("Measurement")
                        .HasForeignKey("LogId")
                        .HasConstraintName("FK_Measurement_Log")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AquaLog.Core.MeasurementKey", "MeasurementKey")
                        .WithMany("Measurement")
                        .HasForeignKey("MeasurementKeyId")
                        .HasConstraintName("FK_Measurement_MeasurementKey")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
