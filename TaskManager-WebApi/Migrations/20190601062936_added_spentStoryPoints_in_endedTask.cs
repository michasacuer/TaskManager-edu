using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManager.WebApi.Migrations
{
    public partial class added_spentStoryPoints_in_endedTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpentStoryPoints",
                table: "EndedTasks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpentStoryPoints",
                table: "EndedTasks");
        }
    }
}
