using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PricingPlans.API.Migrations
{
    public partial class seedingplan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_plansFeatures",
                table: "plansFeatures");

            migrationBuilder.DropIndex(
                name: "IX_plansFeatures_featureId",
                table: "plansFeatures");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "plansFeatures");

            migrationBuilder.AddPrimaryKey(
                name: "PK_plansFeatures",
                table: "plansFeatures",
                columns: new[] { "featureId", "PlanId" });

            migrationBuilder.InsertData(
                table: "plans",
                columns: new[] { "Id", "Descraption", "Name", "PriceMonth", "PriceYear" },
                values: new object[] { 1, "Lorem ipsum dolor sit amet consectetur adipiscing elit \r\ninterdum ullamcorper sed pharetra sene.", "Basic", 7m, 96m });

            migrationBuilder.InsertData(
                table: "plans",
                columns: new[] { "Id", "Descraption", "Name", "PriceMonth", "PriceYear" },
                values: new object[] { 2, "Lorem ipsum dolor sit amet consectetur adipiscing elit \r\ninterdum ullamcorper sed pharetra sene.", "Advanced", 7m, 96m });

            migrationBuilder.InsertData(
                table: "plans",
                columns: new[] { "Id", "Descraption", "Name", "PriceMonth", "PriceYear" },
                values: new object[] { 3, "Lorem ipsum dolor sit amet consectetur adipiscing elit \r\ninterdum ullamcorper sed pharetra sene.", "Pro", 7m, 96m });

            migrationBuilder.InsertData(
                table: "plansFeatures",
                columns: new[] { "PlanId", "featureId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 1, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_plansFeatures",
                table: "plansFeatures");

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "plansFeatures",
                keyColumns: new[] { "PlanId", "featureId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "plansFeatures",
                keyColumns: new[] { "PlanId", "featureId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "plansFeatures",
                keyColumns: new[] { "PlanId", "featureId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "plansFeatures",
                keyColumns: new[] { "PlanId", "featureId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "plansFeatures",
                keyColumns: new[] { "PlanId", "featureId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "plansFeatures",
                keyColumns: new[] { "PlanId", "featureId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "plansFeatures",
                keyColumns: new[] { "PlanId", "featureId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "plansFeatures",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_plansFeatures",
                table: "plansFeatures",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_plansFeatures_featureId",
                table: "plansFeatures",
                column: "featureId");
        }
    }
}
