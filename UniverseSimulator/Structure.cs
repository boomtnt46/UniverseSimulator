using System;
using System.Collections.Generic;
using System.Linq;
using Dynamitey;
using System.Text;
using System.Threading.Tasks;

namespace UniverseSimulator
{
    partial class Configuration
    {
        public class Settings
        {
            public double universeLength { get; set; } = 923320060000;
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
        }

        class Galaxy
        {
            public long stars { get; set; }
            public int blackHoles { get; set; }
            public class Stars
            {
                public long blue { get; set; }
                public long blue_white { get; set; }
                public long white { get; set; }
                public long yellow_white { get; set; }
                public long yellow { get; set; }
                public long orange { get; set; }
                public long red { get; set; }
            }
            public class System
            {
                public int starMass { get; set; }
                public int planets { get; set; }
                public class Planet
                {
                    public int moons { get; set; }
                    public class Life
                    {
                        public int lifeDuration { get; set; }
                        public LifeStage lifeStage { get; set; }
                    }
                }
            }
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


        /// <summary>
        /// Sets a variable
        /// </summary>
        /// <param name="type">The type of variable</param>
        /// <param name="variable">The variable to set</param>
        /// <param name="name">The readable name of the variable</param>
        /// <param name="minValue">The minimun allowed value of the variable</param>
        
    }
}
