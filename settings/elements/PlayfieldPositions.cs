using System;
using System.Collections.Generic;
using System.Text;

namespace elements
{
    public class PlayfieldPositions
    {
        public Dictionary<string, double> novidbg { get; set; }
        public Dictionary<string, double> bg { get; set; }
        public Dictionary<string, double> combobg { get; set; }
        public Dictionary<string, double> judgeline { get; set; }
        public Dictionary<string, double> playfield { get; set; }
        public Dictionary<string, double> combo { get; set; }
        public Dictionary<string, object> combogame { get; set; }
        public Dictionary<string, object> progressbar { get; set; }
        public Dictionary<string, double> rate { get; set; }
        public Dictionary<string, object> accuracy { get; set; }
        public Dictionary<string, object> timegate { get; set; }
        public Dictionary<string, object> combofield { get; set; }
        public Dictionary<string, object> scorefield { get; set; }
        public Dictionary<string, double> progressbarbg { get; set; }
    }
}
