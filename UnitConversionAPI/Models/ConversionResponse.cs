namespace UnitConversionAPI.Models
{
    public class ConversionResponse
    {
        public string FromUnit { get; set; } = string.Empty;
        public string ToUnit { get; set; } = string.Empty;
        public double InputValue { get; set; }
        public double Result { get; set; }
        public string Category { get; set; } = string.Empty;
    }
}
