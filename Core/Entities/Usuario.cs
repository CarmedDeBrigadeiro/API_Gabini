using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Usuario
    {
        public int ID_Usuario { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public string Sobrenome { get; set; } = string.Empty;

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;


        [Required]
        public string SenhaHash { get; set; } = string.Empty;

        [Required]
        public DateTime DataRegistro { get; set; }

        [Required]
        [Phone]
        public string Telefone { get; set; } = string.Empty;

        [Required]
        public string Genero { get; set; } = string.Empty;

        [Required]
        public string CPF { get; set; } = string.Empty;

        public string FotoUrl { get; set; } = string.Empty;

        public List<Endereco> Enderecos { get; set; } = new List<Endereco>();
    }
}
