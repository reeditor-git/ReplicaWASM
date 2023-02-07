﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Replica.Domain;

#nullable disable

namespace Replica.Domain.Migrations
{
    [DbContext(typeof(ReplicaDbContext))]
    [Migration("20230207164103_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PlaceTag", b =>
                {
                    b.Property<Guid>("PlacesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TagsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PlacesId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("PlaceTag");
                });

            modelBuilder.Entity("ProductTag", b =>
                {
                    b.Property<Guid>("ProductsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TagsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProductsId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("ProductTag");
                });

            modelBuilder.Entity("Replica.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Font")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasDefaultValue("Calibri");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b718f35c-6fa7-420b-9acf-82ece06faab9"),
                            Description = "Страви які пропонує заклад, для своїх відвідувачів.",
                            Name = "Страви"
                        },
                        new
                        {
                            Id = new Guid("1f993aaa-9252-4a42-bf4f-b565452dfee7"),
                            Description = "Напої які пропонує заклад, для своїх відвідувачів.",
                            Name = "Напої"
                        },
                        new
                        {
                            Id = new Guid("3d1f906e-3577-42a2-a1f7-e0b07b209075"),
                            Description = "Компоненти які потрібно обрати, для замовлення кальяну.",
                            Name = "Кальяни"
                        },
                        new
                        {
                            Id = new Guid("dbbe08ce-05f3-48a4-b9fa-472b09a19cfc"),
                            Description = "Електронні цигарки, та все необхідне комплектуюче до них.",
                            Name = "VapeCraft"
                        },
                        new
                        {
                            Id = new Guid("64306256-7c3f-4de5-a4e1-cda66d426a99"),
                            Description = "Пивні напої які пропонує заклад, для своїх відвідувачів.",
                            Name = "BeerLaboratory"
                        });
                });

            modelBuilder.Entity("Replica.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ConfirmationStatus")
                        .HasColumnType("int");

                    b.Property<int>("PaymentStatus")
                        .HasColumnType("int");

                    b.Property<Guid>("ReservationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(6,2)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.HasIndex("UserID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Replica.Domain.Entities.Place", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Available")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("*/Image/User/default-place-image.jpg");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<decimal>("RentPrice")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(6,2)")
                        .HasDefaultValue(0m);

                    b.Property<int>("SeatingCapacity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(2);

                    b.HasKey("Id");

                    b.ToTable("Places");

                    b.HasData(
                        new
                        {
                            Id = new Guid("36fc6293-a31f-4240-84fd-8d5676fe1e0e"),
                            Available = 1,
                            Description = "",
                            ImageUrl = "*/Image/User/default-place-image.jpg",
                            Name = "Стіл 1",
                            RentPrice = 0m,
                            SeatingCapacity = 2
                        },
                        new
                        {
                            Id = new Guid("54c0cfd9-3980-4ba1-9a05-3f6fa59795df"),
                            Available = 1,
                            Description = "",
                            ImageUrl = "*/Image/User/default-place-image.jpg",
                            Name = "Ігрова зона з PS5",
                            RentPrice = 400m,
                            SeatingCapacity = 6
                        },
                        new
                        {
                            Id = new Guid("5cd5f0e3-454c-43ca-b7c9-cb1027ae2d62"),
                            Available = 1,
                            Description = "",
                            ImageUrl = "*/Image/User/default-place-image.jpg",
                            Name = "Ігрова зона з XBox",
                            RentPrice = 300m,
                            SeatingCapacity = 4
                        },
                        new
                        {
                            Id = new Guid("79e279ea-e19d-4179-ac13-a9ca421cf56b"),
                            Available = 1,
                            Description = "",
                            ImageUrl = "*/Image/User/default-place-image.jpg",
                            Name = "Стіл 2",
                            RentPrice = 0m,
                            SeatingCapacity = 4
                        },
                        new
                        {
                            Id = new Guid("e2602a5d-6d7f-4b3f-bbf9-e2910208d94f"),
                            Available = 1,
                            Description = "",
                            ImageUrl = "*/Image/User/default-place-image.jpg",
                            Name = "Стіл 3",
                            RentPrice = 0m,
                            SeatingCapacity = 4
                        });
                });

            modelBuilder.Entity("Replica.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("*/Image/User/default-product-image.jpg");

                    b.Property<int>("MeasurementUnits")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(6,2)")
                        .HasDefaultValue(0m);

                    b.Property<double>("Size")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<Guid>("SubcategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("SubcategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e2301e5a-57b0-494a-8bfb-1b4fa3cff0ce"),
                            Description = "",
                            ImageUrl = "*/Image/User/default-product-image.jpg",
                            MeasurementUnits = 3,
                            Name = "Сирний крем-суп",
                            Price = 75m,
                            Size = 300.0,
                            SubcategoryId = new Guid("1ba18109-3b28-4183-894b-6f7741a4074b")
                        },
                        new
                        {
                            Id = new Guid("aa1d3022-d05e-4e2a-b48d-27c1c40f7de1"),
                            Description = "",
                            ImageUrl = "*/Image/User/default-product-image.jpg",
                            MeasurementUnits = 3,
                            Name = "Борщ з телятиною",
                            Price = 87m,
                            Size = 350.0,
                            SubcategoryId = new Guid("1ba18109-3b28-4183-894b-6f7741a4074b")
                        },
                        new
                        {
                            Id = new Guid("21d0c8c8-4ccd-48cd-8279-db933cf199c9"),
                            Description = "",
                            ImageUrl = "*/Image/User/default-product-image.jpg",
                            MeasurementUnits = 3,
                            Name = "Пельмені домашні",
                            Price = 75m,
                            Size = 220.0,
                            SubcategoryId = new Guid("afa905f9-8739-47db-8916-d728d47f8ea2")
                        },
                        new
                        {
                            Id = new Guid("8f4d8fe0-70d5-40a7-9a4c-0e8e9531a0b3"),
                            Description = "",
                            ImageUrl = "*/Image/User/default-product-image.jpg",
                            MeasurementUnits = 3,
                            Name = "Кабачкові рулети з вершковим сиром",
                            Price = 83m,
                            Size = 180.0,
                            SubcategoryId = new Guid("afa905f9-8739-47db-8916-d728d47f8ea2")
                        });
                });

            modelBuilder.Entity("Replica.Domain.Entities.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RefToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Replica.Domain.Entities.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlaceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ReservationTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Replica.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6fa17fba-626d-481c-81cd-bbda29109fab"),
                            Description = "Основний користувач системи, з усіма правами доступу.",
                            Name = "admin"
                        },
                        new
                        {
                            Id = new Guid("2bb5984d-3ff9-49c3-9e54-5dcff385fb98"),
                            Description = "Управлінський персонал лаунж-бару.",
                            Name = "manager"
                        },
                        new
                        {
                            Id = new Guid("0ba5721c-bf18-47f9-be9d-f0f1eb69434a"),
                            Description = "Відповідальний за бар.",
                            Name = "barman"
                        },
                        new
                        {
                            Id = new Guid("2f9d9d3f-a8f3-4916-a904-5d325bac45ec"),
                            Description = "Відповідає за підготовку кальянних замовлень.",
                            Name = "hookah-waiter"
                        },
                        new
                        {
                            Id = new Guid("e4821f82-1182-4bf1-a74a-d390d2c040d6"),
                            Description = "Персонал, який формує замовлення та подає страви відвідувачам.",
                            Name = "waiter"
                        },
                        new
                        {
                            Id = new Guid("1057c418-d34a-46ea-9e7b-b1dffd462a05"),
                            Description = "Звичайний користувач системи, клієнт.",
                            Name = "user"
                        });
                });

            modelBuilder.Entity("Replica.Domain.Entities.Subcategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Subcategories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1ba18109-3b28-4183-894b-6f7741a4074b"),
                            CategoryId = new Guid("b718f35c-6fa7-420b-9acf-82ece06faab9"),
                            Description = "",
                            Name = "Перші страви"
                        },
                        new
                        {
                            Id = new Guid("ec23f360-be45-4eec-bb8a-b7c34e0d1c48"),
                            CategoryId = new Guid("b718f35c-6fa7-420b-9acf-82ece06faab9"),
                            Description = "",
                            Name = "Гарніри"
                        },
                        new
                        {
                            Id = new Guid("afa905f9-8739-47db-8916-d728d47f8ea2"),
                            CategoryId = new Guid("b718f35c-6fa7-420b-9acf-82ece06faab9"),
                            Description = "",
                            Name = "Закуски"
                        },
                        new
                        {
                            Id = new Guid("8487b289-fc03-4bee-9fdd-2ec43be3c1c2"),
                            CategoryId = new Guid("b718f35c-6fa7-420b-9acf-82ece06faab9"),
                            Description = "",
                            Name = "Салати"
                        },
                        new
                        {
                            Id = new Guid("db7f2067-9a18-4cc3-b76c-8b4e877b1b3f"),
                            CategoryId = new Guid("b718f35c-6fa7-420b-9acf-82ece06faab9"),
                            Description = "",
                            Name = "М'ясо та риба"
                        },
                        new
                        {
                            Id = new Guid("47429c78-1bd8-4da7-9c7b-f6a9a03624df"),
                            CategoryId = new Guid("b718f35c-6fa7-420b-9acf-82ece06faab9"),
                            Description = "",
                            Name = "Хліб"
                        },
                        new
                        {
                            Id = new Guid("561be8a7-dac0-4db4-b469-7496adec4fee"),
                            CategoryId = new Guid("b718f35c-6fa7-420b-9acf-82ece06faab9"),
                            Description = "",
                            Name = "Соуси"
                        },
                        new
                        {
                            Id = new Guid("ce0cd619-dad3-4121-baff-108183b5ab3e"),
                            CategoryId = new Guid("b718f35c-6fa7-420b-9acf-82ece06faab9"),
                            Description = "",
                            Name = "Десерти"
                        },
                        new
                        {
                            Id = new Guid("12a9a6f2-544c-406f-a7e3-1f2dd87c8ed5"),
                            CategoryId = new Guid("1f993aaa-9252-4a42-bf4f-b565452dfee7"),
                            Description = "",
                            Name = "Алкогольні"
                        },
                        new
                        {
                            Id = new Guid("1fd0e67d-72ce-4a4b-9d03-f1c2e8d95521"),
                            CategoryId = new Guid("1f993aaa-9252-4a42-bf4f-b565452dfee7"),
                            Description = "",
                            Name = "Безалкогольні"
                        },
                        new
                        {
                            Id = new Guid("c02cba8e-30a1-474b-88e3-19aa9adfc148"),
                            CategoryId = new Guid("3d1f906e-3577-42a2-a1f7-e0b07b209075"),
                            Description = "",
                            Name = "Табак"
                        },
                        new
                        {
                            Id = new Guid("d5de634f-842a-4f3c-a466-47b52d2ae4b2"),
                            CategoryId = new Guid("3d1f906e-3577-42a2-a1f7-e0b07b209075"),
                            Description = "",
                            Name = "Чаша"
                        },
                        new
                        {
                            Id = new Guid("a9fba436-d2f9-408c-af66-d1a381c586d7"),
                            CategoryId = new Guid("3d1f906e-3577-42a2-a1f7-e0b07b209075"),
                            Description = "",
                            Name = "Рідина"
                        },
                        new
                        {
                            Id = new Guid("421c0c78-dee2-4019-8ae9-9eed15927889"),
                            CategoryId = new Guid("dbbe08ce-05f3-48a4-b9fa-472b09a19cfc"),
                            Description = "",
                            Name = "Одноразки"
                        },
                        new
                        {
                            Id = new Guid("d67280c0-9c92-449d-8088-cb491b2f4c67"),
                            CategoryId = new Guid("dbbe08ce-05f3-48a4-b9fa-472b09a19cfc"),
                            Description = "",
                            Name = "Девайси"
                        },
                        new
                        {
                            Id = new Guid("97935587-4c28-479c-8d74-4e36327f1a04"),
                            CategoryId = new Guid("dbbe08ce-05f3-48a4-b9fa-472b09a19cfc"),
                            Description = "",
                            Name = "Рідини"
                        },
                        new
                        {
                            Id = new Guid("82a10754-1207-45f7-bfeb-bf8ad7ac9a99"),
                            CategoryId = new Guid("dbbe08ce-05f3-48a4-b9fa-472b09a19cfc"),
                            Description = "",
                            Name = "Комплектуючі"
                        },
                        new
                        {
                            Id = new Guid("473e6b98-2487-4c5f-87c8-a0cee39cd518"),
                            CategoryId = new Guid("64306256-7c3f-4de5-a4e1-cda66d426a99"),
                            Description = "",
                            Name = "Пиво"
                        },
                        new
                        {
                            Id = new Guid("8cd585a2-5bc9-460c-b0d2-0bf2216969d4"),
                            CategoryId = new Guid("64306256-7c3f-4de5-a4e1-cda66d426a99"),
                            Description = "",
                            Name = "Ель"
                        },
                        new
                        {
                            Id = new Guid("f951e75b-a3e0-4866-bf8e-f341478b2fe7"),
                            CategoryId = new Guid("64306256-7c3f-4de5-a4e1-cda66d426a99"),
                            Description = "",
                            Name = "До пива"
                        });
                });

            modelBuilder.Entity("Replica.Domain.Entities.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2ac51f75-6248-4c4f-898d-19d32e23ff26"),
                            Name = "Сир"
                        },
                        new
                        {
                            Id = new Guid("feaab256-c7db-4cf0-95e9-6cc764da4f60"),
                            Name = "Курятина"
                        },
                        new
                        {
                            Id = new Guid("9df3190c-9ce0-479e-89a8-9b5b0ad9fa01"),
                            Name = "Телятина"
                        },
                        new
                        {
                            Id = new Guid("ea0b7d5f-1a08-49bd-a229-c3e60bc45d3c"),
                            Name = "Борщ"
                        },
                        new
                        {
                            Id = new Guid("9b3021be-d034-45b6-a206-7c2c241e983e"),
                            Name = "Кабачки"
                        },
                        new
                        {
                            Id = new Guid("d83fbb8c-adbe-47e0-b96d-574a8da5f35f"),
                            Name = "Домашнє"
                        },
                        new
                        {
                            Id = new Guid("96a405fe-8b33-4396-bf4e-c38fb888aef6"),
                            Name = "М'ясо"
                        },
                        new
                        {
                            Id = new Guid("e312485e-9217-4cd7-9e3f-8c3d47d44a0c"),
                            Name = "Катопля"
                        },
                        new
                        {
                            Id = new Guid("cfc264d7-4da6-433a-a6d0-fd7d86f88029"),
                            Name = "Вершки"
                        });
                });

            modelBuilder.Entity("Replica.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Birthday")
                        .HasMaxLength(24)
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("*/Image/User/default-user-image.jpg");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d4e6d597-950b-4d87-b568-9ce087f3c79f"),
                            Birthday = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@gmail.com",
                            FirstName = "Admin",
                            ImageUrl = "*/Image/User/default-user-image.jpg",
                            LastName = "Replica",
                            Nickname = "admin",
                            Password = "admin",
                            Phone = "0975440309",
                            RoleId = new Guid("6fa17fba-626d-481c-81cd-bbda29109fab")
                        },
                        new
                        {
                            Id = new Guid("9bbeffef-5cce-40b8-8a40-6dfa637d4800"),
                            Birthday = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "manager@gmail.com",
                            FirstName = "Manager",
                            ImageUrl = "*/Image/User/default-user-image.jpg",
                            LastName = "Replica",
                            Nickname = "manager",
                            Password = "manager",
                            Phone = "0975440308",
                            RoleId = new Guid("2bb5984d-3ff9-49c3-9e54-5dcff385fb98")
                        },
                        new
                        {
                            Id = new Guid("21f8588e-9af3-4173-9f26-70caf34fa9b7"),
                            Birthday = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "barman@gmail.com",
                            FirstName = "Barman",
                            ImageUrl = "*/Image/User/default-user-image.jpg",
                            LastName = "Replica",
                            Nickname = "barman",
                            Password = "barman",
                            Phone = "0975440307",
                            RoleId = new Guid("0ba5721c-bf18-47f9-be9d-f0f1eb69434a")
                        },
                        new
                        {
                            Id = new Guid("3020649d-4974-4331-973b-6d29a02aebb1"),
                            Birthday = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "hookah.waiter@gmail.com",
                            FirstName = "Hookah waiter",
                            ImageUrl = "*/Image/User/default-user-image.jpg",
                            LastName = "Replica",
                            Nickname = "hookah.waiter",
                            Password = "hookah.waiter",
                            Phone = "0975440306",
                            RoleId = new Guid("2f9d9d3f-a8f3-4916-a904-5d325bac45ec")
                        },
                        new
                        {
                            Id = new Guid("f98ee4a4-5378-43a3-9dfc-83d2d46ed2a1"),
                            Birthday = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "waiter@gmail.com",
                            FirstName = "Waiter",
                            ImageUrl = "*/Image/User/default-user-image.jpg",
                            LastName = "Replica",
                            Nickname = "waiter",
                            Password = "waiter",
                            Phone = "0975440305",
                            RoleId = new Guid("e4821f82-1182-4bf1-a74a-d390d2c040d6")
                        },
                        new
                        {
                            Id = new Guid("6d6e8bd8-9fbc-48f9-8e4d-09bfb943f6a6"),
                            Birthday = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "user1@gmail.com",
                            FirstName = "User1",
                            ImageUrl = "*/Image/User/default-user-image.jpg",
                            LastName = "Replica",
                            Nickname = "user1",
                            Password = "user1",
                            Phone = "0975440304",
                            RoleId = new Guid("1057c418-d34a-46ea-9e7b-b1dffd462a05")
                        },
                        new
                        {
                            Id = new Guid("454de094-4b12-4f93-9cf1-1c3312133dbc"),
                            Birthday = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "user2@gmail.com",
                            FirstName = "User2",
                            ImageUrl = "*/Image/User/default-user-image.jpg",
                            LastName = "Replica",
                            Nickname = "user2",
                            Password = "user2",
                            Phone = "0975440303",
                            RoleId = new Guid("1057c418-d34a-46ea-9e7b-b1dffd462a05")
                        });
                });

            modelBuilder.Entity("PlaceTag", b =>
                {
                    b.HasOne("Replica.Domain.Entities.Place", null)
                        .WithMany()
                        .HasForeignKey("PlacesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Replica.Domain.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductTag", b =>
                {
                    b.HasOne("Replica.Domain.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Replica.Domain.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Replica.Domain.Entities.Order", b =>
                {
                    b.HasOne("Replica.Domain.Entities.Reservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Replica.Domain.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Replica.Domain.Entities.Product", b =>
                {
                    b.HasOne("Replica.Domain.Entities.Order", null)
                        .WithMany("Products")
                        .HasForeignKey("OrderId");

                    b.HasOne("Replica.Domain.Entities.Subcategory", "Subcategory")
                        .WithMany("Products")
                        .HasForeignKey("SubcategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subcategory");
                });

            modelBuilder.Entity("Replica.Domain.Entities.RefreshToken", b =>
                {
                    b.HasOne("Replica.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Replica.Domain.Entities.Reservation", b =>
                {
                    b.HasOne("Replica.Domain.Entities.Place", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Place");
                });

            modelBuilder.Entity("Replica.Domain.Entities.Subcategory", b =>
                {
                    b.HasOne("Replica.Domain.Entities.Category", "Category")
                        .WithMany("Subcategorys")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Replica.Domain.Entities.User", b =>
                {
                    b.HasOne("Replica.Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Replica.Domain.Entities.Category", b =>
                {
                    b.Navigation("Subcategorys");
                });

            modelBuilder.Entity("Replica.Domain.Entities.Order", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Replica.Domain.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Replica.Domain.Entities.Subcategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Replica.Domain.Entities.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
