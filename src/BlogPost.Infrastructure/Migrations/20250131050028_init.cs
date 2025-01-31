using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogPost.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "Blogseq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "Categoriesseq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "eventseq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "imageseq",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    BlogGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    FeaturedImage_Url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FeaturedImage_AltText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UrlHandle_Value = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Author_Firstname = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Author_Lastname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CategoryGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UrlHandle_Value = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    EventType_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventType_Id = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogImage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    BlogImageGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    BlogId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogImage_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogPostCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    BlogId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPostCategories_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogPostCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogImage_BlogId",
                table: "BlogImage",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogImage_BlogImageGuid",
                table: "BlogImage",
                column: "BlogImageGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostCategories_BlogId",
                table: "BlogPostCategories",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostCategories_CategoryId",
                table: "BlogPostCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_BlogGuid",
                table: "Blogs",
                column: "BlogGuid",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogImage");

            migrationBuilder.DropTable(
                name: "BlogPostCategories");

            migrationBuilder.DropTable(
                name: "EventLogs");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropSequence(
                name: "Blogseq");

            migrationBuilder.DropSequence(
                name: "Categoriesseq");

            migrationBuilder.DropSequence(
                name: "eventseq");

            migrationBuilder.DropSequence(
                name: "imageseq");
        }
    }
}
