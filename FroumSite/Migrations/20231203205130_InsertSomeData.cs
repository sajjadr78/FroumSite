using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FroumSite.Migrations
{
    public partial class InsertSomeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_UploaderId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Subjects_FroumId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Rooms_RoomId",
                table: "Topics");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Users_UploaderId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Topics_UploaderId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_FroumId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Posts_UploaderId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UploaderId",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "FroumId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "UploaderId",
                table: "Posts");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Topics",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Topics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Rooms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "Posts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Posts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1, "خانواده" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Family", "Name", "Password", "PhoneNumber", "RegisterDate", "Sex" },
                values: new object[] { 1, new DateTime(1999, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "تاجمیرریاحی", "سجاد", "123", "09136941387", new DateTime(2023, 12, 4, 0, 21, 29, 702, DateTimeKind.Local).AddTicks(3031), 0 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "SubjectId", "Title" },
                values: new object[] { 1, 1, "روابط در خانواده" });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Description", "RoomId", "Title", "UserId" },
                values: new object[] { 1, "روابط پدر با فرزندان باید صمیمانه باشد", 1, "روابط پدر با فرزندان", 1 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Caption", "LikeCount", "TopicId", "UploadDate", "UserId" },
                values: new object[] { 1, "خانواده اولین گروهی است که ما تجربه می کنیم", 0, 1, new DateTime(2023, 12, 4, 0, 21, 29, 704, DateTimeKind.Local).AddTicks(1020), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Topics_UserId",
                table: "Topics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_SubjectId",
                table: "Rooms",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TopicId",
                table: "Posts",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

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

            migrationBuilder.DropIndex(
                name: "IX_Topics_UserId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_SubjectId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Posts_TopicId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_UserId",
                table: "Posts");

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Posts");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Topics",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "UploaderId",
                table: "Topics",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FroumId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UploaderId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Topics_UploaderId",
                table: "Topics",
                column: "UploaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_FroumId",
                table: "Rooms",
                column: "FroumId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UploaderId",
                table: "Posts",
                column: "UploaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_UploaderId",
                table: "Posts",
                column: "UploaderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Subjects_FroumId",
                table: "Rooms",
                column: "FroumId",
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
                name: "FK_Topics_Users_UploaderId",
                table: "Topics",
                column: "UploaderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
