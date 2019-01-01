using System;
using System.Collections.Generic;

namespace TSP
{
    class Program
    {
        private static readonly int trials = 100;

        // Run an algorithm a specified number of times, returning the shortest route length found and the average.
        public static double[] RunTrials(Algorithm toRun)
        {
            double shortest = double.PositiveInfinity;
            double total = 0.0;

            for(int i = 0; i < trials; i++)
            {
                toRun.Reset();
                Route result = toRun.Run();
                shortest = result.Length < shortest ? result.Length : shortest;
                total += result.Length;
            }

            return new double[] {shortest, total / (double) trials};
        }

        private static Algorithm[] ChooseAlgorithms(String choice)
        {
            if(choice == null)
            {
                return new Algorithm []
                {
                    new Random(),
                    new Greedy(),
                    new MST()
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

            return null;
        }

        static void Main(string[] args)
        {
            String choice = args.Length > 1 ? args[1] : null;
            Algorithm[] toRun = ChooseAlgorithms(choice);

            if(toRun != null)
            {
                Console.WriteLine("Results:");
                Console.WriteLine("\tName\tBest\tAverage");

                foreach(Algorithm a in toRun)
                {
                    double[] result = RunTrials(a);
                    Console.WriteLine("\t{0}\t{1:00.000}\t{2:00.000}", a.Name, result[0], result[1]);
                }
                
                return;
            }

            // Uh oh, try again.
            Console.WriteLine("TSP Help:");
            Console.WriteLine("To run the program enter: dotnet run ./tsp [ALGORITHM]");
            Console.WriteLine("[ALGORITHM] is the name of the algorithm to use. Valid names are:\n\trandom\n\tgreedy\n\tmst");
            Console.WriteLine("Alternatively if no algorithm argument is given, all available algorithms will be run and compared against each other.");
        }
    }
}
