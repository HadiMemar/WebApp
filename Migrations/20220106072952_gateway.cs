using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class gateway : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gateways_Hubs_HubId",
                table: "Gateways");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Gateways_GatewayId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gateways",
                table: "Gateways");

            migrationBuilder.DropIndex(
                name: "IX_Gateways_HubId",
                table: "Gateways");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Gateways");

            migrationBuilder.DropColumn(
                name: "HubId",
                table: "Gateways");

            migrationBuilder.RenameTable(
                name: "Gateways",
                newName: "Gateway");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gateway",
                table: "Gateway",
                column: "GatewayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Gateway_GatewayId",
                table: "Transactions",
                column: "GatewayId",
                principalTable: "Gateway",
                principalColumn: "GatewayId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Gateway_GatewayId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gateway",
                table: "Gateway");

            migrationBuilder.RenameTable(
                name: "Gateway",
                newName: "Gateways");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Gateways",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "HubId",
                table: "Gateways",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gateways",
                table: "Gateways",
                column: "GatewayId");

            migrationBuilder.CreateIndex(
                name: "IX_Gateways_HubId",
                table: "Gateways",
                column: "HubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gateways_Hubs_HubId",
                table: "Gateways",
                column: "HubId",
                principalTable: "Hubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Gateways_GatewayId",
                table: "Transactions",
                column: "GatewayId",
                principalTable: "Gateways",
                principalColumn: "GatewayId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
