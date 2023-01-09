using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetterReads.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedIdOfBookToISBN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBookInteractions_Books_BookId",
                table: "UserBookInteractions");

            migrationBuilder.DropIndex(
                name: "IX_UserBookInteractions_BookId",
                table: "UserBookInteractions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "UserBookInteractions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "BookISBN",
                table: "UserBookInteractions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Books",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "ISBN");

            migrationBuilder.CreateIndex(
                name: "IX_UserBookInteractions_BookISBN",
                table: "UserBookInteractions",
                column: "BookISBN");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBookInteractions_Books_BookISBN",
                table: "UserBookInteractions",
                column: "BookISBN",
                principalTable: "Books",
                principalColumn: "ISBN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBookInteractions_Books_BookISBN",
                table: "UserBookInteractions");

            migrationBuilder.DropIndex(
                name: "IX_UserBookInteractions_BookISBN",
                table: "UserBookInteractions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookISBN",
                table: "UserBookInteractions");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "UserBookInteractions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserBookInteractions_BookId",
                table: "UserBookInteractions",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBookInteractions_Books_BookId",
                table: "UserBookInteractions",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
