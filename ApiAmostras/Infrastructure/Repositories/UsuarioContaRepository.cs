using ApiAmostras.Application.DTOs;
using ApiAmostras.Domain.Interfaces;
using ApiAmostras.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static ApiAmostras.Services.ServicoResposta;
namespace ApiAmostras.Infrastructure.Repositories
{
   public class UsuarioContaRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration config) : IUsuarioContaRepository
    {
    
        public async Task<RespostaGeral> CreateAccount(Usuario usuario)
        {
            if (usuario is null) return 
                    new RespostaGeral(false, "Informações vazias");
            var newUser = new ApplicationUser()
            {
                UserName = usuario.Email,
                Email = usuario.Email,
                PasswordHash = usuario.Password,            
                EmailConfirmed = true
            };
            var user = await userManager.FindByEmailAsync(newUser.Email);
            if (user is not null) 
                return new RespostaGeral(false, "Usuário já existe");

            var createUser = await userManager.CreateAsync(newUser!, usuario.Password);
            if (!createUser.Succeeded) 
                return new RespostaGeral(false, "Ocorreu algum erro...");

            return new RespostaGeral(true, "Usuário Criado");
            
        }

        public async Task<RespostaLogin> LoginAccount(LoginDTO loginDTO)
        {
            if (loginDTO == null)
                return new RespostaLogin(false, null!, "Dados vazios");

            var getUser = await userManager.FindByEmailAsync(loginDTO.Email);
            if (getUser is null)
                return new RespostaLogin(false, null!, "Usuario não existente");

            bool checkUserPasswords = await userManager.CheckPasswordAsync(getUser, loginDTO.Password);
            if (!checkUserPasswords)
                return new RespostaLogin(false, null!, "Email/Senha inválido");

            //var getUserRole = await userManager.GetRolesAsync(getUser);
            var usuarioSessao = new UsuarioSessao(getUser.Id, getUser.UserName, getUser.Email, "");
            string token = GenerateToken(usuarioSessao);
            return new RespostaLogin(true, token!, "Entrada completa");
        }

        private string GenerateToken(UsuarioSessao user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };
            var token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
