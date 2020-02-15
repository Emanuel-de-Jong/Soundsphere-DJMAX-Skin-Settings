using System;
using System.Collections.Generic;
using System.Text;

namespace elements
{
    public static class sCs
    {
        private static object[] cs = new object[] { 0.5, 0, 0, 0, eBinding.h.ToString() };

        public static object[] Cs
        {
            get
            {
                return cs;
            }
            set
            {
                cs = value;
            }
        }
    }
}
