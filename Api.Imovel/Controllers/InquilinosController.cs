using Api.Domain.Interfaces.Inquilino;
using Api.Entities.Entity.Inquilinos;
using Api.Entities.Entity.ServiceResponse;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Imovel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InquilinosController : ControllerBase
    {
        private readonly InquilinoInterface _inquilinoInterface;
        private readonly ILogger<CorretoresController> _logger;
        public InquilinosController(InquilinoInterface inquilinoInterface,
            ILogger<CorretoresController> logger)
        {
            _inquilinoInterface = inquilinoInterface;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<InquilinoEntity>>>> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var serviceResponse = await _inquilinoInterface.GetAll();
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
        public async Task<ActionResult<ServiceResponse<InquilinoEntity>>> GetEntityById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var serviceResponse = await _inquilinoInterface.GetEntityById(id);
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
        public async Task<ActionResult<ServiceResponse<List<InquilinoEntity>>>> Create(InquilinoEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var serviceResponse = await _inquilinoInterface.Create(entity);
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
        public async Task<ActionResult<ServiceResponse<List<InquilinoEntity>>>> Update(InquilinoEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var serviceResponse = await _inquilinoInterface.Update(entity);
                _logger.LogInformation(serviceResponse.Mensagem);
                return Ok(serviceResponse);
            }
            catch (ArgumentException e)
            {
                _logger.LogError(e.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut("inativaInquilino")]
        public async Task<ActionResult<ServiceResponse<List<InquilinoEntity>>>> Inativa(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var serviceResponse = await _inquilinoInterface.Inativa(id);
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
        public async Task<ActionResult<ServiceResponse<List<InquilinoEntity>>>> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var serviceResponse = await _inquilinoInterface.Delete(id);
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
