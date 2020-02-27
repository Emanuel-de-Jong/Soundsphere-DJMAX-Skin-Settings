
namespace elements
{
    public class PlayfieldSTPositions
    {
        public PlayfieldPositionsItem stparticle1 { get; set; }
        public PlayfieldPositionsItem stparticle2 { get; set; }

        public PlayfieldPositionsItem this[int number]
        {
            get
            {
                switch (number)
                {
                    case 1:
                        return stparticle1;
                    case 2:
                        return stparticle2;
                }
                return stparticle1;
            }
        }
    }
}
