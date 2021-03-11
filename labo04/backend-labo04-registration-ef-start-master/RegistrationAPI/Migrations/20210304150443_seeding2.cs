using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RegistrationAPI.Migrations
{
    public partial class seeding2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VaccinTypes",
                keyColumn: "VaccinTypeId",
                keyValue: new Guid("a163f362-96bc-408c-8d6b-be8886b65dee"));

            migrationBuilder.InsertData(
                table: "VaccinTypes",
                columns: new[] { "VaccinTypeId", "Name" },
                values: new object[] { new Guid("9aa0a7cb-0be0-4a4e-8af4-b9a3f4c664a2"), "Pfizer" });

            migrationBuilder.InsertData(
                table: "VaccinationLocations",
                columns: new[] { "VaccinationLocationId", "Name" },
                values: new object[] { new Guid("fe53e192-7546-42d6-b9bd-0e382b4c9278"), "The Penta" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VaccinTypes",
                keyColumn: "VaccinTypeId",
                keyValue: new Guid("9aa0a7cb-0be0-4a4e-8af4-b9a3f4c664a2"));

            migrationBuilder.DeleteData(
                table: "VaccinationLocations",
                keyColumn: "VaccinationLocationId",
                keyValue: new Guid("fe53e192-7546-42d6-b9bd-0e382b4c9278"));

            migrationBuilder.InsertData(
                table: "VaccinTypes",
                columns: new[] { "VaccinTypeId", "Name" },
                values: new object[] { new Guid("a163f362-96bc-408c-8d6b-be8886b65dee"), "Pfizer" });
        }
    }
}
