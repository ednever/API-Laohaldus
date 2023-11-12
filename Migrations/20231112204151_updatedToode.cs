using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Laohaldus.Migrations
{
    /// <inheritdoc />
    public partial class updatedToode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Pilt",
                table: "Tooted",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pilt",
                table: "Tooted");
        }
    }
}
