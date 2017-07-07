using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CharlesDeep;
using System.Threading.Tasks;
using Dynamitey;
using System.Threading;

namespace UniverseSimulator
{
    partial class Initialization
    {
        //limiting vars
        internal static double maxStarProbability = 100.0;
        internal static Parameters parameters;

        static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                LoadConfig();
            }
            else
            {
                parameters = new Parameters();
                SetConfig();
            }
            Simulate();
        }

        private static void Simulate()
        {
            Map universe = new Map(parameters.universeRadius, parameters.universeRadius);
            universe.ModifyBounds(parameters.universeRadius, parameters.universeRadius);
            //Generate galaxies
            GenerateGalaxies(ref universe);

        }

        private static void GenerateGalaxies(ref Map universe)
        {
            parameters.InitParameters();
            Console.WriteLine("Generating galaxies...");
            for (int x = 0; x < parameters.galaxies; x++)
            {
                double[] selectedZone = Utils.GetObjectByProbability(parameters.universeZones) as double[];
                double xPosition = Utils.Random.NextLong(selectedZone[0], selectedZone[1]);
                Thread.Sleep(new TimeSpan(1000));
                double yPosition = Utils.Random.NextLong(selectedZone[0], selectedZone[1]);

                Galaxy galaxy = new Galaxy();
                galaxy.systems = new List<System>();

                galaxy.galaxyMap = new Map(parameters.galaxyOutskirtsRange[1]+100000, parameters.galaxyOutskirtsRange[1] + 100000);


                long starsToGenerate = Utils.Random.NextLong(parameters.stars, parameters.stars + 1000000);
                Console.WriteLine();
                for (long i = 0; i<starsToGenerate; i++)
                {
                    double progress = (i * 100) / starsToGenerate;
                    Console.CursorLeft = 0;
                    Console.Write(progress.ToString() + "%");

                    object s = Utils.GetObjectByProbability(parameters.starTypes);
                    
                    Star star;
                    if (s is BlueStar)
                    {
                        star = new BlueStar()
                        {
                            mass = Utils.Random.NextDouble(23, 120),
                            radius = Utils.Random.NextDouble(8.5, 15)
                        };
                        

                    }
                    else if (s is BlueWhiteStar)
                    {
                        star = new BlueWhiteStar()
                        {
                            mass = Utils.Random.NextDouble(3.8, 17),
                            radius = Utils.Random.NextDouble(3, 7.4)
                        };
                    }
                    else if (s is WhiteStar)
                    {
                        star = new WhiteStar()
                        {
                            mass = Utils.Random.NextDouble(2, 2.9),
                            radius = Utils.Random.NextDouble(1.7, 2.4)
                        };
                    }
                    else if (s is YellowWhiteStar)
                    {
                        star = new YellowWhiteStar()
                        {
                            mass = Utils.Random.NextDouble(1.3, 1.6),
                            radius = Utils.Random.NextDouble(1.5, 1.5)
                        };
                    }
                    else if (s is YellowStar)
                    {
                        star = new YellowStar()
                        {
                            mass = Utils.Random.NextDouble(0.92, 1.05),
                            radius = Utils.Random.NextDouble(0.92, 1.1)
                        };
                    }
                    else if (s is OrangeStar)
                    {
                        star = new OrangeStar()
                        {
                            mass = Utils.Random.NextDouble(0.67, 0.79),
                            radius = Utils.Random.NextDouble(0.72, 0.85)
                        };
                    }
                    else
                    {
                        star = new RedStar()
                        {
                            mass = Utils.Random.NextDouble(0.06, 0.51),
                            radius = Utils.Random.NextDouble(0.15, 0.6)
                        };
                    }

                    //Create the star System object and set the star and the map
                    System system = new System();
                    system.star = star;
                    system.systemMap = new Map(150, 150);

                    //Create the planets
                    int maxPlanets = 9; //maybe make this variable open to changes by the user
                    int numberOfPlanets = new Random().Next(maxPlanets);
                    system.planets = new List<KeyValuePair<Planet, double>>();
                    for (int p = 0; p < numberOfPlanets; p++)
                    {
                        Planet planet = new Planet();
                        planet.planetarySystemMap = new Map(0.01, 0.01);

                        double XplanetLocation;
                        double YplanetLocation;
                        if (new Random().NextDouble() >= 0.5)
                        {
                            planet.typeOfPlanet = new PlanetType().Gaseous;
                            planet.mass = Utils.Random.NextDouble(14.6, 4152.7);
                            XplanetLocation = Utils.Random.NextDouble(3, 100);
                            YplanetLocation = Utils.Random.NextDouble(3, 100);
                        }
                        else
                        {
                            planet.typeOfPlanet = new PlanetType().Rocky;
                            planet.mass = Utils.Random.NextDouble(0.06, 8.5);
                            XplanetLocation = Utils.Random.NextDouble(0.35, 2.5);
                            YplanetLocation = Utils.Random.NextDouble(0.35, 2.5);
                        }
                        planet.moons = new List<KeyValuePair<Moon, double>>();
                        planet.moons.Capacity = new Random().Next(0, 70);
                        for (int m = 0; m < planet.moons.Capacity; m++)
                        {
                            double XmoonLocation = Utils.Random.NextDouble(0.001, 0.004);
                            double YmoonLocation = Utils.Random.NextDouble(0.001, 0.004);
                            Moon moon = new Moon();
                            moon.mass = Utils.Random.NextDouble(0.000001, 0.00001);
                            planet.moons.Add(new KeyValuePair<Moon, double>(moon, XmoonLocation));
                        }
                        planet.life = new Life();
                        planet.life.lifeStage = new LifeStage().None;

                        system.planets.Add(new KeyValuePair<Planet, double>(planet, XplanetLocation));
                    }
                    galaxy.systems.Add(system);

                }
                Thread.Sleep(new TimeSpan(1));
            }
        }

        

        private void Log(string st) { Console.WriteLine(st); }

        private static void SetConfig()
        {
            //Explanation
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--Instructions for the config--");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write("'double'");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(" means that the value you enter can be decimal (using the ',' symbol)");
            Console.BackgroundColor = ConsoleColor.Blue;
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
            Console.Write("'long'");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(" means that the value you enter can only be an integrer (no decimals allowed)");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
            Console.WriteLine("Percentages MUST be entered following this example: 65% would be typed '0,65' ");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
            Console.WriteLine("You must not to enter the % symbol");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
            Console.WriteLine("Leave it empty to use the default value");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
            Console.WriteLine();

            //Set the values for each probability
            SetVarCustom("double", "universeRadius", "Enter the universe radius (positive double, in astronomical units)", "universe length", 1000000, double.MaxValue);
            parameters.universeCenterRange[0] = 1000000;
            parameters.universeCenterRange[1] = (parameters.universeRadius / 3) - 1;
            parameters.universeMediumRange[0] = parameters.universeRadius / 3;
            parameters.universeMediumRange[1] = (parameters.universeRadius / 1.45) - 1;
            parameters.universeOutskirtsRange[0] = parameters.universeRadius / 1.45;
            parameters.universeOutskirtsRange[1] = parameters.universeRadius;

            SetVarCustom("long", "galaxies", "Enter the number of galaxies (low values are recommended for perfomance) (positive long)", "number of galaxies", 0.9, 1000000000000);
            SetVarCustom("long", "stars", "Enter the average number of stars in each galaxy (lower values use less cpu) (positive long)", "average number of stars in each galaxy", 1000, 1000000000000000);
            SetProbabilityVar("double", "blackHoleProbability", "black holes", 0, 100);
            //Show the warning
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Attention: the maximun cumulative probability of all stars is 100%");
            Console.ForegroundColor = ConsoleColor.White;
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
            //End warning block
            SetProbabilityVar("double", "blueStarProbability", "blue stars", 0, maxStarProbability);
            SetProbabilityVar("double", "blue_whiteStarProbability", "blue-white stars", 0, maxStarProbability);
            SetProbabilityVar("double", "whiteStarProbability", "white stars", 0, maxStarProbability);
            SetProbabilityVar("double", "yellow_whiteStarProbability", "yellow-white stars", 0, maxStarProbability);
            SetProbabilityVar("double", "yellowStarProbability", "yellow stars", 0, maxStarProbability);
            SetProbabilityVar("double", "orangeStarProbability", "orange stars", 0, maxStarProbability);
            SetProbabilityVar("double", "redStarProbability", "red stars", 0, maxStarProbability);
            //Show the warning
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Star block finished!");
            Console.ForegroundColor = ConsoleColor.White;
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
            //End warning block
            SetProbabilityVar("double", "quasarProbability", "quasars", 0, 100);
            SetProbabilityVar("double", "planetProbability", "planets", 0, 100);
            SetProbabilityVar("double", "habitablePlanetProbability", "habitable planets", 0, 100);
            SetProbabilityVar("double", "lifeProbability", "life", 0, 100);
            SetProbabilityVar("double", "lifeExtinctionProbability", "life extinction", 0, 100);
            SetProbabilityVar("double", "intelligentLifeProbability", "intelligent life", 0, 100);
            SetProbabilityVar("double", "intelligentLifeExtinctionProbability", "intelligent life extinction", 0, 100);
            SetVarCustom("double", "evolutionSpeed", "Enter the evolution speed (positive double)", "evolution speed", 0, 10000);
            //SetCustomVar("double", "quatumTunnelingConstant", "Enter the quatum tunneling constant (positive double)", double.MinValue, 1);
            //Still researching this variable, might be removed if it is excessively tricky to implement

            

            Console.ReadKey();
            Console.Clear();
            
        }

        private static void LoadConfig()
        {
            
        }
        /// <summary>
        /// Sets a variable
        /// </summary>
        /// <param name="type">The type of variable</param>
        /// <param name="variable">The variable to set</param>
        /// <param name="variableName">The readable name of the variable</param>
        /// <param name="minValue">The minimun allowed value of the variable</param>
        /// <param name="maxValue">The maximun allowed value of the variable</param>
        private static void SetProbabilityVar(string type, string variable, string variableName, double minValue, double maxValue)
        {
            bool set = false;
            while (!set)
            {
                try
                {
                    Console.Write("Enter the probability of {0} (positive {1}%): ", variableName, type);
                    string textValue = Console.ReadLine();
                    if (textValue == String.Empty)
                    {
                        return;
                    }
                    if (type == "long")
                    {
                        long value = long.Parse(textValue);
                        if (value > minValue && value < maxValue)
                        {
                            Dynamic.InvokeSet(parameters, variable, value);
                            set = true;
                        }
                        else throw new OutOfBoundsException();
                    }
                    else
                    {
                        double value = double.Parse(textValue);
                        if (value > minValue && value < maxValue)
                        {
                            if (variableName.Contains("stars"))
                            {
                                if (maxStarProbability > 0 && maxStarProbability - value >= 0)
                                {
                                    maxStarProbability -= value;
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("Avaiable star probability left: " + maxStarProbability);
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                else throw new OutOfBoundsException();
                            }
                            Dynamic.InvokeSet(parameters, variable, value / 100);
                            set = true;
                        }
                        else throw new OutOfBoundsException();
                    }
                    Console.WriteLine("{0}: {1}%", variableName, Dynamic.InvokeGet(parameters, variable)*100);

                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Only positive {0} values are allowed", type);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        private static void SetVarCustom(string type, string variable, string String, string variableName, double minValue, double maxValue)
        {
            bool set = false;
            while (!set)
            {
                try
                {
                    Console.Write("{0} :", String);
                    string textValue = Console.ReadLine();
                    if (textValue == String.Empty)
                    {
                        return;
                    }
                    if (type == "long")
                    {
                        long value = long.Parse(textValue);
                        if (value > minValue && value < maxValue)
                        {
                            Dynamic.InvokeSet(parameters, variable, value);
                            set = true;
                        }
                        else throw new OutOfBoundsException();
                    }
                    else
                    {
                        double value = double.Parse(textValue);
                        if (value > minValue && value < maxValue)
                        {
                            Dynamic.InvokeSet(parameters, variable, value);
                            set = true;
                        }
                        else throw new OutOfBoundsException();
                    }
                    Console.WriteLine("{0}: {1}", variableName, Dynamic.InvokeGet(parameters, variable));

                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Only positive {0} values are allowed", type);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}
