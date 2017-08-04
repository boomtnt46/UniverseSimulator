using System;
using System.Collections.Generic;
using System.Linq;
using Dynamitey;
using System.Text;
using System.Threading.Tasks;
using CharlesDeep;
using System.Threading;

namespace UniverseSimulator
{
    partial class Initialization
    {

        public static class RNG
        {
            public static Random rng { get; } = new Random();
        }
        public class Parameters
        {

            public void InitParameters()
            {
                universeZones = new List<KeyValuePair<object, double>>
                {
                    new KeyValuePair<object, double>(universeCenterRange, 0.40),
                    new KeyValuePair<object, double>(universeMediumRange, 0.30),
                    new KeyValuePair<object, double>(universeOutskirtsRange, 0.30)
                };
                galaxyZones = new List<KeyValuePair<object, double>>
                {
                    new KeyValuePair<object, double>(galaxyCenterRange, 0.45),
                    new KeyValuePair<object, double>(galaxyCenterRange, 0.35),
                    new KeyValuePair<object, double>(galaxyCenterRange, 0.20)
                };

                starTypes = new List<KeyValuePair<object, double>>
                {
                    new KeyValuePair<object, double>(bs, blueStarProbability),
                    new KeyValuePair<object, double>(bws, blue_whiteStarProbability),
                    new KeyValuePair<object, double>(ws, whiteStarProbability),
                    new KeyValuePair<object, double>(yws, yellow_whiteStarProbability),
                    new KeyValuePair<object, double>(ys, yellowStarProbability),
                    new KeyValuePair<object, double>(os, orangeStarProbability),
                    new KeyValuePair<object, double>(rs, redStarProbability)
                };

                moonQuantity = new List<KeyValuePair<int, double>>
                {
                    new KeyValuePair<int, double>(0, 65),
                    new KeyValuePair<int, double>(1, 20),
                    new KeyValuePair<int, double>(2, 5),
                    new KeyValuePair<int, double>(3, 5.7),
                    new KeyValuePair<int, double>(5, 4.2),
                    new KeyValuePair<int, double>(12, 0.1)
                };
            }
            //Fixed vars here
            public BlueStar bs { get; } = new BlueStar();
            public BlueWhiteStar bws { get; } = new BlueWhiteStar();
            public WhiteStar ws { get; } = new WhiteStar();
            public YellowWhiteStar yws { get; } = new YellowWhiteStar();
            public YellowStar ys { get; } = new YellowStar();
            public OrangeStar os { get; } = new OrangeStar();
            public RedStar rs { get; } = new RedStar();
            public List<KeyValuePair<object, double>> universeZones { get; private set; }
            public List<KeyValuePair<object, double>> galaxyZones { get; private set; }
            public List<KeyValuePair<object, double>> starTypes { get; private set; }
            public List<KeyValuePair<int, double>> moonQuantity { get; private set; }

            //Variables asked to the user start here
            public double universeRadius { get; set; } = 923320060000;
            public long galaxies { get; set; } = 1;
            public long stars { get; set; } = 100000; //This is TEMPORARY!! The before default number was 100000 (too low for a galaxy but it is worth for limiting computaion time)
            public double blackHoleProbability { get; set; } = 0.0001;
            public double blueStarProbability { get; set; } = 0.0000001;
            public double blue_whiteStarProbability { get; set; } = 0.001;
            public double whiteStarProbability { get; set; } = 0.007;
            public double yellow_whiteStarProbability { get; set; } = 0.02;
            public double yellowStarProbability { get; set; } = 0.035;
            public double orangeStarProbability { get; set; } = 0.08;
            public double redStarProbability { get; set; } = 0.8;
            public double planetProbability { get; set; } = 0.6;
            public double habitablePlanetProbability { get; set; } = 0.02;
            public double lifeProbability { get; set; } = 0.000001;
            public double lifeExtinctionProbability { get; set; } = 0.5;
            public double intelligentLifeProbability { get; set; } = 0.001;
            public double intelligentLifeExtinctionProbability { get; set; } = 0.3;
            public double evolutionSpeed { get; set; } = 1;
            public double quatumTunnelingConstant { get; set; } = 5E-39;
            public double quasarProbability { get; set; } = 0.04;
            //Variables asked to the user end here

            public double[] universeCenterRange { get; set; } = new double[2];
            public double[] universeMediumRange { get; set; } = new double[2];
            public double[] universeOutskirtsRange { get; set; } = new double[2];
            public double[] galaxyCenterRange { get; set; } = new double[2];
            public double[] galaxyMediumRange { get; set; } = new double[2];
            public double[] galaxyOutskirtsRange { get; set; } = new double[2];
        }

