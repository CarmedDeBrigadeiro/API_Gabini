using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sobrenome { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string SenhaHash { get; set; } 

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        [Phone]
        public string Telefone { get; set; }

        [Required]
        public string Genero { get; set; }

        [Required]
        public string CPF { get; set; }

        public string FotoUrl { get; set; }

        public List<Endereco> Enderecos { get; set; }
    }
}
