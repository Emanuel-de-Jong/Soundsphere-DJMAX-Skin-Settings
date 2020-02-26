
namespace elements
{
    public class MetaDataItem
    {
        public string name { get; set; }
        public string inputMode { get; set; }
        public string type { get; set; }
        public string path { get; set; }

        public MetaDataItem()
        {
            name = "";
            inputMode = "";
            type = "";
            path = "";
        }
    }
}
