using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MudBlazorCatalogoNaPratica.Migrations
{
    /// <inheritdoc />
    public partial class DadosCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CategoriaId", "Descricao", "Name" },
                values: new object[,]
                {
                    { 1, "Dispositivos de última geração, incluindo smartphones...", "Eletrônicos" },
                    { 2, "Vasta coleção de obras literárias...", "Livros" },
                    { 3, "Utensílios domésticos modernos...", "Cozinha" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "CategoriaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "CategoriaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "CategoriaId",
                keyValue: 3);
        }
    }
}
