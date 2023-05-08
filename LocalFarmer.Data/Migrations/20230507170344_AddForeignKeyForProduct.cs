using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalFarmer.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyForProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdFarmhouse",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdFarmhouse",
                table: "Products",
                column: "IdFarmhouse");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Farmhouses_IdFarmhouse",
                table: "Products",
                column: "IdFarmhouse",
                principalTable: "Farmhouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Farmhouses_IdFarmhouse",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdFarmhouse",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdFarmhouse",
                table: "Products");
        }
    }
}
