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

        public Keymode()
        {
            name = "";
            playfield = "";
            cses = new List<object[]>();
            images = new List<Image>();
            notes = new Dictionary<string, Dictionary<string, NoteComponent>>();
        }

        public static List<Image> GetImages(int notes = 10, int scratches = 0, int layer = 0)
        {
            this.layer = layer;

            List<Image> images = new List<Image>();

            if(notes == 4)
            {
                Image image = new Image() { name = "n1", path = "resources/4K/note1.png", layer = 0 };
            }


            return images;
        }
    }
}
