using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DXCBookStore.DAL.Migrations
{
    /// <inheritdoc />
    public partial class TurnOffRequireSerie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SERIE_BOOKS",
                table: "books");

            migrationBuilder.AlterColumn<int>(
                name: "serie_id",
                table: "books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SERIE_BOOKS",
                table: "books",
                column: "serie_id",
                principalTable: "series",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SERIE_BOOKS",
                table: "books");

            migrationBuilder.AlterColumn<int>(
                name: "serie_id",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SERIE_BOOKS",
                table: "books",
                column: "serie_id",
                principalTable: "series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
