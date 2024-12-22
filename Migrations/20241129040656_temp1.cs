using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PressTheButtonAPI.Migrations
{
    /// <inheritdoc />
    public partial class temp1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("HistoryUsersTable");
            migrationBuilder.DropTable("FavoriteUsersTable");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
