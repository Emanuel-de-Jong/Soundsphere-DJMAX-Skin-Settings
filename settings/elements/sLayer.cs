using System;
using System.Collections.Generic;
using System.Text;

namespace elements
{
    public static class sLayer
    {
        private static int layer = 1;

        public static int Layer
        {
            get
            {
                return layer;
            }
            set
            {
                layer = value;
            }
        }

        public static int GetAndIncrement()
        {
            return layer++;
        }
    }
}
