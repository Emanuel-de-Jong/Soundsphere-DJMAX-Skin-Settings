using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace elements
{
    public class Cs
    {
        public double x { get; set; }
        public double y { get; set; }
        public double a { get; set; }
        public double b { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public eBinding binding { get; set; }

        public object[] getCsAsArr()
        {
            return new object[] { x, y, a, b, Convert.ToString(binding) };
        }
    }
}
