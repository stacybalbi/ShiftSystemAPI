using Microsoft.AspNetCore.Mvc;
using Queue.Application.Queue.Dto;
using Queue.Application.Queue.Handlers;

namespace Queue.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        private readonly IQueueHandler _queueHandler;
        public QueueController(IQueueHandler queueHandler)
        {
            _queueHandler = queueHandler;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var entityToReturn = await _queueHandler.GetById(id);

            if (entityToReturn == null)
                return NotFound();

            return Ok(entityToReturn);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int top = 50)
        {
            var entitiesToReturn = await _queueHandler.GetAll(top);

            if (entitiesToReturn == null)
                return NotFound();

            return Ok(entitiesToReturn);
        }

        [HttpPost("{name}")]
        public async Task<IActionResult> Create([FromRoute] string name)
        {
            try
            {
                QueueDto queueDto = new QueueDto { name = name };
                var entityToCreate = await _queueHandler.Create(queueDto);
                return Ok(entityToCreate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] QueueDto dto)
        {
            try
            {
                await _queueHandler.Update(dto);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _queueHandler.Delete(id);
            return Ok();
        }
    }
}
