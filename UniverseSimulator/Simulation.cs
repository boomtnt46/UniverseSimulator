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
        public Simulation(Map universe, Initialization.Parameters parameters)
        {
            this.universe = universe;
            this.parameters = parameters;
        }

        private Map universe { get; set; }
        private Initialization.Parameters parameters { get; set; }

        public void Simulate()
        {
            foreach (KeyValuePair<object, Position> galaxyAndPosition in universe.GetObjectList())
            {
                Galaxy galaxy = galaxyAndPosition.Key as Galaxy;
                foreach (Initialization.System system in galaxy.systems)
                {
                    var star = TypeOfStar(system.star);
                    
                }
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
