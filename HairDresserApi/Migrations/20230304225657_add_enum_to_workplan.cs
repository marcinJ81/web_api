using Microsoft.EntityFrameworkCore.Migrations;

namespace HairDresserApi.Migrations
{
    public partial class add_enum_to_workplan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShiftTypeSecond",
                table: "WorkPlans",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShiftTypeSecond",
                table: "WorkPlans");
        }
    }
}
