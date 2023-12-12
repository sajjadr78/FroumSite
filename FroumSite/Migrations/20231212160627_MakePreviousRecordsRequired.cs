using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FroumSite.Migrations
{
    public partial class MakePreviousRecordsRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 19, 36, 27, 416, DateTimeKind.Local).AddTicks(5030));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 19, 36, 27, 416, DateTimeKind.Local).AddTicks(5844));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 19, 36, 27, 416, DateTimeKind.Local).AddTicks(5871));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 19, 36, 27, 416, DateTimeKind.Local).AddTicks(5917));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 19, 36, 27, 416, DateTimeKind.Local).AddTicks(5920));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 19, 36, 27, 416, DateTimeKind.Local).AddTicks(5922));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 19, 36, 27, 416, DateTimeKind.Local).AddTicks(5924));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 19, 36, 27, 416, DateTimeKind.Local).AddTicks(5926));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 11,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 19, 36, 27, 416, DateTimeKind.Local).AddTicks(5928));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 12,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 19, 36, 27, 416, DateTimeKind.Local).AddTicks(5930));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 13,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 19, 36, 27, 416, DateTimeKind.Local).AddTicks(5932));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 19, 36, 27, 417, DateTimeKind.Local).AddTicks(1094));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 19, 36, 27, 417, DateTimeKind.Local).AddTicks(1644));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 19, 36, 27, 417, DateTimeKind.Local).AddTicks(1664));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 19, 36, 27, 417, DateTimeKind.Local).AddTicks(1666));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 5,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 19, 36, 27, 417, DateTimeKind.Local).AddTicks(1668));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 6,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 19, 36, 27, 417, DateTimeKind.Local).AddTicks(1670));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 12, 19, 36, 27, 414, DateTimeKind.Local).AddTicks(4950));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 12, 19, 36, 27, 415, DateTimeKind.Local).AddTicks(3023));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 12, 19, 36, 27, 415, DateTimeKind.Local).AddTicks(3042));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 12, 19, 36, 27, 415, DateTimeKind.Local).AddTicks(3046));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 12, 19, 36, 27, 415, DateTimeKind.Local).AddTicks(3050));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 12, 19, 36, 27, 415, DateTimeKind.Local).AddTicks(3053));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 12, 19, 36, 27, 415, DateTimeKind.Local).AddTicks(3056));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 12, 19, 36, 27, 415, DateTimeKind.Local).AddTicks(3060));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 19, 30, 30, 920, DateTimeKind.Local).AddTicks(8413));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 19, 30, 30, 920, DateTimeKind.Local).AddTicks(9268));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 19, 30, 30, 920, DateTimeKind.Local).AddTicks(9292));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 19, 30, 30, 920, DateTimeKind.Local).AddTicks(9295));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 19, 30, 30, 920, DateTimeKind.Local).AddTicks(9296));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 19, 30, 30, 920, DateTimeKind.Local).AddTicks(9299));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 19, 30, 30, 920, DateTimeKind.Local).AddTicks(9301));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 19, 30, 30, 920, DateTimeKind.Local).AddTicks(9303));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 11,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 19, 30, 30, 920, DateTimeKind.Local).AddTicks(9304));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 12,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 19, 30, 30, 920, DateTimeKind.Local).AddTicks(9306));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 13,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 19, 30, 30, 920, DateTimeKind.Local).AddTicks(9307));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                column: "UploadDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "UploadDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4,
                column: "UploadDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 5,
                column: "UploadDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 6,
                column: "UploadDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 12, 19, 30, 30, 918, DateTimeKind.Local).AddTicks(4776));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 12, 19, 30, 30, 919, DateTimeKind.Local).AddTicks(6513));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 12, 19, 30, 30, 919, DateTimeKind.Local).AddTicks(6534));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 12, 19, 30, 30, 919, DateTimeKind.Local).AddTicks(6537));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 12, 19, 30, 30, 919, DateTimeKind.Local).AddTicks(6540));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 12, 19, 30, 30, 919, DateTimeKind.Local).AddTicks(6543));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 12, 19, 30, 30, 919, DateTimeKind.Local).AddTicks(6546));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 12, 19, 30, 30, 919, DateTimeKind.Local).AddTicks(6604));
        }
    }
}
