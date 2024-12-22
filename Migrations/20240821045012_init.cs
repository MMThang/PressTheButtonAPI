using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PressTheButtonAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "scenarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScenarioOwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GoodOutcome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BadOutcome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PressedCount = table.Column<int>(type: "int", nullable: false),
                    DeniedCount = table.Column<int>(type: "int", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scenarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_scenarios_users_ScenarioOwnerId",
                        column: x => x.ScenarioOwnerId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FavoriteUsersTable",
                columns: table => new
                {
                    FavoriteUsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FavoritesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteUsersTable", x => new { x.FavoriteUsersId, x.FavoritesId });
                    table.ForeignKey(
                        name: "FK_FavoriteUsersTable_scenarios_FavoritesId",
                        column: x => x.FavoritesId,
                        principalTable: "scenarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FavoriteUsersTable_users_FavoriteUsersId",
                        column: x => x.FavoriteUsersId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HistoryUsersTable",
                columns: table => new
                {
                    HistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HistoryUsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryUsersTable", x => new { x.HistoryId, x.HistoryUsersId });
                    table.ForeignKey(
                        name: "FK_HistoryUsersTable_scenarios_HistoryId",
                        column: x => x.HistoryId,
                        principalTable: "scenarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoryUsersTable_users_HistoryUsersId",
                        column: x => x.HistoryUsersId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteUsersTable_FavoritesId",
                table: "FavoriteUsersTable",
                column: "FavoritesId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryUsersTable_HistoryUsersId",
                table: "HistoryUsersTable",
                column: "HistoryUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_scenarios_ScenarioOwnerId",
                table: "scenarios",
                column: "ScenarioOwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteUsersTable");

            migrationBuilder.DropTable(
                name: "HistoryUsersTable");

            migrationBuilder.DropTable(
                name: "scenarios");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
