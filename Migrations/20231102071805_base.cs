using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Laohaldus.Migrations
{
    /// <inheritdoc />
    public partial class @base : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kasutajad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kasutajanimi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    E_post = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parool = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kasutajad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategooriad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nimetus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategooriad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Arved",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KasutajaId = table.Column<int>(type: "int", nullable: false),
                    Kuupaev = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arved", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arved_Kasutajad_KasutajaId",
                        column: x => x.KasutajaId,
                        principalTable: "Kasutajad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tooted",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nimetus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kogus = table.Column<int>(type: "int", nullable: false),
                    Uhik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hind = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KategooriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tooted", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tooted_Kategooriad_KategooriaId",
                        column: x => x.KategooriaId,
                        principalTable: "Kategooriad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tellimused",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TooteId = table.Column<int>(type: "int", nullable: false),
                    Kogus = table.Column<int>(type: "int", nullable: false),
                    ToodeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tellimused", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tellimused_Tooted_ToodeId",
                        column: x => x.ToodeId,
                        principalTable: "Tooted",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TellimusedArves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TellimusId = table.Column<int>(type: "int", nullable: false),
                    ArveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TellimusedArves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TellimusedArves_Arved_ArveId",
                        column: x => x.ArveId,
                        principalTable: "Arved",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TellimusedArves_Tellimused_TellimusId",
                        column: x => x.TellimusId,
                        principalTable: "Tellimused",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arved_KasutajaId",
                table: "Arved",
                column: "KasutajaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tellimused_ToodeId",
                table: "Tellimused",
                column: "ToodeId");

            migrationBuilder.CreateIndex(
                name: "IX_TellimusedArves_ArveId",
                table: "TellimusedArves",
                column: "ArveId");

            migrationBuilder.CreateIndex(
                name: "IX_TellimusedArves_TellimusId",
                table: "TellimusedArves",
                column: "TellimusId");

            migrationBuilder.CreateIndex(
                name: "IX_Tooted_KategooriaId",
                table: "Tooted",
                column: "KategooriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TellimusedArves");

            migrationBuilder.DropTable(
                name: "Arved");

            migrationBuilder.DropTable(
                name: "Tellimused");

            migrationBuilder.DropTable(
                name: "Kasutajad");

            migrationBuilder.DropTable(
                name: "Tooted");

            migrationBuilder.DropTable(
                name: "Kategooriad");
        }
    }
}
