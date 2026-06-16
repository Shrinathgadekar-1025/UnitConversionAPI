using UnitConversionAPI.Exceptions;
using UnitConversionAPI.Models;

namespace UnitConversionAPI.Services
{
    public class UnitConversionService : IUnitConversionService
    {
        public ConversionResponse Convert(ConversionRequest request)
        {
            var from = request.FromUnit.Trim().ToLower();
            var to = request.ToUnit.Trim().ToLower();

            double result;
            string category;

            if(LengthUnits.Contains(from) && LengthUnits.Contains(to))
            {
                category = "Length";
                result = ConvertLength(request.Value, from, to);
            }
            else if(WeightUnits.Contains(from) && WeightUnits.Contains(to))
            {
                category = "Weight";
                result = ConvertWeight(request.Value, from, to);
            }
            else if (TemperatureUnits.Contains(from) && TemperatureUnits.Contains(to))
            {
                category = "Temperature";
                result = ConvertTemperature(request.Value, from, to);
            }
            else
            {
                throw new InvalidException($"Conversion from '{request.FromUnit}' to '{request.ToUnit}' is not supported.");
            }

            return new ConversionResponse
            {
                FromUnit = request.FromUnit,
                ToUnit = request.ToUnit,
                InputValue = request.Value,
                Result = Math.Round(result, 4),
                Category = category
            };
        }

        #region Length

        private static readonly Dictionary<string, double> LengthFactors = new()
        {
            { "millimeter",0.001 },
            { "centimeter",0.01 },
            { "meter",1 },
            { "kilometer",1000 },
            { "inch",0.0254 },
            { "foot",0.3048 },
            { "yard",0.9144 },
            { "mile",1609.344 }
        };

        private static readonly HashSet<string> LengthUnits = LengthFactors.Keys.ToHashSet();

        private double ConvertLength(double value, string from, string to)
        {
            double meters = value * LengthFactors[from];
            return meters / LengthFactors[to];
        }

        #endregion

        #region Weight

        private static readonly Dictionary<string, double> WeightFactors = new()
        {
            { "gram",0.001 },
            { "kilogram",1 },
            { "pound",0.45359237 },
            { "ounce",0.0283495231 }
        };

        private static readonly HashSet<string> WeightUnits = WeightFactors.Keys.ToHashSet();

        private double ConvertWeight(double value, string from, string to)
        {
            double kilograms = value * WeightFactors[from];
            return kilograms / WeightFactors[to];
        }

        #endregion

        #region Temperature

        private static readonly HashSet<string> TemperatureUnits = new()
        {
            "celsius",
            "fahrenheit",
            "kelvin"
        };

        private double ConvertTemperature(double value, string from, string to)
        {
            double celsius = from switch
            {
                "celsius" => value,
                "fahrenheit" => (value - 32) * 5 / 9,
                "kelvin" => value - 273.15,
                _ => throw new ArgumentException("Invalid temperature unit.")
            };

            return to switch
            {
                "celsius" => celsius,
                "fahrenheit" => (celsius * 9 / 5) + 32,
                "kelvin" => celsius + 273.15,
                _ => throw new ArgumentException("Invalid temperature unit.")
            };
        }
        #endregion
    }
}

