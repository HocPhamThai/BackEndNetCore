using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.NetCore.Migrations
{
    public partial class initHotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HB_Hotels",
                columns: table => new
                {
                    HotelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HB_Hotels", x => x.HotelID);
                });

            migrationBuilder.CreateTable(
                name: "HB_Rooms",
                columns: table => new
                {
                    RoomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelID = table.Column<int>(type: "int", nullable: false),
                    RoomNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomSquare = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HB_Rooms", x => x.RoomID);
                });

            migrationBuilder.InsertData(
                table: "HB_Hotels",
                columns: new[] { "HotelID", "CreatedDate", "Description", "HotelName" },
                values: new object[,]
                {
                    { -3, new DateTime(2025, 5, 13, 8, 34, 11, 110, DateTimeKind.Local).AddTicks(1712), "Hotel 3", "Hotel 3" },
                    { -2, new DateTime(2025, 5, 13, 8, 34, 11, 110, DateTimeKind.Local).AddTicks(1710), "Hotel 2", "Hotel 2" },
                    { -1, new DateTime(2025, 5, 13, 8, 34, 11, 110, DateTimeKind.Local).AddTicks(1699), "Hotel 1", "Hotel 1" }
                });

            migrationBuilder.InsertData(
                table: "HB_Rooms",
                columns: new[] { "RoomID", "HotelID", "IsActive", "RoomNumber", "RoomSquare" },
                values: new object[,]
                {
                    { -3, 0, 0, "lalala03", 1 },
                    { -2, 0, 0, "lalala02", 1 },
                    { -1, 0, 0, "lalala01", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HB_Hotels");

            migrationBuilder.DropTable(
                name: "HB_Rooms");
        }
    }
}
