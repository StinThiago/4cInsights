using System;
using Microsoft.AspNetCore.Mvc;
using _cInsights.Business;
using _cInsights.Model;
using _cInsights.Business.Enum;

namespace _cInsights.Controllers
{
    [Route("v1/[controller]")]
    public class DiffController : Controller
    {

        /// <summary>
        /// Get the result of the comparison of the values "right" and "left" for the ID informed.
        /// GET /v1/diff
        /// </summary>
        /// <param name="id">id to search</param>
        /// <returns>JsonResult with the information</returns>
        [HttpGet("/v1/healthcheck")]
        public IActionResult GetHealthcheck(string id)
        {
            return new JsonResult("ALIVE");
        }

        /// <summary>
        /// Get the result of the comparison of the values "right" and "left" for the ID informed.
        /// GET v1/diff/{id}
        /// </summary>
        /// <param name="id">id to search</param>
        /// <returns>JsonResult with the information</returns>
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return new JsonResult(DiffBusiness.GetResult(id));
        }
        /// <summary>
        /// Inserts the value in the left property to the ID informed
        /// POST v1/diff/{id}/left
        /// </summary>
        /// <param name="input">JSON with the value</param>
        /// <param name="id">id to references </param>
        /// <returns>
        /// JsonResult with the information. "OK" - if all the information was stored in memory
        /// </returns>
        [HttpPost("{id}/left")]
        public IActionResult PostLeft([FromBody]InputValue input, string id)
        {
            if (input == null) throw new ArgumentNullException("input");
            if (input.value.Trim() == String.Empty) throw new ArgumentException("Input.value cannot be empty", "input");

            if (id == null) throw new ArgumentNullException("id");
            if (id.Trim() == String.Empty) throw new ArgumentException("id cannot be empty", "id");

            DiffBusiness.AddToStorage(id, input.value, EnumDirection.Left);
            return new JsonResult("OK");
        }
        /// <summary>
        /// Inserts the value in the right property to the ID informed
        /// POST v1/diff/{id}/right
        /// </summary>
        /// <param name="input">JSON with the value</param>
        /// <param name="id">id to references </param>
        /// <returns>
        /// JsonResult with the information. "OK" - if all the information was stored in memory
        /// </returns>
        [HttpPost("{id}/right")]
        public IActionResult PostRight([FromBody]InputValue input, string id)
        {
            if (input == null) throw new ArgumentNullException("input");
            if (input.value.Trim() == String.Empty) throw new ArgumentException("Input.value cannot be empty", "input");

            if (id == null) throw new ArgumentNullException("id");
            if (id.Trim() == String.Empty) throw new ArgumentException("id cannot be empty", "id");

            DiffBusiness.AddToStorage(id, input.value, EnumDirection.Right);
            return new JsonResult("OK");
        }
    }
}
