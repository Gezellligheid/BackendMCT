using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RegistrationAPI.Migrations
{
    public partial class seeding1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VaccinTypes",
                columns: new[] { "VaccinTypeId", "Name" },
                values: new object[] { new Guid("a163f362-96bc-408c-8d6b-be8886b65dee"), "Pfizer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VaccinTypes",
                keyColumn: "VaccinTypeId",
                keyValue: new Guid("a163f362-96bc-408c-8d6b-be8886b65dee"));
        }
    }
}
