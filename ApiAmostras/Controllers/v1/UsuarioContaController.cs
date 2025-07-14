using ApiAmostras.Application.DTOs;
using ApiAmostras.Domain.Interfaces;
using ApiAmostras.Domain.Model;
using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
namespace ApiAmostras.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class UsuarioContaController : ControllerBase
    {
        private readonly IUsuarioContaRepository _repository;
        private readonly IMapper _mapper;

        public UsuarioContaController(IUsuarioContaRepository userAccount, IMapper mapper)
        {
            _repository = userAccount ?? throw new ArgumentNullException(nameof(userAccount));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(UsuarioDTO usuarioDTO)
        {
            //Verifica se o DTO é nulo.
            if (usuarioDTO == null)
                return BadRequest("Dados do usuário não podem ser nulos.");

            //Converte DTO para Status
            var usuario = _mapper.Map<Usuario>(usuarioDTO);

            var resultado = await _repository.CreateAccount(usuario);
            return Ok(resultado);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            //Verifica se o DTO é nulo.
            if (loginDTO == null)
                return BadRequest("Dados de login não podem ser nulos.");
            var resultado = await _repository.LoginAccount(loginDTO);
            return Ok(resultado);
        }
    }
}
