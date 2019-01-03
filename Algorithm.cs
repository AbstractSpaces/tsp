using System;

namespace TSP
{
    abstract class Algorithm
    {
        public readonly string Name;

        public Algorithm(string name)
        {
            Name = name;
            Reset();
        }

        // If the class has any internal state, it will be reset between trials.
        abstract public void Reset();
        // Run the algorithm to completion and return the best route found.
        abstract public Route Run();
    }
}