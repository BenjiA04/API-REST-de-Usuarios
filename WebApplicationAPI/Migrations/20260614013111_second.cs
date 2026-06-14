using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationAPI.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCategoria",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "IdProveedor",
                table: "Productos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCategoria",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdProveedor",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
