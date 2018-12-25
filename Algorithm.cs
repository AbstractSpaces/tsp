namespace tsp
{
    abstract class Algorithm
    {
        protected int limit;
        protected Route best;
        protected Route last;

        public Algorithm(int l)
        {
            limit = l;
            best = new Route();
            last = best;
        }

        public Route Run()
        {
            for(int i = 0; i < limit && !Step(); i++);
            return best;
        }

        // Returns true if this is to be the final iteration.
        abstract public bool Step();
    }
}