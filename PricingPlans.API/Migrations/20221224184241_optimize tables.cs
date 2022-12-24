using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PricingPlans.API.Migrations
{
    public partial class optimizetables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "plansFeatures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "plans",
                keyColumn: "Id",
                keyValue: 1,
                column: "Descraption",
                value: "Lorem ipsum dolor sit amet consectetur adipiscing elit interdum ullamcorper sed pharetra sene.");

            migrationBuilder.UpdateData(
                table: "plans",
                keyColumn: "Id",
                keyValue: 2,
                column: "Descraption",
                value: "Lorem ipsum dolor sit amet consectetur adipiscing elit interdum ullamcorper sed pharetra sene.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "plansFeatures");

            migrationBuilder.UpdateData(
                table: "plans",
                keyColumn: "Id",
                keyValue: 1,
                column: "Descraption",
                value: "Lorem ipsum dolor sit amet consectetur adipiscing elit \r\ninterdum ullamcorper sed pharetra sene.");

            migrationBuilder.UpdateData(
                table: "plans",
                keyColumn: "Id",
                keyValue: 2,
                column: "Descraption",
                value: "Lorem ipsum dolor sit amet consectetur adipiscing elit \r\ninterdum ullamcorper sed pharetra sene.");
        }
    }
}
