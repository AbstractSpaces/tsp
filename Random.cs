namespace tsp
{
    class Random : Algorithm
    {
        public Random() : base("Random", 1)
        { }

        override public bool Step()
        {
            best = new Route();
            return true;
        }
    }
}