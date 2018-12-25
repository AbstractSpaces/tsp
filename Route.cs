using System;
using System.Linq;
using System.Collections.Immutable;
using System.Collections.Generic;

namespace tsp
{
    // Represents a solution to the Travelling Salesman Problem.
    // Will be immutable until I find reason to do otherwise.
    class Route
    {
        // Lists City ids in the order visited.
        public readonly ImmutableArray<int> order;
        // Summed distance of the route from start back to start.
        public readonly double length;

        // Create a randomised Route.
        public Route()
        {
            // Get a list of City ids.
            List<int> cities = new List<int>(Enumerable.Range(0, City.Count));

            List<int> o = new List<int>();
            Random rand = new Random();

            while(cities.Count > 0)
            {
                int i = rand.Next(cities.Count);
                o.Add(cities[i]);
                cities.RemoveAt(i);
            }

            order = o.ToImmutableArray();
            length = CalcLength();
        }

        // Create a Route using a specified order.
        // It'd be real nice if I could just require a certain length array in the parameter list.
        // But I refuse to use try-catch every time I call the constructor.
        public Route(int[] o)
        {
            order = o.ToImmutableArray();
            length = CalcLength();
        }

        // Create a new route by swapping two cities in the order of this Route.
        public Route SwapOrder(int indexA, int indexB)
        {
            int[] swapped = new int[order.Length];
            order.CopyTo(swapped);
            int temp = swapped[indexA];
            swapped[indexA] = swapped[indexB];
            swapped[indexB] = temp;
            return new Route(swapped);
        }

        // Retrieve the Routes that are one swap away from the current one.
        public List<Route> Neighbours()
        {
            List<Route> n = new List<Route>();

            for(int i = 0; i < order.Length - 1; i++)
            {
                for(int j = i + 1; j < order.Length; j++)
                {
                    n.Add(SwapOrder(i, j));
                }
            }

            return n;
        }

        public void Print()
        {
            Console.Write("Route: ");
            foreach(int i in order)
            {
                Console.Write(String.Format("{0} ", i));
            }
            Console.WriteLine(String.Format("\nLength: {0}\n", length));
        }

        private double CalcLength()
        {
            double l = 0.0;

            for(int i = 0; i < order.Length-1; i++)
            {
                // Could've done this on one line, chose not to for readability.
                City from = City.ListOf[order[i]];
                double edge = from.edges[order[i+1]];
                l += edge;
            }

            City last = City.ListOf[order[order.Length-1]];
            l += last.edges[order[0]];
            return l;
        }
    }
}