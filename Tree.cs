using System.Collections.Generic;

namespace TSP
{
    class Tree<T>
    {
        private Node<T> Root;

        private class Node<E>
        {
            private E Data;
            private Node<E> Parent;
            private List<Node<E>> Children;

            private Node(E data, Node<E> parent)
            {
                Data = data;
                Parent = parent;
                Children = new List<Node<E>>();
            }
        }
    }
}