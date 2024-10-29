using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Endereco
    {
        public int Id { get; set; }

        [Required]
        public string TipoEndereco { get; set; }

        [Required]
        public string Rua { get; set; }

        [Required]
        public string Numero { get; set; }

        public string Complemento { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        public string CEP { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } 
    }
}
