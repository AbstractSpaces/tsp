using System.Collections.Generic;

namespace TSP
{
    // This algorithm builds a minimum spanning tree of the graph of cities.
    // It then performs a depth first search on the tree and uses the order of traversal to build the route.
    // This guarantees a solution no more than twice the length of the optimal one.
    // There's a lot of side effects in use here that I'm not proud of, I'd prefer a stateless architecture for these algorithms but I'm kind of committed at this point.
    class MST : Algorithm
    {
        private CityTree Tree;
        private bool[] Visited;
        private List<City> Result;
        public MST() : base("MST")
        { }

        override public void Reset()
        {
            Tree = null;
            Visited = new bool[City.Count];
            Result = new List<City>();
        }

        override public Route Run()
        {
            BuildTree();
            DFS(Tree.Root);
            return new Route(Result.ToArray());
        }
        
        // Using Prim's algorithm, build a minimum spanning tree of the graph of Cities.
        private void BuildTree()
        {
            // Select a random City to be the tree's root node.
            City root = Program.RandomElement<City>(City.ListOf);
            Tree = new CityTree(root);

            List<City> onTree = new List<City>();
            onTree.Add(root);

            List<City> offTree = new List<City>(City.ListOf);
            offTree.Remove(root);

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

                Tree.Insert(to, from);
                onTree.Add(to);
                offTree.Remove(to);
            }
        }

        private void DFS(City node)
        {
            Visited[node.ID] = true;
            Result.Add(node);

            foreach(City c in Tree.Children(node))
            {
                if(!Visited[c.ID])
                {
                    DFS(c);
                }
            }
        }
    }
}