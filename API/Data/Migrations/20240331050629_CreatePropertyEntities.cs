using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreatePropertyEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Street = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    State = table.Column<string>(type: "TEXT", nullable: true),
                    ZipCode = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    AddressId = table.Column<int>(type: "INTEGER", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PropertyParameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    YardArea = table.Column<double>(type: "REAL", nullable: false),
                    TotalArea = table.Column<double>(type: "REAL", nullable: false),
                    NumFloors = table.Column<int>(type: "INTEGER", nullable: false),
                    NumRooms = table.Column<int>(type: "INTEGER", nullable: false),
                    NumBedrooms = table.Column<int>(type: "INTEGER", nullable: false),
                    WetPoint = table.Column<bool>(type: "INTEGER", nullable: false),
                    AcceptableSpace = table.Column<bool>(type: "INTEGER", nullable: false),
                    LoggiaSpace = table.Column<double>(type: "REAL", nullable: false),
                    BalconySpace = table.Column<double>(type: "REAL", nullable: false),
                    PorchSpace = table.Column<double>(type: "REAL", nullable: false),
                    StorageRoomSpace = table.Column<double>(type: "REAL", nullable: false),
                    Parking = table.Column<bool>(type: "INTEGER", nullable: false),
                    HotWater = table.Column<string>(type: "TEXT", nullable: true),
                    Heating = table.Column<string>(type: "TEXT", nullable: true),
                    Fireplace = table.Column<bool>(type: "INTEGER", nullable: false),
                    Cellar = table.Column<bool>(type: "INTEGER", nullable: false),
                    Pool = table.Column<bool>(type: "INTEGER", nullable: false),
                    NaturalGas = table.Column<bool>(type: "INTEGER", nullable: false),
                    Alarm = table.Column<bool>(type: "INTEGER", nullable: false),
                    Internet = table.Column<bool>(type: "INTEGER", nullable: false),
                    Water = table.Column<bool>(type: "INTEGER", nullable: false),
                    Sewage = table.Column<bool>(type: "INTEGER", nullable: false),
                    Electricity = table.Column<bool>(type: "INTEGER", nullable: false),
                    Television = table.Column<bool>(type: "INTEGER", nullable: false),
                    PropertyId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyParameters_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_AddressId",
                table: "Properties",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyParameters_PropertyId",
                table: "PropertyParameters",
                column: "PropertyId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyParameters");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
