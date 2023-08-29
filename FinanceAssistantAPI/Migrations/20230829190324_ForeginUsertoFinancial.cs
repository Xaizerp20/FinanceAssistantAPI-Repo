using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceAssistantAPI.Migrations
{
    /// <inheritdoc />
    public partial class ForeginUsertoFinancial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "FinancialRecord",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialRecord_UserId",
                table: "FinancialRecord",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialRecord_ApplicationUser_UserId",
                table: "FinancialRecord",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialRecord_ApplicationUser_UserId",
                table: "FinancialRecord");

            migrationBuilder.DropIndex(
                name: "IX_FinancialRecord_UserId",
                table: "FinancialRecord");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FinancialRecord");
        }
    }
}
