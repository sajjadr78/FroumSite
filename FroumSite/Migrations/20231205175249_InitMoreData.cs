using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FroumSite.Migrations
{
    public partial class InitMoreData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Topics",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadDate",
                value: new DateTime(2023, 12, 5, 21, 22, 48, 886, DateTimeKind.Local).AddTicks(3598));

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "SubjectId", "Title" },
                values: new object[] { 2, 1, "صمیمیت در خانواده" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 3, "سیاست" },
                    { 4, "ورزش" },
                    { 5, "بارداری" },
                    { 6, "ادبیات" },
                    { 2, "تکنولوژی" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 5, 21, 22, 48, 884, DateTimeKind.Local).AddTicks(4801));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Family", "Name", "Password", "PhoneNumber", "RegisterDate", "Sex" },
                values: new object[,]
                {
                    { 2, new DateTime(1980, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "محمدی", "علی", "123", "09121231234", new DateTime(2022, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 3, new DateTime(1995, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "غلامی", "مریم", "123", "09131231598", new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, new DateTime(1994, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "خدادادی", "شیلا", "123", "09136547156", new DateTime(2023, 12, 5, 21, 22, 48, 885, DateTimeKind.Local).AddTicks(2793), 1 },
                    { 6, new DateTime(1991, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "حسن پور", "الناز", "123", "09136512036", new DateTime(2023, 12, 5, 21, 22, 48, 885, DateTimeKind.Local).AddTicks(2811), 1 },
                    { 7, new DateTime(2000, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "حسن زاده", "شهرام", "123", "09123650942", new DateTime(2023, 12, 5, 21, 22, 48, 885, DateTimeKind.Local).AddTicks(2814), 0 },
                    { 8, new DateTime(1985, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "اعتمادی", "محمود", "123", "09425558182", new DateTime(2023, 12, 5, 21, 22, 48, 885, DateTimeKind.Local).AddTicks(2817), 0 },
                    { 9, new DateTime(1980, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "معتمدی", "شهلا", "123", "09116951478", new DateTime(2023, 12, 5, 21, 22, 48, 885, DateTimeKind.Local).AddTicks(2819), 1 },
                    { 10, new DateTime(2004, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "زارع", "زهرا", "123", "09362012361", new DateTime(2023, 12, 5, 21, 22, 48, 885, DateTimeKind.Local).AddTicks(2822), 1 },
                    { 11, new DateTime(2005, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "حیدری", "امیر", "123", "09352142314", new DateTime(2023, 12, 5, 21, 22, 48, 885, DateTimeKind.Local).AddTicks(2825), 0 },
                    { 4, new DateTime(2000, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "مهدوی", "ثریا", "123", "09425874136", new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Caption", "LikeCount", "TopicId", "UploadDate", "UserId" },
                values: new object[] { 2, "بهتر است فضای خانواده صمیمی باشد", 0, 1, new DateTime(2023, 12, 5, 21, 22, 48, 886, DateTimeKind.Local).AddTicks(4426), 10 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "SubjectId", "Title" },
                values: new object[,]
                {
                    { 3, 2, "اپل" },
                    { 4, 2, "شیائومی" },
                    { 5, 2, "تلویزیون های هوشمند" },
                    { 9, 2, "ساعت های هوشمند" },
                    { 10, 2, "گجت های پوشیدنی" },
                    { 11, 2, "ماشین های خودران" },
                    { 6, 3, "داخل" },
                    { 7, 3, "خارج" },
                    { 8, 5, "شیردهی" },
                    { 12, 6, "فردوسی" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Description", "RoomId", "Title", "UserId" },
                values: new object[,]
                {
                    { 4, "تیم کوک حتی فکرش را هم نمی کرد", 3, "سرنوشت اپل در سال 2023", 1 },
                    { 3, "خداحافظی با اندروید", 4, "شیائومی ، تافته ی جدا بافته", 1 },
                    { 5, "چند وقته اخبار دنبال نمی کنم ، هر چیزی میدونید به منم بگید", 6, "از سیاست چه خبر", 1 },
                    { 6, "این موضوع از اهمیت بالایی برخوردار است", 8, "سلامتی در دوران بارداری و شیردهی", 1 },
                    { 2, "اهمیت فردوسی برای ایران", 12, "فردوسی", 1 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Caption", "LikeCount", "TopicId", "UploadDate", "UserId" },
                values: new object[,]
                {
                    { 6, "امسال ، برای اپل سال نحسی بود!", 0, 4, new DateTime(2023, 12, 5, 21, 22, 48, 886, DateTimeKind.Local).AddTicks(4455), 6 },
                    { 5, "گوشی جدید شیائومی به سیستم عامل اختصاصی این شرکت مجهر است", 0, 3, new DateTime(2023, 12, 5, 21, 22, 48, 886, DateTimeKind.Local).AddTicks(4454), 3 },
                    { 7, "اختلاس چای دبش به کجا رسید؟", 0, 5, new DateTime(2023, 12, 5, 21, 22, 48, 886, DateTimeKind.Local).AddTicks(4457), 2 },
                    { 8, "آیا اروپا امسال هم زمستان سختی خواهد داشت؟", 0, 5, new DateTime(2023, 12, 5, 21, 22, 48, 886, DateTimeKind.Local).AddTicks(4459), 3 },
                    { 11, "5 ماه اول شیردهی چقدر مهم است؟", 0, 6, new DateTime(2023, 12, 5, 21, 22, 48, 886, DateTimeKind.Local).AddTicks(4460), 2 },
                    { 12, "استرس در دوران بارداری", 0, 6, new DateTime(2023, 12, 5, 21, 22, 48, 886, DateTimeKind.Local).AddTicks(4461), 4 },
                    { 13, "تغذیه در دوران بارداری", 0, 6, new DateTime(2023, 12, 5, 21, 22, 48, 886, DateTimeKind.Local).AddTicks(4463), 4 },
                    { 3, "فردوسی زحمات زیادی برای ادبیات ایران کشید", 0, 2, new DateTime(2023, 12, 5, 21, 22, 48, 886, DateTimeKind.Local).AddTicks(4450), 9 },
                    { 4, "شاهنامه بسیار پر مفهوم است", 0, 2, new DateTime(2023, 12, 5, 21, 22, 48, 886, DateTimeKind.Local).AddTicks(4452), 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Topics",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadDate",
                value: new DateTime(2023, 12, 5, 13, 10, 29, 339, DateTimeKind.Local).AddTicks(8910));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2023, 12, 5, 13, 10, 29, 338, DateTimeKind.Local).AddTicks(464));
        }
    }
}
