﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Demo.EfCore8;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Demo.Migrations
{
    [DbContext(typeof(TestContext))]
    [Migration("20231211161340_InitContext")]
    partial class InitContext
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Demo.EfCore8.Party", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ComplexProperty<Dictionary<string, object>>("BillingAddress", "Demo.EfCore8.Party.BillingAddress#Address", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("DeliveryAddress", "Demo.EfCore8.Party.DeliveryAddress#Address", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");
                        });

                    b.HasKey("Id");

                    b.ToTable("Parties");
                });
#pragma warning restore 612, 618
        }
    }
}
