using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LocalFarmer.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddpositionforfarmhouseandIdFarmhouseforUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07e5cb64-18d2-4f15-9c7d-ae119f29a131");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "959738f1-5276-41c7-bde4-9123d803eb29");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Farmhouses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Farmhouses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "IdFarmhouse",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7c589744-063c-43c4-962a-019ecded211e", "2", "User", "User" },
                    { "a5538998-7818-4b16-afbe-1dd61fa1f3b6", "1", "Admin", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdFarmhouse",
                table: "AspNetUsers",
                column: "IdFarmhouse");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Farmhouses_IdFarmhouse",
                table: "AspNetUsers",
                column: "IdFarmhouse",
                principalTable: "Farmhouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Farmhouses_IdFarmhouse",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdFarmhouse",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c589744-063c-43c4-962a-019ecded211e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5538998-7818-4b16-afbe-1dd61fa1f3b6");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Farmhouses");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Farmhouses");

            migrationBuilder.DropColumn(
                name: "IdFarmhouse",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07e5cb64-18d2-4f15-9c7d-ae119f29a131", "2", "User", "User" },
                    { "959738f1-5276-41c7-bde4-9123d803eb29", "1", "Admin", "Admin" }
                });
        }
    }
}
