
namespace SimpleRandom
{
    /// <summary>
    /// System.Random
    /// </summary>
    public class SystemRandom : Random32
    {
        //Donald E. Knuth's subtractive random number generator 쓴다고 함.
        //"The Art of Computer Programming, volume 2: Seminumerical Algorithms" 이 책을 참고하라고함.
        //ref: https://rosettacode.org/wiki/Subtractive_generator

        System.Random m_Random = new System.Random();


        public override void Init(uint seed)
        {
            m_Random = new System.Random((int)(seed >> 1));
        }

        public override uint GetRand() => (uint)(m_Random.NextDouble() * RAND_MAX);


        public override float RandRate()
        {
            return (float)m_Random.NextDouble();
        }

        public override double RandRateDouble()
        {
            return m_Random.NextDouble();
        }
    }
}
