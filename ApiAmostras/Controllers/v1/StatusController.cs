using ApiAmostras.Application.DTOs;
using ApiAmostras.Domain.Interfaces;
using ApiAmostras.Domain.Model;
using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiStatus.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Status")]
    [ApiVersion("1.0")]
    //[Authorize]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository _repository;
        private readonly IMapper _mapper;

        public StatusController(

            IStatusRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #region CRUD

        [HttpPost]
        public async Task<IActionResult> Add(StatusDTO statusDTO)
        {
            try
            {
                //Verifica se o DTO é nulo.
                if (statusDTO == null)
                    return BadRequest("Dados não podem ser vazios.");

                var listaStatus = await _repository.GetAllAsync().ConfigureAwait(false);
                var statusExistente = listaStatus.FirstOrDefault(s => s.Descricao.Equals(statusDTO.Descricao, StringComparison.OrdinalIgnoreCase));
                //Verifica se o status já existe
                if (statusExistente != null)
                    return BadRequest("Registro já existente.");

                //Converte DTO para Status
                var status = _mapper.Map<Status>(statusDTO);

                //Seta Id como nulo para que o banco de dados gere automaticamente.                
                status.Id = 0;

                //Adiciona o registro DTO convertido no modelo, no banco de dados.
                var resultado = await Task.Run(() => _repository.CreateAsync(status)).ConfigureAwait(false);
               
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
                //Obtém a lista de status do banco de dados.
                var status = await Task.Run(() => _repository.GetAllAsync()).ConfigureAwait(false);

                //Verifica se a lista de status é nula ou vazia.
                if (!status.Any())
                    return NotFound("Lista de registro é nula ou vazia.");

                //Converte a lista de status para DTOs
                var statusDTO = _mapper.Map<IEnumerable<StatusDTO>>(status);

                //Retorna solicitação com DTOs
                return Ok(statusDTO);
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
                var status = await Task.Run(() => _repository.GetIdAsync(Id)).ConfigureAwait(false);

                //Se a status for nula, retorna NotFound
                if (status == null)
                    return NotFound("Registro inexistente.");

                //Converte a status para DTO
                var statusDTO = _mapper.Map<StatusDTO>(status);

                //Retorna solicitação com DTOs
                return Ok(statusDTO);
            }
            catch (Exception ex)
            {
                //Retorna erro caso ocorra uma exceção
                return NotFound(ex.Message);
            }
        }


        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, StatusDTO statusDTO)
        {
            try
            {
                //Verifica se o Id é válido

                if (statusDTO == null)
                    return BadRequest("Dados não podem ser vazios.");              

                // Verifica se o Id do DTO é igual ao Id do registro no banco de dados.
                if (statusDTO.Id != Id)
                    return BadRequest("Id do registro informado não é igual ao Id do registro no banco de dados.");                

                // Converte o DTO para o modelo Status
                var _status = _mapper.Map<Status>(statusDTO);

                //Adiciona o registro DTO convertido no modelo, no banco de dados.
                var resultado = await Task.Run(() => _repository.UpdateAsync(_status)).ConfigureAwait(false);

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
                var status = await _repository.GetIdAsync(id).ConfigureAwait(false);
                if (status == null)
                    return NotFound("Registro inexistente.");

                var resultado = await _repository.DeleteAsync(status).ConfigureAwait(false);
               
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