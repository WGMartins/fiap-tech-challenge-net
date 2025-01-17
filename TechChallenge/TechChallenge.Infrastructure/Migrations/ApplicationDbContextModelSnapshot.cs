﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TechChallenge.Infrastructure.Repositories;

#nullable disable

namespace TechChallenge.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TechChallenge.Domain.RegionalAggregate.Contato", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("AlteradoEm")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid>("RegionalId")
                        .HasColumnType("uuid");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.HasKey("Id");

                    b.HasIndex("RegionalId");

                    b.ToTable("Contato");
                });

            modelBuilder.Entity("TechChallenge.Domain.RegionalAggregate.Regional", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("AlteradoEm")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Ddd")
                        .HasColumnType("integer");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Regional");
                });

            modelBuilder.Entity("TechChallenge.Domain.RegionalAggregate.Contato", b =>
                {
                    b.HasOne("TechChallenge.Domain.RegionalAggregate.Regional", "Regional")
                        .WithMany()
                        .HasForeignKey("RegionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Regional");
                });
#pragma warning restore 612, 618
        }
    }
}
