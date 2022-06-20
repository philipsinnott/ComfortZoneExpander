using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComfortZoneExpanderAPI.Migrations
{
    public partial class AddRatingToDailyItemDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "DailyItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "DailyItems");
        }
    }
}
