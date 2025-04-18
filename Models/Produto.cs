using System.ComponentModel.DataAnnotations;

namespace ProdutosComAutenticacaoJWT.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        public string NomeProduto { get; set; }

        [Required(ErrorMessage = "A descrição do produto é obrigatória.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O preço do produto é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "A quantidade em estoque é obrigatória.")]
        public int QuantidadeEstoque { get; set; }
    }
}
