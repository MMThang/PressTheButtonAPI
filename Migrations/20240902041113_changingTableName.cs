using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PressTheButtonAPI.Migrations
{
    /// <inheritdoc />
    public partial class changingTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScenarioUser_scenarios_HistoryId",
                table: "ScenarioUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ScenarioUser_users_HistoryUsersId",
                table: "ScenarioUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ScenarioUser1_scenarios_FavoritesId",
                table: "ScenarioUser1");

            migrationBuilder.DropForeignKey(
                name: "FK_ScenarioUser1_users_FavoriteUsersId",
                table: "ScenarioUser1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScenarioUser1",
                table: "ScenarioUser1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScenarioUser",
                table: "ScenarioUser");

            migrationBuilder.RenameTable(
                name: "ScenarioUser1",
                newName: "FavoriteScenarioUser");

            migrationBuilder.RenameTable(
                name: "ScenarioUser",
                newName: "HistoryScenarioUser");

            migrationBuilder.RenameIndex(
                name: "IX_ScenarioUser1_FavoritesId",
                table: "FavoriteScenarioUser",
                newName: "IX_FavoriteScenarioUser_FavoritesId");

            migrationBuilder.RenameIndex(
                name: "IX_ScenarioUser_HistoryUsersId",
                table: "HistoryScenarioUser",
                newName: "IX_HistoryScenarioUser_HistoryUsersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteScenarioUser",
                table: "FavoriteScenarioUser",
                columns: new[] { "FavoriteUsersId", "FavoritesId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_HistoryScenarioUser",
                table: "HistoryScenarioUser",
                columns: new[] { "HistoryId", "HistoryUsersId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteScenarioUser_scenarios_FavoritesId",
                table: "FavoriteScenarioUser",
                column: "FavoritesId",
                principalTable: "scenarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteScenarioUser_users_FavoriteUsersId",
                table: "FavoriteScenarioUser",
                column: "FavoriteUsersId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryScenarioUser_scenarios_HistoryId",
                table: "HistoryScenarioUser",
                column: "HistoryId",
                principalTable: "scenarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryScenarioUser_users_HistoryUsersId",
                table: "HistoryScenarioUser",
                column: "HistoryUsersId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteScenarioUser_scenarios_FavoritesId",
                table: "FavoriteScenarioUser");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteScenarioUser_users_FavoriteUsersId",
                table: "FavoriteScenarioUser");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryScenarioUser_scenarios_HistoryId",
                table: "HistoryScenarioUser");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryScenarioUser_users_HistoryUsersId",
                table: "HistoryScenarioUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HistoryScenarioUser",
                table: "HistoryScenarioUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteScenarioUser",
                table: "FavoriteScenarioUser");

            migrationBuilder.RenameTable(
                name: "HistoryScenarioUser",
                newName: "ScenarioUser");

            migrationBuilder.RenameTable(
                name: "FavoriteScenarioUser",
                newName: "ScenarioUser1");

            migrationBuilder.RenameIndex(
                name: "IX_HistoryScenarioUser_HistoryUsersId",
                table: "ScenarioUser",
                newName: "IX_ScenarioUser_HistoryUsersId");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteScenarioUser_FavoritesId",
                table: "ScenarioUser1",
                newName: "IX_ScenarioUser1_FavoritesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScenarioUser",
                table: "ScenarioUser",
                columns: new[] { "HistoryId", "HistoryUsersId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScenarioUser1",
                table: "ScenarioUser1",
                columns: new[] { "FavoriteUsersId", "FavoritesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ScenarioUser_scenarios_HistoryId",
                table: "ScenarioUser",
                column: "HistoryId",
                principalTable: "scenarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScenarioUser_users_HistoryUsersId",
                table: "ScenarioUser",
                column: "HistoryUsersId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScenarioUser1_scenarios_FavoritesId",
                table: "ScenarioUser1",
                column: "FavoritesId",
                principalTable: "scenarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScenarioUser1_users_FavoriteUsersId",
                table: "ScenarioUser1",
                column: "FavoriteUsersId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
