
namespace SimpleRandom
{ 
    public abstract class Random
    {
        public abstract void Init(int seed);
        public abstract void Init(uint seed);
        public abstract void Init(long seed);
        public abstract void Init(ulong seed);


        public abstract float RandRate();
        public abstract double RandRateDouble();


        public virtual int RandRange(int min, int max)
        {
            return min + (int)(RandRateDouble() * (max - min));
        }

        public virtual long RandRange(long min, long max)
        {
            return min + (long)(RandRateDouble() * (max - min));
        }

        public virtual float RandRange(float min, float max)
        {
            return min + RandRate() * (max - min);
        }

        public virtual double RandRange(double min, double max)
        {
            return min + RandRateDouble() * (max - min);
        }
    }

    public abstract class Random32 : Random
    {
        public virtual int RandMax => int.MaxValue;

        float m_RandToRateFloat = 0f;
        protected float RandToRateFloat
        {
            get
            {
                if (m_RandToRateFloat == 0f)
                    m_RandToRateFloat = 1f / RandMax;
                return m_RandToRateFloat;
            }
        }

        double m_RandToRateDouble = 0d;
        protected double RandToRateDouble
        {
            get
            {
                if (m_RandToRateDouble == 0d)
                    m_RandToRateDouble = 1d / RandMax;
                return m_RandToRateDouble;
            }
        }


        //public abstract void Init(int seed);
        public override void Init(uint seed) => Init((int)(seed % int.MaxValue));
        public override void Init(long seed) => Init((int)(seed % int.MaxValue));
        public override void Init(ulong seed) => Init((int)(seed % int.MaxValue));
        public abstract int Rand();



        public override float RandRate()
        {
            return Rand() * RandToRateFloat;
        }

        public override double RandRateDouble()
        {
            return Rand() * RandToRateDouble;
        }
    }

    public abstract class Random64 : Random
    {
        public abstract ulong RandMax { get; }

        float m_RandToRateFloat = 0f;
        protected float RandToRateFloat
        {
            get
            {
                if (m_RandToRateFloat == 0f)
                    m_RandToRateFloat = 1f / RandMax;
                return m_RandToRateFloat;
            }
        }

        double m_RandToRateDouble = 0d;
        protected double RandToRateDouble
        {
            get
            {
                if (m_RandToRateDouble == 0d)
                    m_RandToRateDouble = 1d / RandMax;
                return m_RandToRateDouble;
            }
        }


        //public abstract void Init(ulong seed);
        public override void Init(int seed) => Init((ulong)seed);
        public override void Init(uint seed) => Init((ulong)seed);
        public override void Init(long seed) => Init((ulong)seed);
        public abstract ulong Rand();



        public override float RandRate()
        {
            return Rand() * RandToRateFloat;
        }

        public override double RandRateDouble()
        {
            return Rand() * RandToRateDouble;
        }
    }
}
