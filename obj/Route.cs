
using System.Collections.Immutable;
using System.Collections.Generic;

// Represents a solution to the Travelling Salesman Problem.
// Will be immutable until I find reason to do otherwise.
class Route
{
    // Lists City ids in the order visited.
    public readonly ImmutableArray<int> order;
    // Summed distance of the route from start back to start.
    public readonly double length;

    // It'd be real nice if I could just require a certain length array in the parameter list.
    // But I refuse to use try-catch every time I call the constructor.
    public Route(int[] o)
    {
        order = ImmutableArray.CreateRange(o);

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
        length = l;
    }
}