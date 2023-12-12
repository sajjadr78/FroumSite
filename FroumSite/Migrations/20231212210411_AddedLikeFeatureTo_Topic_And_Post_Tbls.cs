using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FroumSite.Migrations
{
    public partial class AddedLikeFeatureTo_Topic_And_Post_Tbls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserLikePosts",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    PostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLikePosts", x => new { x.UserId, x.PostId });
                    table.ForeignKey(
                        name: "FK_UserLikePosts_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLikePosts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLikeTopics",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    TopicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLikeTopics", x => new { x.UserId, x.TopicId });
                    table.ForeignKey(
                        name: "FK_UserLikeTopics_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLikeTopics_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserLikePosts_PostId",
                table: "UserLikePosts",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLikeTopics_TopicId",
                table: "UserLikeTopics",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLikePosts");

            migrationBuilder.DropTable(
                name: "UserLikeTopics");

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
        }
    }
}
