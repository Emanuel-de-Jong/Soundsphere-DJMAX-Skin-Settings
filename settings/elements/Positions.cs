using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace elements
{
    class Positions
    {
        public Dictionary<string, Dictionary<string, Dictionary<string, List<double>>>> measure1 { get; set; }
        public Dictionary<string, Dictionary<string, Dictionary<string, List<double>>>> key1 { get; set; }
        public Dictionary<string, Dictionary<string, Dictionary<string, List<double>>>> key2 { get; set; }
        public Dictionary<string, Dictionary<string, Dictionary<string, List<double>>>> key3 { get; set; }
        public Dictionary<string, Dictionary<string, Dictionary<string, List<double>>>> key4 { get; set; }
        public Dictionary<string, Dictionary<string, Dictionary<string, List<double>>>> key5 { get; set; }
        public Dictionary<string, Dictionary<string, Dictionary<string, List<double>>>> key6 { get; set; }
        public Dictionary<string, Dictionary<string, Dictionary<string, List<double>>>> key7 { get; set; }
        public Dictionary<string, Dictionary<string, Dictionary<string, List<double>>>> key8 { get; set; }
        public Dictionary<string, Dictionary<string, Dictionary<string, List<double>>>> key9 { get; set; }
        public Dictionary<string, Dictionary<string, Dictionary<string, List<double>>>> key10 { get; set; }
        public Dictionary<string, Dictionary<string, Dictionary<string, List<double>>>> scratch1 { get; set; }
        public Dictionary<string, Dictionary<string, Dictionary<string, List<double>>>> scratch2 { get; set; }

        public Dictionary<string, Dictionary<string, Dictionary<string, List<double>>>> this[int index]
        {
            get
            {
                switch (index)
                {
                    case 1:
                        return key1;
                    case 2:
                        return key2;
                    case 3:
                        return key3;
                    case 4:
                        return key4;
                    case 5:
                        return key5;
                    case 6:
                        return key6;
                    case 7:
                        return key7;
                    case 8:
                        return key8;
                    case 9:
                        return key9;
                    case 10:
                        return key10;
                }
                return measure1;
            }
        }
    }
}
