
namespace SimpleRandom
{
    /// <summary>
    /// 메르센 트위스터
    /// </summary>
    public class MT19937Random : Random
    {
        //ref: https://en.wikipedia.org/wiki/Mersenne_Twister
        //ref: https://evan-moon.github.io/2019/07/14/what-is-random/

        const uint N = 624;
        const uint M = 397;
        const uint F = 1812433253;

        const uint UPPER_MASK = uint.MaxValue / 2; // 0x80000000
        const uint LOWER_MASK = UPPER_MASK - 1; // 0x7fffffff
        const uint MATRIX_A = 0x9908b0df;
        static readonly uint[] mag01 = new uint[]{ 0, MATRIX_A };

        uint[] m_MT = new uint[N];
        uint m_Index = 0;

        public override int RandMax => int.MaxValue;

        public override void Init(int seed)
        {
            m_MT[0] = (uint)seed;
            for (m_Index = 1; m_Index < N; m_Index++)
            {
                m_MT[m_Index] = F * (m_MT[m_Index - 1] ^ (m_MT[m_Index - 1] >> 30)) + m_Index;
                m_MT[m_Index] &= 0xffffffff;
            }
        }

        public override int Rand()
        {
            uint x = 0;

            if (m_Index >= N)
            {
                if (m_Index == N + 1)
                    Init(5489);

                uint i;
                for (i = 0; i < N - M; ++i)
                {
                    x = (m_MT[i] & UPPER_MASK) | (m_MT[i + 1] & LOWER_MASK);
                    m_MT[i] = m_MT[i + M] ^ (x >> 1) ^ mag01[x & 1];
                }
                for (; i < N - 1; ++i)
                {
                    x = (m_MT[i] & UPPER_MASK) | (m_MT[i + 1] & LOWER_MASK);
                    m_MT[i] = m_MT[i + ((int)M - (int)N)] ^ (x >> 1) ^ mag01[x & 1];
                }
                x = (m_MT[N - 1] & UPPER_MASK) | (m_MT[0] & LOWER_MASK);
                m_MT[N - 1] = m_MT[M - 1] ^ (x >> 1) ^ mag01[x & 1];

                m_Index = 0;
            }

            x = m_MT[m_Index++];

            x ^= (x >> 11);
            x ^= (x << 7) & 0x9d2c5680;
            x ^= (x << 15) & 0xefc60000;
            x ^= (x >> 18);

            int output = (int)(x >> 1);
            if (output < 0) output += int.MaxValue;
            return output;
        }
    }
}
