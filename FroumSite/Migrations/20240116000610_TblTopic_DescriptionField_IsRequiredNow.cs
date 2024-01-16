using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FroumSite.Migrations
{
    public partial class TblTopic_DescriptionField_IsRequiredNow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Topics",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadDate",
                value: new DateTime(2024, 1, 16, 3, 36, 10, 82, DateTimeKind.Local).AddTicks(9579));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "UploadDate",
                value: new DateTime(2024, 1, 16, 3, 36, 10, 83, DateTimeKind.Local).AddTicks(510));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "UploadDate",
                value: new DateTime(2024, 1, 16, 3, 36, 10, 83, DateTimeKind.Local).AddTicks(537));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "UploadDate",
                value: new DateTime(2024, 1, 16, 3, 36, 10, 83, DateTimeKind.Local).AddTicks(539));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                column: "UploadDate",
                value: new DateTime(2024, 1, 16, 3, 36, 10, 83, DateTimeKind.Local).AddTicks(541));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6,
                column: "UploadDate",
                value: new DateTime(2024, 1, 16, 3, 36, 10, 83, DateTimeKind.Local).AddTicks(543));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7,
                column: "UploadDate",
                value: new DateTime(2024, 1, 16, 3, 36, 10, 83, DateTimeKind.Local).AddTicks(544));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8,
                column: "UploadDate",
                value: new DateTime(2024, 1, 16, 3, 36, 10, 83, DateTimeKind.Local).AddTicks(546));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 11,
                column: "UploadDate",
                value: new DateTime(2024, 1, 16, 3, 36, 10, 83, DateTimeKind.Local).AddTicks(548));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 12,
                column: "UploadDate",
                value: new DateTime(2024, 1, 16, 3, 36, 10, 83, DateTimeKind.Local).AddTicks(549));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 13,
                column: "UploadDate",
                value: new DateTime(2024, 1, 16, 3, 36, 10, 83, DateTimeKind.Local).AddTicks(551));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadDate",
                value: new DateTime(2024, 1, 16, 3, 36, 10, 83, DateTimeKind.Local).AddTicks(5117));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                column: "UploadDate",
                value: new DateTime(2024, 1, 16, 3, 36, 10, 83, DateTimeKind.Local).AddTicks(5627));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "UploadDate",
                value: new DateTime(2024, 1, 16, 3, 36, 10, 83, DateTimeKind.Local).AddTicks(5646));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4,
                column: "UploadDate",
                value: new DateTime(2024, 1, 16, 3, 36, 10, 83, DateTimeKind.Local).AddTicks(5648));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 5,
                column: "UploadDate",
                value: new DateTime(2024, 1, 16, 3, 36, 10, 83, DateTimeKind.Local).AddTicks(5649));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 6,
                column: "UploadDate",
                value: new DateTime(2024, 1, 16, 3, 36, 10, 83, DateTimeKind.Local).AddTicks(5651));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2024, 1, 16, 3, 36, 10, 81, DateTimeKind.Local).AddTicks(4));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "RegisterDate",
                value: new DateTime(2024, 1, 16, 3, 36, 10, 81, DateTimeKind.Local).AddTicks(9355));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "RegisterDate",
                value: new DateTime(2024, 1, 16, 3, 36, 10, 81, DateTimeKind.Local).AddTicks(9373));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "RegisterDate",
                value: new DateTime(2024, 1, 16, 3, 36, 10, 81, DateTimeKind.Local).AddTicks(9377));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "RegisterDate",
                value: new DateTime(2024, 1, 16, 3, 36, 10, 81, DateTimeKind.Local).AddTicks(9380));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "RegisterDate",
                value: new DateTime(2024, 1, 16, 3, 36, 10, 81, DateTimeKind.Local).AddTicks(9382));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "RegisterDate",
                value: new DateTime(2024, 1, 16, 3, 36, 10, 81, DateTimeKind.Local).AddTicks(9385));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "RegisterDate",
                value: new DateTime(2024, 1, 16, 3, 36, 10, 81, DateTimeKind.Local).AddTicks(9387));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Topics",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 300);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadDate",
                value: new DateTime(2023, 12, 13, 0, 34, 10, 859, DateTimeKind.Local).AddTicks(6713));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "UploadDate",
                value: new DateTime(2023, 12, 13, 0, 34, 10, 859, DateTimeKind.Local).AddTicks(7559));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "UploadDate",
                value: new DateTime(2023, 12, 13, 0, 34, 10, 859, DateTimeKind.Local).AddTicks(7583));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "UploadDate",
                value: new DateTime(2023, 12, 13, 0, 34, 10, 859, DateTimeKind.Local).AddTicks(7585));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                column: "UploadDate",
                value: new DateTime(2023, 12, 13, 0, 34, 10, 859, DateTimeKind.Local).AddTicks(7587));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6,
                column: "UploadDate",
                value: new DateTime(2023, 12, 13, 0, 34, 10, 859, DateTimeKind.Local).AddTicks(7589));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7,
                column: "UploadDate",
                value: new DateTime(2023, 12, 13, 0, 34, 10, 859, DateTimeKind.Local).AddTicks(7591));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8,
                column: "UploadDate",
                value: new DateTime(2023, 12, 13, 0, 34, 10, 859, DateTimeKind.Local).AddTicks(7592));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 11,
                column: "UploadDate",
                value: new DateTime(2023, 12, 13, 0, 34, 10, 859, DateTimeKind.Local).AddTicks(7594));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 12,
                column: "UploadDate",
                value: new DateTime(2023, 12, 13, 0, 34, 10, 859, DateTimeKind.Local).AddTicks(7595));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 13,
                column: "UploadDate",
                value: new DateTime(2023, 12, 13, 0, 34, 10, 859, DateTimeKind.Local).AddTicks(7597));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadDate",
                value: new DateTime(2023, 12, 13, 0, 34, 10, 860, DateTimeKind.Local).AddTicks(2677));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                column: "UploadDate",
                value: new DateTime(2023, 12, 13, 0, 34, 10, 860, DateTimeKind.Local).AddTicks(3259));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "UploadDate",
                value: new DateTime(2023, 12, 13, 0, 34, 10, 860, DateTimeKind.Local).AddTicks(3278));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4,
                column: "UploadDate",
                value: new DateTime(2023, 12, 13, 0, 34, 10, 860, DateTimeKind.Local).AddTicks(3280));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 5,
                column: "UploadDate",
                value: new DateTime(2023, 12, 13, 0, 34, 10, 860, DateTimeKind.Local).AddTicks(3282));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 6,
                column: "UploadDate",
                value: new DateTime(2023, 12, 13, 0, 34, 10, 860, DateTimeKind.Local).AddTicks(3285));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 13, 0, 34, 10, 857, DateTimeKind.Local).AddTicks(7062));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 13, 0, 34, 10, 858, DateTimeKind.Local).AddTicks(5850));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 13, 0, 34, 10, 858, DateTimeKind.Local).AddTicks(5865));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 13, 0, 34, 10, 858, DateTimeKind.Local).AddTicks(5868));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 13, 0, 34, 10, 858, DateTimeKind.Local).AddTicks(5871));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 13, 0, 34, 10, 858, DateTimeKind.Local).AddTicks(5874));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 13, 0, 34, 10, 858, DateTimeKind.Local).AddTicks(5876));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 13, 0, 34, 10, 858, DateTimeKind.Local).AddTicks(5880));
        }
    }
}
