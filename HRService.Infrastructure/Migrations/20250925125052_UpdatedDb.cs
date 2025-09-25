using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Jobs_DepartmentId",
                table: "Jobs",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Departments_DepartmentId",
                table: "Jobs",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Departments_DepartmentId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_DepartmentId",
                table: "Jobs");
        }
    }
}
