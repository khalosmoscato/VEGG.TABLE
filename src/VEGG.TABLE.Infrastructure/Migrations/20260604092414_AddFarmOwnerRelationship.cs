using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VEGG.TABLE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFarmOwnerRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProduceTable_Farms_FarmId",
                table: "ProduceTable");

            migrationBuilder.DropIndex(
                name: "IX_ProduceTable_FarmId",
                table: "ProduceTable");

            migrationBuilder.DropColumn(
                name: "FarmId",
                table: "ProduceTable");

            migrationBuilder.UpdateData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$G7VbY4W8z1zW7F4Q1j6Qj.qH8zM8G.VzS6LhZ9KqW.0f2gQ8m8hXy");

            migrationBuilder.UpdateData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$uK8fS9j2lK7mN4Q2x5P5e.rJ0hZ7G.VzS6LhZ9KqW.0f2gQ8m8hXy");

            migrationBuilder.UpdateData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$vN2mX5Q8k1jL4H3x6T9a.rJ0hZ7G.VzS6LhZ9KqW.0f2gQ8m8hXy");

            migrationBuilder.UpdateData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$wL3bV8k9m2pQ5D4y7R1b.rJ0hZ7G.VzS6LhZ9KqW.0f2gQ8m8hXy");

            migrationBuilder.InsertData(
                table: "UserTable",
                columns: new[] { "Id", "Email", "Name", "Password", "UserType" },
                values: new object[,]
                {
                    { 6, "buyer1@test.com", "GreenShopper", "$2a$11$G7VbY4W8z1zW7F4Q1j6Qj.qH8zM8G.VzS6LhZ9KqW.0f2gQ8m8hXy", 1 },
                    { 7, "buyer2@test.com", "OrganicFan", "$2a$11$fK5Qz7n.uV.z8L3M9KqW.0f2gQ8m8hXyLhZ9KqW.0f2gQ8m8hXy", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Farms_OwnerId",
                table: "Farms",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Farms_UserTable_OwnerId",
                table: "Farms",
                column: "OwnerId",
                principalTable: "UserTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Farms_UserTable_OwnerId",
                table: "Farms");

            migrationBuilder.DropIndex(
                name: "IX_Farms_OwnerId",
                table: "Farms");

            migrationBuilder.DeleteData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.AddColumn<int>(
                name: "FarmId",
                table: "ProduceTable",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ProduceTable",
                keyColumn: "ProduceId",
                keyValue: 1,
                column: "FarmId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProduceTable",
                keyColumn: "ProduceId",
                keyValue: 2,
                column: "FarmId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProduceTable",
                keyColumn: "ProduceId",
                keyValue: 3,
                column: "FarmId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProduceTable",
                keyColumn: "ProduceId",
                keyValue: 4,
                column: "FarmId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProduceTable",
                keyColumn: "ProduceId",
                keyValue: 5,
                column: "FarmId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProduceTable",
                keyColumn: "ProduceId",
                keyValue: 6,
                column: "FarmId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProduceTable",
                keyColumn: "ProduceId",
                keyValue: 7,
                column: "FarmId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProduceTable",
                keyColumn: "ProduceId",
                keyValue: 8,
                column: "FarmId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProduceTable",
                keyColumn: "ProduceId",
                keyValue: 9,
                column: "FarmId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProduceTable",
                keyColumn: "ProduceId",
                keyValue: 10,
                column: "FarmId",
                value: null);

            migrationBuilder.UpdateData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "hashed_pw_2");

            migrationBuilder.UpdateData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "hashed_pw_3");

            migrationBuilder.UpdateData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "hashed_pw_4");

            migrationBuilder.UpdateData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "hashed_pw_5");

            migrationBuilder.CreateIndex(
                name: "IX_ProduceTable_FarmId",
                table: "ProduceTable",
                column: "FarmId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProduceTable_Farms_FarmId",
                table: "ProduceTable",
                column: "FarmId",
                principalTable: "Farms",
                principalColumn: "Id");
        }
    }
}
