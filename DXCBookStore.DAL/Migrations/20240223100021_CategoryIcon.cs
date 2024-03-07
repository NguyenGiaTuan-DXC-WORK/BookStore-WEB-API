using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DXCBookStore.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CategoryIcon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "category_icon",
                table: "categories",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ReportResponseModels",
                columns: table => new
                {
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportResponseModels");

            migrationBuilder.DropColumn(
                name: "category_icon",
                table: "categories");
        }
    }
}
