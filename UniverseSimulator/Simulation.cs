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
        public Simulation(Map universe, Configuration parameters)
        {
            this.universe = universe;
            this.parameters = parameters;
        }

        private Map universe { get; set; }
        private Configuration parameters { get; set; }

        public void Simulate()
        {

        }
    }
}
