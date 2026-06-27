using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MudBlazorCatalogoNaPratica.Migrations
{
    /// <inheritdoc />
    public partial class AjusteRolesFixas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a818f41-5e8b-4e55-8b30-63fc393bd683");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8656c60d-75c4-4552-b427-5bfccc11fc10");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a2df468e-28ff-451f-bfa9-e85df6ee47ab", "f09b5523-2877-45ea-971a-28e46950e32b", "User", "USER" },
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "b8453489-0115-4fa8-b21a-c55dbfce1f93", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2df468e-28ff-451f-bfa9-e85df6ee47ab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7b013f0-5201-4317-abd8-c211f91b7330");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4a818f41-5e8b-4e55-8b30-63fc393bd683", "b845cb86-79e2-485e-934e-6671554660bf", "Admin", "ADMIN" },
                    { "8656c60d-75c4-4552-b427-5bfccc11fc10", "c61b1663-33e8-4917-86b2-49c55057c572", "User", "USER" }
                });
        }
    }
}
