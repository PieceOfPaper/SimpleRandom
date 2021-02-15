
namespace SimpleRandom
{
    public class Well512Random : Random32
    {
        //ref: http://www.iro.umontreal.ca/~panneton/WELLRNG.html

        const uint W = 32;
        const uint R = 16;
        const uint P = 0;
        const uint M1 = 13;
        const uint M2 = 9;
        const uint M3 = 5;

        uint m_StateIndex = 0;
        uint[] m_States = new uint[R];
      

        public override void Init(int seed) => Init((uint)seed);
        public override void Init(uint seed)
        {
            m_StateIndex = 0;
            for (int i = 0; i < R; i ++)
            {
                m_States[i] = seed;
                seed += seed + 100;
            }
        }

        public override int Rand()
        {
            var z0 = m_States[(m_StateIndex+15) & 0x0000000fU];
            var z1 = (m_States[m_StateIndex]^(m_States[m_StateIndex]<<(16))) ^ (m_States[(m_StateIndex+M1) & 0x0000000fU]^(m_States[(m_StateIndex+M1) & 0x0000000fU]<<(15)));
            var z2 = (m_States[(m_StateIndex+M2) & 0x0000000fU]^(m_States[(m_StateIndex+M2) & 0x0000000fU]>>11));
            var newV1 = z1 ^ z2; 
            var newV0 = (z0^(z0<<2)) ^ (z1^(z1<<18)) ^ (z2<<28) ^ (newV1 ^ ((newV1<<5)) & 0xda442d24U);
            m_StateIndex = (m_StateIndex + 15) & 0x0000000fU;
            m_States[m_StateIndex] = newV0;
            return (int)(m_States[m_StateIndex] >> 1);
        }
    }
}
