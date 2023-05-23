using AirsoftClub.Domain.Core.Enums;
using AirsoftClub.Domain.Core.Models;
using AirsoftClub.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Infrastructure.Data.InitData
{
    internal static class InitDbData
    {
        public static void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
            new User
            {
                Id = new Guid("e4001e95-3efb-4e74-add8-9b70ec190b5a"),
                Name = "User1",
                Password = HashPasswordHelper.HashPassword("11111111"),
            },
            new User
            {
                Id = new Guid("6f8e30bc-5cbd-4116-9587-e1620df6647f"),
                Name = "User2",
                Password = HashPasswordHelper.HashPassword("11111111"),
            },
            new User
            {
                Id = new Guid("a16ca84c-196a-412d-b2f7-99eadcd5ef54"),
                Name = "User3",
                Password = HashPasswordHelper.HashPassword("11111111"),
            },
            new User
            {
                Id = new Guid("c10b956d-2cf4-4f55-8773-695e94fdcb07"),
                Name = "User4",
                Password = HashPasswordHelper.HashPassword("11111111"),
            },
            new User
            {
                Id = new Guid("960cb14e-d653-46ed-96ba-c75cd8703f4a"),
                Name = "User5",
                Password = HashPasswordHelper.HashPassword("11111111"),
            });

            builder.Entity<Team>().HasData(new Team
            {
                Id = new Guid("901947ca-cd11-4119-8370-3ed82f51e40e"),
                Name = "СК БУЛАТ",
                Description = "Команда не преследует ни каких политических, религиозных и криминальных взглядов. Все командные мероприятия проводятся в рамках действующего законодательства и несут спортивно-оздоровительные и развлекательные цели.\r\n"
            });

            builder.Entity<Player>().HasData(new Player
            {
                Id = new Guid("04dee4c7-4970-42e1-a410-d15b04eba3f6"),
                CallSign = "Шарп",
                GameRole = GameRole.Sniper,
                Description = "Я кустик, кустик, кустик, я вовсе не медведь",
                TeamRole = TeamRole.Member,
                UserId = new Guid("e4001e95-3efb-4e74-add8-9b70ec190b5a"),
                TeamId = new Guid("901947ca-cd11-4119-8370-3ed82f51e40e"),
            },
            new Player
            {
                Id = new Guid("c500a219-47ac-47ba-83df-98ab98216199"),
                CallSign = "Дрон",
                GameRole = GameRole.Stormtrooper,
                Description = "Нет ума - штурмуй дома",
                TeamRole = TeamRole.Member,
                UserId = new Guid("6f8e30bc-5cbd-4116-9587-e1620df6647f"),
                TeamId = new Guid("901947ca-cd11-4119-8370-3ed82f51e40e"),
            },
            new Player
            {
                Id = new Guid("49d02ad1-f647-463e-8239-52379c99b271"),
                CallSign = "Бивень",
                GameRole = GameRole.MachineGunner,
                Description = "Лучшая снайперка - это пулемет",
                UserId = new Guid("a16ca84c-196a-412d-b2f7-99eadcd5ef54"),
            },
            new Player
            {
                Id = new Guid("f4e1705b-b47f-4edd-9b91-8b375f41298d"),
                CallSign = "Ведьмак",
                GameRole = GameRole.Stormtrooper,
                TeamRole = TeamRole.Member,
                UserId = new Guid("c10b956d-2cf4-4f55-8773-695e94fdcb07"),
                TeamId = new Guid("901947ca-cd11-4119-8370-3ed82f51e40e"),
            },
            new Player
            {
                Id = new Guid("5952c9f1-e22a-4ca8-833e-b84f701ccc60"),
                CallSign = "Бро",
                GameRole = GameRole.Stormtrooper,
                Description = "Играй в удовольствие",
                TeamRole = TeamRole.Commander,
                UserId = new Guid("960cb14e-d653-46ed-96ba-c75cd8703f4a"),
                TeamId = new Guid("901947ca-cd11-4119-8370-3ed82f51e40e"),
            });

            builder.Entity<Club>().HasData(new Club
            {
                Id = new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"),
                Name = "Клуб \"БАРС\"",
                Description = "Мы делаем страйкбол! Лазертаг и пейнтбол!",
            });

            builder.Entity<ClubPlayer>().HasData(new ClubPlayer
            {
                ClubId = new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"),
                PlayerId = new Guid("04dee4c7-4970-42e1-a410-d15b04eba3f6"),
                ClubRole = ClubRole.Admin
            },
            new ClubPlayer
            {
                ClubId = new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"),
                PlayerId = new Guid("c500a219-47ac-47ba-83df-98ab98216199"),
                ClubRole = ClubRole.Member
            },
            new ClubPlayer
            {
                ClubId = new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"),
                PlayerId = new Guid("49d02ad1-f647-463e-8239-52379c99b271"),
                ClubRole = ClubRole.Member
            },
            new ClubPlayer
            {
                ClubId = new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"),
                PlayerId = new Guid("f4e1705b-b47f-4edd-9b91-8b375f41298d"),
                ClubRole = ClubRole.Member
            },
            new ClubPlayer
            {
                ClubId = new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"),
                PlayerId = new Guid("5952c9f1-e22a-4ca8-833e-b84f701ccc60"),
                ClubRole = ClubRole.Member
            });

            builder.Entity<FiringField>().HasData(new FiringField
            {
                Id = new Guid("27ec8685-7f27-4c8a-a64a-6be33edf2715"),
                Name = "Сосновая",
                Text = "Открытая, обустроенная площадка , общей площадью 3 Га по адресу ул. Сосновая 18. " +
                "ЛУЧШАЯ ПЛОЩАДКА В ЧЕРТЕ ГОРОДА МИНСК! Площадка полностью освещена, имеется парковка, теплая " +
                "раздевалка, питьевая вода, туалеты, электричество, беседки, мангалы. Это единственная отрытая площадка в г.Минске. " +
                "Разрешено использование на территории пейнтбольных и страйкбольных гранат и дымов.\r\n4 игровые зоны С нами, ваши выходные и " +
                "будни будут незабываемы. ЖДЁМ ВАС В КЛУБЕ БАРС!",
                CreationDt = new DateTime(20, 7, 3),
                IsCovered = false,
                Address = "Минск, ул. Сосновая 18",
                GPS = "53°54’24.3?N 27°39’06.4?E",
                ClubId = new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"),
            },
            new FiringField
            {
                Id = new Guid("db067322-63b7-4d9b-bbba-53a73b2d551b"),
                Name = "Зеленое",
                Text = "Открытая , обустроенная площадка для игры в страйкбол, общей площадью 5 Га по адресу Зеленое п/л Дзержинец. " +
                "На наш взгляд самая интересное место для игры в страйкбол в РБ. На территории, окруженной хвоевым лесом, расположены 22 здания, " +
                "с оптимальным расстоянием друг от друга для игры. На площадке имеются беседки для шашлыка, стоянка для автомобилей. " +
                "Это единственная Отрытая площадка под Минском где разрешено использование страйкбольных гранат и дымов. Площадка расположена " +
                "за Ратомкой в 10 км от МКАД.",
                CreationDt = new DateTime(20, 7, 3),
                IsCovered = false,
                Address = "Минск, ул. Сосновая 18",
                GPS = "53°58’18.4?N 27°17’09.0?E",
                ClubId = new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"),
            });

            builder.Entity<Game>().HasData(new Game
            {
                Id = new Guid("74a9c57e-42e9-43a9-afed-a4f796e20d68"),
                Text = "Площадка \"СОСНА \", Минск, Сосновая 18",
                RentalPrice = 40,
                DefaultPrice = 15,
                CreationDt = new DateTime(23, 4, 13, 11, 40, 0),
                StartDt = new DateTime(23, 4, 16, 10, 0, 0),
                FiringFieldId = new Guid("27ec8685-7f27-4c8a-a64a-6be33edf2715"),
                ClubId = new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"),
                GameType = GameType.SundayGame,
            },
            new Game
            {
                Id = new Guid("c9283cd5-2b80-4c63-9c78-3467b2adeb8e"),
                Text = "Площадка \"СОСНА \", Минск, Сосновая 18",
                RentalPrice = 40,
                DefaultPrice = 15,
                CreationDt = new DateTime(23, 4, 6, 16, 32, 0),
                StartDt = new DateTime(23, 4, 9, 10, 0, 0),
                FiringFieldId = new Guid("27ec8685-7f27-4c8a-a64a-6be33edf2715"),
                ClubId = new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"),
                GameType = GameType.SundayGame,
            });

            builder.Entity<TeamRecord>().HasData(new TeamRecord
            {
                Id = new Guid("49850c6a-3f61-4726-8d52-9a8961be9106"),
                TeamId = new Guid("901947ca-cd11-4119-8370-3ed82f51e40e"),
                GameId = new Guid("74a9c57e-42e9-43a9-afed-a4f796e20d68"),
                PeopleCount = 3,
            },
            new TeamRecord
            {
                Id = new Guid("170c289c-4051-4dd2-8533-d5786b502e4f"),
                TeamId = new Guid("901947ca-cd11-4119-8370-3ed82f51e40e"),
                GameId = new Guid("c9283cd5-2b80-4c63-9c78-3467b2adeb8e"),
                PeopleCount = 4,
            });

            builder.Entity<SoloRecord>().HasData(new SoloRecord
            {
                Id = new Guid("a2ec19a3-6b23-4455-bbfd-1bf5abda8d5e"),
                NeedARent = true,
                PickUp = PickUp.PublicTransport,
                GameId = new Guid("74a9c57e-42e9-43a9-afed-a4f796e20d68"),
                PlayerId = new Guid("49d02ad1-f647-463e-8239-52379c99b271"),
            },
            new SoloRecord
            {
                Id = new Guid("db64e48a-3397-44d9-9aa1-f8407aa0aaf1"),
                NeedARent = true,
                PickUp = PickUp.NeedARide,
                GameId = new Guid("c9283cd5-2b80-4c63-9c78-3467b2adeb8e"),
                PlayerId = new Guid("49d02ad1-f647-463e-8239-52379c99b271"),
            });
        }
    }
}
