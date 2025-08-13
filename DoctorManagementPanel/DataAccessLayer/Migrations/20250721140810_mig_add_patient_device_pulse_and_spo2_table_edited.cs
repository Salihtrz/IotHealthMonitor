using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_patient_device_pulse_and_spo2_table_edited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Doctors_DoctorID",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Patients_PatientID",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Pulses_Patients_PatientID",
                table: "Pulses");

            migrationBuilder.DropForeignKey(
                name: "FK_SpO2s_Patients_PatientID",
                table: "SpO2s");

            migrationBuilder.DropColumn(
                name: "InspectionDate",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "PatientID",
                table: "SpO2s",
                newName: "DeviceID");

            migrationBuilder.RenameIndex(
                name: "IX_SpO2s_PatientID",
                table: "SpO2s",
                newName: "IX_SpO2s_DeviceID");

            migrationBuilder.RenameColumn(
                name: "PatientID",
                table: "Pulses",
                newName: "DeviceID");

            migrationBuilder.RenameIndex(
                name: "IX_Pulses_PatientID",
                table: "Pulses",
                newName: "IX_Pulses_DeviceID");

            migrationBuilder.AlterColumn<int>(
                name: "SpO2Value",
                table: "SpO2s",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "PatientID",
                table: "Prescriptions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorID",
                table: "Prescriptions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Doctors_DoctorID",
                table: "Prescriptions",
                column: "DoctorID",
                principalTable: "Doctors",
                principalColumn: "DoctorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Patients_PatientID",
                table: "Prescriptions",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pulses_Devices_DeviceID",
                table: "Pulses",
                column: "DeviceID",
                principalTable: "Devices",
                principalColumn: "DeviceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpO2s_Devices_DeviceID",
                table: "SpO2s",
                column: "DeviceID",
                principalTable: "Devices",
                principalColumn: "DeviceID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Doctors_DoctorID",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Patients_PatientID",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Pulses_Devices_DeviceID",
                table: "Pulses");

            migrationBuilder.DropForeignKey(
                name: "FK_SpO2s_Devices_DeviceID",
                table: "SpO2s");

            migrationBuilder.RenameColumn(
                name: "DeviceID",
                table: "SpO2s",
                newName: "PatientID");

            migrationBuilder.RenameIndex(
                name: "IX_SpO2s_DeviceID",
                table: "SpO2s",
                newName: "IX_SpO2s_PatientID");

            migrationBuilder.RenameColumn(
                name: "DeviceID",
                table: "Pulses",
                newName: "PatientID");

            migrationBuilder.RenameIndex(
                name: "IX_Pulses_DeviceID",
                table: "Pulses",
                newName: "IX_Pulses_PatientID");

            migrationBuilder.AlterColumn<string>(
                name: "SpO2Value",
                table: "SpO2s",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PatientID",
                table: "Prescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DoctorID",
                table: "Prescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InspectionDate",
                table: "Patients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Doctors_DoctorID",
                table: "Prescriptions",
                column: "DoctorID",
                principalTable: "Doctors",
                principalColumn: "DoctorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Patients_PatientID",
                table: "Prescriptions",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pulses_Patients_PatientID",
                table: "Pulses",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpO2s_Patients_PatientID",
                table: "SpO2s",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
