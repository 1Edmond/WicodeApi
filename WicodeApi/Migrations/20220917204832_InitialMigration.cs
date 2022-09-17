using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WicodeApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Etat = table.Column<int>(type: "tinyint", nullable: false, defaultValue:0),
                    DateInscription = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InscriptionId = table.Column<int>(type: "int", nullable: false),
                    DatePayement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Etat = table.Column<int>(type: "tinyint", nullable: false, defaultValue:0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payements", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscriptions");

            migrationBuilder.DropTable(
                name: "Payements");
        }
    }
}
