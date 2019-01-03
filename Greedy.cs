using System.Collections.Generic;

namespace TSP
{
    // This algorithms starts with a random Route, and repeatedly performs the swap that reduces Route length the most.
    // It treats the problem as a graph search where nodes are neighboured by routes differing by one swap.
    // It also happens to be an implementation of the 2-opt algorithm, but "2-opt" isn't a legal identifier so I'm staying with the name Greedy.
    class Greedy : Algorithm
    {
        private Route Current;

        public Greedy() : base("Greedy")
        { }

        override public void Reset()
        {
            Current = new Route();
        }

        override public Route Run()
        {
            while(true)
            {
                List<Route> n = Current.Neighbours();
                Route bestNeighbour = n[0];

                foreach(Route r in n)
                {
                    if(r.Length < bestNeighbour.Length)
                    {
                        bestNeighbour = r;
                    }
                }

                if(bestNeighbour.Length < Current.Length)
                {
                    Current = bestNeighbour;
                }
                else
                {
                    break;
                }
            }

            return Current; 
        }
    }
}