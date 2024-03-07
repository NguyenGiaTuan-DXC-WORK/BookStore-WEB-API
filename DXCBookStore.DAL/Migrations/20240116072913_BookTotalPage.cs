using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DXCBookStore.DAL.Migrations
{
    /// <inheritdoc />
    public partial class BookTotalPage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "total_page",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "total_page",
                table: "books");
        }
    }
}
