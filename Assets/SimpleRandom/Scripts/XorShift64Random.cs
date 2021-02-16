
namespace SimpleRandom
{
    public class XorShift64Random : Random64
    {
        //ref: https://en.wikipedia.org/wiki/Xorshift

        ulong m_Seed;

        public override void Init(ulong seed) => m_Seed = seed;

        public override ulong GetRand()
        {
            ulong x = m_Seed;
            x ^= x << 13;
            x ^= x >> 7;
            x ^= x << 17;
            m_Seed = x;
            return m_Seed;
        }
    }
}