using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnnlineStore.Migrations.OnlineStoreDb
{
    /// <inheritdoc />
    public partial class seedsomedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CoverImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Biography", "Name" },
                values: new object[,]
                {
                    { new Guid("080b5cb7-b849-40cf-9b90-645cde291033"), "Mark Twain was an American writer and humorist known for his novels 'The Adventures of Tom Sawyer' and 'Adventures of Huckleberry Finn.", "Mark Twain" },
                    { new Guid("83b98008-1cdd-4432-b87e-fc9f7abcaedc"), "J.K. Rowling is a British author, best known for writing the 'Harry Potter' series which has become one of the best-selling book series in history.", "J.K. Rowling" },
                    { new Guid("b893780a-45a1-41a3-9144-161864aca2ba"), "Jane Austen was an English novelist known for her six major novels including 'Pride and Prejudice' and 'Sense and Sensibility'.", "Jane Austen" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("12ab5a40-b795-40ce-b15d-8018422c8577"), "Educational" },
                    { new Guid("88f9ab88-463b-4c13-bf25-e18b6c480f9c"), "Novel" },
                    { new Guid("afd1fa53-a0ff-48ef-9704-300ed1837ba4"), "Children" },
                    { new Guid("f57eaa3d-89eb-4cef-bbe0-2aacc290b439"), "Self development" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CoverImageUrl", "Description", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("2eb18ede-7b1b-4d83-b1e4-871cce818c8a"), new Guid("080b5cb7-b849-40cf-9b90-645cde291033"), new Guid("f57eaa3d-89eb-4cef-bbe0-2aacc290b439"), "7_habits.jpg", "A self-help book by Stephen R. Covey that provides a principle-centered approach for solving personal and professional problems.", 29.99m, "The 7 Habits of Highly Effective People" },
                    { new Guid("67375ef5-72d0-4451-ae8f-3f6055edcdd6"), new Guid("83b98008-1cdd-4432-b87e-fc9f7abcaedc"), new Guid("afd1fa53-a0ff-48ef-9704-300ed1837ba4"), "harry_potter.jpg", "The first book in the Harry Potter series by J.K. Rowling.", 24.99m, "Harry Potter and the Sorcerer's Stone" },
                    { new Guid("6f5e32e2-b224-4497-9dd8-ab5e0ca5ec8e"), new Guid("080b5cb7-b849-40cf-9b90-645cde291033"), new Guid("88f9ab88-463b-4c13-bf25-e18b6c480f9c"), "tom_sawyer.jpg", "A novel by Mark Twain about a young boy's adventures in the American South.", 19.99m, "The Adventures of Tom Sawyer" },
                    { new Guid("c5de44d9-ceb9-4481-bdfd-ec47a5d25fb3"), new Guid("b893780a-45a1-41a3-9144-161864aca2ba"), new Guid("88f9ab88-463b-4c13-bf25-e18b6c480f9c"), "pride_and_prejudice.jpg", "A classic novel by Jane Austen exploring themes of love and social class.", 14.99m, "Pride and Prejudice" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
