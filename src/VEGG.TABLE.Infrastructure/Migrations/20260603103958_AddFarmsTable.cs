using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VEGG.TABLE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFarmsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FarmId",
                table: "ProduceTable",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Farms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    Lng = table.Column<double>(type: "float", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farms", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Farms",
                columns: new[] { "Id", "Lat", "Lng", "Name", "OwnerId" },
                values: new object[,]
                {
                    { 1, 51.533200000000001, -0.063200000000000006, "Hackney City Farm", 1 },
                    { 2, 51.498800000000003, -0.041599999999999998, "Surrey Docks Farm", 2 },
                    { 3, 51.547800000000002, -0.14560000000000001, "Kentish Town City Farm", 3 },
                    { 4, 51.519500000000001, -0.064500000000000002, "Spitalfields Farm", 4 },
                    { 5, 51.422499999999999, -0.063500000000000001, "Crystal Palace Park Farm", 5 }
                });

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

            migrationBuilder.InsertData(
                table: "UserTable",
                columns: new[] { "Id", "Email", "Name", "Password", "UserType" },
                values: new object[,]
                {
                    { 2, "contact@fresh.co.uk", "FreshFarmers", "hashed_pw_2", 0 },
                    { 3, "info@londongreens.co.uk", "LondonGreens", "hashed_pw_3", 0 },
                    { 4, "hello@spital.co.uk", "SpitalFieldsOrg", "hashed_pw_4", 0 },
                    { 5, "team@crystalveg.co.uk", "CrystalVeg", "hashed_pw_5", 0 }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProduceTable_Farms_FarmId",
                table: "ProduceTable");

            migrationBuilder.DropTable(
                name: "Farms");

            migrationBuilder.DropIndex(
                name: "IX_ProduceTable_FarmId",
                table: "ProduceTable");

            migrationBuilder.DeleteData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "FarmId",
                table: "ProduceTable");
        }
    }
}
