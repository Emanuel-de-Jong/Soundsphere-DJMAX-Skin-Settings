using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace elements
{
    public class Image
    {
        public string name { get; set; }
        public string path { get; set; }
        public int layer { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public eBlendMode blendMode { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public eBlendAlphaMode blendAlphaMode { get; set; }
    }
}
