using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PricingPlans.API.Migrations
{
    public partial class seedingfeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "features",
                columns: new[] { "Id", "featuresName" },
                values: new object[,]
                {
                    { 1, "Unlimited members" },
                    { 2, "Unlimited feedback" },
                    { 3, "Weekly team Feedback Friday" },
                    { 4, "Custom Kudos +9 illustration" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "features",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "features",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "features",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "features",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
