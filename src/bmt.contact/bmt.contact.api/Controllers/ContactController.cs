using bmt.contact.application.Commands;
using bmt.contact.application.DTO;
using bmt.contact.application.Queries;
using bmt.shared.abstractions.Commands;
using bmt.shared.abstractions.Queries;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bmt.contact.api.Controllers
{
    public class ContactController : BaseController
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public ContactController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        // GET: api/<ContactController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactDto>>> Get([FromQuery] SearchContact query)
        {
            var results = await _queryDispatcher.QueryAsync(query);
            return OkOrNotFound(results);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ContactDto>> Get([FromRoute] GetContact query)
        {
            try
            {
                var result = await _queryDispatcher.QueryAsync(query);
                return OkOrNotFound(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ContactController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateContact command)
        {
            try
            {
                await _commandDispatcher.DispatchAsync(command);
                return CreatedAtAction(nameof(Get), new { id = command.id }, null);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ContactController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateContact command)
        {
            try
            {
                await _commandDispatcher.DispatchAsync(command);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteContact command)
        {
            try
            {
                await _commandDispatcher.DispatchAsync(command);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
