
namespace elements.PlayfieldItems
{
    public class StaticObject : PlayfieldItem
    {
        public string image { get; set; }

        public StaticObject():base()
        {
            image = "";
        }
    }
}
