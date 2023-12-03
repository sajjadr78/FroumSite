using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FroumSite.Migrations
{
    public partial class InitRecords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Subjects_FroumId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_FroumId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "FroumId",
                table: "Rooms");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "Posts",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Caption", "LikeCount", "TopicId", "UploadDate", "UploaderId" },
                values: new object[] { 1, "خانواده اولین گروهی است که ما تجربه می کنیم", 0, null, new DateTime(2023, 12, 3, 20, 21, 52, 946, DateTimeKind.Local).AddTicks(279), null });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "SubjectId", "Title" },
                values: new object[] { 1, null, "روابط در خانواده" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1, "خانواده" });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Description", "RoomId", "Title", "UploaderId" },
                values: new object[] { 1, "روابط پدر با فرزندان باید صمیمانه باشد", null, "روابط پدر با فرزندان", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Family", "Name", "Password", "PhoneNumber", "RegisterDate", "Sex" },
                values: new object[] { 1, new DateTime(1999, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "تاجمیرریاحی", "سجاد", "123", "09136941387", new DateTime(2023, 12, 3, 20, 21, 52, 948, DateTimeKind.Local).AddTicks(5334), 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_SubjectId",
                table: "Rooms",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TopicId",
                table: "Posts",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Topics_TopicId",
                table: "Posts",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Subjects_SubjectId",
                table: "Rooms",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Topics_TopicId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Subjects_SubjectId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_SubjectId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Posts_TopicId",
                table: "Posts");

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Posts");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 11);

            migrationBuilder.AddColumn<int>(
                name: "FroumId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_FroumId",
                table: "Rooms",
                column: "FroumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Subjects_FroumId",
                table: "Rooms",
                column: "FroumId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
