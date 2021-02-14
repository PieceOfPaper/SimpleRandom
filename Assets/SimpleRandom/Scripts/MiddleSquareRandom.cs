
namespace SimpleRandom
{
    /// <summary>
    /// 중앙 제곱법
    /// </summary>
    public class MiddleSquareRandom : Random
    {
        //ref: https://en.wikipedia.org/wiki/Middle-square_method

        const int UNIT1 = 1000000;
        const int UNIT2 = 100;

        float m_CurrentSeed;

        public override int RandMax => UNIT1 / UNIT2;

        public override void Init(int seed)
        {
            if ((seed * seed) < UNIT2)
            {
                throw new System.Exception($"최소 {(int)System.Math.Sqrt(UNIT2)}정도는 넣어주십쇼.");
            }

            m_CurrentSeed = seed % RandMax;
        }

        public override int Rand()
        {
            float result;

            result = m_CurrentSeed * m_CurrentSeed;
            result %= UNIT1;
            result /= UNIT2;
            m_CurrentSeed = result;

            return (int)result;
        }
    }
}
