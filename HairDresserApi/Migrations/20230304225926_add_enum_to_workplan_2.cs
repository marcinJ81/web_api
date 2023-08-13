using Microsoft.EntityFrameworkCore.Migrations;

namespace HairDresserApi.Migrations
{
    public partial class add_enum_to_workplan_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShiftTypeSecondName",
                table: "WorkPlans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShiftTypeSecondName",
                table: "WorkPlans");
        }
    }
}
