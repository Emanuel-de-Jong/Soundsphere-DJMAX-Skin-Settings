using System;
using System.Collections.Generic;
using System.Text;

namespace elements.PlayfieldItems
{
    public class ProgressBar : PlayfieldItem
    {
        public int[] color { get; set; }
        public string direction { get; set; }
        public string mode { get; set; }

        public ProgressBar():base()
        {
            color = new int[] { 0, 0, 0, 0 };
            direction = "";
            mode = "";
        }
    }
}
