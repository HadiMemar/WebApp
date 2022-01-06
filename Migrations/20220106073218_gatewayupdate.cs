using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class gatewayupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Gateway_GatewayId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "Gateway");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_GatewayId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "GatewayId",
                table: "Transactions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GatewayId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Gateway",
                columns: table => new
                {
                    GatewayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Attribute = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Type = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gateway", x => x.GatewayId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_GatewayId",
                table: "Transactions",
                column: "GatewayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Gateway_GatewayId",
                table: "Transactions",
                column: "GatewayId",
                principalTable: "Gateway",
                principalColumn: "GatewayId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
