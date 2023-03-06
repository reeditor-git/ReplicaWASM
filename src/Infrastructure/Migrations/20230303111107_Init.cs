using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Replica.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Font = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false, defaultValue: "Calibri")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "*/Image/User/default-place-image.jpg"),
                    SeatingCapacity = table.Column<int>(type: "int", nullable: false, defaultValue: 2),
                    RentPrice = table.Column<decimal>(type: "decimal(6,2)", nullable: false, defaultValue: 0m),
                    Available = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subcategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subcategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "*/Image/User/default-user-image.jpg"),
                    Phone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", maxLength: 24, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Blocked = table.Column<bool>(type: "bit", nullable: false),
                    BlockingReason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaceTags",
                columns: table => new
                {
                    PlaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceTags", x => new { x.PlaceId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PlaceTags_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaceTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalCost = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    ConfirmationStatus = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "*/Image/User/default-product-image.jpg"),
                    Size = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    MeasurementUnits = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Price = table.Column<decimal>(type: "decimal(6,2)", nullable: false, defaultValue: 0m),
                    SubcategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Subcategories_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalTable: "Subcategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTags",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTags", x => new { x.ProductId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ProductTags_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("1f993aaa-9252-4a42-bf4f-b565452dfee7"), "Напої які пропонує заклад, для своїх відвідувачів.", "Напої" },
                    { new Guid("3d1f906e-3577-42a2-a1f7-e0b07b209075"), "Компоненти які потрібно обрати, для замовлення кальяну.", "Кальяни" },
                    { new Guid("64306256-7c3f-4de5-a4e1-cda66d426a99"), "Пивні напої які пропонує заклад, для своїх відвідувачів.", "BeerLaboratory" },
                    { new Guid("b718f35c-6fa7-420b-9acf-82ece06faab9"), "Страви які пропонує заклад, для своїх відвідувачів.", "Страви" },
                    { new Guid("dbbe08ce-05f3-48a4-b9fa-472b09a19cfc"), "Електронні цигарки, та все необхідне комплектуюче до них.", "VapeCraft" }
                });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "Available", "Description", "ImageUrl", "Name", "RentPrice", "SeatingCapacity" },
                values: new object[] { new Guid("11f7292d-a432-438a-8166-2a362e152342"), 1, "", "*/Image/User/default-place-image.jpg", "Ігрова зона з XBox", 300m, 4 });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "Available", "Description", "ImageUrl", "Name", "SeatingCapacity" },
                values: new object[,]
                {
                    { new Guid("b9c9ce8b-cab3-44a4-a27f-fb9e7d9cc220"), 1, "", "*/Image/User/default-place-image.jpg", "Стіл 3", 4 },
                    { new Guid("bebdf36c-e319-4742-bf02-3abaaccf9dfa"), 1, "", "*/Image/User/default-place-image.jpg", "Стіл 2", 4 }
                });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "Available", "Description", "ImageUrl", "Name", "RentPrice", "SeatingCapacity" },
                values: new object[] { new Guid("becb0025-890c-4bfd-a384-66525bb8c1e2"), 1, "", "*/Image/User/default-place-image.jpg", "Ігрова зона з PS5", 400m, 6 });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "Available", "Description", "ImageUrl", "Name", "SeatingCapacity" },
                values: new object[] { new Guid("f9c16520-2579-4234-a579-4d68a7fbec23"), 1, "", "*/Image/User/default-place-image.jpg", "Стіл 1", 2 });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("0ba5721c-bf18-47f9-be9d-f0f1eb69434a"), "Відповідальний за бар.", "barman" },
                    { new Guid("1057c418-d34a-46ea-9e7b-b1dffd462a05"), "Звичайний користувач системи, клієнт.", "user" },
                    { new Guid("2bb5984d-3ff9-49c3-9e54-5dcff385fb98"), "Управлінський персонал лаунж-бару.", "manager" },
                    { new Guid("2f9d9d3f-a8f3-4916-a904-5d325bac45ec"), "Відповідає за підготовку кальянних замовлень.", "hookah-waiter" },
                    { new Guid("6fa17fba-626d-481c-81cd-bbda29109fab"), "Основний користувач системи, з усіма правами доступу.", "admin" },
                    { new Guid("e4821f82-1182-4bf1-a74a-d390d2c040d6"), "Персонал, який формує замовлення та подає страви відвідувачам.", "waiter" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2ac51f75-6248-4c4f-898d-19d32e23ff26"), "Сир" },
                    { new Guid("96a405fe-8b33-4396-bf4e-c38fb888aef6"), "М'ясо" },
                    { new Guid("9b3021be-d034-45b6-a206-7c2c241e983e"), "Кабачки" },
                    { new Guid("9df3190c-9ce0-479e-89a8-9b5b0ad9fa01"), "Телятина" },
                    { new Guid("cfc264d7-4da6-433a-a6d0-fd7d86f88029"), "Вершки" },
                    { new Guid("d83fbb8c-adbe-47e0-b96d-574a8da5f35f"), "Домашнє" },
                    { new Guid("e312485e-9217-4cd7-9e3f-8c3d47d44a0c"), "Катопля" },
                    { new Guid("ea0b7d5f-1a08-49bd-a229-c3e60bc45d3c"), "Борщ" },
                    { new Guid("feaab256-c7db-4cf0-95e9-6cc764da4f60"), "Курятина" }
                });

            migrationBuilder.InsertData(
                table: "Subcategories",
                columns: new[] { "Id", "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("12a9a6f2-544c-406f-a7e3-1f2dd87c8ed5"), new Guid("1f993aaa-9252-4a42-bf4f-b565452dfee7"), "", "Алкогольні" },
                    { new Guid("1ba18109-3b28-4183-894b-6f7741a4074b"), new Guid("b718f35c-6fa7-420b-9acf-82ece06faab9"), "", "Перші страви" },
                    { new Guid("1fd0e67d-72ce-4a4b-9d03-f1c2e8d95521"), new Guid("1f993aaa-9252-4a42-bf4f-b565452dfee7"), "", "Безалкогольні" },
                    { new Guid("421c0c78-dee2-4019-8ae9-9eed15927889"), new Guid("dbbe08ce-05f3-48a4-b9fa-472b09a19cfc"), "", "Одноразки" },
                    { new Guid("473e6b98-2487-4c5f-87c8-a0cee39cd518"), new Guid("64306256-7c3f-4de5-a4e1-cda66d426a99"), "", "Пиво" },
                    { new Guid("47429c78-1bd8-4da7-9c7b-f6a9a03624df"), new Guid("b718f35c-6fa7-420b-9acf-82ece06faab9"), "", "Хліб" },
                    { new Guid("561be8a7-dac0-4db4-b469-7496adec4fee"), new Guid("b718f35c-6fa7-420b-9acf-82ece06faab9"), "", "Соуси" },
                    { new Guid("82a10754-1207-45f7-bfeb-bf8ad7ac9a99"), new Guid("dbbe08ce-05f3-48a4-b9fa-472b09a19cfc"), "", "Комплектуючі" },
                    { new Guid("8487b289-fc03-4bee-9fdd-2ec43be3c1c2"), new Guid("b718f35c-6fa7-420b-9acf-82ece06faab9"), "", "Салати" },
                    { new Guid("8cd585a2-5bc9-460c-b0d2-0bf2216969d4"), new Guid("64306256-7c3f-4de5-a4e1-cda66d426a99"), "", "Ель" },
                    { new Guid("97935587-4c28-479c-8d74-4e36327f1a04"), new Guid("dbbe08ce-05f3-48a4-b9fa-472b09a19cfc"), "", "Рідини" },
                    { new Guid("a9fba436-d2f9-408c-af66-d1a381c586d7"), new Guid("3d1f906e-3577-42a2-a1f7-e0b07b209075"), "", "Рідина" },
                    { new Guid("afa905f9-8739-47db-8916-d728d47f8ea2"), new Guid("b718f35c-6fa7-420b-9acf-82ece06faab9"), "", "Закуски" },
                    { new Guid("c02cba8e-30a1-474b-88e3-19aa9adfc148"), new Guid("3d1f906e-3577-42a2-a1f7-e0b07b209075"), "", "Табак" },
                    { new Guid("ce0cd619-dad3-4121-baff-108183b5ab3e"), new Guid("b718f35c-6fa7-420b-9acf-82ece06faab9"), "", "Десерти" },
                    { new Guid("d5de634f-842a-4f3c-a466-47b52d2ae4b2"), new Guid("3d1f906e-3577-42a2-a1f7-e0b07b209075"), "", "Чаша" },
                    { new Guid("d67280c0-9c92-449d-8088-cb491b2f4c67"), new Guid("dbbe08ce-05f3-48a4-b9fa-472b09a19cfc"), "", "Девайси" },
                    { new Guid("db7f2067-9a18-4cc3-b76c-8b4e877b1b3f"), new Guid("b718f35c-6fa7-420b-9acf-82ece06faab9"), "", "М'ясо та риба" },
                    { new Guid("ec23f360-be45-4eec-bb8a-b7c34e0d1c48"), new Guid("b718f35c-6fa7-420b-9acf-82ece06faab9"), "", "Гарніри" },
                    { new Guid("f951e75b-a3e0-4866-bf8e-f341478b2fe7"), new Guid("64306256-7c3f-4de5-a4e1-cda66d426a99"), "", "До пива" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Blocked", "BlockingReason", "Email", "ExpiryDate", "FirstName", "ImageUrl", "LastName", "Password", "Phone", "RefreshToken", "RoleId", "Username" },
                values: new object[,]
                {
                    { new Guid("21f8588e-9af3-4173-9f26-70caf34fa9b7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "barman@gmail.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Barman", "*/Image/User/default-user-image.jpg", "Replica", "d7fa96b0923a796d06f7c732d3cc3a8b6579b9e4c921748fd3d93ded5e673aff", "0975440307", null, new Guid("0ba5721c-bf18-47f9-be9d-f0f1eb69434a"), "barman" },
                    { new Guid("3020649d-4974-4331-973b-6d29a02aebb1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "hookah.waiter@gmail.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hookah waiter", "*/Image/User/default-user-image.jpg", "Replica", "cb1fa3dcec90d28b039192c8b6f7d9fa8420680f1dc47edf7f93cffacc52c835", "0975440306", null, new Guid("2f9d9d3f-a8f3-4916-a904-5d325bac45ec"), "hookahwaiter" },
                    { new Guid("454de094-4b12-4f93-9cf1-1c3312133dbc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "user2@gmail.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User2", "*/Image/User/default-user-image.jpg", "Replica", "6025d18fe48abd45168528f18a82e265dd98d421a7084aa09f61b341703901a3", "0975440303", null, new Guid("1057c418-d34a-46ea-9e7b-b1dffd462a05"), "user2" },
                    { new Guid("6d6e8bd8-9fbc-48f9-8e4d-09bfb943f6a6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "user1@gmail.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User1", "*/Image/User/default-user-image.jpg", "Replica", "0a041b9462caa4a31bac3567e0b6e6fd9100787db2ab433d96f6d178cabfce90", "0975440304", null, new Guid("1057c418-d34a-46ea-9e7b-b1dffd462a05"), "user1" },
                    { new Guid("9bbeffef-5cce-40b8-8a40-6dfa637d4800"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "manager@gmail.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manager", "*/Image/User/default-user-image.jpg", "Replica", "6ee4a469cd4e91053847f5d3fcb61dbcc91e8f0ef10be7748da4c4a1ba382d17", "0975440308", null, new Guid("2bb5984d-3ff9-49c3-9e54-5dcff385fb98"), "manager" },
                    { new Guid("d4e6d597-950b-4d87-b568-9ce087f3c79f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "admin@gmail.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", "*/Image/User/default-user-image.jpg", "Replica", "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", "0975440309", null, new Guid("6fa17fba-626d-481c-81cd-bbda29109fab"), "admin" },
                    { new Guid("f98ee4a4-5378-43a3-9dfc-83d2d46ed2a1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "waiter@gmail.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Waiter", "*/Image/User/default-user-image.jpg", "Replica", "9beb7c0bd91394a08c1138752c0f196ab638f1da2c290184890184cfcb821ab4", "0975440305", null, new Guid("e4821f82-1182-4bf1-a74a-d390d2c040d6"), "waiter" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "MeasurementUnits", "Name", "OrderId", "Price", "Size", "SubcategoryId" },
                values: new object[,]
                {
                    { new Guid("16fd8cc5-580d-41e4-b75b-52e9d4e8fba2"), "", "*/Image/User/default-product-image.jpg", 3, "Борщ з телятиною", null, 87m, 350.0, new Guid("1ba18109-3b28-4183-894b-6f7741a4074b") },
                    { new Guid("219943ad-7f4a-4635-97cb-e14bfda6ced5"), "", "*/Image/User/default-product-image.jpg", 3, "Пельмені домашні", null, 75m, 220.0, new Guid("afa905f9-8739-47db-8916-d728d47f8ea2") },
                    { new Guid("b1b9528c-1728-49b7-81d2-fda2d2dbf2e7"), "", "*/Image/User/default-product-image.jpg", 3, "Сирний крем-суп", null, 75m, 300.0, new Guid("1ba18109-3b28-4183-894b-6f7741a4074b") },
                    { new Guid("dff69eb0-df62-49cc-a828-993dca89305b"), "", "*/Image/User/default-product-image.jpg", 3, "Кабачкові рулети з вершковим сиром", null, 83m, 180.0, new Guid("afa905f9-8739-47db-8916-d728d47f8ea2") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ReservationId",
                table: "Orders",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserID",
                table: "Orders",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceTags_TagId",
                table: "PlaceTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderId",
                table: "Products",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubcategoryId",
                table: "Products",
                column: "SubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTags_TagId",
                table: "ProductTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PlaceId",
                table: "Reservations",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategories_CategoryId",
                table: "Subcategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaceTags");

            migrationBuilder.DropTable(
                name: "ProductTags");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Subcategories");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
