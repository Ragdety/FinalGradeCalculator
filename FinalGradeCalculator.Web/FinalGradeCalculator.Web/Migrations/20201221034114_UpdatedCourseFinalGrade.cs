using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalGradeCalculator.Web.Migrations
{
    public partial class UpdatedCourseFinalGrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "FinalGrade",
                table: "Courses",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "FinalGrade",
                table: "Courses",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);
        }
    }
}
