
namespace elements
{
    public class PlayfieldKeymodePositions
    {
        public PlayfieldPositionsItem key1 { get; set; }
        public PlayfieldPositionsItem key2 { get; set; }
        public PlayfieldPositionsItem key3 { get; set; }
        public PlayfieldPositionsItem key4 { get; set; }
        public PlayfieldPositionsItem key5 { get; set; }
        public PlayfieldPositionsItem key6 { get; set; }
        public PlayfieldPositionsItem fxkey1 { get; set; }
        public PlayfieldPositionsItem fxkey2 { get; set; }
        public PlayfieldPositionsItem fxkey3 { get; set; }
        public PlayfieldPositionsItem fxkey4 { get; set; }

        public PlayfieldPositionsItem beam1 { get; set; }
        public PlayfieldPositionsItem beam2 { get; set; }
        public PlayfieldPositionsItem beam3 { get; set; }
        public PlayfieldPositionsItem beam4 { get; set; }
        public PlayfieldPositionsItem beam5 { get; set; }
        public PlayfieldPositionsItem beam6 { get; set; }
        public PlayfieldPositionsItem fxbeam1 { get; set; }
        public PlayfieldPositionsItem fxbeam2 { get; set; }
        public PlayfieldPositionsItem fxbeam3 { get; set; }
        public PlayfieldPositionsItem fxbeam4 { get; set; }

        public PlayfieldPositionsItem particle1 { get; set; }
        public PlayfieldPositionsItem particle2 { get; set; }
        public PlayfieldPositionsItem particle3 { get; set; }
        public PlayfieldPositionsItem particle4 { get; set; }
        public PlayfieldPositionsItem particle5 { get; set; }
        public PlayfieldPositionsItem particle6 { get; set; }
        public PlayfieldPositionsItem fxparticle1 { get; set; }
        public PlayfieldPositionsItem fxparticle2 { get; set; }
        public PlayfieldPositionsItem fxparticle3 { get; set; }
        public PlayfieldPositionsItem fxparticle4 { get; set; }


        public PlayfieldPositionsItem this[string name]
        {
            get
            {
                return name switch
                {
                    "key1" => key1,
                    "key2" => key2,
                    "key3" => key3,
                    "key4" => key4,
                    "key5" => key5,
                    "key6" => key6,
                    "fxkey1" => fxkey1,
                    "fxkey2" => fxkey2,
                    "fxkey3" => fxkey3,
                    "fxkey4" => fxkey4,
                    "beam1" => beam1,
                    "beam2" => beam2,
                    "beam3" => beam3,
                    "beam4" => beam4,
                    "beam5" => beam5,
                    "beam6" => beam6,
                    "fxbeam1" => fxbeam1,
                    "fxbeam2" => fxbeam2,
                    "fxbeam3" => fxbeam3,
                    "fxbeam4" => fxbeam4,
                    "particle1" => particle1,
                    "particle2" => particle2,
                    "particle3" => particle3,
                    "particle4" => particle4,
                    "particle5" => particle5,
                    "particle6" => particle6,
                    "fxparticle1" => fxparticle1,
                    "fxparticle2" => fxparticle2,
                    "fxparticle3" => fxparticle3,
                    "fxparticle4" => fxparticle4,
                    _ => key1,
                };
            }
        }
    }
}
