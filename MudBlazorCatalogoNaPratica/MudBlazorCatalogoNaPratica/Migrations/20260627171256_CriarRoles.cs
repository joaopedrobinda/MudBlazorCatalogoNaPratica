using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MudBlazorCatalogoNaPratica.Migrations
{
    /// <inheritdoc />
    public partial class CriarRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4a818f41-5e8b-4e55-8b30-63fc393bd683", "b845cb86-79e2-485e-934e-6671554660bf", "Admin", "ADMIN" },
                    { "8656c60d-75c4-4552-b427-5bfccc11fc10", "c61b1663-33e8-4917-86b2-49c55057c572", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a818f41-5e8b-4e55-8b30-63fc393bd683");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8656c60d-75c4-4552-b427-5bfccc11fc10");
        }
    }
}
