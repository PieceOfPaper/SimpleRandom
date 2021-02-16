
namespace SimpleRandom
{
    public class SubtractiveGeneratorRandom : Random32
    {
        //ref: https://rosettacode.org/wiki/Subtractive_generator

        protected uint[] m_State;
        protected uint m_Pos;
        
        public override void Init(uint seed)
        {
            m_State = new uint[55];

            uint[] temp = new uint[55];
            temp[0] = seed;
            temp[1] = 1;
            for(uint i = 2; i < 55; ++i)
                temp[i] = temp[i - 2] - temp[i - 1];
    
            for(uint i = 0; i < 55; ++i)
                m_State[i] = temp[(34 * (i + 1)) % 55];

            m_Pos = 54;
            for(uint i = 55; i < 220; ++i)
                Rand();
        }

        public override uint GetRand()
        {
            var temp = m_State[(m_Pos + 1) % 55] - m_State[(m_Pos + 32) % 55];
            m_Pos = (m_Pos + 1) % 55;
            m_State[m_Pos] = temp;
            return temp;
        }
    }
}
