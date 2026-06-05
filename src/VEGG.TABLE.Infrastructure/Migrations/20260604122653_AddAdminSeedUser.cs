using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VEGG.TABLE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminSeedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserTable",
                columns: new[] { "Id", "Email", "Name", "Password", "UserType" },
                values: new object[] { 8, "admin@vegg.table", "AdminUser", "$2a$11$.L.EhNZir7n.hylCEenduOkBlqrdyXHt0jtDqMrW46jy0.pKbkMw2", 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}