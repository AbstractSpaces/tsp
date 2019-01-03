# TODO

Simulated annealing
Tabu

# Models

The central data structures are the City, the list thereof, and the ordered list comprising a solution to the TSP.

## City

The algorithms are only concerned with edges between Cities, so the structures are simply a way to organise edges.
For performance it makes sense to pre-calculate all edges.
It will be easier for the algorithms if each City holds a list of all edges to all other Cities. There will be some redundancy, but it's O(1) in terms of space so nothing to worry about.
For cities to reference each other in this list of edges, a fixed integer identifier should be assigned to each. I'll hard code the identifiers in a static list of some sort.

## Route

A list of cities describing the order of travel, with an implied return to the start.
Should have a method for calculating total length of the solution.
If I need a method for printing a solution, it makes sense to put it here.

# Program

## Execution

dotnet tsp \[ALGORITHM/ALL\]

## Behaviour

Fetch chosen ALGORITHM(s).
Start a loop that will run a preset number of trials.
Keep track of the best route found and the average route length.
Print the best and average after algorithm finishes.
If "all" was given as the argument, repeat for all available algorithms.

# Algorithms

## Greedy

Start with a random route.
Enumerate the routes one swap away from the current one, choose the shortest.
Repeat until the shortest route is the current one.

## MST

Build a minimum spanning tree from the graph, then pre-order DFS the tree.
Represent tree with int array.
Use Prim's algorithm to build the tree:
    Maintain lists of cities IN and OUT of the tree.
    While OUT.length > 0:
        For city i in IN, find shortest edge to one of j in OUT.
        Mark tree\[j\] = i;
        Move j from OUT to IN.