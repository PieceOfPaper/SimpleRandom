
namespace SimpleRandom
{ 
    public abstract class Random
    {
        public abstract void Init(int seed);
        public abstract void Init(uint seed);
        public abstract void Init(long seed);
        public abstract void Init(ulong seed);

        public abstract void Rand();

        public abstract float RandRate();
        public abstract double RandRateDouble();

        public virtual int RandRange(int min, int max) => min + (int)(RandRateDouble() * (max - min));
        public virtual long RandRange(long min, long max) => min + (long)(RandRateDouble() * (max - min));
        public virtual float RandRange(float min, float max) => min + RandRate() * (max - min);
        public virtual double RandRange(double min, double max) => min + RandRateDouble() * (max - min);
    }

    public abstract class Random32 : Random
    {
        protected const uint RAND_MAX = uint.MaxValue;
        protected const float RAND_TO_RATE_FLOAT = 1f / ((int)(RAND_MAX >> 1));
        protected const double RAND_TO_RATE_DOUBLE = 1d / ((int)(RAND_MAX >> 1));


        //public abstract void Init(uint seed);
        public override void Init(int seed) => Init((uint)seed);
        public override void Init(long seed) => Init((uint)(seed % uint.MaxValue));
        public override void Init(ulong seed) => Init((uint)(seed % uint.MaxValue));

        public override void Rand() => GetRand();
        public abstract uint GetRand();

        public override float RandRate() => (int)(GetRand() >> 1) * RAND_TO_RATE_FLOAT;
        public override double RandRateDouble() => (int)(GetRand() >> 1) * RAND_TO_RATE_DOUBLE;
    }

    public abstract class Random64 : Random
    {
        protected const ulong RAND_MAX = ulong.MaxValue;
        protected const float RAND_TO_RATE_FLOAT = 1f / ((long)(RAND_MAX >> 1));
        protected const double RAND_TO_RATE_DOUBLE = 1d / ((long)(RAND_MAX >> 1));


        //public abstract void Init(ulong seed);
        public override void Init(int seed) => Init((ulong)seed);
        public override void Init(uint seed) => Init((ulong)seed);
        public override void Init(long seed) => Init((ulong)seed);

        public override void Rand() => GetRand();
        public abstract ulong GetRand();

        public override float RandRate() => (long)(GetRand() >> 1) * RAND_TO_RATE_FLOAT;
        public override double RandRateDouble() => (long)(GetRand() >> 1) * RAND_TO_RATE_DOUBLE;
    }
}
