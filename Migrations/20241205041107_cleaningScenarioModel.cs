using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PressTheButtonAPI.Migrations
{
    /// <inheritdoc />
    public partial class cleaningScenarioModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteScenarioUser_ScenarioId",
                table: "FavoriteScenarioUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteScenarioUser_UserId",
                table: "FavoriteScenarioUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryScenarioUser_ScenarioId",
                table: "HistoryScenarioUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryScenarioUser_UserId",
                table: "HistoryScenarioUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteScenarioUser_ScenarioId",
                table: "FavoriteScenarioUsers",
                column: "scenarioId",
                principalTable: "Scenarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteScenarioUser_UserId",
                table: "FavoriteScenarioUsers",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryScenarioUser_ScenarioId",
                table: "HistoryScenarioUsers",
                column: "scenarioId",
                principalTable: "Scenarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryScenarioUser_UserId",
                table: "HistoryScenarioUsers",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteScenarioUser_ScenarioId",
                table: "FavoriteScenarioUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteScenarioUser_UserId",
                table: "FavoriteScenarioUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryScenarioUser_ScenarioId",
                table: "HistoryScenarioUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryScenarioUser_UserId",
                table: "HistoryScenarioUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteScenarioUser_ScenarioId",
                table: "FavoriteScenarioUsers",
                column: "scenarioId",
                principalTable: "Scenarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteScenarioUser_UserId",
                table: "FavoriteScenarioUsers",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryScenarioUser_ScenarioId",
                table: "HistoryScenarioUsers",
                column: "scenarioId",
                principalTable: "Scenarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryScenarioUser_UserId",
                table: "HistoryScenarioUsers",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
