
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
                return number switch
                {
                    1 => stparticle1,
                    2 => stparticle2,
                    _ => stparticle1,
                };
            }
        }
    }
}
