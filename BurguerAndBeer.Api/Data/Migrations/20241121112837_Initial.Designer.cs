﻿// <auto-generated />
using System;
using BurguerAndBeer.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BurguerAndBeer.Api.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241121112837_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BurguerAndBeer.Api.Data.Entities.Burguer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("nvarchar(180)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Burguer");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Hamburguesa con carne de res, queso cheddar, lechuga, tomate y aderezo especial.",
                            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer1.png?raw=true",
                            Name = "Clásica Suprema",
                            Price = 5.9900000000000002
                        },
                        new
                        {
                            Id = 2,
                            Description = "Carne ahumada con salsa BBQ, cebolla crujiente y queso gouda.",
                            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer2.png?raw=true",
                            Name = "BBQ Texana",
                            Price = 6.9900000000000002
                        },
                        new
                        {
                            Id = 3,
                            Description = "Cargada de queso cheddar, bacon crujiente y mayonesa especial.",
                            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer3.png?raw=true",
                            Name = "Cheddar Bacon Deluxe",
                            Price = 7.4900000000000002
                        },
                        new
                        {
                            Id = 4,
                            Description = "Carne con queso suizo, piña caramelizada y salsa teriyaki.",
                            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer4.png?raw=true",
                            Name = "Hawaiana Tropical",
                            Price = 6.4900000000000002
                        },
                        new
                        {
                            Id = 5,
                            Description = "Con jalapeños, salsa picante, queso pepper jack y cebolla.",
                            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer5.png?raw=true",
                            Name = "Picante Infernal",
                            Price = 6.9900000000000002
                        },
                        new
                        {
                            Id = 6,
                            Description = "Doble carne aplastada, queso cheddar y salsa especial.",
                            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer6.png?raw=true",
                            Name = "Doble Smashburger",
                            Price = 7.9900000000000002
                        },
                        new
                        {
                            Id = 7,
                            Description = "Hamburguesa vegetariana con vegetales frescos y hummus.",
                            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer7.png?raw=true",
                            Name = "Veggie Lovers",
                            Price = 5.4900000000000002
                        },
                        new
                        {
                            Id = 8,
                            Description = "Seta portobello a la parrilla, queso suizo y mayonesa de ajo.",
                            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer8.png?raw=true",
                            Name = "Portobello Melt",
                            Price = 6.9900000000000002
                        },
                        new
                        {
                            Id = 9,
                            Description = "Carne de res con aceite de trufa, queso brie y rúcula.",
                            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer9.png?raw=true",
                            Name = "Trufa Gourmet",
                            Price = 8.9900000000000002
                        });
                });

            modelBuilder.Entity("BurguerAndBeer.Api.Data.Entities.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("OrderAt")
                        .HasColumnType("datetime2");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<string>("UserAddress")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("BurguerAndBeer.Api.Data.Entities.OrderItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("BurguerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("BurguerAndBeer.Api.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("nvarchar(180)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BurguerAndBeer.Api.Data.Entities.OrderItem", b =>
                {
                    b.HasOne("BurguerAndBeer.Api.Data.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("BurguerAndBeer.Api.Data.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
