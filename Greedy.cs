using System.Collections.Generic;

namespace tsp
{
    // This algorithms starts with a random Route, and repeatedly performs the swap that reduces Route length the most.
    class Greedy : Algorithm
    {
        public Greedy() : base("Greedy")
        { }

        override public Route Run()
        {
            while(!Step());
            return best;
        }

        private bool Step()
        {
            List<Route> n = last.Neighbours();
            Route selected = last;

            foreach(Route i in n)
            {
                if(i.length < selected.length)
                {
                    selected = i;
                }
            }

            if(selected.length >= best.length)
            {
                return true;
            }
            else
            {
                best = selected;
                return false;
            }
        }
    }
}