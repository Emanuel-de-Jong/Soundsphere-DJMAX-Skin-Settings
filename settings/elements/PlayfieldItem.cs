using elements.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace elements
{
    public class PlayfieldItem
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public eClass classa { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public double w { get; set; }
        public double h { get; set; }
        public int layer { get; set; }
        public object[] cs { get; set; }

        public PlayfieldItem()
        {
            classa = eClass.ProgressBar;
            x = 0;
            y = 0;
            w = 0;
            h = 0;
            layer = 0;
        }
    }
}
