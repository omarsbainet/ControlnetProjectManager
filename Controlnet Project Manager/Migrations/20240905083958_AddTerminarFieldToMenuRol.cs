using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Controlnet_Project_Manager.Migrations
{
    /// <inheritdoc />
    public partial class AddTerminarFieldToMenuRol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Terminar",
                table: "MenuRoles",
                type: "tinyint(1)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Terminar",
                table: "MenuRoles");
        }
    }
}
