using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CallAppUserManagementTask.cs.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "id",
                keyValue: 1,
                column: "personalNumber",
                value: "55359788670");

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "id",
                keyValue: 2,
                column: "personalNumber",
                value: "24017436263");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "Password1!");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "Password1!");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "isActive", "password", "username" },
                values: new object[,]
                {
                    { 3, "Nathan@yesenia.net", true, "Password1!", "Samantha" },
                    { 4, "Julianne.OConner@kory.org", true, "Password1!", "Karianne" },
                    { 5, "Lucio_Hettinger@annie.ca", false, "Password1!", "Kamren" }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "id", "firstName", "lastName", "personalNumber", "userid" },
                values: new object[] { 3, "Clementine", "Bauch", "59866202820", 3 });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "id", "firstName", "lastName", "personalNumber", "userid" },
                values: new object[] { 4, "Patricia", "Lebsack", "22418390819", 4 });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "id", "firstName", "lastName", "personalNumber", "userid" },
                values: new object[] { 5, "Chelsey", "Dietrich", "80023584477", 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "id",
                keyValue: 1,
                column: "personalNumber",
                value: "88972572591");

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "id",
                keyValue: 2,
                column: "personalNumber",
                value: "21255826995");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "");
        }
    }
}
