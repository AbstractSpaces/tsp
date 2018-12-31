namespace TSP
{
    // This simply chooses a random route.
    // Its performance is the baseline against which other algorithms can be compared.
    class Random : Algorithm
    {
        public Random() : base("Random")
        { }

        override public void Reset()
        { }

        override public Route Run()
        {
            return new Route();
        }
    }
}