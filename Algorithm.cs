using System;

namespace tsp
{
    abstract class Algorithm
    {
        public readonly String name;
        protected int limit;
        protected Route best;
        protected Route last;

        public Algorithm(String n, int l)
        {
            name = n;
            limit = l;
            best = new Route();
            last = best;
        }

        public void Reset()
        {
            best = new Route();
            last = best;
        }

        public Route Run()
        {
            for(int i = 0; i < limit && !Step(); i++);
            return best;
        }

        // Run the algorithm a specified number of times, returning the shortest route length found and the average.
        public double[] RunTrials(int t)
        {
            double shortest = double.PositiveInfinity;
            double total = 0.0;

            for(int i = 0; i < t; i++)
            {
                Reset();
                Route result = Run();
                shortest = result.length < shortest ? result.length : shortest;
                total += result.length;
            }

            return new double[] {shortest, total / (double) t};
        }

        // Returns true if this is to be the final iteration.
        abstract public bool Step();
    }
}