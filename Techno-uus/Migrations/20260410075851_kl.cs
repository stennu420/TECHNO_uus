using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Techno_uus.Migrations
{
    /// <inheritdoc />
    public partial class kl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArtGallery",
                columns: table => new
                {
                    ArtId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PupilName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PupilId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtWorkTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtWorkDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtGallery", x => x.ArtId);
                });

            migrationBuilder.CreateTable(
                name: "GalleryImages",
                columns: table => new
                {
                    ImageID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ListID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryImages", x => x.ImageID);
                });

            migrationBuilder.CreateTable(
                name: "Mentors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pupil",
                columns: table => new
                {
                    PupilId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasEnrolleddAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DayOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCode = table.Column<int>(type: "int", nullable: false),
                    GamerTag = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pupil", x => x.PupilId);
                });

            migrationBuilder.CreateTable(
                name: "SportsGames",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SportName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstTeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeTeamPlayers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondTeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondTeamPlayers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameResult = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HalfTimeScore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondHalfTimeScore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatchEndScore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HalfTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MatchStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportsGames", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "StudyGroup",
                columns: table => new
                {
                    StudyGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudyStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudyEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaderPupilId = table.Column<int>(type: "int", nullable: false),
                    ClassroomInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyGroup", x => x.StudyGroupId);
                    table.ForeignKey(
                        name: "FK_StudyGroup_Pupil_LeaderPupilId",
                        column: x => x.LeaderPupilId,
                        principalTable: "Pupil",
                        principalColumn: "PupilId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudyGroup_LeaderPupilId",
                table: "StudyGroup",
                column: "LeaderPupilId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtGallery");

            migrationBuilder.DropTable(
                name: "GalleryImages");

            migrationBuilder.DropTable(
                name: "Mentors");

            migrationBuilder.DropTable(
                name: "SportsGames");

            migrationBuilder.DropTable(
                name: "StudyGroup");

            migrationBuilder.DropTable(
                name: "Pupil");
        }
    }
}
