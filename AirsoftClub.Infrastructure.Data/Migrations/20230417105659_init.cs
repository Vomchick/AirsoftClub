using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AirsoftClub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClubInfoPosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubInfoPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClubInfoPosts_Clubs_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FiringFields",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCovered = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiringFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FiringFields_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamInfoPosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamInfoPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamInfoPosts_Teams_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CallSign = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    GameRole = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamRole = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Players_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentalPrice = table.Column<int>(type: "int", nullable: false),
                    DefaultPrice = table.Column<int>(type: "int", nullable: false),
                    StartDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GameType = table.Column<int>(type: "int", nullable: false),
                    FiringFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_FiringFields_FiringFieldId",
                        column: x => x.FiringFieldId,
                        principalTable: "FiringFields",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClubPlayers",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubPlayers", x => new { x.PlayerId, x.ClubId });
                    table.ForeignKey(
                        name: "FK_ClubPlayers_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClubPlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerInfoPosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerInfoPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerInfoPosts_Players_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoloRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NeedARent = table.Column<bool>(type: "bit", nullable: false),
                    PickUp = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoloRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoloRecords_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoloRecords_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeopleCount = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamRecords_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamRecords_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"), "Мы делаем страйкбол! Лазертаг и пейнтбол!", "Клуб \"БАРС\"" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("901947ca-cd11-4119-8370-3ed82f51e40e"), "Команда не преследует ни каких политических, религиозных и криминальных взглядов. Все командные мероприятия проводятся в рамках действующего законодательства и несут спортивно-оздоровительные и развлекательные цели.\r\n", "СК БУЛАТ" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password" },
                values: new object[,]
                {
                    { new Guid("6f8e30bc-5cbd-4116-9587-e1620df6647f"), "User2", "11111111" },
                    { new Guid("960cb14e-d653-46ed-96ba-c75cd8703f4a"), "User5", "11111111" },
                    { new Guid("a16ca84c-196a-412d-b2f7-99eadcd5ef54"), "User3", "11111111" },
                    { new Guid("c10b956d-2cf4-4f55-8773-695e94fdcb07"), "User4", "11111111" },
                    { new Guid("e4001e95-3efb-4e74-add8-9b70ec190b5a"), "User1", "11111111" }
                });

            migrationBuilder.InsertData(
                table: "FiringFields",
                columns: new[] { "Id", "Address", "ClubId", "CreationDt", "GPS", "IsCovered", "Name", "Photo", "Text" },
                values: new object[,]
                {
                    { new Guid("27ec8685-7f27-4c8a-a64a-6be33edf2715"), "Минск, ул. Сосновая 18", new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"), new DateTime(20, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "53°54’24.3?N 27°39’06.4?E", false, "Сосновая", null, "Открытая, обустроенная площадка , общей площадью 3 Га по адресу ул. Сосновая 18. ЛУЧШАЯ ПЛОЩАДКА В ЧЕРТЕ ГОРОДА МИНСК! Площадка полностью освещена, имеется парковка, теплая раздевалка, питьевая вода, туалеты, электричество, беседки, мангалы. Это единственная отрытая площадка в г.Минске. Разрешено использование на территории пейнтбольных и страйкбольных гранат и дымов.\r\n4 игровые зоны С нами, ваши выходные и будни будут незабываемы. ЖДЁМ ВАС В КЛУБЕ БАРС!" },
                    { new Guid("db067322-63b7-4d9b-bbba-53a73b2d551b"), "Минск, ул. Сосновая 18", new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"), new DateTime(20, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "53°58’18.4?N 27°17’09.0?E", false, "Зеленое", null, "Открытая , обустроенная площадка для игры в страйкбол, общей площадью 5 Га по адресу Зеленое п/л Дзержинец. На наш взгляд самая интересное место для игры в страйкбол в РБ. На территории, окруженной хвоевым лесом, расположены 22 здания, с оптимальным расстоянием друг от друга для игры. На площадке имеются беседки для шашлыка, стоянка для автомобилей. Это единственная Отрытая площадка под Минском где разрешено использование страйкбольных гранат и дымов. Площадка расположена за Ратомкой в 10 км от МКАД." }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "CallSign", "Description", "GameRole", "TeamId", "TeamRole", "UserId" },
                values: new object[,]
                {
                    { new Guid("04dee4c7-4970-42e1-a410-d15b04eba3f6"), "Шарп", "Я кустик, кустик, кустик, я вовсе не медведь", 1, new Guid("901947ca-cd11-4119-8370-3ed82f51e40e"), 2, new Guid("e4001e95-3efb-4e74-add8-9b70ec190b5a") },
                    { new Guid("49d02ad1-f647-463e-8239-52379c99b271"), "Бивень", "Лучшая снайперка - это пулемет", 3, null, null, new Guid("a16ca84c-196a-412d-b2f7-99eadcd5ef54") },
                    { new Guid("5952c9f1-e22a-4ca8-833e-b84f701ccc60"), "Бро", "Играй в удовольствие", 0, new Guid("901947ca-cd11-4119-8370-3ed82f51e40e"), 0, new Guid("960cb14e-d653-46ed-96ba-c75cd8703f4a") },
                    { new Guid("c500a219-47ac-47ba-83df-98ab98216199"), "Дрон", "Нет ума - штурмуй дома", 0, new Guid("901947ca-cd11-4119-8370-3ed82f51e40e"), 2, new Guid("6f8e30bc-5cbd-4116-9587-e1620df6647f") },
                    { new Guid("f4e1705b-b47f-4edd-9b91-8b375f41298d"), "Ведьмак", null, 0, new Guid("901947ca-cd11-4119-8370-3ed82f51e40e"), 2, new Guid("c10b956d-2cf4-4f55-8773-695e94fdcb07") }
                });

            migrationBuilder.InsertData(
                table: "ClubPlayers",
                columns: new[] { "ClubId", "PlayerId" },
                values: new object[,]
                {
                    { new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"), new Guid("04dee4c7-4970-42e1-a410-d15b04eba3f6") },
                    { new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"), new Guid("49d02ad1-f647-463e-8239-52379c99b271") },
                    { new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"), new Guid("5952c9f1-e22a-4ca8-833e-b84f701ccc60") },
                    { new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"), new Guid("c500a219-47ac-47ba-83df-98ab98216199") },
                    { new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"), new Guid("f4e1705b-b47f-4edd-9b91-8b375f41298d") }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "ClubId", "CreationDt", "DefaultPrice", "FiringFieldId", "GameType", "Photo", "RentalPrice", "StartDt", "Text" },
                values: new object[,]
                {
                    { new Guid("74a9c57e-42e9-43a9-afed-a4f796e20d68"), new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"), new DateTime(23, 4, 13, 11, 40, 0, 0, DateTimeKind.Unspecified), 15, new Guid("27ec8685-7f27-4c8a-a64a-6be33edf2715"), 1, null, 40, new DateTime(23, 4, 16, 10, 0, 0, 0, DateTimeKind.Unspecified), "Площадка \"СОСНА \", Минск, Сосновая 18" },
                    { new Guid("c9283cd5-2b80-4c63-9c78-3467b2adeb8e"), new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"), new DateTime(23, 4, 6, 16, 32, 0, 0, DateTimeKind.Unspecified), 15, new Guid("27ec8685-7f27-4c8a-a64a-6be33edf2715"), 1, null, 40, new DateTime(23, 4, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), "Площадка \"СОСНА \", Минск, Сосновая 18" }
                });

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
                name: "IX_ClubInfoPosts_AuthorId",
                table: "ClubInfoPosts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubPlayers_ClubId",
                table: "ClubPlayers",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_FiringFields_ClubId",
                table: "FiringFields",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_ClubId",
                table: "Games",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_FiringFieldId",
                table: "Games",
                column: "FiringFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerInfoPosts_AuthorId",
                table: "PlayerInfoPosts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserId",
                table: "Players",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SoloRecords_GameId",
                table: "SoloRecords",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_SoloRecords_PlayerId",
                table: "SoloRecords",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamInfoPosts_AuthorId",
                table: "TeamInfoPosts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamRecords_GameId",
                table: "TeamRecords",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamRecords_TeamId",
                table: "TeamRecords",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClubInfoPosts");

            migrationBuilder.DropTable(
                name: "ClubPlayers");

            migrationBuilder.DropTable(
                name: "PlayerInfoPosts");

            migrationBuilder.DropTable(
                name: "SoloRecords");

            migrationBuilder.DropTable(
                name: "TeamInfoPosts");

            migrationBuilder.DropTable(
                name: "TeamRecords");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "FiringFields");

            migrationBuilder.DropTable(
                name: "Clubs");
        }
    }
}
