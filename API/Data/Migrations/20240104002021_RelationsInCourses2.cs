using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulbEd.Data.Migrations
{
    /// <inheritdoc />
    public partial class RelationsInCourses2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassSchedule_Modules_ModuleId",
                table: "ClassSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassSchedule",
                table: "ClassSchedule");

            migrationBuilder.RenameTable(
                name: "ClassSchedule",
                newName: "ClassSchedules");

            migrationBuilder.RenameIndex(
                name: "IX_ClassSchedule_ModuleId",
                table: "ClassSchedules",
                newName: "IX_ClassSchedules_ModuleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassSchedules",
                table: "ClassSchedules",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSchedules_Modules_ModuleId",
                table: "ClassSchedules",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassSchedules_Modules_ModuleId",
                table: "ClassSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassSchedules",
                table: "ClassSchedules");

            migrationBuilder.RenameTable(
                name: "ClassSchedules",
                newName: "ClassSchedule");

            migrationBuilder.RenameIndex(
                name: "IX_ClassSchedules_ModuleId",
                table: "ClassSchedule",
                newName: "IX_ClassSchedule_ModuleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassSchedule",
                table: "ClassSchedule",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSchedule_Modules_ModuleId",
                table: "ClassSchedule",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id");
        }
    }
}
