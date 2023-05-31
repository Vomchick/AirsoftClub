﻿// <auto-generated />
using System;
using AirsoftClub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AirsoftClub.Infrastructure.Data.Migrations
{
    [DbContext(typeof(AirsoftClubDbContext))]
    [Migration("20230529214549_game_date_correction")]
    partial class game_date_correction
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AirsoftClub.Domain.Core.Models.Club", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("Clubs");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"),
                            Description = "Мы делаем страйкбол! Лазертаг и пейнтбол!",
                            Name = "Клуб \"БАРС\""
                        });
                });

            modelBuilder.Entity("AirsoftClub.Domain.Core.Models.ClubPlayer", b =>
                {
                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClubId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ClubRole")
                        .HasColumnType("int");

                    b.HasKey("PlayerId", "ClubId");

                    b.HasIndex("ClubId");

                    b.ToTable("ClubPlayers");

                    b.HasData(
                        new
                        {
                            PlayerId = new Guid("04dee4c7-4970-42e1-a410-d15b04eba3f6"),
                            ClubId = new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"),
                            ClubRole = 0
                        },
                        new
                        {
                            PlayerId = new Guid("c500a219-47ac-47ba-83df-98ab98216199"),
                            ClubId = new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"),
                            ClubRole = 1
                        },
                        new
                        {
                            PlayerId = new Guid("49d02ad1-f647-463e-8239-52379c99b271"),
                            ClubId = new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"),
                            ClubRole = 1
                        },
                        new
                        {
                            PlayerId = new Guid("f4e1705b-b47f-4edd-9b91-8b375f41298d"),
                            ClubId = new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"),
                            ClubRole = 1
                        },
                        new
                        {
                            PlayerId = new Guid("5952c9f1-e22a-4ca8-833e-b84f701ccc60"),
                            ClubId = new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"),
                            ClubRole = 1
                        });
                });

            modelBuilder.Entity("AirsoftClub.Domain.Core.Models.FiringField", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ClubId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDt")
                        .HasColumnType("datetime2");

                    b.Property<string>("GPS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCovered")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.ToTable("FiringFields");

                    b.HasData(
                        new
                        {
                            Id = new Guid("27ec8685-7f27-4c8a-a64a-6be33edf2715"),
                            Address = "Минск, ул. Сосновая 18",
                            ClubId = new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"),
                            CreationDt = new DateTime(2020, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GPS = "53°54’24.3?N 27°39’06.4?E",
                            IsCovered = false,
                            Name = "Сосновая",
                            Text = "Открытая, обустроенная площадка , общей площадью 3 Га по адресу ул. Сосновая 18. ЛУЧШАЯ ПЛОЩАДКА В ЧЕРТЕ ГОРОДА МИНСК! Площадка полностью освещена, имеется парковка, теплая раздевалка, питьевая вода, туалеты, электричество, беседки, мангалы. Это единственная отрытая площадка в г.Минске. Разрешено использование на территории пейнтбольных и страйкбольных гранат и дымов.\r\n4 игровые зоны С нами, ваши выходные и будни будут незабываемы. ЖДЁМ ВАС В КЛУБЕ БАРС!"
                        },
                        new
                        {
                            Id = new Guid("db067322-63b7-4d9b-bbba-53a73b2d551b"),
                            Address = "Минск, ул. Сосновая 18",
                            ClubId = new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"),
                            CreationDt = new DateTime(2020, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GPS = "53°58’18.4?N 27°17’09.0?E",
                            IsCovered = false,
                            Name = "Зеленое",
                            Text = "Открытая , обустроенная площадка для игры в страйкбол, общей площадью 5 Га по адресу Зеленое п/л Дзержинец. На наш взгляд самая интересное место для игры в страйкбол в РБ. На территории, окруженной хвоевым лесом, расположены 22 здания, с оптимальным расстоянием друг от друга для игры. На площадке имеются беседки для шашлыка, стоянка для автомобилей. Это единственная Отрытая площадка под Минском где разрешено использование страйкбольных гранат и дымов. Площадка расположена за Ратомкой в 10 км от МКАД."
                        });
                });

            modelBuilder.Entity("AirsoftClub.Domain.Core.Models.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClubId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DefaultPrice")
                        .HasColumnType("int");

                    b.Property<Guid?>("FiringFieldId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GameType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RentalPrice")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.HasIndex("FiringFieldId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = new Guid("74a9c57e-42e9-43a9-afed-a4f796e20d68"),
                            ClubId = new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"),
                            CreationDt = new DateTime(2023, 4, 13, 11, 40, 0, 0, DateTimeKind.Unspecified),
                            DefaultPrice = 15,
                            FiringFieldId = new Guid("27ec8685-7f27-4c8a-a64a-6be33edf2715"),
                            GameType = 1,
                            Name = "Воскреска",
                            RentalPrice = 40,
                            StartDt = new DateTime(2023, 4, 16, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            Text = "Площадка \"СОСНА \", Минск, Сосновая 18"
                        },
                        new
                        {
                            Id = new Guid("c9283cd5-2b80-4c63-9c78-3467b2adeb8e"),
                            ClubId = new Guid("7bd411fe-7139-4dd0-9bc2-5b9f00f98317"),
                            CreationDt = new DateTime(2023, 4, 6, 16, 32, 0, 0, DateTimeKind.Unspecified),
                            DefaultPrice = 15,
                            FiringFieldId = new Guid("27ec8685-7f27-4c8a-a64a-6be33edf2715"),
                            GameType = 1,
                            Name = "Воскреска",
                            RentalPrice = 40,
                            StartDt = new DateTime(2023, 4, 9, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            Text = "Площадка \"СОСНА \", Минск, Сосновая 18"
                        });
                });

            modelBuilder.Entity("AirsoftClub.Domain.Core.Models.InfoPost.ClubInfoPost", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("ClubInfoPosts");
                });

            modelBuilder.Entity("AirsoftClub.Domain.Core.Models.InfoPost.PlayerInfoPost", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("PlayerInfoPosts");
                });

            modelBuilder.Entity("AirsoftClub.Domain.Core.Models.InfoPost.TeamInfoPost", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("TeamInfoPosts");
                });

            modelBuilder.Entity("AirsoftClub.Domain.Core.Models.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CallSign")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GameRole")
                        .HasColumnType("int");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid?>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("TeamRole")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            Id = new Guid("04dee4c7-4970-42e1-a410-d15b04eba3f6"),
                            CallSign = "Шарп",
                            Description = "Я кустик, кустик, кустик, я вовсе не медведь",
                            GameRole = 1,
                            TeamId = new Guid("901947ca-cd11-4119-8370-3ed82f51e40e"),
                            TeamRole = 2,
                            UserId = new Guid("e4001e95-3efb-4e74-add8-9b70ec190b5a")
                        },
                        new
                        {
                            Id = new Guid("c500a219-47ac-47ba-83df-98ab98216199"),
                            CallSign = "Дрон",
                            Description = "Нет ума - штурмуй дома",
                            GameRole = 0,
                            TeamId = new Guid("901947ca-cd11-4119-8370-3ed82f51e40e"),
                            TeamRole = 2,
                            UserId = new Guid("6f8e30bc-5cbd-4116-9587-e1620df6647f")
                        },
                        new
                        {
                            Id = new Guid("49d02ad1-f647-463e-8239-52379c99b271"),
                            CallSign = "Бивень",
                            Description = "Лучшая снайперка - это пулемет",
                            GameRole = 3,
                            UserId = new Guid("a16ca84c-196a-412d-b2f7-99eadcd5ef54")
                        },
                        new
                        {
                            Id = new Guid("f4e1705b-b47f-4edd-9b91-8b375f41298d"),
                            CallSign = "Ведьмак",
                            GameRole = 0,
                            TeamId = new Guid("901947ca-cd11-4119-8370-3ed82f51e40e"),
                            TeamRole = 2,
                            UserId = new Guid("c10b956d-2cf4-4f55-8773-695e94fdcb07")
                        },
                        new
                        {
                            Id = new Guid("5952c9f1-e22a-4ca8-833e-b84f701ccc60"),
                            CallSign = "Бро",
                            Description = "Играй в удовольствие",
                            GameRole = 0,
                            TeamId = new Guid("901947ca-cd11-4119-8370-3ed82f51e40e"),
                            TeamRole = 0,
                            UserId = new Guid("960cb14e-d653-46ed-96ba-c75cd8703f4a")
                        });
                });

            modelBuilder.Entity("AirsoftClub.Domain.Core.Models.SoloRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("NeedARent")
                        .HasColumnType("bit");

                    b.Property<int>("PickUp")
                        .HasColumnType("int");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("SoloRecords");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a2ec19a3-6b23-4455-bbfd-1bf5abda8d5e"),
                            GameId = new Guid("74a9c57e-42e9-43a9-afed-a4f796e20d68"),
                            NeedARent = true,
                            PickUp = 0,
                            PlayerId = new Guid("49d02ad1-f647-463e-8239-52379c99b271")
                        },
                        new
                        {
                            Id = new Guid("db64e48a-3397-44d9-9aa1-f8407aa0aaf1"),
                            GameId = new Guid("c9283cd5-2b80-4c63-9c78-3467b2adeb8e"),
                            NeedARent = true,
                            PickUp = 1,
                            PlayerId = new Guid("49d02ad1-f647-463e-8239-52379c99b271")
                        });
                });

            modelBuilder.Entity("AirsoftClub.Domain.Core.Models.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = new Guid("901947ca-cd11-4119-8370-3ed82f51e40e"),
                            Description = "Команда не преследует ни каких политических, религиозных и криминальных взглядов. Все командные мероприятия проводятся в рамках действующего законодательства и несут спортивно-оздоровительные и развлекательные цели.\r\n",
                            Name = "СК БУЛАТ"
                        });
                });

            modelBuilder.Entity("AirsoftClub.Domain.Core.Models.TeamRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PeopleCount")
                        .HasColumnType("int");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamRecords");

                    b.HasData(
                        new
                        {
                            Id = new Guid("49850c6a-3f61-4726-8d52-9a8961be9106"),
                            GameId = new Guid("74a9c57e-42e9-43a9-afed-a4f796e20d68"),
                            PeopleCount = 3,
                            TeamId = new Guid("901947ca-cd11-4119-8370-3ed82f51e40e")
                        },
                        new
                        {
                            Id = new Guid("170c289c-4051-4dd2-8533-d5786b502e4f"),
                            GameId = new Guid("c9283cd5-2b80-4c63-9c78-3467b2adeb8e"),
                            PeopleCount = 4,
                            TeamId = new Guid("901947ca-cd11-4119-8370-3ed82f51e40e")
                        });
                });

            modelBuilder.Entity("AirsoftClub.Domain.Core.Models.TeamRequest", b =>
                {
                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("TeamRequests");
                });

            modelBuilder.Entity("AirsoftClub.Domain.Core.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e4001e95-3efb-4e74-add8-9b70ec190b5a"),
                            Name = "User1",
                            Password = "ee79976c9380d5e337fc1c095ece8c8f22f91f306ceeb161fa51fecede2c4ba1"
                        },
                        new
                        {
                            Id = new Guid("6f8e30bc-5cbd-4116-9587-e1620df6647f"),
                            Name = "User2",
                            Password = "ee79976c9380d5e337fc1c095ece8c8f22f91f306ceeb161fa51fecede2c4ba1"
                        },
                        new
                        {
                            Id = new Guid("a16ca84c-196a-412d-b2f7-99eadcd5ef54"),
                            Name = "User3",
                            Password = "ee79976c9380d5e337fc1c095ece8c8f22f91f306ceeb161fa51fecede2c4ba1"
                        },
                        new
                        {
                            Id = new Guid("c10b956d-2cf4-4f55-8773-695e94fdcb07"),
                            Name = "User4",
                            Password = "ee79976c9380d5e337fc1c095ece8c8f22f91f306ceeb161fa51fecede2c4ba1"
                        },
                        new
                        {
                            Id = new Guid("960cb14e-d653-46ed-96ba-c75cd8703f4a"),
                            Name = "User5",
                            Password = "ee79976c9380d5e337fc1c095ece8c8f22f91f306ceeb161fa51fecede2c4ba1"
                        });
                });

            modelBuilder.Entity("AirsoftClub.Domain.Core.Models.ClubPlayer", b =>
                {
                    b.HasOne("AirsoftClub.Domain.Core.Models.Club", "Club")
                        .WithMany("ClubPlayers")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirsoftClub.Domain.Core.Models.Player", "Player")
                        .WithMany("ClubPlayers")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Club");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("AirsoftClub.Domain.Core.Models.FiringField", b =>
                {
                    b.HasOne("AirsoftClub.Domain.Core.Models.Club", "Club")
                        .WithMany("FiringFields")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Club");
                });

            modelBuilder.Entity("AirsoftClub.Domain.Core.Models.Game", b =>
                {
                    b.HasOne("AirsoftClub.Domain.Core.Models.Club", "Club")
                        .WithMany("Games")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirsoftClub.Domain.Core.Models.FiringField", "FiringField")
                        .WithMany("Games")
                        .HasForeignKey("FiringFieldId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Club");

                    b.Navigation("FiringField");
                });

            modelBuilder.Entity("AirsoftClub.Domain.Core.Models.InfoPost.ClubInfoPost", b =>
                {
                    b.HasOne("AirsoftClub.Domain.Core.Models.Club", "Author")
                        .WithMany("ClubInfoPosts")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("AirsoftClub.Domain.Core.Models.InfoPost.PlayerInfoPost", b =>
                {
                    b.HasOne("AirsoftClub.Domain.Core.Models.Player", "Author")
                        .WithMany("PlayerInfoPosts")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("AirsoftClub.Domain.Core.Models.InfoPost.TeamInfoPost", b =>
                {
                    b.HasOne("AirsoftClub.Domain.Core.Models.Team", "Author")
                        .WithMany("TeamInfoPosts")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("AirsoftClub.Domain.Core.Models.Player", b =>
                {
                    b.HasOne("AirsoftClub.Domain.Core.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("AirsoftClub.Domain.Core.Models.User", "User")
                        .WithOne("Player")
                        .HasForeignKey("AirsoftClub.Domain.Core.Models.Player", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AirsoftClub.Domain.Core.Models.SoloRecord", b =>
                {
                    b.HasOne("AirsoftClub.Domain.Core.Models.Game", "Game")
                        .WithMany("SoloRecords")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirsoftClub.Domain.Core.Models.Player", "Player")
                        .WithMany("SoloRecords")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("AirsoftClub.Domain.Core.Models.TeamRecord", b =>
                {
                    b.HasOne("AirsoftClub.Domain.Core.Models.Game", "Game")
                        .WithMany("TeamRecords")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirsoftClub.Domain.Core.Models.Team", "Team")
                        .WithMany("TeamRecords")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("AirsoftClub.Domain.Core.Models.TeamRequest", b =>
                {
                    b.HasOne("AirsoftClub.Domain.Core.Models.Player", "Player")
                        .WithMany("TeamRequests")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirsoftClub.Domain.Core.Models.Team", "Team")
                        .WithMany("TeamRequests")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("AirsoftClub.Domain.Core.Models.Club", b =>
                {
                    b.Navigation("ClubInfoPosts");

                    b.Navigation("ClubPlayers");

                    b.Navigation("FiringFields");

                    b.Navigation("Games");
                });

            modelBuilder.Entity("AirsoftClub.Domain.Core.Models.FiringField", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("AirsoftClub.Domain.Core.Models.Game", b =>
                {
                    b.Navigation("SoloRecords");

                    b.Navigation("TeamRecords");
                });

            modelBuilder.Entity("AirsoftClub.Domain.Core.Models.Player", b =>
                {
                    b.Navigation("ClubPlayers");

                    b.Navigation("PlayerInfoPosts");

                    b.Navigation("SoloRecords");

                    b.Navigation("TeamRequests");
                });

            modelBuilder.Entity("AirsoftClub.Domain.Core.Models.Team", b =>
                {
                    b.Navigation("Players");

                    b.Navigation("TeamInfoPosts");

                    b.Navigation("TeamRecords");

                    b.Navigation("TeamRequests");
                });

            modelBuilder.Entity("AirsoftClub.Domain.Core.Models.User", b =>
                {
                    b.Navigation("Player")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
