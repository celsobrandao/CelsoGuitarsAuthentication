﻿// <auto-generated />
using System;
using CelsoGuitarsAuthentication.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CelsoGuitarsAuthentication.Repository.Migrations
{
    [DbContext(typeof(CelsoGuitarsAuthenticationContext))]
    [Migration("20220924070449_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CelsoGuitarsAuthentication.Domain.Usuario.Usuario", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("ID");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("CelsoGuitarsAuthentication.Domain.Usuario.Usuario", b =>
                {
                    b.OwnsOne("CelsoGuitarsAuthentication.Domain.Usuario.ValueObject.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UsuarioID")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Email");

                            b1.HasKey("UsuarioID");

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioID");
                        });

                    b.OwnsOne("CelsoGuitarsAuthentication.Domain.Usuario.ValueObject.Senha", "Senha", b1 =>
                        {
                            b1.Property<Guid>("UsuarioID")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("nvarchar(200)")
                                .HasColumnName("Senha");

                            b1.HasKey("UsuarioID");

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioID");
                        });

                    b.Navigation("Email");

                    b.Navigation("Senha");
                });
#pragma warning restore 612, 618
        }
    }
}
