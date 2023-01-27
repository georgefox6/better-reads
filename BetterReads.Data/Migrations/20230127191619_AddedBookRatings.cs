using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetterReads.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedBookRatings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookISBN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FiveStarRatings = table.Column<int>(type: "int", nullable: false),
                    FourStarRatings = table.Column<int>(type: "int", nullable: false),
                    ThreeStarRatings = table.Column<int>(type: "int", nullable: false),
                    TwoStarRatings = table.Column<int>(type: "int", nullable: false),
                    OneStarRatings = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookRatings_Books_BookISBN",
                        column: x => x.BookISBN,
                        principalTable: "Books",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookRatings_BookISBN",
                table: "BookRatings",
                column: "BookISBN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookRatings");
        }
    }
}
