using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirsoftClub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class game_date_correction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("74a9c57e-42e9-43a9-afed-a4f796e20d68"),
                columns: new[] { "CreationDt", "StartDt" },
                values: new object[] { new DateTime(2023, 4, 13, 11, 40, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 16, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("c9283cd5-2b80-4c63-9c78-3467b2adeb8e"),
                columns: new[] { "CreationDt", "StartDt" },
                values: new object[] { new DateTime(2023, 4, 6, 16, 32, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 9, 10, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("74a9c57e-42e9-43a9-afed-a4f796e20d68"),
                columns: new[] { "CreationDt", "StartDt" },
                values: new object[] { new DateTime(23, 4, 13, 11, 40, 0, 0, DateTimeKind.Unspecified), new DateTime(23, 4, 16, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("c9283cd5-2b80-4c63-9c78-3467b2adeb8e"),
                columns: new[] { "CreationDt", "StartDt" },
                values: new object[] { new DateTime(23, 4, 6, 16, 32, 0, 0, DateTimeKind.Unspecified), new DateTime(23, 4, 9, 10, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
