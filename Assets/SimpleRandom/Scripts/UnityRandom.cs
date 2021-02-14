
namespace SimpleRandom
{
    /// <summary>
    /// 유니티 랜덤
    /// </summary>
    [System.Obsolete("테스트용 코드")]
    public class UnityRandom : Random
    {
        public override int RandMax => int.MaxValue;

        public override void Init(int seed)
        {
            UnityEngine.Random.InitState(seed);
        }

        public override int Rand()
        {
            return (int)(UnityEngine.Random.value * RandMax);
        }
    }
}
