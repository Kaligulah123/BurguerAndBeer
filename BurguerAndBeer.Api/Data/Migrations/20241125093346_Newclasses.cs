using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BurguerAndBeer.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class Newclasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beer",
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
                    table.PrimaryKey("PK_Beer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chips",
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
                    table.PrimaryKey("PK_Chips", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dessert",
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
                    table.PrimaryKey("PK_Dessert", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Beer",
                columns: new[] { "Id", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "A refreshing pale ale with hints of citrus and a balanced malt profile.", "https://github.com/Kaligulah123/Images-Icons/blob/main/Beers/beer1.png?raw=true", "Pale Ale", 4.9900000000000002 },
                    { 2, "A bold India Pale Ale with strong hoppy aromas and a crisp finish.", "https://github.com/Kaligulah123/Images-Icons/blob/main/Beers/beer2.png?raw=true", "IPA", 5.4900000000000002 },
                    { 3, "A dark stout with rich chocolate and coffee flavors.", "https://github.com/Kaligulah123/Images-Icons/blob/main/Beers/beer3.png?raw=true", "Stout", 5.9900000000000002 },
                    { 4, "A light and crisp wheat beer with notes of banana and clove.", "https://github.com/Kaligulah123/Images-Icons/blob/main/Beers/beer4.png?raw=true", "Wheat Beer", 4.4900000000000002 },
                    { 5, "A classic lager with a clean taste and a smooth finish.", "https://github.com/Kaligulah123/Images-Icons/blob/main/Beers/beer5.png?raw=true", "Lager", 4.9900000000000002 },
                    { 6, "A crisp and refreshing pilsner with a slight floral hop aroma.", "https://github.com/Kaligulah123/Images-Icons/blob/main/Beers/beer6.png?raw=true", "Pilsner", 4.79 },
                    { 7, "A smooth amber ale with caramel notes and a balanced bitterness.", "https://github.com/Kaligulah123/Images-Icons/blob/main/Beers/beer7.png?raw=true", "Amber Ale", 5.29 },
                    { 8, "A rich porter with roasted malt flavors and hints of vanilla.", "https://github.com/Kaligulah123/Images-Icons/blob/main/Beers/beer8.png?raw=true", "Porter", 5.79 },
                    { 9, "A farmhouse ale with fruity and spicy notes, perfect for summer.", "https://github.com/Kaligulah123/Images-Icons/blob/main/Beers/beer9.png?raw=true", "Saison", 5.4900000000000002 },
                    { 10, "A nutty brown ale with hints of toffee and a smooth finish.", "https://github.com/Kaligulah123/Images-Icons/blob/main/Beers/beer10.png?raw=true", "Brown Ale", 5.29 },
                    { 11, "A complex Belgian ale with fruity esters and a spicy yeast character.", "https://github.com/Kaligulah123/Images-Icons/blob/main/Beers/beer11.png?raw=true", "Belgian Ale", 6.4900000000000002 }
                });

            migrationBuilder.UpdateData(
                table: "Burguer",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Burger with beef patty, cheddar cheese, lettuce, tomato, and special sauce.", "Classic Supreme" });

            migrationBuilder.UpdateData(
                table: "Burguer",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Smoked meat with BBQ sauce, crispy onion, and gouda cheese.", "BBQ Texan" });

            migrationBuilder.UpdateData(
                table: "Burguer",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Loaded with cheddar cheese, crispy bacon, and special mayonnaise.");

            migrationBuilder.UpdateData(
                table: "Burguer",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Beef patty with Swiss cheese, caramelized pineapple, and teriyaki sauce.", "Tropical Hawaiian" });

            migrationBuilder.UpdateData(
                table: "Burguer",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name" },
                values: new object[] { "With jalapeños, hot sauce, pepper jack cheese, and onion.", "Inferno Spicy" });

            migrationBuilder.UpdateData(
                table: "Burguer",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Double smashed patty, cheddar cheese, and special sauce.", "Double Smashburger" });

            migrationBuilder.UpdateData(
                table: "Burguer",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "Vegetarian burger with fresh vegetables and hummus.");

            migrationBuilder.UpdateData(
                table: "Burguer",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: "Grilled portobello mushroom, Swiss cheese, and garlic mayonnaise.");

            migrationBuilder.UpdateData(
                table: "Burguer",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Beef patty with truffle oil, brie cheese, and arugula.", "Gourmet Truffle" });

            migrationBuilder.InsertData(
                table: "Chips",
                columns: new[] { "Id", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Crispy golden French fries, lightly salted.", "https://github.com/Kaligulah123/Images-Icons/blob/main/Chips/patatas1.png?raw=true", "French Fries", 2.4900000000000002 },
                    { 2, "French fries topped with crispy bacon and a savory sauce.", "https://github.com/Kaligulah123/Images-Icons/blob/main/Chips/patatas2.png?raw=true", "Bacon Fries", 3.29 },
                    { 3, "Thick-cut potato wedges, perfectly seasoned and baked until golden.", "https://github.com/Kaligulah123/Images-Icons/blob/main/Chips/patatas3.png?raw=true", "Wedges Fries", 2.9900000000000002 }
                });

            migrationBuilder.InsertData(
                table: "Dessert",
                columns: new[] { "Id", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "A rich chocolate cupcake topped with creamy chocolate frosting.", "https://github.com/Kaligulah123/Images-Icons/blob/main/Desserts/cupcake_chocolate.png?raw=true", "Chocolate Cupcake ", 2.9900000000000002 },
                    { 2, "A delightful strawberry cupcake with a fresh strawberry glaze.", "https://github.com/Kaligulah123/Images-Icons/blob/main/Desserts/cupcake_fresa.png?raw=true", "Strawberry Cupcake", 2.79 },
                    { 3, "A moist blackberry cupcake with a tangy cream cheese frosting.", "https://github.com/Kaligulah123/Images-Icons/blob/main/Desserts/cupcake_mora.png?raw=true", "Blackberry Cupcake", 2.8900000000000001 },
                    { 4, "A classic red velvet cupcake with a smooth cream cheese frosting.", "https://github.com/Kaligulah123/Images-Icons/blob/main/Desserts/cupcake_redvelvet.png?raw=true", "Red Velvet Cupcake", 3.1899999999999999 },
                    { 5, "A decadent chocolate tart with a buttery crust and rich ganache filling.", "https://github.com/Kaligulah123/Images-Icons/blob/main/Desserts/tarta_chocolate.png?raw=true", "Chocolate Pie", 4.9900000000000002 },
                    { 6, "A creamy butter tart with a flaky pastry and smooth filling.", "https://github.com/Kaligulah123/Images-Icons/blob/main/Desserts/tarta_mantequilla.png?raw=true", "Butter Pie", 4.4900000000000002 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beer");

            migrationBuilder.DropTable(
                name: "Chips");

            migrationBuilder.DropTable(
                name: "Dessert");

            migrationBuilder.UpdateData(
                table: "Burguer",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Hamburguesa con carne de res, queso cheddar, lechuga, tomate y aderezo especial.", "Clásica Suprema" });

            migrationBuilder.UpdateData(
                table: "Burguer",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Carne ahumada con salsa BBQ, cebolla crujiente y queso gouda.", "BBQ Texana" });

            migrationBuilder.UpdateData(
                table: "Burguer",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Cargada de queso cheddar, bacon crujiente y mayonesa especial.");

            migrationBuilder.UpdateData(
                table: "Burguer",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Carne con queso suizo, piña caramelizada y salsa teriyaki.", "Hawaiana Tropical" });

            migrationBuilder.UpdateData(
                table: "Burguer",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Con jalapeños, salsa picante, queso pepper jack y cebolla.", "Picante Infernal" });

            migrationBuilder.UpdateData(
                table: "Burguer",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Doble carne aplastada, queso cheddar y salsa especial.", "Doble Smashburger" });

            migrationBuilder.UpdateData(
                table: "Burguer",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "Hamburguesa vegetariana con vegetales frescos y hummus.");

            migrationBuilder.UpdateData(
                table: "Burguer",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: "Seta portobello a la parrilla, queso suizo y mayonesa de ajo.");

            migrationBuilder.UpdateData(
                table: "Burguer",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Carne de res con aceite de trufa, queso brie y rúcula.", "Trufa Gourmet" });
        }
    }
}
