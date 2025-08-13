using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_update_Pulse_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientID",
                table: "Pulses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pulses_PatientID",
                table: "Pulses",
                column: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pulses_Patients_PatientID",
                table: "Pulses",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pulses_Patients_PatientID",
                table: "Pulses");

            migrationBuilder.DropIndex(
                name: "IX_Pulses_PatientID",
                table: "Pulses");

            migrationBuilder.DropColumn(
                name: "PatientID",
                table: "Pulses");
        }
    }
}
