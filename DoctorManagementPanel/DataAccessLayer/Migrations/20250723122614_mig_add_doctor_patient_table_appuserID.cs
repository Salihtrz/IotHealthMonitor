using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_doctor_patient_table_appuserID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AppUserID",
                table: "Patients",
                column: "AppUserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_AppUserID",
                table: "Doctors",
                column: "AppUserID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_AspNetUsers_AppUserID",
                table: "Doctors",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_AspNetUsers_AppUserID",
                table: "Patients",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_AspNetUsers_AppUserID",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_AspNetUsers_AppUserID",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_AppUserID",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_AppUserID",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Doctors");
        }
    }
}
