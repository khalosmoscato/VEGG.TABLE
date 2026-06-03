using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VEGG.TABLE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$.L.EhNZir7n.hylCEenduOkBlqrdyXHt0jtDqMrW46jy0.pKbkMw2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "highthere");
        }
    }
}