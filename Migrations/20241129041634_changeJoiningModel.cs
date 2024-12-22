using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PressTheButtonAPI.Migrations
{
    /// <inheritdoc />
    public partial class changeJoiningModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scenarios_Users_ScenarioOwnerId",
                table: "Scenarios");

            migrationBuilder.AddForeignKey(
                name: "FK_Scenarios_Users_ScenarioOwnerId",
                table: "Scenarios",
                column: "ScenarioOwnerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scenarios_Users_ScenarioOwnerId",
                table: "Scenarios");

            migrationBuilder.AddForeignKey(
                name: "FK_Scenarios_Users_ScenarioOwnerId",
                table: "Scenarios",
                column: "ScenarioOwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
