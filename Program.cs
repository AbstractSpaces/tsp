using System;
using System.Collections.Generic;

namespace tsp
{
    class Program
    {
        private static int trials = 10;

        private static Algorithm[] ChooseAlgorithms(String choice)
        {
            if(choice == null)
            {
                return new Algorithm []
                {
                    new Random(),
                    new Greedy()
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

            return null;
        }

        static void Main(string[] args)
        {
            String choice = args.Length > 1 ? args[2] : null;
            Algorithm[] toRun = ChooseAlgorithms(choice);

            if(toRun != null)
            {
                Console.WriteLine("Results:");
                Console.WriteLine("\tName\tBest\tAverage");

                foreach(Algorithm a in toRun)
                {
                    double[] result = a.RunTrials(trials);
                    Console.WriteLine("\t{0}\t{1:00.000}\t{2:00.000}", a.name, result[0], result[1]);
                }
                
                return;
            }

            // Uh oh, try again.
            Console.WriteLine("TSP Help:");
            Console.WriteLine("To run the program enter: dotnet run ./tsp [ALGORITHM]");
            Console.WriteLine("[ALGORITHM] is the name of the algorithm to use. Valid names are:\n\trandom\n\tgreedy");
            Console.WriteLine("Alternatively if no algorithm argument is given, all available algorithms will be run and compared against each other.");
        }
    }
}