        public class Galaxy
        {
            public List<System> systems { get; set; }
            public Map galaxyMap { get; set; }
            public double[] position { get; set; }
        }

        public abstract class Star
        {
            
        }

        public class Moon
        {
            public double mass { get; set; }
        }

        public class BlackHole : Star
        {
            double mass { get; set; }
        }

        public class Life
        {
            public double lifeDuration { get; set; }
            public LifeStage lifeStage { get; set; }
        }
    
        //Times is in millions of years (My)
        //Distances in Astronomical Units (UA)
        //Masses in Solar Masses
        public class BlueStar : Star
        {
            public const double minimunHabitableZone = 890;
            public const double maxLifeTime = 3;
            public double lifeTime { get; set; } = 0;
            public double mass { get; set; }
            public double radius { get; set; }
        }
        public class BlueWhiteStar : Star
        {
            public const double habitableZone = 35;
            public const double maxLifeTime = 50;
            public double lifeTime { get; set; } = 0;
            public double mass { get; set; }
            public double radius { get; set; }

        }
        public class WhiteStar : Star
        {
            public const double habitableZone = 6;
            public const double maxLifeTime = 700;
            public double lifeTime { get; set; } = 0;
            public double mass { get; set; }
            public double radius { get; set; }
        }
        public class YellowWhiteStar : Star
        {
            public const double habitableZone = 2.15;
            public const double maxLifeTime = 2500;
            public double lifeTime { get; set; } = 0;
            public double mass { get; set; }
            public double radius { get; set; }

        }
        public class YellowStar : Star
        {
            public const double habitableZone = 1;
            public const double maxLifeTime = 10000;
            public double lifeTime { get; set; } = 0;
            public double mass { get; set; }
            public double radius { get; set; }

        }
        public class OrangeStar : Star
        {
            public const double habitableZone = 0.52;
            public const double maxLifeTime = 33500;
            public double lifeTime { get; set; } = 0;
            public double mass { get; set; }
            public double radius { get; set; }
        }
        public class RedStar : Star
        {
            public const double habitableZone = 0.1;
            public const double maxLifeTime = 300000;
            public double lifeTime { get; set; } = 0;
            public double mass { get; set; }
            public double radius { get; set; }
        }

        public class Planet
        {
            public Map planetarySystemMap { get; set; }
            public PlanetType typeOfPlanet { get; set; }
            public List<KeyValuePair<Moon, double>> moons { get; set; }
            public double mass { get; set; }
            public Life life { get; set; }
        }

        public class System
        {
            public Map systemMap { get; set; }
            public Star star { get; set; }
            public List<KeyValuePair<Planet, Position>> planets { get; set; }
        }

        public class PlanetType
        {
            public PlanetType Rocky { get; }
            public PlanetType Gaseous { get; }
        }

        public class LifeStage
        {
            public LifeStage None { get; }
            public LifeStage Miscroscopic { get; }
            public LifeStage Savage { get; }
            public LifeStage Civilized { get; }
            public LifeStage Advanced { get; }
            public LifeStage Spacial { get; }
        }

        public class OutOfBoundsException : Exception
        {

        }
    }
    static class Utils
    {

        public static object GetObjectByProbability(List<KeyValuePair<object, double>> objectsToChoose)
        {
            double rollerino;
            double cumulative = 0;
            for (int z = 0; z < 2; z++)
            {
                rollerino = Initialization.RNG.rng.NextDouble();
                for (int i = 0; i < objectsToChoose.Count; i++)
                {
                    cumulative += objectsToChoose[i].Value;
                    if (rollerino < cumulative)
                    {
                        return objectsToChoose[i].Key;
                    }
                }
            }
            return objectsToChoose[objectsToChoose.Count - 1].Key;
        }

        public static class Random
        {
            public static long NextLong(double minValue, double maxValue)
            {
                byte[] buf = new byte[8];
                Initialization.RNG.rng.NextBytes(buf);
                long longRand = BitConverter.ToInt64(buf, 0);

                return (Math.Abs(longRand % ((long)maxValue - (long)minValue)) + (long)minValue);
            }

            public static double NextDouble(double minValue, double maxValue)
            {
                return Initialization.RNG.rng.NextDouble() * (maxValue - minValue) + minValue;
            }
        }

    }
}

