using System;
using System.Collections.Generic;
using System.Text;

namespace elements
{
    public class Cs
    {
        public double num1 { get; set; }
        public double num2 { get; set; }
        public double num3 { get; set; }
        public double num4 { get; set; }
        public string orientation { get; set; }

        public object[] getCsAsArr()
        {
            return new object[] { num1, num2, num3, num4, orientation };
        }
    }
}
