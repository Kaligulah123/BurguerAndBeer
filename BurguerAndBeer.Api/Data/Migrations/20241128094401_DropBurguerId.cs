using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurguerAndBeer.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class DropBurguerId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
           name: "BurguerId",
           table: "OrderItem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
           name: "BurguerId",
           table: "OrderItem",
           type: "bigint",
           nullable: false,
           defaultValue: 0L);
        }
    }
}
