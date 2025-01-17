﻿using elements.Enums;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace elements.PlayfieldItems
{
    public class ScoreDisplay:PlayfieldItem
    {
        public List<int> color { get; set; }
        public string format { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public eField field { get; set; }
        public Dictionary<string, string> align { get; set; }
        public string font { get; set; }
        public int size { get; set; }

        public ScoreDisplay():base()
        {
            color = new List<int>() { 0, 0, 0, 0 };
            format = "";
            field = eField.score;
            align = new Dictionary<string, string>() { { "x", "" }, { "y", "" } };
            font = "";
            size = 0;
        }
    }
}
