using System.Collections.Generic;

namespace tsp
{
    class Greedy : Algorithm
    {
        public Greedy(int l) : base("Greedy", l)
        { }

        override public bool Step()
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