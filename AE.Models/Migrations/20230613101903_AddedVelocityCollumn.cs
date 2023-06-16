using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AE.Models.Migrations
{
    /// <inheritdoc />
    public partial class AddedVelocityCollumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Velocity",
                table: "Ships",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Velocity",
                table: "Ships");
        }
    }
}
