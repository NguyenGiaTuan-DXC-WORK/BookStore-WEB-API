using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddCategorySelfRef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "category_parent_id",
                table: "categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_categories_category_parent_id",
                table: "categories",
                column: "category_parent_id");

            migrationBuilder.AddForeignKey(
                name: "FK_CATEGORY_PARENT",
                table: "categories",
                column: "category_parent_id",
                principalTable: "categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CATEGORY_PARENT",
                table: "categories");

            migrationBuilder.DropIndex(
                name: "IX_categories_category_parent_id",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "category_parent_id",
                table: "categories");
        }
    }
}
