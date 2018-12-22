using System;
using System.Collections.Immutable;
using System.Collections.Generic;

// Contains essential information about cities along the route.
class City
{
    // The number of cities being considered.
    public static int Count;
    
    public static ImmutableArray<City> ListOf;

    static City()
    {
        Count = 10;

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
        double[][] distances = new double[Count][];

        for(int i = 0; i < Count; i++) {
            distances[i] = new double[Count];
        }

        for(int i = 0; i < Count; i++)
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

        City[] Cities = new City[Count];

        for(int i = 0; i < Count; i++)
        {
            Cities[i] = new City(i, names[i], distances[i]);
        }

        ListOf = Cities.ToImmutableArray();
    }

    public readonly int id;
    public readonly string name;
    // Distances from this city to each other city.
    // Array indices match the id of each city.
    public readonly ImmutableArray<double> edges;

    private City(int i, string n, double[] e)
    {
        id = i;
        name = n;
        edges = e.ToImmutableArray();
    }
}
