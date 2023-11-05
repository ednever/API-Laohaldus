using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Laohaldus.Migrations
{
    /// <inheritdoc />
    public partial class updatedKategooriad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Pilt",
                table: "Kategooriad",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pilt",
                table: "Kategooriad");
        }
    }
}
