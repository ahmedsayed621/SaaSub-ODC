using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PricingPlans.API.Migrations
{
    public partial class optimizeagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "plansFeatures",
                keyColumns: new[] { "PlanId", "featureId" },
                keyValues: new object[] { 1, 1 },
                column: "Id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "plansFeatures",
                keyColumns: new[] { "PlanId", "featureId" },
                keyValues: new object[] { 2, 1 },
                column: "Id",
                value: 5);

            migrationBuilder.UpdateData(
                table: "plansFeatures",
                keyColumns: new[] { "PlanId", "featureId" },
                keyValues: new object[] { 1, 2 },
                column: "Id",
                value: 2);

            migrationBuilder.UpdateData(
                table: "plansFeatures",
                keyColumns: new[] { "PlanId", "featureId" },
                keyValues: new object[] { 2, 2 },
                column: "Id",
                value: 6);

            migrationBuilder.UpdateData(
                table: "plansFeatures",
                keyColumns: new[] { "PlanId", "featureId" },
                keyValues: new object[] { 1, 3 },
                column: "Id",
                value: 3);

            migrationBuilder.UpdateData(
                table: "plansFeatures",
                keyColumns: new[] { "PlanId", "featureId" },
                keyValues: new object[] { 2, 3 },
                column: "Id",
                value: 7);

            migrationBuilder.UpdateData(
                table: "plansFeatures",
                keyColumns: new[] { "PlanId", "featureId" },
                keyValues: new object[] { 1, 4 },
                column: "Id",
                value: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "plansFeatures",
                keyColumns: new[] { "PlanId", "featureId" },
                keyValues: new object[] { 1, 1 },
                column: "Id",
                value: 0);

            migrationBuilder.UpdateData(
                table: "plansFeatures",
                keyColumns: new[] { "PlanId", "featureId" },
                keyValues: new object[] { 2, 1 },
                column: "Id",
                value: 0);

            migrationBuilder.UpdateData(
                table: "plansFeatures",
                keyColumns: new[] { "PlanId", "featureId" },
                keyValues: new object[] { 1, 2 },
                column: "Id",
                value: 0);

            migrationBuilder.UpdateData(
                table: "plansFeatures",
                keyColumns: new[] { "PlanId", "featureId" },
                keyValues: new object[] { 2, 2 },
                column: "Id",
                value: 0);

            migrationBuilder.UpdateData(
                table: "plansFeatures",
                keyColumns: new[] { "PlanId", "featureId" },
                keyValues: new object[] { 1, 3 },
                column: "Id",
                value: 0);

            migrationBuilder.UpdateData(
                table: "plansFeatures",
                keyColumns: new[] { "PlanId", "featureId" },
                keyValues: new object[] { 2, 3 },
                column: "Id",
                value: 0);

            migrationBuilder.UpdateData(
                table: "plansFeatures",
                keyColumns: new[] { "PlanId", "featureId" },
                keyValues: new object[] { 1, 4 },
                column: "Id",
                value: 0);
        }
    }
}
