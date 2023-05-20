using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirsoftClub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class playerPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Players",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("04dee4c7-4970-42e1-a410-d15b04eba3f6"),
                column: "Photo",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("49d02ad1-f647-463e-8239-52379c99b271"),
                column: "Photo",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("5952c9f1-e22a-4ca8-833e-b84f701ccc60"),
                column: "Photo",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("c500a219-47ac-47ba-83df-98ab98216199"),
                column: "Photo",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("f4e1705b-b47f-4edd-9b91-8b375f41298d"),
                column: "Photo",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Players");
        }
    }
}
