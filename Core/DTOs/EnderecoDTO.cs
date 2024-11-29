using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class EnderecoDTO
    {
        public int ID_Endereco { get; set; }

        [Required]
        public string Tipo_Endereco { get; set; }

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

        public int ID_Usuario { get; set; }

        public EnderecoDTO(
            int idEndereco,
            string tipoEndereco,
            string rua,
            string numero,
            string complemento,
            string bairro,
            string cidade,
            string estado,
            string cep,
            int idUsuario)
        {
            ID_Endereco = idEndereco;
            Tipo_Endereco = tipoEndereco;
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            CEP = cep;
            ID_Usuario = idUsuario;
        }
    }
}
