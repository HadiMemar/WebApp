using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class stockhub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Transactions",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "HubId",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Transactions",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "HubId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Transactions");
        }
    }
}
