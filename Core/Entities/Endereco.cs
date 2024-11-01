using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Endereco
    {
        public int ID_Endereco { get; set; }

        [Required]
        public string Tipo_Endereco { get; set; } = string.Empty;

        [Required]
        public string Rua { get; set; } = string.Empty;

        [Required]
        public string Numero { get; set; } = string.Empty;

        public string Complemento { get; set; } = string.Empty;

        [Required]
        public string Bairro { get; set; } = string.Empty;

        [Required]
        public string Cidade { get; set; } = string.Empty;

        [Required]
        public string Estado { get; set; } = string.Empty;

        [Required]
        public string CEP { get; set; } = string.Empty;

        [ForeignKey("Usuario")]
        public int ID_Usuario { get; set; }
        public Usuario Usuario { get; set; } = new Usuario(); 
    }
}
