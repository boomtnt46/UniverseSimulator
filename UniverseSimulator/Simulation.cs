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
        public static object GetObjectByProbability(List<KeyValuePair<object, double>> list)
        {
            System.Random rng = new System.Random();
            double rollerino = rng.NextDouble();
            double cumulative = 0;

            for (int i = 0; i < list.Count; i++)
            {
                cumulative += list[i].Value;
                if (rollerino < cumulative)
                {
                    return list[i].Key;
                }
            }
            return true;
        }

        public static class Random
        {
            public static long NextLong(double minValue, double maxValue)
            {
                double doubleLowerLimit = minValue;
                double doubleUpperLimit = maxValue;

                while (doubleLowerLimit > 1)
                {
                    doubleLowerLimit = doubleLowerLimit / 10;
                }
                int divisionsNum = 0;
                while (doubleUpperLimit >= 1)
                {
                    doubleUpperLimit = doubleUpperLimit / 10;
                    divisionsNum++;
                }

                long number = 0;
                System.Random r = new System.Random();
                bool done = false;
                while (!done)
                {
                    double value = r.NextDouble();
                    if (value < doubleLowerLimit && value > doubleUpperLimit)
                    {
                        number = (long)(value * Math.Pow(10, divisionsNum));
                        done = true;
                    }

                }

                return number;
            }
        }
    }
}
