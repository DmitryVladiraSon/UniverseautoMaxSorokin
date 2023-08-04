using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Universeauto.Migrations
{
    /// <inheritdoc />
    public partial class updateOrderLines1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceCustomer",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "PriceEmployee",
                table: "OrderLines");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PriceCustomer",
                table: "OrderLines",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceEmployee",
                table: "OrderLines",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
