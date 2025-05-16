using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class NullableAppUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppTasks_AppUsers_AppUserID",
                table: "AppTasks");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserID",
                table: "AppTasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AppTasks_AppUsers_AppUserID",
                table: "AppTasks",
                column: "AppUserID",
                principalTable: "AppUsers",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppTasks_AppUsers_AppUserID",
                table: "AppTasks");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserID",
                table: "AppTasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppTasks_AppUsers_AppUserID",
                table: "AppTasks",
                column: "AppUserID",
                principalTable: "AppUsers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
