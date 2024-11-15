using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Produto
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required]
        public decimal Preco { get; set; }
    }
}
