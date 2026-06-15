using UnitConversionAPI.Models;

namespace UnitConversionAPI.Services
{
    public interface IUnitConversionService
    {
        ConversionResponse Convert(ConversionRequest request);
    }
}
