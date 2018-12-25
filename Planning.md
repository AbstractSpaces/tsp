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

dotnet tsp \[ALGORITHM/ALL\] \[LIMIT\]

## Behaviour

Store a dictionary of algorithm names to their associated types.
Fetch chosen ALGORITHM via dictionary and instantiate it.
Start a loop that will run a preset number of trials.
Give LIMIT iterations to find its final answer.
Keep track of the best route found and the average route length.
Print the best and average after algorithm finishes.
If "all" was given as the argument, repeat for all available algorithms.

# Algorithms

## General Interface

For the program to select and iterate through algorithms, they'll need a unified interface or parent class.
It'd be nice if I could select the class by passing the argument to a dictionary, but that would require being able to use a class as the value of a variable and I don't think it's possible.
I'll just have to hard code algorithm selection and instantiation instead.
I might use external config files for algorithms to load certain values from during contruction, allowing me to change the values without rewriting constructor calls.

Algorithm classes needs:
    limit;      Iteration limit set at construction.
    best;       The best route found so far.
    last;       The route selected during the most recent iteration.
    step();     Run the next iteration of the algorithm.
    run();      Run the algorithm start to finish and return the best route.

## Greedy

Start with a random route.
Enumerate the routes one swap away from the current one, choose the shortest.
Repeat until the shortest route is the current one.