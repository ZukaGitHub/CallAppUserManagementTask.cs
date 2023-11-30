using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CallAppUserManagementTask.cs.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "isActive", "password", "username" },
                values: new object[] { 1, "Sincere@april.biz", true, "", "Bret" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "isActive", "password", "username" },
                values: new object[] { 2, "Shanna@melissa.tv", true, "", "Antonette" });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "id", "firstName", "lastName", "personalNumber", "userid" },
                values: new object[] { 1, "Leanne", "Graham", "88972572591", 1 });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "id", "firstName", "lastName", "personalNumber", "userid" },
                values: new object[] { 2, "Ervin", "Howell", "21255826995", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
