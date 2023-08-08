using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LocalFarmer.Data.Migrations
{
    /// <inheritdoc />
    public partial class Farmhousenotrequiredforuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Farmhouses_IdFarmhouse",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c589744-063c-43c4-962a-019ecded211e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5538998-7818-4b16-afbe-1dd61fa1f3b6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2309cc94-b050-4115-9f62-531d11b259ac", "1", "Admin", "Admin" },
                    { "32a199fe-5b64-4d40-bbde-b37034f2f303", "2", "User", "User" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Farmhouses_IdFarmhouse",
                table: "AspNetUsers",
                column: "IdFarmhouse",
                principalTable: "Farmhouses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Farmhouses_IdFarmhouse",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2309cc94-b050-4115-9f62-531d11b259ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32a199fe-5b64-4d40-bbde-b37034f2f303");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7c589744-063c-43c4-962a-019ecded211e", "2", "User", "User" },
                    { "a5538998-7818-4b16-afbe-1dd61fa1f3b6", "1", "Admin", "Admin" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Farmhouses_IdFarmhouse",
                table: "AspNetUsers",
                column: "IdFarmhouse",
                principalTable: "Farmhouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
