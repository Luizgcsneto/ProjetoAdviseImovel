using Api.Domain.Interfaces.Corretor;
using Api.Entities.Entity.Corretor;
using Api.Entities.Entity.ServiceResponse;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Imovel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorretoresController : ControllerBase
    {
        private readonly ICorretorInterface _icorretorInterface;
        private readonly ILogger<CorretoresController> _logger;

        public CorretoresController(ICorretorInterface icorretorInterface,
            ILogger<CorretoresController> logger)
        {
            _icorretorInterface = icorretorInterface;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CorretorEntity>>>> GetAll()
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var serviceResponse = await _icorretorInterface.GetAll();
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
        public async Task<ActionResult<ServiceResponse<CorretorEntity>>> GetEntityById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var serviceResponse = await _icorretorInterface.GetEntityById(id);
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
        public async Task<ActionResult<ServiceResponse<List<CorretorEntity>>>> Create(CorretorEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var serviceResponse = await _icorretorInterface.Create(entity);
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
        public async Task<ActionResult<ServiceResponse<List<CorretorEntity>>>> Update(CorretorEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var serviceResponse = await _icorretorInterface.Update(entity);
                _logger.LogInformation(serviceResponse.Mensagem);
                return Ok(serviceResponse);
            }
            catch (ArgumentException e)
            {
                _logger.LogError(e.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut("inativaCorretor")]
        public async Task<ActionResult<ServiceResponse<List<CorretorEntity>>>> Inativa(int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var serviceResponse = await _icorretorInterface.Inativa(id);
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
        public async Task<ActionResult<ServiceResponse<List<CorretorEntity>>>> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var serviceResponse = await _icorretorInterface.Delete(id);
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
