using System.Collections.Generic;

namespace TSP
{
    // This class is primarily for the MST algorithm, which involves directly accessing nodes and inserting children under them.
    // A block representation of the tree provides best access to individual nodes.
    // I was going to make it a generic class, but I doubt I'll reuse it and I could save some time by making it City specific.
    class CityTree
    {
        public readonly City Root;
        // Each element corresponds to a City in City.ListOf.
        // The value of each element is the index/ID of that node's parent.
        private int[] Tree;

        public CityTree(City root)
        {
            Root = root;
            Tree = new int[City.Count];
            Tree[Root.ID] = -1;
        }

        // If/when I have time I'll add some checking to ensure the insertion doesn't violate the tree structure.
        public void Insert(City child, City parent)
        {
            Tree[child.ID] = parent.ID;
        }

        public List<City> Children(City parent)
        {
            List<City> children = new List<City>();

            for(int i = 0; i < Tree.Length; i++)
            {
                if(Tree[i] == parent.ID)
                {
                    children.Add(City.ListOf[i]);
                }
            }

            return children;
        }
    }
}