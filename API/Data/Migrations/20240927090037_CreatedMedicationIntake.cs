using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreatedMedicationIntake : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeOfMed",
                table: "MedicationIntakes",
                newName: "Name");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Medications",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Medications");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "MedicationIntakes",
                newName: "TypeOfMed");
        }
    }
}
