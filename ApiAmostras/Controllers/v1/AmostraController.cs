using ApiAmostras.Application.DTOs;
using ApiAmostras.Domain.Interfaces;
using ApiAmostras.Domain.Model;
using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiAmostras.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Amostra")]
    [ApiVersion("1.0")]
    //[Authorize]
    public class AmostraController : ControllerBase
    {
        private readonly IAmostraRepository _repository;
        private readonly IStatusRepository _repositoryStatus;
        private readonly IMapper _mapper;    

        public AmostraController(
            
            IAmostraRepository repository,
            IStatusRepository repositoryStatus,
            IMapper mapper)
        {
            _repositoryStatus = repositoryStatus;
            _repository = repository;
            _mapper = mapper;            
        }

        #region CRUD

        [HttpPost]
        public async Task<IActionResult> Add(AmostraDTO amostraDTO)
        {
            try
            {
                //Verifica se o DTO é nulo.
                if (amostraDTO == null)
                    return BadRequest("Dados não podem ser vazios.");

                var listaAmostras = await _repository.GetAllAsync().ConfigureAwait(false);
                //Verifica se o registro já existe
                if (listaAmostras.Any(a => a.Codigo.Equals(amostraDTO.Codigo, StringComparison.OrdinalIgnoreCase)))
                    return BadRequest("Registro já existente.");              

                //Converte DTO para Amostra
                var amostra = _mapper.Map<Amostra>(amostraDTO);

                //Seta Id como nulo para que o banco de dados gere automaticamente.                
                amostra.Id = 0;

                //Adiciona o registro DTO convertido no modelo, no banco de dados.
                var resultado = await Task.Run(() => _repository.CreateAsync(amostra)).ConfigureAwait(false);
               
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                //Obtém a lista de amostras do banco de dados.
                var amostras = await Task.Run(() => _repository.GetAllAsync()).ConfigureAwait(false);

                //Verifica se a lista de amostras é nula ou vazia.
                if (!amostras.Any())
                    return NotFound("Lista de registros é nula ou vazia.");

                //Converte a lista de amostras para DTOs
                var amostraDTO = _mapper.Map<IEnumerable<AmostraDTO>>(amostras);

                //Retorna solicitação com DTOs
                return Ok(amostraDTO); 
            }
            catch (Exception ex)
            {
                //Retorna erro caso ocorra uma exceção
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            try
            {
                //Verifica se o Id é válido
                var amostra = await Task.Run(() => _repository.GetIdAsync(Id)).ConfigureAwait(false);

                //Se a amostra for nula, retorna NotFound
                if (amostra == null)
                    return NotFound("Registro inexistente.");

                //Converte a amostra para DTO
                var amostraDTO = _mapper.Map<AmostraDTO>(amostra);

                //Retorna solicitação com DTOs
                return Ok(amostraDTO); 
            }
            catch (Exception ex)
            {
                //Retorna erro caso ocorra uma exceção
                return NotFound(ex.Message);
            }
        }


        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, AmostraDTO amostraDTO)
        {
            try
            {
                //Verifica se o Id é válido

                if (amostraDTO == null)
                    return BadRequest("Dados não podem ser vazios.");

                // Obtém a amostra do banco de dados pelo Id
                //var amostra = await Task.Run(() => _repository.GetIdAsync(Id)).ConfigureAwait(false);
                //if (amostra == null)
                //    return NotFound("Amostra inexistente.");

                // Verifica se o Id do DTO é igual ao Id do registro no banco de dados.
                if (amostraDTO.Id != Id)
                    return BadRequest("Id do registro informado não é igual ao Id do registro no banco de dados.");

                //var listaAmostras = await _repository.GetAllAsync().ConfigureAwait(false);
                ////Verifica se o statusId já existe
                //if (listaAmostras.Any(a => a.Codigo.Equals(amostraDTO.Codigo, StringComparison.OrdinalIgnoreCase)))
                //    return BadRequest("Amostra já existente.");

                // Converte o DTO para o modelo Amostra
                var _amostra = _mapper.Map<Amostra>(amostraDTO);               

                //Adiciona o registro DTO convertido no modelo, no banco de dados.
                var resultado = await Task.Run(() => _repository.UpdateAsync(_amostra)).ConfigureAwait(false);                
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                // Obtém a conta do banco de dados pelo Id
                var amostra = await _repository.GetIdAsync(id).ConfigureAwait(false);
                if (amostra == null)
                    return NotFound("Registro inexistente.");

                var resultado = await _repository.DeleteAsync(amostra).ConfigureAwait(false);
                // Verifica se a exclusão foi bem sucedida.
               
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        #endregion CRUD
    }
}