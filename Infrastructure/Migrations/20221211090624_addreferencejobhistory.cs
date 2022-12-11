using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addreferencejobhistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_JobHistories_DepartmentId",
                table: "JobHistories",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobHistories_Departments_DepartmentId",
                table: "JobHistories",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobHistories_Departments_DepartmentId",
                table: "JobHistories");

            migrationBuilder.DropIndex(
                name: "IX_JobHistories_DepartmentId",
                table: "JobHistories");
        }
    }
}
