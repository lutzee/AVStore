using System;
using System.Drawing;
using AVStore.Core;
using AVStore.Domain.Models;

namespace AVStore.Domain.Extensions
{
    public static class DetailExtensions
    {
        public static Dimension ToDimension(this Detail detail)
        {
            return !detail.Type.Name.Equals(DetailType.Dimensions.Name, StringComparison.OrdinalIgnoreCase) 
                ? null 
                : Dimension.TryParse(detail.Value);
        }

        public static Color? ToColor(this Detail detail)
        {
            var typeName = detail.Type.Name;
            return !typeName.Equals(DetailType.PrimaryColor.Name, StringComparison.OrdinalIgnoreCase) 
                   || !typeName.Equals(DetailType.SecondaryColor.Name, StringComparison.OrdinalIgnoreCase)
                ? (Color?)null
                : Color.FromName(detail.Value);
        }
    }
}
