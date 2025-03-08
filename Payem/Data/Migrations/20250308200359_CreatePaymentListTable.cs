using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payem.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreatePaymentListTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentListId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PaymentList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentList", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_PaymentListId",
                table: "Products",
                column: "PaymentListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_PaymentList_PaymentListId",
                table: "Products",
                column: "PaymentListId",
                principalTable: "PaymentList",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_PaymentList_PaymentListId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "PaymentList");

            migrationBuilder.DropIndex(
                name: "IX_Products_PaymentListId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PaymentListId",
                table: "Products");
        }
    }
}
