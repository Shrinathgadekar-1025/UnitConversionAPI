using Microsoft.AspNetCore.Mvc;
using UnitConversionAPI.Services;

namespace UnitConversionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnitConversionController : ControllerBase
    {
        private readonly IUnitConversionService _conversionService;

        public UnitConversionController(IUnitConversionService conversionService)
        {
            _conversionService = conversionService;
        }

        [HttpPost("convert")]
        public IActionResult Convert ([FromBody] Models.ConversionRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = _conversionService.Convert(request);
            return Ok(response);
        }
    }
}
