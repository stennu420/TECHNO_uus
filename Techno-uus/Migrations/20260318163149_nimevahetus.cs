using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Techno_uus.Migrations
{
    /// <inheritdoc />
    public partial class nimevahetus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StudyGroup",
                newName: "StudyGroupId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Pupil",
                newName: "PupilId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudyGroupId",
                table: "StudyGroup",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PupilId",
                table: "Pupil",
                newName: "Id");
        }
    }
}
