
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MudBlazorCatalogoNaPratica.Shared.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [MaxLength(100)]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "A descrição do produto é obrigatória.")]
        [MaxLength(200)]
        public string? Descricao { get; set; }
        [Required(ErrorMessage = "O preço deve ser informado")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        [Column(TypeName = "decimal(12,2)")]
        public decimal Preco { get; set; }
       
        public string? Imagem { get; set; }
        
        [Required(ErrorMessage = "A categoria do produto é obrigatória.")]
        public int CategoriaId { get; set; }
        public virtual Categoria? Categoria { get; set; }
    }
}