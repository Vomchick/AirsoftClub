using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirsoftClub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ClubRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClubRole",
                table: "ClubPlayers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ClubPlayers",
                keyColumns: new[] { "ClubId", "PlayerId" },
                keyValues: new object[] { new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"), new Guid("04dee4c7-4970-42e1-a410-d15b04eba3f6") },
                column: "ClubRole",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ClubPlayers",
                keyColumns: new[] { "ClubId", "PlayerId" },
                keyValues: new object[] { new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"), new Guid("49d02ad1-f647-463e-8239-52379c99b271") },
                column: "ClubRole",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ClubPlayers",
                keyColumns: new[] { "ClubId", "PlayerId" },
                keyValues: new object[] { new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"), new Guid("5952c9f1-e22a-4ca8-833e-b84f701ccc60") },
                column: "ClubRole",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ClubPlayers",
                keyColumns: new[] { "ClubId", "PlayerId" },
                keyValues: new object[] { new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"), new Guid("c500a219-47ac-47ba-83df-98ab98216199") },
                column: "ClubRole",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ClubPlayers",
                keyColumns: new[] { "ClubId", "PlayerId" },
                keyValues: new object[] { new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"), new Guid("f4e1705b-b47f-4edd-9b91-8b375f41298d") },
                column: "ClubRole",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClubRole",
                table: "ClubPlayers");
        }
    }
}
