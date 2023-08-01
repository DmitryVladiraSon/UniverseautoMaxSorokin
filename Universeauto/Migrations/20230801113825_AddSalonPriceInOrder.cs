using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Universeauto.Migrations
{
    /// <inheritdoc />
    public partial class AddSalonPriceInOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SalonPrice",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalonPrice",
                table: "Orders");
        }
    }
}
