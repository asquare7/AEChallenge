using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AE.Models.Migrations
{
    /// <inheritdoc />
    public partial class RandomPortData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
    table: "Ports",
    columns: new[] { "Name", "Latitude", "Longitude", "CreatedBy", "CreatedDate", "ChangedBy", "ChangedDate" },
    values: new object[,]
    {
        { "Port1", 41.8781, -87.6298, 1, new DateTime(2023, 6, 13), 2, new DateTime(2023, 6, 13) },
        { "Port2", 34.0522, -118.2437, 3, new DateTime(2023, 6, 13), 4, new DateTime(2023, 6, 13) },
        { "Port3", 51.5074, -0.1278, 5, new DateTime(2023, 6, 13), 6, new DateTime(2023, 6, 13) },
        { "Port4", 40.7128, -74.0060, 7, new DateTime(2023, 6, 13), 8, new DateTime(2023, 6, 13) },
        { "Port5", 39.9042, 116.4074, 9, new DateTime(2023, 6, 13), 10, new DateTime(2023, 6, 13) },
        { "Port6", 35.6895, 139.6917, 11, new DateTime(2023, 6, 13), 12, new DateTime(2023, 6, 13) },
        { "Port7", -33.8688, 151.2093, 13, new DateTime(2023, 6, 13), 14, new DateTime(2023, 6, 13) },
        { "Port8", 37.7749, -122.4194, 15, new DateTime(2023, 6, 13), 16, new DateTime(2023, 6, 13) },
        { "Port9", 28.6139, 77.2090, 17, new DateTime(2023, 6, 13), 18, new DateTime(2023, 6, 13) },
        { "Port10", 55.7558, 37.6176, 19, new DateTime(2023, 6, 13), 20, new DateTime(2023, 6, 13) }
    });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
