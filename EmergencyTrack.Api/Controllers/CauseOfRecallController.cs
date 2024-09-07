using EmergencyTrack.Application.Abstractions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmergencyTrack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CauseOfRecallController : ControllerBase
    {
        private readonly ICauseOfRecallService _service;

        public CauseOfRecallController(ICauseOfRecallService service)
        {
            _service = service;
        }



        // GET: api/<CauseOfRecallController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CauseOfRecallController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CauseOfRecallController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CauseOfRecallController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CauseOfRecallController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
