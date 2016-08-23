using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace _cInsights.Controllers
{
    [Route("v1/[controller]")]
    public class DiffController : Controller
    {
        // GET v1/diff
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET v1/diff/{id}
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST v1/diff/{id}/left
        [HttpPost("{id}/left")]
        public IActionResult PostLeft(string id)
        {
            return new NoContentResult();
        }

        // POST v1/diff/{id}/right
        [HttpPost("{id}/right")]
        public IActionResult PostRight(string id)
        {
            return new NoContentResult();
        }
    }
}
