using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurguerAndBeer.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewOrderItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Agregar las columnas CategoryId e ItemId a la tabla Items
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",       // Nombre de la columna
                table: "OrderItem",          // Nombre de la tabla donde se agregará la columna
                nullable: false,         // Indica si la columna puede ser nula (false significa que no puede ser nula)
                defaultValue: 0);        // Valor por defecto

            migrationBuilder.AddColumn<int>(
                name: "ItemId",          // Nombre de la columna
                table: "OrderItem",          // Nombre de la tabla donde se agregará la columna
                nullable: false,         // Indica si la columna puede ser nula (false significa que no puede ser nula)
                defaultValue: 0);        // Valor por defecto
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Eliminar las columnas CategoryId e ItemId si la migración se revierte
            migrationBuilder.DropColumn(
                name: "CategoryId",      // Nombre de la columna
                table: "OrderItem");         // Nombre de la tabla de la cual se eliminará la columna

            migrationBuilder.DropColumn(
                name: "ItemId",          // Nombre de la columna
                table: "OrderItem");         // Nombre de la tabla de la cual se eliminará la columna
        }
    }
}
