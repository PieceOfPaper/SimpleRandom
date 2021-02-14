
namespace SimpleRandom
{
    /// <summary>
    /// 선형 합동 생성기
    /// </summary>
    public class LCGRandom : Random
    {
        //ref: https://en.wikipedia.org/wiki/Linear_congruential_generator

        protected long m_CurrentValue = 0;
        protected virtual long A => 1664525;
        protected virtual long C => 1013904223;
        public override int RandMax => int.MaxValue;


        public override void Init(int seed)
        {
            m_CurrentValue = seed % RandMax;
        }

        public override int Rand()
        {
            m_CurrentValue = (A * m_CurrentValue + C) % RandMax;
            return (int)m_CurrentValue;
        }
    }
}
