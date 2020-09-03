using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace aspnetcore_log_filter.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    AppUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    LoginDate = table.Column<DateTime>(nullable: false),
                    Path = table.Column<string>(nullable: true),
                    QueryString = table.Column<string>(nullable: true),
                    Method = table.Column<string>(nullable: true),
                    Payload = table.Column<string>(nullable: true),
                    Response = table.Column<string>(nullable: true),
                    ResponseCode = table.Column<string>(nullable: true),
                    RequestedOn = table.Column<DateTime>(nullable: false),
                    RespondedOn = table.Column<DateTime>(nullable: false),
                    IsSuccessStatusCode = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.AppUserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
