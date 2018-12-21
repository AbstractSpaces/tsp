# Models

The central data structures are the City, the list thereof, and the ordered list comprising a solution to the TSP.

## City

The algorithms are only concerned with edges between Cities, so the structures are simply a way to organise edges.
For performance it makes sense to pre-calculate all edges.
It will be easier for the algorithms if each City holds a list of all edges to all other Cities. There will be some redundancy, but it's O(1) in terms of space so nothing to worry about.
For cities to reference each other in this list of edges, a fixed integer identifier should be assigned to each. I'll hard code the identifiers in a static list of some sort.

## City List

The main program can store a simple array of City instances.
By matching list index to the identifier assigned to each City, fetching a City's data can be done with List\[ID\].

## Solution

A list of cities describing the order of travel, with an implied return to the start.
Should have a method for calculating total length of the solution.
If I need a method for printing a solution, it makes sense to put it here.