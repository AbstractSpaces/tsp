using System.Collections.Generic;

namespace TSP
{
    // This algorithm builds a minimum spanning tree of the graph of cities.
    // It then performs a depth first search on the tree and uses the order of traversal to build the route.
    // This guarantees a solution no more than twice the length of the optimal one.
    class MST : Algorithm
    {
        // The spanning tree is represented by this array.
        // Each index corresponds to the city with that index as its ID.
        // The value of each element is the index/ID of that City's parent node, with the root node labelled with -1 as parent.
        private List<int> Tree;

        public MST() : base("MST")
        { }

        override public void Reset()
        {
            Tree = new List<int>(City.Count);
        }

        override public Route Run()
        {
            BuildTree();
            return SearchTree();
        }
        
        // Using Prim's algorithm, build a minimum spanning tree of the graph of Cities.
        private void BuildTree()
        {
            // Select a random City to be the tree's root node.
            int root = new System.Random().Next(City.Count);
            Tree[root] = -1;

            List<City> onTree = new List<City>();
            onTree.Add(City.ListOf[root]);

            List<City> offTree = new List<City>(City.ListOf);
            offTree.RemoveAt(root);

            // Begin Prim's algorithm.
            while(onTree.Count < City.Count)
            {
                City from = onTree[0];
                City to = offTree[0];

                foreach(City i in onTree)
                {
                    foreach(City j in offTree)
                    {
                        if(i.Edges[j.ID] < from.Edges[to.ID])
                        {
                            from = i;
                            to = j;
                        }
                    }
                }

                Tree[to.ID] = from.ID;
                onTree.Add(to);
                offTree.Remove(to);
            }
        }

        private Route SearchTree()
        {
            List<City> r = new List<City>();
            
        }
    }
}