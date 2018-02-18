using System.Text.RegularExpressions;

namespace AVStore.Core
{
    public class Dimension
    {
        public decimal Width { get; set; }

        public decimal Height { get; set; }

        public decimal Depth { get; set; }

        public Dimension()
        {
        }

        public static Dimension TryParse(string dimensions)
        {
            var regex = new Regex(@"(?'width'(?'widthValue'[0-9]+|\.[0-9]+|[0-9]+\.[0-9]+)(?'widthScale'c|m)?m)\*(?'height'(?'heightValue'[0-9]+|\.[0-9]+|[0-9]+\.[0-9]+)(?'heightScale'c|m)?m)\*(?'depth'(?'depthValue'[0-9]+|\.[0-9]+|[0-9]+\.[0-9]+)(?'depthScale'c|m)?m)");
            var matches = regex.Match(dimensions);
            if (matches.Success == false)
            {
                return null;
            }

            var dimension = new Dimension
            {
                Width = ParseDecimalWithScale(matches.Groups["widthValue"].Value, matches.Groups["widthScale"].Value),
                Height = ParseDecimalWithScale(matches.Groups["heightValue"].Value, matches.Groups["heightScale"].Value),
                Depth = ParseDecimalWithScale(matches.Groups["depthValue"].Value, matches.Groups["depthScale"].Value)
            };

            return dimension;
        }

        private static decimal ParseDecimalWithScale(string value, string scale)
        {
            decimal.TryParse(value, out var result);
            if (scale == "c")
            {
                result = result * 100;
            }
            else if (scale == "")
            {
                result = result * 1000;
            }

            return result;
        }

        public Dimension(decimal height, decimal width, decimal depth)
        {
            Height = height;
            Width = width;
            Depth = depth;
        }

        public override bool Equals(object obj)
        {
            return obj is Dimension dimension &&
                   Width == dimension.Width &&
                   Height == dimension.Height &&
                   Depth == dimension.Depth;
        }

        protected bool Equals(Dimension other)
        {
            return Width == other.Width && Height == other.Height && Depth == other.Depth;
        }

        public override int GetHashCode()
        {
            // As we are doing arithmatical operations based on integral types, we might overflow the bounds of the types
            // Unchecked keyword supresses any exceptions raised from doing this
            unchecked
            {
                var hashCode = Width.GetHashCode();
                hashCode = (hashCode * 397) ^ Height.GetHashCode();
                hashCode = (hashCode * 397) ^ Depth.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// Converts the dimension into a string repesentation using the most sensible value range in 
        /// </summary>
        public override string ToString()
        {
            if (Width <= 10 && Height <= 10 && Depth <= 10)
            {
                return $"{Width.ToMillimeters()}x{Height.ToMillimeters()}x{Depth.ToMillimeters()}";
            }

            if (Width >= 10 && Width <= 100 && Height >= 10 && Height <= 100 && Depth >= 10 && Depth <= 100 )
            {
                return $"{Width.ToCentimeters()}x{Height.ToCentimeters()}x{Depth.ToCentimeters()}";
            }

            return $"{Width.ToMeters()}x{Height.ToMeters()}x{Depth.ToMeters()}";
        }
    }
}
