using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DXCBookStore.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddBookQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantity",
                table: "books");
        }
    }
}
