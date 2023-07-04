﻿// <auto-generated />
using System;
using Back_End_Challenge_20210221.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Back_End_Challenge_20210221.Migrations
{
    [DbContext(typeof(EfSqlServerAdapter))]
    partial class EfSqlServerAdapterModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Back_End_Challenge_20210221.Domain.Models.Agency", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ProgramId")
                        .HasColumnType("bigint");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProgramId");

                    b.ToTable("Agencies");
                });

            modelBuilder.Entity("Back_End_Challenge_20210221.Domain.Models.Configuration", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Family")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("LaunchLibraryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Variant")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Configurations");
                });

            modelBuilder.Entity("Back_End_Challenge_20210221.Domain.Models.Launch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Failreason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hashtag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Holdreason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Imported_T")
                        .HasColumnType("datetime2");

                    b.Property<string>("Infographic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Inhold")
                        .HasColumnType("bit");

                    b.Property<long?>("LaunchLibraryId")
                        .HasColumnType("bigint");

                    b.Property<long?>("LaunchServiceProviderId")
                        .HasColumnType("bigint");

                    b.Property<long?>("MissionId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Net")
                        .HasColumnType("datetime2");

                    b.Property<long?>("PadId")
                        .HasColumnType("bigint");

                    b.Property<long?>("Probability")
                        .HasColumnType("bigint");

                    b.Property<long?>("RocketId")
                        .HasColumnType("bigint");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<long?>("StatusLaunchId")
                        .HasColumnType("bigint");

                    b.Property<bool>("Tbddate")
                        .HasColumnType("bit");

                    b.Property<bool>("Tbdtime")
                        .HasColumnType("bit");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("WebcastLive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("WindowEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("WindowStart")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LaunchServiceProviderId");

                    b.HasIndex("MissionId");

                    b.HasIndex("PadId");

                    b.HasIndex("RocketId");

                    b.HasIndex("StatusLaunchId");

                    b.ToTable("Launchers");
                });

            modelBuilder.Entity("Back_End_Challenge_20210221.Domain.Models.LaunchServiceProvider", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LaunchServiceProviders");
                });

            modelBuilder.Entity("Back_End_Challenge_20210221.Domain.Models.Location", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MapImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TotalLandingCount")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalLaunchCount")
                        .HasColumnType("bigint");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Back_End_Challenge_20210221.Domain.Models.Mission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LaunchDesignator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("LaunchLibraryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("OrbitId")
                        .HasColumnType("bigint");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrbitId");

                    b.ToTable("Missions");
                });

            modelBuilder.Entity("Back_End_Challenge_20210221.Domain.Models.Orbit", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Abbrev")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Orbits");
                });

            modelBuilder.Entity("Back_End_Challenge_20210221.Domain.Models.Pad", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("AgencyId")
                        .HasColumnType("bigint");

                    b.Property<string>("InfoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Latitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("LocationId")
                        .HasColumnType("bigint");

                    b.Property<string>("Longitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MapImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MapUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("TotalLaunchCount")
                        .HasColumnType("bigint");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WikiUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Pads");
                });

            modelBuilder.Entity("Back_End_Challenge_20210221.Domain.Models.Program", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InfoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("LaunchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WikiUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LaunchId");

                    b.ToTable("Programs");
                });

            modelBuilder.Entity("Back_End_Challenge_20210221.Domain.Models.Rocket", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("ConfigurationId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ConfigurationId");

                    b.ToTable("Rockets");
                });

            modelBuilder.Entity("Back_End_Challenge_20210221.Domain.Models.Status", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Back_End_Challenge_20210221.Domain.Models.Agency", b =>
                {
                    b.HasOne("Back_End_Challenge_20210221.Domain.Models.Program", null)
                        .WithMany("Agencies")
                        .HasForeignKey("ProgramId");
                });

            modelBuilder.Entity("Back_End_Challenge_20210221.Domain.Models.Launch", b =>
                {
                    b.HasOne("Back_End_Challenge_20210221.Domain.Models.LaunchServiceProvider", "LaunchServiceProvider")
                        .WithMany()
                        .HasForeignKey("LaunchServiceProviderId");

                    b.HasOne("Back_End_Challenge_20210221.Domain.Models.Mission", "Mission")
                        .WithMany()
                        .HasForeignKey("MissionId");

                    b.HasOne("Back_End_Challenge_20210221.Domain.Models.Pad", "Pad")
                        .WithMany()
                        .HasForeignKey("PadId");

                    b.HasOne("Back_End_Challenge_20210221.Domain.Models.Rocket", "Rocket")
                        .WithMany()
                        .HasForeignKey("RocketId");

                    b.HasOne("Back_End_Challenge_20210221.Domain.Models.Status", "StatusLaunch")
                        .WithMany()
                        .HasForeignKey("StatusLaunchId");

                    b.Navigation("LaunchServiceProvider");

                    b.Navigation("Mission");

                    b.Navigation("Pad");

                    b.Navigation("Rocket");

                    b.Navigation("StatusLaunch");
                });

            modelBuilder.Entity("Back_End_Challenge_20210221.Domain.Models.Mission", b =>
                {
                    b.HasOne("Back_End_Challenge_20210221.Domain.Models.Orbit", "Orbit")
                        .WithMany()
                        .HasForeignKey("OrbitId");

                    b.Navigation("Orbit");
                });

            modelBuilder.Entity("Back_End_Challenge_20210221.Domain.Models.Pad", b =>
                {
                    b.HasOne("Back_End_Challenge_20210221.Domain.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Back_End_Challenge_20210221.Domain.Models.Program", b =>
                {
                    b.HasOne("Back_End_Challenge_20210221.Domain.Models.Launch", null)
                        .WithMany("Program")
                        .HasForeignKey("LaunchId");
                });

            modelBuilder.Entity("Back_End_Challenge_20210221.Domain.Models.Rocket", b =>
                {
                    b.HasOne("Back_End_Challenge_20210221.Domain.Models.Configuration", "Configuration")
                        .WithMany()
                        .HasForeignKey("ConfigurationId");

                    b.Navigation("Configuration");
                });

            modelBuilder.Entity("Back_End_Challenge_20210221.Domain.Models.Launch", b =>
                {
                    b.Navigation("Program");
                });

            modelBuilder.Entity("Back_End_Challenge_20210221.Domain.Models.Program", b =>
                {
                    b.Navigation("Agencies");
                });
#pragma warning restore 612, 618
        }
    }
}
