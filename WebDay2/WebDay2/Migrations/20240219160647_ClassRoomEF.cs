using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebDay2.Migrations
{
    /// <inheritdoc />
    public partial class ClassRoomEF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyClassRoomClassRoomID",
                table: "Students",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClassRoom",
                columns: table => new
                {
                    ClassRoomID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRoom", x => x.ClassRoomID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_MyClassRoomClassRoomID",
                table: "Students",
                column: "MyClassRoomClassRoomID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ClassRoom_MyClassRoomClassRoomID",
                table: "Students",
                column: "MyClassRoomClassRoomID",
                principalTable: "ClassRoom",
                principalColumn: "ClassRoomID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_ClassRoom_MyClassRoomClassRoomID",
                table: "Students");

            migrationBuilder.DropTable(
                name: "ClassRoom");

            migrationBuilder.DropIndex(
                name: "IX_Students_MyClassRoomClassRoomID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MyClassRoomClassRoomID",
                table: "Students");
        }
    }
}
