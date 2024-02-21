using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebDay3.Data.Migrations
{
    /// <inheritdoc />
    public partial class Appoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    AppointmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppointementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AppointmentGuestUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.AppointmentID);
                    table.ForeignKey(
                        name: "FK_Appointment_AspNetUsers_AppointmentGuestUserId",
                        column: x => x.AppointmentGuestUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointment_AspNetUsers_AppointmentUserId",
                        column: x => x.AppointmentUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_AppointmentGuestUserId",
                table: "Appointment",
                column: "AppointmentGuestUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_AppointmentUserId",
                table: "Appointment",
                column: "AppointmentUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");
        }
    }
}
