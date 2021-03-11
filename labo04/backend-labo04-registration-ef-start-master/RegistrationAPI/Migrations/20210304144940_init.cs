using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RegistrationAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VaccinationLocations",
                columns: table => new
                {
                    VaccinationLocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationLocations", x => x.VaccinationLocationId);
                });

            migrationBuilder.CreateTable(
                name: "VaccinationRegistrations",
                columns: table => new
                {
                    VaccinationRegistrationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    VaccinationDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VaccinTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VaccinationLocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationRegistrations", x => x.VaccinationRegistrationId);
                });

            migrationBuilder.CreateTable(
                name: "VaccinTypes",
                columns: table => new
                {
                    VaccinTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinTypes", x => x.VaccinTypeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VaccinationLocations");

            migrationBuilder.DropTable(
                name: "VaccinationRegistrations");

            migrationBuilder.DropTable(
                name: "VaccinTypes");
        }
    }
}
