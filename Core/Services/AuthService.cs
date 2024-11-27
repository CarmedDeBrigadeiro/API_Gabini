using Core.Entities;
using Core.Interfaces;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUsuarioRepository usuarioRepository, IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
        }

        public async Task<bool> Register(Usuario usuario)
        {
            var usuarioExistente = await _usuarioRepository.ObterUsuarioAsync(usuario.Email);
            if (usuarioExistente != null)
                return false;

            await _usuarioRepository.AdicionarUsuarioAsync(usuario);
            return true;
        }

        public async Task<string> Login(LoginRequest loginRequest)
        {
            var usuario = await _usuarioRepository.ObterUsuarioAsync(loginRequest.Email);
            if (usuario == null || loginRequest.Senha != usuario.Senha)
            {
                // Se as credenciais não são válidas, retorne null
                return null;
            }

            // Gerar o token se a senha for válida
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, usuario.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token); // Retorna o token gerado
        }

        public string GetJwtKey()
        {
            return _configuration["Jwt:Key"];
        }

        public string GetJwtIssuer()
        {
            return _configuration["Jwt:Issuer"];
        }

        public string GetJwtAudience()
        {
            return _configuration["Jwt:Audience"];
        }
    }
}
