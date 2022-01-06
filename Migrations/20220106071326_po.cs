using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class po : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompoundTransactionId",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CompoundTransactionId",
                table: "Transactions",
                column: "CompoundTransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_CompoundTransactions_CompoundTransactionId",
                table: "Transactions",
                column: "CompoundTransactionId",
                principalTable: "CompoundTransactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_CompoundTransactions_CompoundTransactionId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CompoundTransactionId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CompoundTransactionId",
                table: "Transactions");
        }
    }
}
