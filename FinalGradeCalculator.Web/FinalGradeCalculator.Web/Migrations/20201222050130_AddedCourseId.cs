using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalGradeCalculator.Web.Migrations
{
    public partial class AddedCourseId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GradedItems_Courses_CourseId",
                table: "GradedItems");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "GradedItems",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GradedItems_Courses_CourseId",
                table: "GradedItems",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GradedItems_Courses_CourseId",
                table: "GradedItems");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "GradedItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_GradedItems_Courses_CourseId",
                table: "GradedItems",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
