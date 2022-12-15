using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Person.Application.Person.Dto;
using Person.Application.Person.Handlers;
using Person.Infrastructure.Services;

namespace Person.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonHandler _personHandler;
        private readonly IWebHostEnvironment _env;
        public PersonController(IPersonHandler personHandler, IWebHostEnvironment env)
        {
            _personHandler = personHandler;
            _env = env;
        }

        

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var entityToReturn = await _personHandler.GetById(id);

            if (entityToReturn == null)
                return NotFound();

            return Ok(entityToReturn);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int top = 50)
        {
            var entitiesToReturn = await _personHandler.Get(top);

            if (entitiesToReturn == null)
                return NotFound();

            return Ok(entitiesToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] PersonDto personDto)
        {
            try
            {
                var entityToCreate = await _personHandler.Create(personDto);
                return Ok(entityToCreate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }
    }
}
