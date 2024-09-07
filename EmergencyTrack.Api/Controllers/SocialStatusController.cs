using EmergencyTrack.Application.Abstractions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmergencyTrack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialStatusController : ControllerBase
    {
        private readonly ISocialStatusService _service;

        public SocialStatusController(ISocialStatusService service)
        {
            _service = service;
        }



        // GET: api/<SocialStatusController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SocialStatusController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SocialStatusController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SocialStatusController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SocialStatusController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
