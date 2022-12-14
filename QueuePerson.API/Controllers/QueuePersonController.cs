using Microsoft.AspNetCore.Mvc;
using Queue.Application.Queue.Handlers;
using QueuePerson.Application.QueuePerson.Dto;
using QueuePerson.Application.QueuePerson.Handlers;
using QueuePerson.Infrastructure.Context;

namespace QueuePerson.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueuePersonController : ControllerBase
    {
        private readonly IQueuePersonHandler _queuePersonHandler;
        private readonly IQueuePersonDbContext _dbcontext;
        public QueuePersonController(IQueuePersonHandler queuePersonHandler, IQueuePersonDbContext dbconext)
        {
            _queuePersonHandler = queuePersonHandler;
            _dbcontext = dbconext;
        }


        [HttpGet("{queueId}")]
        public async Task<IActionResult> Get([FromRoute] int queueId)
        {
            var entitiesToReturn = await _queuePersonHandler.GetByQueueId(queueId);

            if (entitiesToReturn == null)
                return NotFound();

            return Ok(entitiesToReturn);
        }


        [HttpPost("Put")]
        public async Task<IActionResult> Put([FromBody] QueuePersonDto queuePerson)
        {
            try
            {
                await _queuePersonHandler.Put(queuePerson);
                _dbcontext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPost("Push/{queueId}")]
        public async Task<IActionResult> Push([FromRoute] int queueId)
        {
            try
            {
                await _queuePersonHandler.Push(queueId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

    }
}
