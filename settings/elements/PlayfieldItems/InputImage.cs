﻿using elements.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace elements.PlayfieldItems
{
    public class InputImage : PlayfieldItem
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public eInputType inputType { get; set; }
        public int inputIndex { get; set; }
        public string released { get; set; }
        public string pressed { get; set; }

        public InputImage():base()
        {
            inputType = eInputType.key;
            inputIndex = 0;
            released = "";
            pressed = "";
        }
    }
}
