using System;
using System.Collections.Generic;
using System.Linq;
using CharlesDeep;
using System.Text;
using System.Threading.Tasks;
using static UniverseSimulator.Initialization;

namespace UniverseSimulator
{
    class Simulation
    {
        public Simulation(Map universe, Parameters parameters)
        {
            this.universe = universe;
            this.parameters = parameters;
        }

        private Map universe { get; set; }
        private Parameters parameters { get; set; }

        public void Simulate()
        {
            long year = 0;
            bool paused = false;
            while (!paused)
            {
                Console.Clear();
                Console.Write("Year {0}", year);
                foreach (KeyValuePair<object, Position> galaxyAndPosition in universe.GetObjectList())
                {
                    
                    Galaxy galaxy = galaxyAndPosition.Key as Galaxy;
                    foreach (Initialization.System system in galaxy.systems)
                    {
                        var star = TypeOfStar(system.star);
                        if (star.lifeTime > star.maxLifeTime)
                        {
                            //Destroy system as we're not adding it to the updated list
                            continue;
                        }
                        
                        foreach (KeyValuePair<Planet, Position> planetAndPosition in system.planets)
                        {
                            if (planetAndPosition.Key.life.lifeStage == new LifeStage().None)
                            {
                                if (RNG.rng.NextDouble() <= parameters.lifeProbability)
                                {
                                    planetAndPosition.Key.life.lifeStage = new LifeStage().Miscroscopic;
                                }
                            }
                            else
                            {
                                if (RNG.rng.NextDouble() <= parameters.lifeExtinctionProbability)
                                {
                                    planetAndPosition.Key.life.lifeStage = new LifeStage().None;
                                    planetAndPosition.Key.life.lifeDuration = 0.0;
                                    Console.WriteLine("A lifeform just went extint");
                                }
                                else
                                {
                                    if (planetAndPosition.Key.life.lifeStage == new LifeStage().Miscroscopic && planetAndPosition.Key.life.lifeDuration > 1100000000)
                                    {
                                        planetAndPosition.Key.life.lifeStage = new LifeStage().Savage;
                                        Console.WriteLine("A lifeform just advanced into the primal era");
                                    }
                                }
                            }
                        }
                    }
                }
                year += 1000000;
            }
        }


        public dynamic TypeOfStar(Star star)
        {

            if (star is BlueStar)
            {
                return star as BlueStar;
            }
            else if (star is BlueWhiteStar)
            {
                return star as BlueWhiteStar;

            }
            else if (star is WhiteStar)
            {
                return star as WhiteStar;

            }
            else if (star is YellowWhiteStar)
            {
                return star as YellowWhiteStar;

            }
            else if (star is YellowStar)
            {
                return star as YellowStar;

            }
            else if (star is OrangeStar)
            {
                return star as OrangeStar;

            }
            else 
            {
                return star as RedStar;

            }
        }

    }

    
}
