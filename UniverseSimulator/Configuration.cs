using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CharlesDeep;
using System.Threading.Tasks;
using Dynamitey;

namespace UniverseSimulator
{
    partial class Configuration
    {
        //limiting vars
        internal static double maxStarProbability = 100;
        internal static Settings config = new Settings();

        static void Main(string[] args)
        {
            if (args.Length != 0)
                LoadConfig();
            else
                SetConfig();

            Simulate();
        }

        private static void Simulate()
        {
            Map universe = new Map(config.universeLength, 923320060000);

            //Generate galaxies
            GenerateGalaxies(ref universe);

        }

        private static void GenerateGalaxies(ref Map universe)
        {
            Random rng = new Random();
            for (int x = 0; x < config.galaxies; x++)
            {
                //double xPosition = MathNet.Numerics.Random.RandomExtensions.
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
            Console.WriteLine();

            //Set the values for each probability
            SetVarCustom("double", "universeLength", "Enter the universe radius (positive double, in astronomical units)", "universe length", 1000000, double.MaxValue);
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
            SetProbabilityVar("double", "panetProbability", "planets", 0, 100);
            SetProbabilityVar("double", "habitablePlanetProbability", "habitable planets", 0, 100);
            SetProbabilityVar("double", "lifeProbability", "life", 0, 100);
            SetProbabilityVar("double", "lifeExtinctionProbability", "life extinction", 0, 100);
            SetProbabilityVar("double", "intelligentLifeProbability", "intelligent life", 0, 100);
            SetProbabilityVar("double", "intelligentLifeExtinctionProbability", "intelligent life extinction", 0, 100);
            SetVarCustom("double", "evolutionSpeed", "Enter the evolution speed (positive double)", "evolution speed", 0.000000000000001, 10000);
            //SetCustomVar("double", "quatumTunnelingConstant", "Enter the quatum tunneling constant (positive double)", double.MinValue, 1);
            //Still researching this variable, might be removed if it is excessively tricky to implement

            

            Console.ReadKey();
            
        }

        private static void LoadConfig()
        {
            
        }

        private static void SetProbabilityVar(string type, string variable, string variableName, double minValue, double maxValue)
        {
            bool set = false;
            while (!set)
            {
                try
                {
                    Console.Write("Enter the probability of {0} (positive {1}%): ", variableName, type);
                    string textValue = Console.ReadLine();
                    if (type == "long")
                    {
                        long value = long.Parse(textValue);
                        if (value > minValue && value < maxValue)
                        {
                            Dynamic.InvokeSet(config, variable, value);
                            set = true;
                        }
                        else throw new OutOfBoundsException();
                    }
                    else
                    {
                        double value = double.Parse(textValue);
                        if (value > minValue || value < maxValue)
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
                            Dynamic.InvokeSet(config, variable, value / 100);
                            set = true;
                        }
                        else throw new OutOfBoundsException();
                    }
                    Console.WriteLine("{0}: {1}%", variableName, Dynamic.InvokeGet(config, variable));

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
                    if (type == "long")
                    {
                        long value = long.Parse(textValue);
                        if (value > minValue && value < maxValue)
                        {
                            Dynamic.InvokeSet(config, variable, value);
                            set = true;
                        }
                        else throw new OutOfBoundsException();
                    }
                    else
                    {
                        double value = double.Parse(textValue);
                        if (value > minValue && value < maxValue)
                        {
                            Dynamic.InvokeSet(config, variable, value);
                            set = true;
                        }
                        else throw new OutOfBoundsException();
                    }
                    Console.WriteLine("{0}: {1}", variableName, Dynamic.InvokeGet(config, variable));

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
