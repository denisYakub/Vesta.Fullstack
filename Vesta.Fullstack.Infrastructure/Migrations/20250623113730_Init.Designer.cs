﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Vesta.Fullstack.Infrastructure.DbContexts;

#nullable disable

namespace Vesta.Fullstack.Infrastructure.Migrations
{
    [DbContext(typeof(PostgresDbContext))]
    [Migration("20250623113730_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Vesta.Fullstack.Domain.Entities.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("CargoCollectionDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("cargo_collection_date");

                    b.Property<float>("CargoWeightKilograms")
                        .HasColumnType("real")
                        .HasColumnName("cargo_weight_kilograms");

                    b.Property<string>("RecipientAddress")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("recipient_address");

                    b.Property<string>("RecipientCity")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("recipient_city");

                    b.Property<string>("SenderAddress")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("sender_address");

                    b.Property<string>("SenderCity")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("sender_city");

                    b.HasKey("Id");

                    b.ToTable("orders");
                });
#pragma warning restore 612, 618
        }
    }
}
