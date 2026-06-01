using System;

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VEGG.TABLE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProduceTable",
                columns: table => new
                {
                    ProduceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotograghPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsLiked = table.Column<bool>(type: "bit", nullable: false),
                    IsOnSale = table.Column<bool>(type: "bit", nullable: false),
                    IsPurchased = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduceTable", x => x.ProduceId);
                });

            migrationBuilder.CreateTable(
                name: "UserTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LikedTable",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProduceId = table.Column<int>(type: "int", nullable: false),
                    LikedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikedTable", x => new { x.UserId, x.ProduceId });
                    table.ForeignKey(
                        name: "FK_LikedTable_ProduceTable_ProduceId",
                        column: x => x.ProduceId,
                        principalTable: "ProduceTable",
                        principalColumn: "ProduceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikedTable_UserTable_UserId",
                        column: x => x.UserId,
                        principalTable: "UserTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProduceTable",
                columns: new[] { "ProduceId", "Category", "Description", "IsLiked", "IsOnSale", "IsPurchased", "Name", "PhotograghPath", "Price", "Stock", "UserId", "Weight" },
                values: new object[,]
                {
                    { 1, 9, "Plums for sale", false, false, false, "Plums", "", 2.0, 1, 1, 2.0 },
                    { 2, 9, "Fresh apples for sale", true, false, false, "Apples", "", 1.5, 5, 1, 3.0 },
                    { 3, 9, "Organic bananas", false, true, false, "Bananas", "", 0.98999999999999999, 10, 2, 2.0 },
                    { 4, 9, "Crunchy carrots for cooking", false, false, true, "Carrots", "", 1.2, 7, 2, 4.0 },
                    { 5, 9, "Juicy red tomatoes", true, true, false, "Tomatoes", "", 2.75, 8, 3, 3.0 },
                    { 6, 9, "Farm fresh potatoes", false, false, false, "Potatoes", "", 3.0, 15, 3, 10.0 },
                    { 7, 9, "Sweet strawberries", true, true, true, "Strawberries", "", 4.5, 6, 4, 1.0 },
                    { 8, 9, "Fresh green lettuce", false, false, false, "Lettuce", "", 1.1000000000000001, 4, 4, 1.0 },
                    { 9, 9, "Citrus oranges for juice", true, false, true, "Oranges", "", 2.2999999999999998, 12, 5, 5.0 },
                    { 10, 9, "Cool fresh cucumbers", false, true, false, "Cucumbers", "", 1.8, 9, 5, 2.0 }
                });

            migrationBuilder.InsertData(
                table: "UserTable",
                columns: new[] { "Id", "Email", "Name", "Password", "UserType" },
                values: new object[] { 1, "bossman@live.co.uk", "VegManDan", "highthere", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_LikedTable_ProduceId",
                table: "LikedTable",
                column: "ProduceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LikedTable");

            migrationBuilder.DropTable(
                name: "ProduceTable");

            migrationBuilder.DropTable(
                name: "UserTable");
        }
    }
}