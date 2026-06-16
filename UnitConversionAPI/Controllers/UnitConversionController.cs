using Microsoft.AspNetCore.Mvc;
using UnitConversionAPI.Services;

namespace UnitConversionAPI.Controllers
{
    /// <summary>
    /// Performs unit conversions.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UnitConversionController : ControllerBase
    {
        private readonly IUnitConversionService _conversionService;

        public UnitConversionController(IUnitConversionService conversionService)
        {
            _conversionService = conversionService;
        }

        /// <summary>
        /// Converts one unit into another.
        /// </summary>
        /// <param name="request">Conversion request.</param>
        /// <returns>Converted result.</returns>
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
