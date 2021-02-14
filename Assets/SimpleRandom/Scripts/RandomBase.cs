
namespace SimpleRandom
{ 
    public abstract class Random
    {
        public abstract int RandMax { get; }

        public abstract void Init(int seed);
        public abstract int Rand();



        public virtual int RandRange(int min, int max)
        {
            return min + (int)((Rand() / (float)RandMax) * (max - min));
        }

        public virtual float RandRange(float min, float max)
        {
            return min + (Rand() / (float)RandMax) * (max - min);
        }
    }
}
