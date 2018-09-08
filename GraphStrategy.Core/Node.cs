using System;
using System.Collections.Generic;

namespace GraphStrategy.Core
{
    public class Node
    {
        public Node()
        {
            NeighborNodes = new List<Node>();
        }

        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Owner { get; set; }
        public int Armies { get; set; }

        public List<Node> NeighborNodes { get; set; }
    }
}
