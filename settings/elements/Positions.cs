using System.Collections.Generic;

namespace elements
{
    class Positions
    {
        public Dictionary<string, Dictionary<string, Dictionary<string, List<double>>>> measure1 { get; set; }
        public Dictionary<string, Dictionary<string, Dictionary<string, List<double>>>> scratch1 { get; set; }
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
        public Dictionary<string, Dictionary<string, Dictionary<string, List<double>>>> scratch2 { get; set; }

        public Dictionary<string, Dictionary<string, Dictionary<string, List<double>>>> this[string name]
        {
            get
            {
                switch (name)
                {
                    case "measure1":
                        return scratch1;
                    case "scratch1":
                        return scratch1;
                    case "key1":
                        return key1;
                    case "key2":
                        return key2;
                    case "key3":
                        return key3;
                    case "key4":
                        return key4;
                    case "key5":
                        return key5;
                    case "key6":
                        return key6;
                    case "key7":
                        return key7;
                    case "key8":
                        return key8;
                    case "key9":
                        return key9;
                    case "key10":
                        return key10;
                    case "scratch2":
                        return scratch2;
                }
                return measure1;
            }
        }
    }
}
