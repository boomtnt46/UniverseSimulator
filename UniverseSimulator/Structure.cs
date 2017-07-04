using System;
using System.Collections.Generic;
using System.Linq;
using Dynamitey;
using System.Text;
using System.Threading.Tasks;

namespace UniverseSimulator
{
    partial class Initialization
    {
        public class Parameters
        {
            public Parameters()
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
                    new KeyValuePair<object, double>(bs as Star, blueStarProbability),
                    new KeyValuePair<object, double>(bws as Star, blue_whiteStarProbability),
                    new KeyValuePair<object, double>(ws as Star, whiteStarProbability),
                    new KeyValuePair<object, double>(yws as Star, yellow_whiteStarProbability),
                    new KeyValuePair<object, double>(ys as Star, yellowStarProbability),
                    new KeyValuePair<object, double>(os as Star, orangeStarProbability),
                    new KeyValuePair<object, double>(rs as Star, redStarProbability)
                };
            }
            //Fixed vars here
            public BlueStar bs { get; }
            public BlueWhiteStar bws { get; }
            public WhiteStar ws { get; }
            public YellowWhiteStar yws { get; }
            public YellowStar ys { get; }
            public OrangeStar os { get; }
            public RedStar rs { get; }
            public List<KeyValuePair<object, double>> universeZones { get; private set; }
            public List<KeyValuePair<object, double>> galaxyZones { get; private set; }
            public List<KeyValuePair<object, double>> starTypes { get; private set; }

            //Variables asked to the user start here
            public double universeRadius { get; set; } = 923320060000;
            public long galaxies { get; set; }
            public long stars { get; set; }
            public double blackHoleProbability { get; set; }
            public double blueStarProbability { get; set; }
            public double blue_whiteStarProbability { get; set; }
            public double whiteStarProbability { get; set; }
            public double yellow_whiteStarProbability { get; set; }
            public double yellowStarProbability { get; set; }
            public double orangeStarProbability { get; set; }
            public double redStarProbability { get; set; }
            public double planetProbability { get; set; }
            public double habitablePlanetProbability { get; set; }
            public double lifeProbability { get; set; }
            public double lifeExtinctionProbability { get; set; }
            public double intelligentLifeProbability { get; set; }
            public double intelligentLifeExtinctionProbability { get; set; }
            public double evolutionSpeed { get; set; }
            public double quatumTunnelingConstant { get; set; }
            public double quasarProbability { get; set; }
            //Variables asked to the user end here

            public double[] universeCenterRange { get; set; }
            public double[] universeMediumRange { get; set; }
            public double[] universeOutskirtsRange { get; set; }
            public double[] galaxyCenterRange { get; set; }
            public double[] galaxyMediumRange { get; set; }
            public double[] galaxyOutskirtsRange { get; set; }
        }

        public class Galaxy
        {
            public List<System> systems { get; set; }
        }

        public abstract class Star
        {

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

        public class BlueStar : Star
        {
            public double mass { get; set; }
            public double radius { get; set; }

        }
        public class BlueWhiteStar : Star
        {
            public double mass { get; set; }
            public double radius { get; set; }

        }
        public class WhiteStar : Star
        {
            public double mass { get; set; }
            public double radius { get; set; }

        }
        public class YellowWhiteStar : Star
        {
            public double mass { get; set; }
            public double radius { get; set; }

        }
        public class YellowStar : Star
        {
            public double mass { get; set; }
            public double radius { get; set; }

        }
        public class OrangeStar : Star
        {
            public double mass { get; set; }
            public double radius { get; set; }
        }
        public class RedStar : Star
        {
            public double mass { get; set; }
            public double radius { get; set; }

        }

        public class Planet
        {
            public int moons { get; set; }
            public class Life
            {
                public long lifeDuration { get; set; }
                public LifeStage lifeStage { get; set; }
            }
        }

        public class System
        {
            public Star star;
            public List<KeyValuePair<Planet, double>> planets;
        }

        public class LifeStage
        {
            public LifeStage Savage { get; }
            public LifeStage Civilized { get; }
            public LifeStage Advanced { get; }
            public LifeStage Spacial { get; }
        }

        public class OutOfBoundsException : Exception
        {

        }
    }
}
