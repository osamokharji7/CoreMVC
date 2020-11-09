using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dbBackend.Migrations
{
    public partial class Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "designation",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_designation", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    id = table.Column<int>(type: "serial", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelID = table.Column<int>(nullable: true),
                    LastName = table.Column<string>(unicode: false, maxLength: 40, nullable: false),
                    FirstName = table.Column<string>(unicode: false, maxLength: 40, nullable: true),
                    designation = table.Column<int>(nullable: false),
                    joining_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.id);
                    table.ForeignKey(
                        name: "FK__employee__design__1D114BD1",
                        column: x => x.designation,
                        principalTable: "designation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employee_designation_HotelID",
                        column: x => x.HotelID,
                        principalTable: "designation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employee_designation",
                table: "employee",
                column: "designation");

            migrationBuilder.CreateIndex(
                name: "IX_employee_HotelID",
                table: "employee",
                column: "HotelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "designation");
        }
    }
}
