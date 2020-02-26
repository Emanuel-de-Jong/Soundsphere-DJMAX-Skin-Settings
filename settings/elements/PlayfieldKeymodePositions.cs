
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
                switch (name)
                {
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
                    case "fxkey1":
                        return fxkey1;
                    case "fxkey2":
                        return fxkey2;
                    case "fxkey3":
                        return fxkey3;
                    case "fxkey4":
                        return fxkey4;
                    case "beam1":
                        return beam1;
                    case "beam2":
                        return beam2;
                    case "beam3":
                        return beam3;
                    case "beam4":
                        return beam4;
                    case "beam5":
                        return beam5;
                    case "beam6":
                        return beam6;
                    case "fxbeam1":
                        return fxbeam1;
                    case "fxbeam2":
                        return fxbeam2;
                    case "fxbeam3":
                        return fxbeam3;
                    case "fxbeam4":
                        return fxbeam4;
                    case "particle1":
                        return particle1;
                    case "particle2":
                        return particle2;
                    case "particle3":
                        return particle3;
                    case "particle4":
                        return particle4;
                    case "particle5":
                        return particle5;
                    case "particle6":
                        return particle6;
                    case "fxparticle1":
                        return fxparticle1;
                    case "fxparticle2":
                        return fxparticle2;
                    case "fxparticle3":
                        return fxparticle3;
                    case "fxparticle4":
                        return fxparticle4;
                }
                return key1;
            }
        }
    }
}
