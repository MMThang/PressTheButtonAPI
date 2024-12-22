using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PressTheButtonAPI.Migrations
{
    /// <inheritdoc />
    public partial class removeLikeCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Scenarios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Scenarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ScenarioUser",
                columns: table => new
                {
                    HistoryId = table.Column<int>(type: "int", nullable: false),
                    HistoryUsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScenarioUser", x => new { x.HistoryId, x.HistoryUsersId });
                    table.ForeignKey(
                        name: "FK_ScenarioUser_Scenarios_HistoryId",
                        column: x => x.HistoryId,
                        principalTable: "Scenarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScenarioUser_Users_HistoryUsersId",
                        column: x => x.HistoryUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScenarioUser1",
                columns: table => new
                {
                    FavoriteUsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FavoritesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScenarioUser1", x => new { x.FavoriteUsersId, x.FavoritesId });
                    table.ForeignKey(
                        name: "FK_ScenarioUser1_Scenarios_FavoritesId",
                        column: x => x.FavoritesId,
                        principalTable: "Scenarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScenarioUser1_Users_FavoriteUsersId",
                        column: x => x.FavoriteUsersId,
                        principalTable: "Users",
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
    }
}
