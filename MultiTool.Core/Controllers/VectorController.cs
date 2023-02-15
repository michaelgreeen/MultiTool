using Microsoft.AspNetCore.Mvc;
using MultiTool.Core.Providers;
using MultiTool.Models;

namespace MultiTool.Core.Controllers
{
    [Route("[controller]/[action]")]
    public class VectorController : Controller
    {
        private readonly ICalculationProvider _calculationProvider;
        public VectorController(ICalculationProvider calculationProvider)
        {
            _calculationProvider = calculationProvider;
        }
        [HttpPost]
        public ActionResult<double> GetLength([FromBody] VectorDto vector)
        {
            var result = _calculationProvider.GetVectorLength(vector.x, vector.y, vector.z);
            
            return result >= 0 ? Ok(result) : BadRequest();
        }
    }
}
