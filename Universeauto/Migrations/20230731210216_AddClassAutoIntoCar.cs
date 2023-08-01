using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Universeauto.Migrations
{
    /// <inheritdoc />
    public partial class AddClassAutoIntoCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClassAuto",
                table: "Cars",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassAuto",
                table: "Cars");
        }
    }
}
