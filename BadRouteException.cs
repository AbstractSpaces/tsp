using System;

namespace TSP
{
    // This doesn't follow the recommended way to implement a custom exception, but I only needed it for debugging and it served its purpose.
    class BadRouteException : Exception
    {
        public readonly int RouteLength;
        public readonly Algorithm Cause;

        public BadRouteException(int length, Algorithm cause)
        {
            RouteLength = length;
            Cause = cause;
        }

        override public string ToString()
        {
            return $"{Cause.Name} returned an invalid Route with {RouteLength} Cities.";
        }
    }
}