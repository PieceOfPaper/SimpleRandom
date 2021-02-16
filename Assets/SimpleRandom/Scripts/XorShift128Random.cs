
namespace SimpleRandom
{
    public class XorShift128Random : Random32
    {
        //ref: https://en.wikipedia.org/wiki/Xorshift

        uint[] m_Seeds = new uint[4];

        public override void Init(uint seed)
        {
            for (uint i = 0; i < m_Seeds.Length; i++)
                m_Seeds[i] = seed + i;
        }

        public override uint GetRand()
        {
            uint t = m_Seeds[3];

            uint s = m_Seeds[0];
            m_Seeds[3] = m_Seeds[2];
            m_Seeds[2] = m_Seeds[1];
            m_Seeds[1] = s;

            t ^= t << 11;
            t ^= t >> 8;
            m_Seeds[0] = t ^ s ^ (s >> 19);
            return m_Seeds[0];
        }
    }
}
