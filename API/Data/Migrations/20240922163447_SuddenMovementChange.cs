using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class SuddenMovementChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confirmation",
                table: "SuddenMovements");

            migrationBuilder.AddColumn<bool>(
                name: "Confirm",
                table: "SuddenMovements",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confirm",
                table: "SuddenMovements");

            migrationBuilder.AddColumn<bool>(
                name: "Confirmation",
                table: "SuddenMovements",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
