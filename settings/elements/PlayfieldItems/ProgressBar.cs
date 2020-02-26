using System.Collections.Generic;

namespace elements.PlayfieldItems
{
    public class ProgressBar : PlayfieldItem
    {
        public List<int> color { get; set; }
        public string direction { get; set; }
        public string mode { get; set; }

        public ProgressBar():base()
        {
            color = new List<int>() { 0, 0, 0, 0 };
            direction = "";
            mode = "";
        }
    }
}
