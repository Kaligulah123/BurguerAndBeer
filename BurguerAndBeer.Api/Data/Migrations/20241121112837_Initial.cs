using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BurguerAndBeer.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Burguer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Burguer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Hash = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    BurguerId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Burguer",
                columns: new[] { "Id", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Hamburguesa con carne de res, queso cheddar, lechuga, tomate y aderezo especial.", "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer1.png?raw=true", "Clásica Suprema", 5.9900000000000002 },
                    { 2, "Carne ahumada con salsa BBQ, cebolla crujiente y queso gouda.", "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer2.png?raw=true", "BBQ Texana", 6.9900000000000002 },
                    { 3, "Cargada de queso cheddar, bacon crujiente y mayonesa especial.", "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer3.png?raw=true", "Cheddar Bacon Deluxe", 7.4900000000000002 },
                    { 4, "Carne con queso suizo, piña caramelizada y salsa teriyaki.", "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer4.png?raw=true", "Hawaiana Tropical", 6.4900000000000002 },
                    { 5, "Con jalapeños, salsa picante, queso pepper jack y cebolla.", "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer5.png?raw=true", "Picante Infernal", 6.9900000000000002 },
                    { 6, "Doble carne aplastada, queso cheddar y salsa especial.", "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer6.png?raw=true", "Doble Smashburger", 7.9900000000000002 },
                    { 7, "Hamburguesa vegetariana con vegetales frescos y hummus.", "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer7.png?raw=true", "Veggie Lovers", 5.4900000000000002 },
                    { 8, "Seta portobello a la parrilla, queso suizo y mayonesa de ajo.", "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer8.png?raw=true", "Portobello Melt", 6.9900000000000002 },
                    { 9, "Carne de res con aceite de trufa, queso brie y rúcula.", "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer9.png?raw=true", "Trufa Gourmet", 8.9900000000000002 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Burguer");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
