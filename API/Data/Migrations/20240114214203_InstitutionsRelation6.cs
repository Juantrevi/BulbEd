using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulbEd.Data.Migrations
{
    /// <inheritdoc />
    public partial class InstitutionsRelation6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResetToken",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResetToken",
                table: "AspNetUsers");
        }
    }
}
