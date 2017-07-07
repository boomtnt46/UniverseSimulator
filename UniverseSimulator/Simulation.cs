using System;
using System.Collections.Generic;
using System.Linq;
using CharlesDeep;
using System.Text;
using System.Threading.Tasks;

namespace UniverseSimulator
{
    class Simulation
    {
        public Simulation(Map universe, Initialization parameters)
        {
            this.universe = universe;
            this.parameters = parameters;
        }

        private Map universe { get; set; }
        private Initialization parameters { get; set; }

        public void Simulate()
        {

        }


    }

    static class Utils
    {
        public static object GetObjectByProbability(List<KeyValuePair<object, double>> objectsToChoose)
        {
            System.Random rng = new System.Random((int)DateTime.Now.Ticks);
            double rollerino;
            double cumulative = 0;
            for (int z = 0; z < 2; z++)
            {
                rollerino = rng.NextDouble();
                for (int i = 0; i < objectsToChoose.Count; i++)
                {
                    cumulative += objectsToChoose[i].Value;
                    if (rollerino < cumulative)
                    {
                        return objectsToChoose[i].Key;
                    }
                }
            }
            return objectsToChoose[objectsToChoose.Count-1].Key;
        }

        public static class Random
        {
            public static long NextLong(double minValue, double maxValue)
            {
                System.Random r = new System.Random((int)DateTime.Now.Ticks);

                byte[] buf = new byte[8];
                r.NextBytes(buf);
                long longRand = BitConverter.ToInt64(buf, 0);

                return (Math.Abs(longRand % ((long)maxValue - (long) minValue)) + (long) minValue);
            }

            public static double NextDouble(double minValue, double maxValue)
            {
                return new System.Random((int)DateTime.Now.Ticks).NextDouble() * (maxValue - minValue) + minValue;
            }
        }
        
    }
}
