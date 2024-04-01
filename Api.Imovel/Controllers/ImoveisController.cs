using Api.Domain.Interfaces.Imovel;
using Api.Entities.Entity.Imovel;
using Api.Entities.Entity.ServiceResponse;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Imovel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImoveisController : ControllerBase
    {
        private readonly IimovelInterface _imovelInterface;
        private readonly ILogger<CorretoresController> _logger;
        public ImoveisController(IimovelInterface imovelInterface,
            ILogger<CorretoresController> logger)
        {
            _imovelInterface = imovelInterface;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ImovelEntity>>>> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var serviceResponse = await _imovelInterface.GetAll();
                _logger.LogInformation(serviceResponse.Mensagem);
                return Ok(serviceResponse);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ImovelEntity>>> GetEntityById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var serviceResponse = await _imovelInterface.GetEntityById(id);
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
        public async Task<ActionResult<ServiceResponse<List<ImovelEntity>>>> Create(ImovelEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var serviceResponse = await _imovelInterface.Create(entity);
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
        public async Task<ActionResult<ServiceResponse<List<ImovelEntity>>>> Update(ImovelEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var serviceResponse = await _imovelInterface.Update(entity);
                _logger.LogInformation(serviceResponse.Mensagem);
                return Ok(serviceResponse);
            }
            catch (ArgumentException e)
            {
                _logger.LogError(e.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut("inativaImovel")]
        public async Task<ActionResult<ServiceResponse<List<ImovelEntity>>>> Inativa(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var serviceResponse = await _imovelInterface.Inativa(id);
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
        public async Task<ActionResult<ServiceResponse<List<ImovelEntity>>>> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var serviceResponse = await _imovelInterface.Delete(id);
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
