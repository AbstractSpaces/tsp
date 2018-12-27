using System;
using System.Collections.Generic;

namespace tsp
{
    class Program
    {
        private static int trials = 10;

        private static String help =
            @"TSP Help:
            To run the program enter:
                dotnet tsp LIMIT [ALGORITHM]

            LIMIT determines how many iterations the algorithm(s) will be allowed to run. It must be a positive integer.
            [ALGORITHM] is the name of the algorithm to use. Valid names are:
                random
                greedy
            Alternatively if no algorithm argument is given, all available algorithms will be run and compared against each other.
            ";

        private static Algorithm[] ChooseAlgorithms(String choice, int limit)
        {
            if(choice == null)
            {
                return new Algorithm []
                {
                    new Random(),
                    new Greedy(limit)
                };
            }
            else if(choice == "random")
            {
                return new Algorithm [] { new Random() };
            }
            else if(choice == "greedy")
            {
                return new Algorithm [] { new Greedy(limit) };
            }

            return null;
        }

        static void Main(string[] args)
        {
            int limit;

            if(args.Length >= 2 && Int32.TryParse(args[1], out limit))
            {
                String choice = args.Length > 2 ? args[2] : null;
                Algorithm[] toRun = ChooseAlgorithms(choice, limit);

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
            }

            // Uh oh, try again.
            Console.Write(help);
        }
    }
}
