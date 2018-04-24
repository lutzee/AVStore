using System;
using System.Collections.Generic;
using System.Drawing;
using AVStore.Core;

namespace AVStore.Domain.Entities
{
    public class DetailType : Enumeration
    {
        public static DetailType Brand = new DetailType(1, "Brand", typeof(string));
        
        // I am constricting colors here to System.Drawring.Color to make color matchin easy
        public static DetailType PrimaryColor = new DetailType(2, "PrimaryColor", typeof(Color));

        // I am constricting colors here to System.Drawring.Color to make color matchin easy
        public static DetailType SecondaryColor = new DetailType(3, "SecondaryColor", typeof(Color));

        // I am constricting colors here to System.Drawring.Color to make color matchin easy
        public static DetailType Dimensions = new DetailType(4, "Dimensions", typeof(Dimension));

        public ICollection<Detail> Details { get; set; }

        public DetailType()
        {
        }

        public DetailType(int id, string name, Type valueType)
            :base(id, name, valueType)
        {
        }

        public static IEnumerable<DetailType> List()
        {
            return new[] { Brand, PrimaryColor, SecondaryColor, Dimensions };
        }
    }
}
