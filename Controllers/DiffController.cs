using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using _cInsights.Model;
using _cInsights.Business;
using _cInsights.Business.Distance;
using _cInsights.Controllers.Input;
using System;
using System.Text;

namespace _cInsights.Controllers
{
    [Route("v1/[controller]")]
    public class DiffController : Controller
    {
        // GET v1/diff
        [HttpGet]
        public IEnumerable<Diff> GetAllDiferences()
        {
            return DiffBusiness.GetAllResults();
        }

        // GET v1/diff/{id}
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var diff = DiffBusiness.FindAll(id);
            var right = diff[0].right;
            var rightBase64Decoded = Encoding.UTF8.GetString(Convert.FromBase64String(right));
            var left = diff[0].left;
            var leftBase64Decoded = Encoding.UTF8.GetString(Convert.FromBase64String(left));

            var result = LCS.Result(rightBase64Decoded, leftBase64Decoded);
            var simple = right.CompareTo(left);
            
            return new JsonResult(simple + "|" + result + " | " + right + " | " + rightBase64Decoded + " | " + left + " | " + leftBase64Decoded);
        }

        // POST v1/diff/{id}/left
        [HttpPost("{id}/left")]
        public IActionResult PostLeft([FromBody]InputValue input, string id)
        {
            DiffBusiness.AddDiffToComparer(id, input.value, EnumDirection.Left);
            return new JsonResult(id + " | " + input.ToString() + "|" + Diff.ListInstance.FindLast(x => x.id.Equals(id)).ToString());
        }

        // POST v1/diff/{id}/right
        [HttpPost("{id}/right")]
        public IActionResult PostRight([FromBody]InputValue input, string id)
        {
            DiffBusiness.AddDiffToComparer(id, input.value, EnumDirection.Right);
            return new JsonResult(id + " | " + input.ToString() + "|" + Diff.ListInstance.FindLast(x => x.id.Equals(id)).ToString());
        }
    }
}
