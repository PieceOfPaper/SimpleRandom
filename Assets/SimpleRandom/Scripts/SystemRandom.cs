
namespace SimpleRandom
{
    /// <summary>
    /// System.Random
    /// </summary>
    public class SystemRandom : Random
    {
        System.Random m_Random = new System.Random();

        public override int RandMax => int.MaxValue;

        public override void Init(int seed) { m_Random = new System.Random(seed); }
        public override int Rand() => m_Random.Next();
    }
}
