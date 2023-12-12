using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FroumSite.Migrations
{
    public partial class AddLikeCount_UploadDateRecordToTopicTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LikeCount",
                table: "Topics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UploadDate",
                table: "Topics",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikeCount",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "UploadDate",
                table: "Topics");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadDate",
                value: new DateTime(2023, 12, 7, 3, 25, 4, 800, DateTimeKind.Local).AddTicks(3628));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "UploadDate",
                value: new DateTime(2023, 12, 7, 3, 25, 4, 800, DateTimeKind.Local).AddTicks(4475));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "UploadDate",
                value: new DateTime(2023, 12, 7, 3, 25, 4, 800, DateTimeKind.Local).AddTicks(4500));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "UploadDate",
                value: new DateTime(2023, 12, 7, 3, 25, 4, 800, DateTimeKind.Local).AddTicks(4503));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                column: "UploadDate",
                value: new DateTime(2023, 12, 7, 3, 25, 4, 800, DateTimeKind.Local).AddTicks(4504));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6,
                column: "UploadDate",
                value: new DateTime(2023, 12, 7, 3, 25, 4, 800, DateTimeKind.Local).AddTicks(4506));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7,
                column: "UploadDate",
                value: new DateTime(2023, 12, 7, 3, 25, 4, 800, DateTimeKind.Local).AddTicks(4508));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8,
                column: "UploadDate",
                value: new DateTime(2023, 12, 7, 3, 25, 4, 800, DateTimeKind.Local).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 11,
                column: "UploadDate",
                value: new DateTime(2023, 12, 7, 3, 25, 4, 800, DateTimeKind.Local).AddTicks(4511));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 12,
                column: "UploadDate",
                value: new DateTime(2023, 12, 7, 3, 25, 4, 800, DateTimeKind.Local).AddTicks(4512));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 13,
                column: "UploadDate",
                value: new DateTime(2023, 12, 7, 3, 25, 4, 800, DateTimeKind.Local).AddTicks(4514));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 7, 3, 25, 4, 798, DateTimeKind.Local).AddTicks(4360));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 7, 3, 25, 4, 799, DateTimeKind.Local).AddTicks(2518));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 7, 3, 25, 4, 799, DateTimeKind.Local).AddTicks(2533));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 7, 3, 25, 4, 799, DateTimeKind.Local).AddTicks(2536));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 7, 3, 25, 4, 799, DateTimeKind.Local).AddTicks(2539));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 7, 3, 25, 4, 799, DateTimeKind.Local).AddTicks(2542));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 7, 3, 25, 4, 799, DateTimeKind.Local).AddTicks(2544));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 7, 3, 25, 4, 799, DateTimeKind.Local).AddTicks(2547));
        }
    }
}
