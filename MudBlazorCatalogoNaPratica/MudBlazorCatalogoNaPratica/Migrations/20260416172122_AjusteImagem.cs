using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudBlazorCatalogoNaPratica.Migrations
{
    /// <inheritdoc />
    public partial class AjusteImagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemUrl",
                table: "Produtos");

            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "Produtos",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Produtos");

            migrationBuilder.AddColumn<string>(
                name: "ImagemUrl",
                table: "Produtos",
                type: "TEXT",
                maxLength: 250,
                nullable: true);
        }
    }
}
