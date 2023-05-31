using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirsoftClub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_name_to_game : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "FiringFields",
                keyColumn: "Id",
                keyValue: new Guid("27ec8685-7f27-4c8a-a64a-6be33edf2715"),
                column: "CreationDt",
                value: new DateTime(2020, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "FiringFields",
                keyColumn: "Id",
                keyValue: new Guid("db067322-63b7-4d9b-bbba-53a73b2d551b"),
                column: "CreationDt",
                value: new DateTime(2020, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("74a9c57e-42e9-43a9-afed-a4f796e20d68"),
                column: "Name",
                value: "Воскреска");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("c9283cd5-2b80-4c63-9c78-3467b2adeb8e"),
                column: "Name",
                value: "Воскреска");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Games");

            migrationBuilder.UpdateData(
                table: "FiringFields",
                keyColumn: "Id",
                keyValue: new Guid("27ec8685-7f27-4c8a-a64a-6be33edf2715"),
                column: "CreationDt",
                value: new DateTime(20, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "FiringFields",
                keyColumn: "Id",
                keyValue: new Guid("db067322-63b7-4d9b-bbba-53a73b2d551b"),
                column: "CreationDt",
                value: new DateTime(20, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
