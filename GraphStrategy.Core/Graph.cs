using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphStrategy.Core
{
    public class Graph
    {
        public Graph()
        {
            Nodes = new List<Node>();
        }

        public List<Node> Nodes { get; set; }
        //public bool[,] AdjacencyMatrix { get; set; }

        public void BuildGraph(int width, int height, int chanceToCreateLink)
        {
            int numberOfNodes = width * height;

            //AdjacencyMatrix = new bool[numberOfNodes, numberOfNodes];

            //Create all of the nodes - O(xy)
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Node newNode = new Node();
                    newNode.Name = x.ToString() + "," + y.ToString();
                    newNode.X = x;
                    newNode.Y = y;
                    Nodes.Add(newNode);
                }
            }

            //Create the links between the nodes - O(xy)
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Node currentNode = GetTargetNode(x, y);
                    if (currentNode != null)
                    {
                        //create links to the left
                        CreateLinkBetweenNodes(chanceToCreateLink, currentNode, x - 1, y, width, height);
                        //create links to the right
                        CreateLinkBetweenNodes(chanceToCreateLink, currentNode, x + 1, y, width, height);
                        //create links above
                        CreateLinkBetweenNodes(chanceToCreateLink, currentNode, x, y - 1, width, height);
                        //create links below
                        CreateLinkBetweenNodes(chanceToCreateLink, currentNode, x, y + 1, width, height);

                        //TODO: Add Diagonal links
                        ////create links to the top left
                        //CreateLinkBetweenNodes(chanceToCreateLink, currentNode, x - 1, y - 1, width, height);
                        ////create links to the top right
                        //CreateLinkBetweenNodes(chanceToCreateLink, currentNode, x + 1, y + 1, width, height);
                        ////create links to the bottom left
                        //CreateLinkBetweenNodes(chanceToCreateLink, currentNode, x - 1, y - 1, width, height);
                        ////create links to the bottom right
                        //CreateLinkBetweenNodes(chanceToCreateLink, currentNode, x + 1, y + 1, width, height);
                    }
                }
            }
        }

        //This is an undirected graph, so links should be made in both directions
        private void CreateLinkBetweenNodes(int chanceToCreateLink, Node sourceNode, int x, int y, int width, int height)
        {
            //Ensure we don't create a link to a node that is out of bounds
            if (x >= 0 && x <= width - 1 && y >= 0 && y <= height - 1)
            {
                //Randomize the creation a little bit to create some varability
                if (Utility.GenerateRandomNumber(1, 100) <= chanceToCreateLink)
                {
                    Node neighborNode = GetTargetNode(x, y);
                    if (neighborNode != null)
                    {
                        //Add the link from the source to neighbour 
                        AddNodeAlreadyToNeighborList(sourceNode, neighborNode);
                        //Add the link from the neighbour to source
                        AddNodeAlreadyToNeighborList(neighborNode, sourceNode);
                    }
                }
            }
        }

        private void AddNodeAlreadyToNeighborList(Node sourceNode, Node neighborNode)
        {
            //only add the link if it doesn't already exist
            if (sourceNode.NeighborNodes.Where<Node>(a => a == neighborNode).Count<Node>() == 0)
            {
                sourceNode.NeighborNodes.Add(neighborNode);
            }
        }

        //Get the target node that matches the x and y coordinates
        private Node GetTargetNode(int x, int y)
        {
            return Nodes.SingleOrDefault<Node>(a => a.X == x && a.Y == y);
        }
    }
}
