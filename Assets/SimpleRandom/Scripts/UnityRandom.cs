
namespace SimpleRandom
{
    /// <summary>
    /// 유니티 랜덤
    /// </summary>
    [System.Obsolete("비교 테스트용 코드. 실제로 이걸 쓰지는 마시오.")]
    public class UnityRandom : Random32
    {
        // Marsaglia's Xorshift 128 쓴다고 함.
        //ref: https://en.wikipedia.org/wiki/Xorshift


        public override int RandMax => int.MaxValue;

        public override void Init(int seed)
        {
            UnityEngine.Random.InitState((int)seed);
        }

        public override void Init(uint seed) => Init((int)seed);

        public override int Rand()
        {
            return (int)(UnityEngine.Random.value * RandMax);
        }

        public override float RandRate()
        {
            return UnityEngine.Random.value;
        }

        public override double RandRateDouble()
        {
            return UnityEngine.Random.value;
        }
    }
}
