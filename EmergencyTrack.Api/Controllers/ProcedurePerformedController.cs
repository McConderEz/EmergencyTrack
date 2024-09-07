using EmergencyTrack.Application.Abstractions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmergencyTrack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedurePerformedController : ControllerBase
    {
        private readonly IProcedurePerformedService _service;

        public ProcedurePerformedController(IProcedurePerformedService service)
        {
            _service = service;
        }



        // GET: api/<ProcedurePerformedController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProcedurePerformedController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProcedurePerformedController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProcedurePerformedController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProcedurePerformedController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
