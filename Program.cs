using System;
using System.Collections.Generic;

namespace TSP
{
    class Program
    {
        private static readonly int Trials = 100;

        // Several of my classes need a random number generator, it makes sense to instantiate one here that they all can use.
        private static System.Random Rand = new System.Random();

        public static int RandomInt(int lower, int upper)
        {
            return Rand.Next(lower, upper);
        }

        public static T RandomElement<T>(IList<T> list)
        {
            return list[RandomInt(0, list.Count)];
        }

        // Run an algorithm a specified number of times, returning the shortest route length found and the average.
        public static double[] RunTrials(Algorithm toRun)
        {
            double shortest = double.PositiveInfinity;
            double total = 0.0;

            for(int i = 0; i < Trials; i++)
            {
                toRun.Reset();
                Route result = toRun.Run();
                
                if(result.Count != City.Count)
                {
                    throw new BadRouteException(result.Count, toRun);
                }

                shortest = result.Length < shortest ? result.Length : shortest;
                total += result.Length;
            }

            return new double[] {shortest, total / (double) Trials};
        }

        private static Algorithm[] ChooseAlgorithms(String choice)
        {
            if(choice == null)
            {
                return new Algorithm []
                {
                    new Random(),
                    new Greedy(),
                    new MST(),
                    new Insert()
                };
            }
            else if(choice == "random")
            {
                return new Algorithm [] { new Random() };
            }
            else if(choice == "greedy")
            {
                return new Algorithm [] { new Greedy() };
            }
            else if(choice == "mst")
            {
                return new Algorithm[] { new MST() };
            }
            else if(choice == "insert")
            {
                return new Algorithm[] { new Insert() };
            }
            else
            {
                return null;
            }
        }

        static void Main(string[] args)
        {
            String choice = args.Length > 1 ? args[1] : null;
            Algorithm[] toRun = ChooseAlgorithms(choice);

            if(toRun != null)
            {
                if(toRun.Length == 1)
                {
                    Console.WriteLine($"Running {toRun[0].Name}...");
                    Route result = toRun[0].Run();
                    Console.WriteLine("Algorithm returned route:");
                    result.Print();
                }
                else
                {
                    Console.WriteLine("Results:");
                    Console.WriteLine("\tName\tBest\tAverage");

                    foreach(Algorithm a in toRun)
                    {
                        try
                        {
                            double[] result = RunTrials(a);
                            Console.WriteLine("\t{0}\t{1:00.000}\t{2:00.000}", a.Name, result[0], result[1]);
                        }
                        catch(BadRouteException e)
                        {
                            Console.WriteLine(e.ToString());
                            break;
                        }
                    }
                }

                return;
            }

            // Uh oh, try again.
            Console.WriteLine("TSP Help:");
            Console.WriteLine("To run the program enter: dotnet run ./tsp [ALGORITHM]");
            Console.WriteLine("[ALGORITHM] is the name of the algorithm to use. Valid names are:\n\trandom\n\tgreedy\n\tmst\n\tinsert");
            Console.WriteLine("Alternatively if no algorithm argument is given, all available algorithms will be run and compared against each other.");
        }
    }
}
