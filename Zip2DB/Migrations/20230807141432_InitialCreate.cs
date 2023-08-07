using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zip2DB.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zavezanci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ureditev = table.Column<char>(type: "TEXT", nullable: true),
                    ZavezanostZaDDV = table.Column<char>(type: "TEXT", nullable: true),
                    Davcna = table.Column<string>(type: "TEXT", nullable: false),
                    Maticna = table.Column<string>(type: "TEXT", nullable: true),
                    DatumRegistracije = table.Column<DateTime>(type: "TEXT", nullable: true),
                    SifraDejavnosti = table.Column<string>(type: "TEXT", nullable: false),
                    ImeZavezanca = table.Column<string>(type: "TEXT", nullable: false),
                    Naslov = table.Column<string>(type: "TEXT", nullable: false),
                    FinancniUrad = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zavezanci", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zavezanci");
        }
    }
}
