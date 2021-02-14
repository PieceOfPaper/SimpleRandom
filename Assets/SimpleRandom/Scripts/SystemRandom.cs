
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

        public override int RandMax => int.MaxValue;

        public override void Init(int seed)
        {
            m_Random = new System.Random((int)seed);
        }

        public override int Rand() => (int)(m_Random.NextDouble() * RandMax);


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
