using System.Collections.Generic;

namespace TSP
{
    // This algorithm builds a route one City at a time.
    // It randomly chooses the next City to insert, then identifies the insertion point for it that least increases the Route's length.
    class Insert : Algorithm
    {
        private Route Result;
        private List<City> offRoute;

        public Insert() : base("Insert")
        { }

        override public void Reset()
        {
            // Choose a random City as the first on the Route.
            City first = Program.RandomElement(City.ListOf);
            Result = new Route(new City[] { first });
            offRoute = new List<City>(City.ListOf);
            offRoute.Remove(first);
        }

        override public Route Run()
        {
            while(Result.Count < City.Count)
            {
                City next = Program.RandomElement(offRoute);
                offRoute.Remove(next);

                Route best = Result.Insert(next, 0);

                for(int i = 1; i <= Result.Count; i++)
                {
                    Route compare = Result.Insert(next, i);
                    if(compare.Length < best.Length)
                    {
                        best = compare;
                    }
                }
                
                Result = best;
            }

            return Result;
        }
    }
}