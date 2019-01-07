# TSP

This program is a demonstration of several different algorithms applied to the travelling salesman problem, as well as a comparison of their results.

I formed the graph to apply the problem to by taking a list of the most populated cities in Australia and using their latitude and longitude to roughly calculate the straight line distance between each pair of cities in degrees (Is this a valid way to measure distance? I'm not sure, but it works as an example of the problem so let's just roll with it).

The program measures the performance of an algorithm by how short a route it can produce, with routes visiting every city exactly once then returning to the starting city.

Most of this code was rushed together in my spare time so it's not necessarily the most elegant or well tested product I'm capable of producing, but at this point I'll be happy for something that seems vaguely functional and complete.

## Usage

The program requires you to have .NET Core (or the full Framework) installed. Clone the repository or just download /bin/tsp.dll, and open a terminal window in the same directory as your downloaded tsp.dll. Then execute:

    dotnet run tsp [ALGORITHM]

The \[ALGORITHM\] argument is optional. If not given, the program will output a results comparison of all implemented algorithms.
Alternatively a single algorithm can be run by supplying one of the following names:

    random
    hillclimb
    mst
    insert