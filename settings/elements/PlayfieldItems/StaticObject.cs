using elements.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace elements.PlayfieldItems
{
    public class StaticObject : PlayfieldItem
    {
        public string image { get; set; }

        public StaticObject():base()
        {
            image = "";
        }
    }
}
