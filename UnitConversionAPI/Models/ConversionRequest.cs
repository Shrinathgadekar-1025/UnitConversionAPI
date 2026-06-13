using System.ComponentModel.DataAnnotations;

namespace UnitConversionAPI.Models
{
    public class ConversionRequest
    {
        [Required]
        public string FromUnit { get; set; } = string.Empty;

        [Required]
        public string ToUnit { get; set; } = string.Empty;

        [Range(double.MinValue, double.MaxValue)]
        public double Value { get; set; }
    }
}
