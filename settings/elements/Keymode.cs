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

        public static List<Image> GetImages(int notes = 10, int scratches = 0)
        {
            List<Image> images = new List<Image>();

            string dir = "";
            if (notes >= 6)
            {
                dir = "6K";
            }
            else
            {
                dir = notes.ToString() + "K";
            }

            for (int i=1; i <=2; i++)
            {
                string noteCount = i.ToString();
                images.Add(new Image() { name = "n" + noteCount + "b", path = "resources/" + dir + "/note" + noteCount + "body.png", layer = sLayer.GetAndIncrement() });
                images.Add(new Image() { name = "n" + noteCount + "h", path = "resources/" + dir + "/note" + noteCount + "head.png", layer = sLayer.GetAndIncrement() });
                images.Add(new Image() { name = "n" + noteCount + "t", path = "resources/" + dir + "/note" + noteCount + "tail.png", layer = sLayer.GetAndIncrement() });
                images.Add(new Image() { name = "n" + noteCount, path = "resources/" + dir + "/note" + noteCount + ".png", layer = sLayer.GetAndIncrement() });
            }

            if (notes == 8)
            {
                for (int i = 1; i <= 2; i++)
                {
                    string side = i == 1 ? "left" : "right";
                    images.Add(new Image() { name = "fx" + side + "b", path = "resources/" + dir + "/fx" + side + "body.png", layer = sLayer.GetAndIncrement() });
                    images.Add(new Image() { name = "fx" + side + "h", path = "resources/" + dir + "/fx" + side + "head.png", layer = sLayer.GetAndIncrement() });
                    images.Add(new Image() { name = "fx" + side + "t", path = "resources/" + dir + "/fx" + side + "tail.png", layer = sLayer.GetAndIncrement() });
                    images.Add(new Image() { name = "fx" + side, path = "resources/" + dir + "/fx" + side + ".png", layer = sLayer.GetAndIncrement() });
                }
            }
            else if(notes == 10)
            {
                for (int i = 1; i <= 2; i++)
                {
                    string side = i == 1 ? "left" : "right";
                    for (int j = 1; j <= 2; j++)
                    {
                        string fxCount = i.ToString();
                        images.Add(new Image() { name = "fx" + side + "b", path = "resources/" + dir + "/fx" + side + "body.png", layer = sLayer.GetAndIncrement() });
                        images.Add(new Image() { name = "fx" + side + "h", path = "resources/" + dir + "/fx" + side + "head.png", layer = sLayer.GetAndIncrement() });
                        images.Add(new Image() { name = "fx" + side + "t", path = "resources/" + dir + "/fx" + side + "tail.png", layer = sLayer.GetAndIncrement() });
                        images.Add(new Image() { name = "fx" + side, path = "resources/" + dir + "/fx" + side + ".png", layer = sLayer.GetAndIncrement() });
                    }
                }
            }

            return images;
        }
    }
}
