using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class UsuarioDTO
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
        public DateTime Data_Registro { get; set; }

        [Required]
        [Phone]
        public string Telefone { get; set; } = string.Empty;

        [Required]
        public string Genero { get; set; } = string.Empty;

        [Required]
        public string CPF { get; set; } = string.Empty;

        public string FotoUrl { get; set; } = string.Empty;

        public List<Endereco> Enderecos { get; set; } = new List<Endereco>();

        public UsuarioDTO(int id, string nome, string sobrenome, string username, string email, string senhaHash, DateTime dataRegistro, string telefone, string genero, string cpf, List<Endereco> enderecos)
        {
            ID_Usuario = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Username = username;
            Email = email;
            SenhaHash = senhaHash;
            Data_Registro = dataRegistro;
            Telefone = telefone;
            Genero = genero;
            CPF = cpf;
            Enderecos = enderecos;
        }
    }
}
