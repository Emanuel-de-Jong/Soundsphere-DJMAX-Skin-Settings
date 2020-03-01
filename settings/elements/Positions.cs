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
                return name switch
                {
                    "measure1" => scratch1,
                    "scratch1" => scratch1,
                    "key1" => key1,
                    "key2" => key2,
                    "key3" => key3,
                    "key4" => key4,
                    "key5" => key5,
                    "key6" => key6,
                    "key7" => key7,
                    "key8" => key8,
                    "key9" => key9,
                    "key10" => key10,
                    "scratch2" => scratch2,
                    _ => measure1,
                };
            }
        }
    }
}
