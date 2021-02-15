
namespace SimpleRandom
{
    public class XorShiftRandom : Random32
    {
        //ref: https://en.wikipedia.org/wiki/Xorshift

        uint m_Seed;
        
        public override int RandMax => int.MaxValue;

        public override void Init(int seed) => Init((uint)seed);
        public override void Init(uint seed)
        {
            m_Seed = seed;
        }

        public override int Rand()
        {
            uint x = m_Seed;
            x ^= x << 13;
            x ^= x >> 17;
            x ^= x << 5;
            m_Seed = x;
            return (int)(m_Seed >> 1);
        }
    }
}
