using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace kolosJD.Migrations
{
    /// <inheritdoc />
    public partial class Pierwsza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Muzyk",
                columns: table => new
                {
                    IdMuzyk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Pseudonim = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Muzyk_pk", x => x.IdMuzyk);
                });

            migrationBuilder.CreateTable(
                name: "Wytwornia",
                columns: table => new
                {
                    IdWytwornia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Wytwornia_pk", x => x.IdWytwornia);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    IdAlbum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaAlbumu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DataWydania = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    IdWytwornia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Album_pk", x => x.IdAlbum);
                    table.ForeignKey(
                        name: "Album_Wytwornia_pk",
                        column: x => x.IdWytwornia,
                        principalTable: "Wytwornia",
                        principalColumn: "IdWytwornia",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Utwor",
                columns: table => new
                {
                    IdUtwor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaUtworu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CzasTrwania = table.Column<float>(type: "real", nullable: false),
                    IdAlbum = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Utwor_pk", x => x.IdUtwor);
                    table.ForeignKey(
                        name: "Utwor_Album",
                        column: x => x.IdAlbum,
                        principalTable: "Album",
                        principalColumn: "IdAlbum",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WykonawcaUtworu",
                columns: table => new
                {
                    IdMuzyk = table.Column<int>(type: "int", nullable: false),
                    IdUtwor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Muzyk_Utwor_pk", x => new { x.IdMuzyk, x.IdUtwor });
                    table.ForeignKey(
                        name: "FK_WykonawcaUtworu_Muzyk_IdMuzyk",
                        column: x => x.IdMuzyk,
                        principalTable: "Muzyk",
                        principalColumn: "IdMuzyk",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WykonawcaUtworu_Utwor_IdUtwor",
                        column: x => x.IdUtwor,
                        principalTable: "Utwor",
                        principalColumn: "IdUtwor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Muzyk",
                columns: new[] { "IdMuzyk", "Imie", "Nazwisko", "Pseudonim" },
                values: new object[,]
                {
                    { 1, "Tomasz", "Malaka", "MalaczekUwU" },
                    { 2, "Leokadia", "Mloda", "Leosia" }
                });

            migrationBuilder.InsertData(
                table: "Utwor",
                columns: new[] { "IdUtwor", "CzasTrwania", "IdAlbum", "NazwaUtworu" },
                values: new object[,]
                {
                    { 1, 2.54f, null, "BFF" },
                    { 2, 6.9f, null, "Lato" }
                });

            migrationBuilder.InsertData(
                table: "Wytwornia",
                columns: new[] { "IdWytwornia", "Nazwa" },
                values: new object[,]
                {
                    { 1, "Fajna" },
                    { 2, "Niefajna" }
                });

            migrationBuilder.InsertData(
                table: "Album",
                columns: new[] { "IdAlbum", "DataWydania", "IdWytwornia", "NazwaAlbumu" },
                values: new object[,]
                {
                    { 1, new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "To od Gangu Albanii" },
                    { 2, new DateTime(2020, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Cos tam" }
                });

            migrationBuilder.InsertData(
                table: "WykonawcaUtworu",
                columns: new[] { "IdMuzyk", "IdUtwor" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_IdWytwornia",
                table: "Album",
                column: "IdWytwornia");

            migrationBuilder.CreateIndex(
                name: "IX_Utwor_IdAlbum",
                table: "Utwor",
                column: "IdAlbum");

            migrationBuilder.CreateIndex(
                name: "IX_WykonawcaUtworu_IdUtwor",
                table: "WykonawcaUtworu",
                column: "IdUtwor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WykonawcaUtworu");

            migrationBuilder.DropTable(
                name: "Muzyk");

            migrationBuilder.DropTable(
                name: "Utwor");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Wytwornia");
        }
    }
}
