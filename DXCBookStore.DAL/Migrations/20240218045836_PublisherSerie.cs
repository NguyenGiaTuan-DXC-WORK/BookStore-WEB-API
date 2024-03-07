using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DXCBookStore.DAL.Migrations
{
    /// <inheritdoc />
    public partial class PublisherSerie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "publisher_id",
                table: "series",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_series_publisher_id",
                table: "series",
                column: "publisher_id");

            migrationBuilder.AddForeignKey(
                name: "FK_PUBLISHER_SERIES",
                table: "series",
                column: "publisher_id",
                principalTable: "publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PUBLISHER_SERIES",
                table: "series");

            migrationBuilder.DropIndex(
                name: "IX_series_publisher_id",
                table: "series");

            migrationBuilder.DropColumn(
                name: "publisher_id",
                table: "series");
        }
    }
}
