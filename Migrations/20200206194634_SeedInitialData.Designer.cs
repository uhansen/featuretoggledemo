﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using featuretoggledemo.Data;

namespace featuretoggledemo.Migrations
{
    [DbContext(typeof(featuretoggledemoContext))]
    [Migration("20200206194634_SeedInitialData")]
    partial class SeedInitialData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("featuretoggledemo.Models.Feature", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Enabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Features");

                    b.HasData(
                        new
                        {
                            Id = new Guid("42164028-e54d-4f1c-9558-5a38bd1a5e00"),
                            Enabled = false,
                            Name = "FeatureA"
                        },
                        new
                        {
                            Id = new Guid("b563353c-638c-4c25-a7e0-0ac85f1d8e6f"),
                            Enabled = false,
                            Name = "FeatureB"
                        },
                        new
                        {
                            Id = new Guid("dc9e3353-9f60-4d32-a3fc-9a77203fb66c"),
                            Enabled = false,
                            Name = "FeatureC"
                        },
                        new
                        {
                            Id = new Guid("9fa9658b-f8ab-4a54-9b22-f93b7f75a807"),
                            Enabled = false,
                            Name = "FeatureD"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
