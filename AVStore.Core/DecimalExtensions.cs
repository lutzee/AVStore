namespace AVStore.Core
{
    public static class DecimalExtensions
    {
        public static string ToMillimeters(this decimal value)
        {
            return $"{value}mm";
        }

        public static string ToCentimeters(this decimal value)
        {
            return $"{value / 100}cm";
        }

        public static string ToMeters(this decimal value)
        {
            return $"{value / 1000}m";
        }
    }
}
