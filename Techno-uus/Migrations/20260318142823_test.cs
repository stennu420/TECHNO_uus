using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Techno_uus.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudyGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_StudyGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyGroup_Pupil_LeaderPupilId",
                        column: x => x.LeaderPupilId,
                        principalTable: "Pupil",
                        principalColumn: "Id",
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
                name: "StudyGroup");
        }
    }
}
