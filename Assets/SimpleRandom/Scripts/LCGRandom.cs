
namespace SimpleRandom
{
    /// <summary>
    /// 선형 합동 생성기
    /// </summary>
    public class LCGRandom : Random32
    {
        //ref: https://ko.wikipedia.org/wiki/%EC%84%A0%ED%98%95_%ED%95%A9%EB%8F%99_%EC%83%9D%EC%84%B1%EA%B8%B0
        //ref: https://en.wikipedia.org/wiki/Linear_congruential_generator


        // 1. C와 M이 서로소여야 한다.
        // 2. A-1이 M의 모든 소인수로 나눠져야 한다.
        // 3.M이 4의 배수일 경우, A-1도 4의 배수여야 한다.
        protected virtual uint A => 1664525;
        protected virtual uint C => 1013904223;
        protected uint M => RAND_MAX;


        protected uint m_Seed = 0;


        public override void Init(uint seed) => m_Seed = seed;
        public override uint GetRand()
        {
            m_Seed = (A * m_Seed + C) % M;
            return m_Seed;
        }
    }
}
