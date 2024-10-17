using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Controlnet_Project_Manager.Migrations
{
    /// <inheritdoc />
    public partial class AddNullableCostoToCPMUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Coste",
                table: "Usuarios",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coste",
                table: "Usuarios");
        }
    }
}
