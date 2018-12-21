using System;
using System.Collections.Immutable;
using System.Collections.Generic;

class City
{
    public readonly int id;
    public readonly string name;
    public readonly ImmutableArray<double> edges;

    public static City[] GetList()
    {
        // Number of cities.
        int n = 10;

        string[] names = {
            "Sydney",
            "Melbourne",
            "Brisbane",
            "Perth",
            "Adelaide",
            "Gold Coast",
            "Newcastle",
            "Canberra",
            "Sunshine Coast",
            "Wollongong"
        };

        // Coordinates are listed as degrees (South, East).
        double[,] coordinates = {
            {33.865, 151.209444},
            {7.813611, 144.963056},
            {27.466667, 153.033333},
            {31.952222, 115.858889},
            {34.928889, 138.601111},
            {28.016667, 153.4},
            {32.916667, 151.75},
            {35.3075, 149.124444},
            {26.65, 153.066667},
            {34.433056, 150.883056}
        };

        // Table of distances between each pair of cities.
        double[][] distances = new double[n][];

        for(int i = 0; i < n; i++) {
            distances[i] = new double[n];
        }

        for(int i = 0; i < n; i++)
        {
            for(int j = 0; j < i; j++)
            {
                // I don't know if the Pythagoras theorem can be applied to degrees, but real world data isn't important to the project anyway.
                double[] diff = {coordinates[i,0] - coordinates[j,0], coordinates[i,1] - coordinates[j,1]};
                double dist = Math.Sqrt(Math.Pow(diff[0], 2) + Math.Pow(diff[1], 2));
                distances[i][j] = dist;
                distances[j][i] = dist;
            }
        }

        City[] Cities = new City[n];

        for(int i = 0; i < n; i++)
        {
            // Turn the array into a list so I can delete an element from it.
            // Not an elegant solution, there's probably a better way to remove said element or prevent its existence in the first place.
            List<double> edges = new List<double>(distances[i]);
            // The City doesn't need to store an edge to itself.
            edges.RemoveAt(i);
            Cities[i] = new City(i, names[i], edges);
        }

        return Cities;
    }

    private City(int i, string n, IEnumerable<double> e)
    {
        id = i;
        name = n;
        edges = ImmutableArray.CreateRange(e);
    }
}
