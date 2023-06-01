using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AirsoftClub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class records_key_change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamRecords",
                table: "TeamRecords");

            migrationBuilder.DropIndex(
                name: "IX_TeamRecords_TeamId",
                table: "TeamRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SoloRecords",
                table: "SoloRecords");

            migrationBuilder.DropIndex(
                name: "IX_SoloRecords_PlayerId",
                table: "SoloRecords");

            migrationBuilder.DeleteData(
                table: "SoloRecords",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("a2ec19a3-6b23-4455-bbfd-1bf5abda8d5e"));

            migrationBuilder.DeleteData(
                table: "SoloRecords",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("db64e48a-3397-44d9-9aa1-f8407aa0aaf1"));

            migrationBuilder.DeleteData(
                table: "TeamRecords",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("170c289c-4051-4dd2-8533-d5786b502e4f"));

            migrationBuilder.DeleteData(
                table: "TeamRecords",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("49850c6a-3f61-4726-8d52-9a8961be9106"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TeamRecords");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SoloRecords");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamRecords",
                table: "TeamRecords",
                columns: new[] { "TeamId", "GameId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoloRecords",
                table: "SoloRecords",
                columns: new[] { "PlayerId", "GameId" });

            migrationBuilder.InsertData(
                table: "SoloRecords",
                columns: new[] { "GameId", "PlayerId", "NeedARent", "PickUp" },
                values: new object[,]
                {
                    { new Guid("74a9c57e-42e9-43a9-afed-a4f796e20d68"), new Guid("49d02ad1-f647-463e-8239-52379c99b271"), true, 0 },
                    { new Guid("c9283cd5-2b80-4c63-9c78-3467b2adeb8e"), new Guid("49d02ad1-f647-463e-8239-52379c99b271"), true, 1 }
                });

            migrationBuilder.InsertData(
                table: "TeamRecords",
                columns: new[] { "GameId", "TeamId", "PeopleCount" },
                values: new object[,]
                {
                    { new Guid("74a9c57e-42e9-43a9-afed-a4f796e20d68"), new Guid("901947ca-cd11-4119-8370-3ed82f51e40e"), 3 },
                    { new Guid("c9283cd5-2b80-4c63-9c78-3467b2adeb8e"), new Guid("901947ca-cd11-4119-8370-3ed82f51e40e"), 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamRecords",
                table: "TeamRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SoloRecords",
                table: "SoloRecords");

            migrationBuilder.DeleteData(
                table: "SoloRecords",
                keyColumns: new[] { "GameId", "PlayerId" },
                keyValues: new object[] { new Guid("74a9c57e-42e9-43a9-afed-a4f796e20d68"), new Guid("49d02ad1-f647-463e-8239-52379c99b271") });

            migrationBuilder.DeleteData(
                table: "SoloRecords",
                keyColumns: new[] { "GameId", "PlayerId" },
                keyValues: new object[] { new Guid("c9283cd5-2b80-4c63-9c78-3467b2adeb8e"), new Guid("49d02ad1-f647-463e-8239-52379c99b271") });

            migrationBuilder.DeleteData(
                table: "TeamRecords",
                keyColumns: new[] { "GameId", "TeamId" },
                keyValues: new object[] { new Guid("74a9c57e-42e9-43a9-afed-a4f796e20d68"), new Guid("901947ca-cd11-4119-8370-3ed82f51e40e") });

            migrationBuilder.DeleteData(
                table: "TeamRecords",
                keyColumns: new[] { "GameId", "TeamId" },
                keyValues: new object[] { new Guid("c9283cd5-2b80-4c63-9c78-3467b2adeb8e"), new Guid("901947ca-cd11-4119-8370-3ed82f51e40e") });

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "TeamRecords",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "SoloRecords",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamRecords",
                table: "TeamRecords",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoloRecords",
                table: "SoloRecords",
                column: "Id");

            migrationBuilder.InsertData(
                table: "SoloRecords",
                columns: new[] { "Id", "GameId", "NeedARent", "PickUp", "PlayerId" },
                values: new object[,]
                {
                    { new Guid("a2ec19a3-6b23-4455-bbfd-1bf5abda8d5e"), new Guid("74a9c57e-42e9-43a9-afed-a4f796e20d68"), true, 0, new Guid("49d02ad1-f647-463e-8239-52379c99b271") },
                    { new Guid("db64e48a-3397-44d9-9aa1-f8407aa0aaf1"), new Guid("c9283cd5-2b80-4c63-9c78-3467b2adeb8e"), true, 1, new Guid("49d02ad1-f647-463e-8239-52379c99b271") }
                });

            migrationBuilder.InsertData(
                table: "TeamRecords",
                columns: new[] { "Id", "GameId", "PeopleCount", "TeamId" },
                values: new object[,]
                {
                    { new Guid("170c289c-4051-4dd2-8533-d5786b502e4f"), new Guid("c9283cd5-2b80-4c63-9c78-3467b2adeb8e"), 4, new Guid("901947ca-cd11-4119-8370-3ed82f51e40e") },
                    { new Guid("49850c6a-3f61-4726-8d52-9a8961be9106"), new Guid("74a9c57e-42e9-43a9-afed-a4f796e20d68"), 3, new Guid("901947ca-cd11-4119-8370-3ed82f51e40e") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamRecords_TeamId",
                table: "TeamRecords",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_SoloRecords_PlayerId",
                table: "SoloRecords",
                column: "PlayerId");
        }
    }
}
