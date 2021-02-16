
namespace SimpleRandom
{
    /// <summary>
    /// 메르센 트위스터
    /// </summary>
    public class MT19937_64Random : Random64
    {
        //ref: https://en.wikipedia.org/wiki/Mersenne_Twister
        //ref: https://evan-moon.github.io/2019/07/14/what-is-random/

        const ulong N = 312;
        const ulong M = 156;
        const ulong F = 6364136223846793005UL;

        const ulong UPPER_MASK = 0xFFFFFFFF80000000UL;
        const ulong LOWER_MASK = 0x7FFFFFFFUL;
        const ulong MATRIX_A = 0xB5026F5AA96619E9UL;
        static readonly ulong[] mag01 = new ulong[] { 0, MATRIX_A };

        ulong[] m_MT = new ulong[N];
        ulong m_Index = 0;


        public override void Init(ulong seed)
        {
            m_MT[0] = seed;
            for (m_Index = 1; m_Index < N; m_Index++)
            {
                m_MT[m_Index] = F * (m_MT[m_Index - 1] ^ (m_MT[m_Index - 1] >> 30)) + m_Index;
                m_MT[m_Index] &= 0xffffffffffffffff;
            }
        }

        public override ulong GetRand()
        {
            uint i;
            ulong x;

            if (m_Index >= N)
            {
                if (m_Index == N + 1)
                    Init(5489UL);

                for (i = 0; i < N - M; i++)
                {
                    x = (m_MT[i] & UPPER_MASK) | (m_MT[i + 1] & LOWER_MASK);
                    m_MT[i] = m_MT[i + M] ^ (x >> 1) ^ mag01[(int)(x & 1UL)];
                }
                for (; i < N - 1; i++)
                {
                    x = (m_MT[i] & UPPER_MASK) | (m_MT[i + 1] & LOWER_MASK);
                    m_MT[i] = m_MT[i + ((int)M - (int)N)] ^ (x >> 1) ^ mag01[(int)(x & 1UL)];
                }
                x = (m_MT[N - 1] & UPPER_MASK) | (m_MT[0] & LOWER_MASK);
                m_MT[N - 1] = m_MT[M - 1] ^ (x >> 1) ^ mag01[(int)(x & 1UL)];

                m_Index = 0;
            }

            x = m_MT[m_Index++];

            x ^= (x >> 29) & 0x5555555555555555UL;
            x ^= (x << 17) & 0x71D67FFFEDA60000UL;
            x ^= (x << 37) & 0xFFF7EEE000000000UL;
            x ^= (x >> 43);

            return x;
        }
    }
}
