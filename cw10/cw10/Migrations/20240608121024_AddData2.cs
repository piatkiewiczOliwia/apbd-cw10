using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cw10.Migrations
{
    /// <inheritdoc />
    public partial class AddData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "IdPatient",
                keyValue: 1,
                column: "Birthdate",
                value: new DateTime(2024, 6, 8, 14, 10, 24, 390, DateTimeKind.Local).AddTicks(9620));

            migrationBuilder.InsertData(
                table: "prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 1, new DateTime(2024, 6, 8, 14, 10, 24, 390, DateTimeKind.Local).AddTicks(9700), new DateTime(2024, 6, 8, 14, 10, 24, 390, DateTimeKind.Local).AddTicks(9700), 2, 1 });

            migrationBuilder.InsertData(
                table: "prescription_medicaments",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[] { 1, 1, "bwdfieriuwfo", 100 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "prescription_medicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "IdPatient",
                keyValue: 1,
                column: "Birthdate",
                value: new DateTime(2024, 6, 8, 14, 7, 13, 434, DateTimeKind.Local).AddTicks(1150));
        }
    }
}
