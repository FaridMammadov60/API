using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValue: false),
                    CreateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValue: false),
                    CreateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false, defaultValue: 0m),
                    DisCountPrice = table.Column<decimal>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImageUrl", "IsActive", "Name", "UpdateTime" },
                values: new object[,]
                {
                    { 1, null, true, "Computer", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, null, true, "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, null, true, "Game", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, null, true, "Electronic", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DisCountPrice", "IsActive", "Name", "Price", "UpdateTime" },
                values: new object[] { 1, 1, 60m, true, "Lenova Thinkpad", 1800m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DisCountPrice", "IsActive", "Name", "Price", "UpdateTime" },
                values: new object[] { 2, 2, 40m, true, "Iphone 13 Pro", 2300m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
