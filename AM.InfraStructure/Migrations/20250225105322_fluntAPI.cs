﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.InfraStructure.Migrations
{
    /// <inheritdoc />
    public partial class fluntAPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassenger_Flights_FlightsFlightId",
                table: "FlightPassenger");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassenger_Passengers_PassengersPassportNumber",
                table: "FlightPassenger");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Planes_planefk",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Planes",
                table: "Planes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger");

            migrationBuilder.RenameTable(
                name: "Planes",
                newName: "MyPlane");

            migrationBuilder.RenameTable(
                name: "FlightPassenger",
                newName: "FP");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "MyPlane",
                newName: "PlaneCapacity");

            migrationBuilder.RenameIndex(
                name: "IX_FlightPassenger_PassengersPassportNumber",
                table: "FP",
                newName: "IX_FP_PassengersPassportNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyPlane",
                table: "MyPlane",
                column: "PlaneId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FP",
                table: "FP",
                columns: new[] { "FlightsFlightId", "PassengersPassportNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_MyPlane_planefk",
                table: "Flights",
                column: "planefk",
                principalTable: "MyPlane",
                principalColumn: "PlaneId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FP_Flights_FlightsFlightId",
                table: "FP",
                column: "FlightsFlightId",
                principalTable: "Flights",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FP_Passengers_PassengersPassportNumber",
                table: "FP",
                column: "PassengersPassportNumber",
                principalTable: "Passengers",
                principalColumn: "PassportNumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_MyPlane_planefk",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_FP_Flights_FlightsFlightId",
                table: "FP");

            migrationBuilder.DropForeignKey(
                name: "FK_FP_Passengers_PassengersPassportNumber",
                table: "FP");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyPlane",
                table: "MyPlane");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FP",
                table: "FP");

            migrationBuilder.RenameTable(
                name: "MyPlane",
                newName: "Planes");

            migrationBuilder.RenameTable(
                name: "FP",
                newName: "FlightPassenger");

            migrationBuilder.RenameColumn(
                name: "PlaneCapacity",
                table: "Planes",
                newName: "Capacity");

            migrationBuilder.RenameIndex(
                name: "IX_FP_PassengersPassportNumber",
                table: "FlightPassenger",
                newName: "IX_FlightPassenger_PassengersPassportNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Planes",
                table: "Planes",
                column: "PlaneId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger",
                columns: new[] { "FlightsFlightId", "PassengersPassportNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPassenger_Flights_FlightsFlightId",
                table: "FlightPassenger",
                column: "FlightsFlightId",
                principalTable: "Flights",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPassenger_Passengers_PassengersPassportNumber",
                table: "FlightPassenger",
                column: "PassengersPassportNumber",
                principalTable: "Passengers",
                principalColumn: "PassportNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Planes_planefk",
                table: "Flights",
                column: "planefk",
                principalTable: "Planes",
                principalColumn: "PlaneId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
