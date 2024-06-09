using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cw10.Migrations
{
    /// <inheritdoc />
    public partial class AddData1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "bobek@hotmail.com", "Bob", "Jobs" },
                    { 2, "alice123@hotmail.com", "Alice", "Stewart" }
                });

            migrationBuilder.InsertData(
                table: "medicaments",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "fdkujb", "Velaxin", "antidepressant" },
                    { 2, "fdkufdgjb", "Apap", "pain killer" }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "IdPatient", "Birthdate", "FirstName", "LastName" },
                values: new object[] { 1, new DateTime(2024, 6, 8, 14, 7, 13, 434, DateTimeKind.Local).AddTicks(1150), "Pep", "Trol" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "IdDoctor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "IdDoctor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "medicaments",
                keyColumn: "IdMedicament",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "medicaments",
                keyColumn: "IdMedicament",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "IdPatient",
                keyValue: 1);
        }
    }
}
