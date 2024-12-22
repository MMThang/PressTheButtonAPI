using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PressTheButtonAPI.Migrations
{
    /// <inheritdoc />
    public partial class changingRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteUsersTable");

            migrationBuilder.DropTable(
                name: "HistoryUsersTable");

            migrationBuilder.CreateTable(
                name: "ScenarioUser",
                columns: table => new
                {
                    HistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HistoryUsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScenarioUser", x => new { x.HistoryId, x.HistoryUsersId });
                    table.ForeignKey(
                        name: "FK_ScenarioUser_scenarios_HistoryId",
                        column: x => x.HistoryId,
                        principalTable: "scenarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScenarioUser_users_HistoryUsersId",
                        column: x => x.HistoryUsersId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScenarioUser1",
                columns: table => new
                {
                    FavoriteUsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FavoritesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScenarioUser1", x => new { x.FavoriteUsersId, x.FavoritesId });
                    table.ForeignKey(
                        name: "FK_ScenarioUser1_scenarios_FavoritesId",
                        column: x => x.FavoritesId,
                        principalTable: "scenarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScenarioUser1_users_FavoriteUsersId",
                        column: x => x.FavoriteUsersId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScenarioUser_HistoryUsersId",
                table: "ScenarioUser",
                column: "HistoryUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_ScenarioUser1_FavoritesId",
                table: "ScenarioUser1",
                column: "FavoritesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScenarioUser");

            migrationBuilder.DropTable(
                name: "ScenarioUser1");

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
        }
    }
}
