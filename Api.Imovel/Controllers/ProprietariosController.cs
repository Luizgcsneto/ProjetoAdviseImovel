using Api.Domain.Interfaces.Corretor;
using Api.Domain.Interfaces.Inquilino;
using Api.Domain.Interfaces.Proprietario;
using Api.Entities.Entity.Corretor;
using Api.Entities.Entity.Proprietario;
using Api.Entities.Entity.ServiceResponse;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Imovel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProprietariosController : ControllerBase
    {
        private readonly IProprietarioInterface _proprietarioInterface;
        private readonly ILogger<CorretoresController> _logger;
        public ProprietariosController(IProprietarioInterface proprietarioInterface,
            ILogger<CorretoresController> logger)
        {
            _proprietarioInterface = proprietarioInterface;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ProprietarioEntity>>>> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var serviceResponse = await _proprietarioInterface.GetAll();
                _logger.LogInformation(serviceResponse.Mensagem);
                return Ok(serviceResponse);
            }
            catch (ArgumentException e)
            {
                _logger.LogError(e.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ProprietarioEntity>>> GetEntityById(int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var serviceResponse = await _proprietarioInterface.GetEntityById(id);
                _logger.LogInformation(serviceResponse.Mensagem);
                return Ok(serviceResponse);
            }
            catch (ArgumentException e)
            {
                _logger.LogError(e.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }


        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<ProprietarioEntity>>>> Create(ProprietarioEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var serviceResponse = await _proprietarioInterface.Create(entity);
                _logger.LogInformation(serviceResponse.Mensagem);
                return Ok(serviceResponse);
            }
            catch (ArgumentException e)
            {
                _logger.LogError(e.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<ProprietarioEntity>>>> Update(ProprietarioEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var serviceResponse = await _proprietarioInterface.Update(entity);
                _logger.LogInformation(serviceResponse.Mensagem);
                return Ok(serviceResponse);
            }
            catch (ArgumentException e)
            {
                _logger.LogError(e.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut("inativaProprietario")]
        public async Task<ActionResult<ServiceResponse<List<ProprietarioEntity>>>> Inativa(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var serviceResponse = await _proprietarioInterface.Inativa(id);
                _logger.LogInformation(serviceResponse.Mensagem);
                return Ok(serviceResponse);
            }
            catch (ArgumentException e)
            {
                _logger.LogError(e.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<ProprietarioEntity>>>> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var serviceResponse = await _proprietarioInterface.Delete(id);
                _logger.LogInformation(serviceResponse.Mensagem);
                return Ok(serviceResponse);
            }
            catch (ArgumentException e)
            {
                _logger.LogError(e.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }


    }
}
