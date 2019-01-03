using System;
using System.Linq;
using System.Collections.Immutable;
using System.Collections.Generic;

namespace TSP
{
    // Represents a solution to the Travelling Salesman Problem.
    // Will be immutable until I find reason to do otherwise.
    class Route
    {
        // Lists City ids in the order visited.
        public readonly ImmutableArray<City> Order;
        // Summed distance of the route from start back to start.
        public readonly double Length;

        // Create a randomised Route.
        public Route()
        {
            // Get a list of City ids.
            List<int> id = new List<int>(Enumerable.Range(0, City.Count));

            List<City> o = new List<City>();
            System.Random rand = new System.Random();

            while(id.Count > 0)
            {
                int i = rand.Next(id.Count);
                o.Add(City.ListOf[id[i]]);
                id.RemoveAt(i);
            }

            Order = o.ToImmutableArray();
            Length = CalcLength();
        }

        // Create a Route using a specified order.
        public Route(City[] o)
        {
            Order = o.ToImmutableArray();
            Length = CalcLength();
        }

        // Create a Route by adding a City to an existing route, at the specified position.
        public Route Insert(City city, int position)
        {
            if(position > Order.Length)
            {
                Console.WriteLine("Can't insert City at index {0}. Defaulting to end of array.", position);
                position = Order.Length;
            }
            City[] newOrder = new City[Order.Length + 1];
            Order.CopyTo(0, newOrder, 0, position);
            newOrder[position] = city;
            Order.CopyTo(position, newOrder, position + 1, Order.Length - position);
            return new Route(newOrder);
        }

        // Create a new route by swapping two cities in the order of this Route.
        public Route SwapOrder(int indexA, int indexB)
        {
            City[] swapped = new City[Order.Length];
            Order.CopyTo(swapped);
            City temp = swapped[indexA];
            swapped[indexA] = swapped[indexB];
            swapped[indexB] = temp;
            return new Route(swapped);
        }

        // Retrieve the Routes that are one swap away from the current one.
        public List<Route> Neighbours()
        {
            List<Route> n = new List<Route>();

            for(int i = 0; i < Order.Length - 1; i++)
            {
                for(int j = i + 1; j < Order.Length; j++)
                {
                    n.Add(SwapOrder(i, j));
                }
            }

            return n;
        }

        public void Print()
        {
            Console.Write("Route: ");
            foreach(City i in Order)
            {
                Console.Write(String.Format("{0} ", i.Name));
            }
            Console.WriteLine(String.Format("\nLength: {0}\n", Length));
        }

        private double CalcLength()
        {
            double l = 0.0;

            for(int i = 0; i < Order.Length-1; i++)
            {
                // Could've done this on one line, chose not to for readability.
                City from = Order[i];
                double edge = from.Edges[Order[i+1].ID];
                l += edge;
            }

            City last = Order[Order.Length-1];
            l += last.Edges[Order[0].ID];
            return l;
        }
    }
}