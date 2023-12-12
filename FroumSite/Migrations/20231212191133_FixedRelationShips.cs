using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FroumSite.Migrations
{
    public partial class FixedRelationShips : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Topics_TopicId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Subjects_SubjectId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Rooms_RoomId",
                table: "Topics");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Users_UserId",
                table: "Topics");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 22, 41, 33, 191, DateTimeKind.Local).AddTicks(5774));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 22, 41, 33, 191, DateTimeKind.Local).AddTicks(6694));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 22, 41, 33, 191, DateTimeKind.Local).AddTicks(6719));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 22, 41, 33, 191, DateTimeKind.Local).AddTicks(6721));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 22, 41, 33, 191, DateTimeKind.Local).AddTicks(6722));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 22, 41, 33, 191, DateTimeKind.Local).AddTicks(6724));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 22, 41, 33, 191, DateTimeKind.Local).AddTicks(6725));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 22, 41, 33, 191, DateTimeKind.Local).AddTicks(6727));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 11,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 22, 41, 33, 191, DateTimeKind.Local).AddTicks(6729));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 12,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 22, 41, 33, 191, DateTimeKind.Local).AddTicks(6730));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 13,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 22, 41, 33, 191, DateTimeKind.Local).AddTicks(6731));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 22, 41, 33, 192, DateTimeKind.Local).AddTicks(1872));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 22, 41, 33, 192, DateTimeKind.Local).AddTicks(2443));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 22, 41, 33, 192, DateTimeKind.Local).AddTicks(2461));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 22, 41, 33, 192, DateTimeKind.Local).AddTicks(2463));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 5,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 22, 41, 33, 192, DateTimeKind.Local).AddTicks(2465));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 6,
                column: "UploadDate",
                value: new DateTime(2023, 12, 12, 22, 41, 33, 192, DateTimeKind.Local).AddTicks(2468));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 12, 22, 41, 33, 189, DateTimeKind.Local).AddTicks(5869));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 12, 22, 41, 33, 190, DateTimeKind.Local).AddTicks(4278));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 12, 22, 41, 33, 190, DateTimeKind.Local).AddTicks(4293));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 12, 22, 41, 33, 190, DateTimeKind.Local).AddTicks(4297));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 12, 22, 41, 33, 190, DateTimeKind.Local).AddTicks(4299));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 12, 22, 41, 33, 190, DateTimeKind.Local).AddTicks(4302));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 12, 22, 41, 33, 190, DateTimeKind.Local).AddTicks(4304));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 12, 22, 41, 33, 190, DateTimeKind.Local).AddTicks(4307));

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Topics_TopicId",
                table: "Posts",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Subjects_SubjectId",
                table: "Rooms",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Rooms_RoomId",
                table: "Topics",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Users_UserId",
                table: "Topics",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Topics_TopicId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Subjects_SubjectId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Rooms_RoomId",
                table: "Topics");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Users_UserId",
                table: "Topics");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Topics_TopicId",
                table: "Posts",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Subjects_SubjectId",
                table: "Rooms",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Rooms_RoomId",
                table: "Topics",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Users_UserId",
                table: "Topics",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
