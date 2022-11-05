using bmt.contact.application.Commands;
using bmt.contact.application.DTO;
using bmt.contact.application.Queries;
using bmt.shared.abstractions.Commands;
using bmt.shared.abstractions.Queries;
using Microsoft.AspNetCore.Mvc;

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
            var result = await _queryDispatcher.QueryAsync(query);
            return OkOrNotFound(result);
        }

        // POST api/<ContactController>
        [HttpPost]
        public async Task<IActionResult> Post(CreateContact command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return CreatedAtAction(nameof(Get), new { id = command.id }, null);
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
