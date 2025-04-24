using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.InfraStructure.Migrations
{
    /// <inheritdoc />
    public partial class tpt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmploymentDate",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "Function",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "HealthInformation",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "PassengerType",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Passengers");

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    PassportNumber = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    EmploymentDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Function = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.PassportNumber);
                    table.ForeignKey(
                        name: "FK_Staffs_Passengers_PassportNumber",
                        column: x => x.PassportNumber,
                        principalTable: "Passengers",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "travellerss",
                columns: table => new
                {
                    PassportNumber = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    HealthInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_travellerss", x => x.PassportNumber);
                    table.ForeignKey(
                        name: "FK_travellerss_Passengers_PassportNumber",
                        column: x => x.PassportNumber,
                        principalTable: "Passengers",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "travellerss");

            migrationBuilder.AddColumn<DateTime>(
                name: "EmploymentDate",
                table: "Passengers",
                type: "Date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Function",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HealthInformation",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PassengerType",
                table: "Passengers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Salary",
                table: "Passengers",
                type: "float",
                nullable: true);
        }
    }
}
