﻿
namespace SimpleRandom
{
    /// <summary>
    /// System.Random
    /// </summary>
    public class SystemRandom : Random
    {
        //Donald E. Knuth's subtractive random number generator 쓴다고 함.
        //ref: https://rosettacode.org/wiki/Subtractive_generator

        System.Random m_Random = new System.Random();

        public override int RandMax => int.MaxValue;

        public override void Init(int seed) { m_Random = new System.Random(seed); }
        public override int Rand() => m_Random.Next();
    }
}
