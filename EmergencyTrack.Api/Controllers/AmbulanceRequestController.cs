using EmergencyTrack.Application.Abstractions;
using EmergencyTrack.Application.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmergencyTrack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmbulanceRequestController : ControllerBase
    {
        private readonly IAmbulanceRequestService _service;

        public AmbulanceRequestController(IAmbulanceRequestService service)
        {
            _service = service;
        }




        // GET: api/<AmbulanceRequestController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AmbulanceRequestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AmbulanceRequestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AmbulanceRequestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AmbulanceRequestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
