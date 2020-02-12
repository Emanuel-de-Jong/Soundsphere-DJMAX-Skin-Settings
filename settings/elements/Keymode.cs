using System;
using System.Collections.Generic;

namespace elements
{
    public class Keymode
    {
        public string name { get; set; }
        public string playfield { get; set; }
        public List<object[]> cses { get; set; }
        public List<Image> images { get; set; }
        public Dictionary<string, Dictionary<string, NoteComponent>> notes { get; set; }
    }
}
