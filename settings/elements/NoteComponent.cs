
namespace elements
{
    public class NoteComponent
    {
        public int? cs { get; set; }
        public Gc gc { get; set; }
        public Sb sb { get; set; }
        public int layer { get; set; }
        public string image { get; set; }

        public NoteComponent()
        {
            gc = new Gc();
            sb = new Sb();
            layer = 0;
        }
    }
}
