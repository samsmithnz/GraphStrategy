using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphStrategy.Core;

namespace GraphStrategy.Test
{
    [TestClass]
    public class GraphTest
    {
        [TestMethod]
        public void TestByHandGraphCreation()
        {
            //Arrange
            Graph newGraph = new Graph();
            Node newNode = new Node();
            newNode.Name = "Name1";
            newNode.Owner = "Red";
            newNode.Armies = 5;
            newGraph.Nodes.Add(newNode);

            Node newNode2 = new Node();
            newNode2.Name = "Name2";
            newNode2.Owner = "Blue";
            newNode2.Armies = 3;
            newGraph.Nodes.Add(newNode2);

            //Add the relationships
            newNode.NeighborNodes.Add(newNode2);
            newNode2.NeighborNodes.Add(newNode);

            //Act

            //Assert
            Assert.IsTrue(newGraph.Nodes != null);
            Assert.IsTrue(newGraph.Nodes.Count == 2);
            Assert.IsTrue(newGraph.Nodes[0].NeighborNodes[0] == newNode2);
            Assert.IsTrue(newGraph.Nodes[1].NeighborNodes[0] == newNode);
        }

        [TestMethod]
        public void TestGraphBuildingSize1()
        {
            //arrange
            Graph newGraph = new Graph();
            int width = 1;
            int height = 1;
            int chanceToCreateLink = 100; //100%

            //act
            newGraph.BuildGraph(width, height, chanceToCreateLink);

            //assert
            Assert.AreEqual(newGraph.Nodes.Count, width * height);
            //test the nodes
            Assert.AreEqual(newGraph.Nodes[0].Name, "0,0");
            //test the links
            Assert.AreEqual(newGraph.Nodes[0].NeighborNodes.Count, 0);
        }

        [TestMethod]
        public void TestGraphBuilding4()
        {
            //arrange
            Graph newGraph = new Graph();
            int width = 2;
            int height = 2;
            int chanceToCreateLink = 100; //100%

            //act
            newGraph.BuildGraph(width, height, chanceToCreateLink);

            //assert
            Assert.AreEqual(newGraph.Nodes.Count, width * height);
            //test the nodes
            Assert.AreEqual(newGraph.Nodes[0].Name, "0,0");
            Assert.AreEqual(newGraph.Nodes[1].Name, "0,1");
            Assert.AreEqual(newGraph.Nodes[2].Name, "1,0");
            Assert.AreEqual(newGraph.Nodes[3].Name, "1,1");
            //test the links
            Assert.AreEqual(newGraph.Nodes[0].NeighborNodes.Count, 2);
            Assert.AreEqual(newGraph.Nodes[1].NeighborNodes.Count, 2);
            Assert.AreEqual(newGraph.Nodes[2].NeighborNodes.Count, 2);
            Assert.AreEqual(newGraph.Nodes[3].NeighborNodes.Count, 2);
        }

        [TestMethod]
        public void TestGraphBuilding9With100PercentChance()
        {
            //arrange
            Graph newGraph = new Graph();
            int width = 3;
            int height = 3;
            int chanceToCreateLink = 100; //100%

            //act
            newGraph.BuildGraph(width, height, chanceToCreateLink);

            //assert
            Assert.AreEqual(newGraph.Nodes.Count, width * height);
            //test the nodes
            Assert.AreEqual(newGraph.Nodes[0].Name, "0,0");
            Assert.AreEqual(newGraph.Nodes[1].Name, "0,1");
            Assert.AreEqual(newGraph.Nodes[2].Name, "0,2");
            Assert.AreEqual(newGraph.Nodes[3].Name, "1,0");
            Assert.AreEqual(newGraph.Nodes[4].Name, "1,1");
            Assert.AreEqual(newGraph.Nodes[5].Name, "1,2");
            Assert.AreEqual(newGraph.Nodes[6].Name, "2,0");
            Assert.AreEqual(newGraph.Nodes[7].Name, "2,1");
            Assert.AreEqual(newGraph.Nodes[8].Name, "2,2");
            //test the links
            Assert.AreEqual(newGraph.Nodes[0].NeighborNodes.Count, 2);
            Assert.AreEqual(newGraph.Nodes[1].NeighborNodes.Count, 3);
            Assert.AreEqual(newGraph.Nodes[2].NeighborNodes.Count, 2);
            Assert.AreEqual(newGraph.Nodes[3].NeighborNodes.Count, 3);
            Assert.AreEqual(newGraph.Nodes[4].NeighborNodes.Count, 4);
            Assert.AreEqual(newGraph.Nodes[5].NeighborNodes.Count, 3);
            Assert.AreEqual(newGraph.Nodes[6].NeighborNodes.Count, 2);
            Assert.AreEqual(newGraph.Nodes[7].NeighborNodes.Count, 3);
            Assert.AreEqual(newGraph.Nodes[8].NeighborNodes.Count, 2);
        }

        [TestMethod]
        public void TestGraphBuilding9With20PercentChance()
        {
            //arrange
            Graph newGraph = new Graph();
            int width = 3;
            int height = 3;
            int chanceToCreateLink = 20; //20%

            //act
            newGraph.BuildGraph(width, height, chanceToCreateLink);

            //assert
            Assert.AreEqual(newGraph.Nodes.Count, width * height);
            //test the nodes
            Assert.AreEqual(newGraph.Nodes[0].Name, "0,0");
            Assert.AreEqual(newGraph.Nodes[1].Name, "0,1");
            Assert.AreEqual(newGraph.Nodes[2].Name, "0,2");
            Assert.AreEqual(newGraph.Nodes[3].Name, "1,0");
            Assert.AreEqual(newGraph.Nodes[4].Name, "1,1");
            Assert.AreEqual(newGraph.Nodes[5].Name, "1,2");
            Assert.AreEqual(newGraph.Nodes[6].Name, "2,0");
            Assert.AreEqual(newGraph.Nodes[7].Name, "2,1");
            Assert.AreEqual(newGraph.Nodes[8].Name, "2,2");
            //test the links
            Assert.IsTrue(newGraph.Nodes[0].NeighborNodes.Count >= 0);
            Assert.IsTrue(newGraph.Nodes[0].NeighborNodes.Count <= 2);
            Assert.IsTrue(newGraph.Nodes[1].NeighborNodes.Count >= 0);
            Assert.IsTrue(newGraph.Nodes[1].NeighborNodes.Count <= 3);
            Assert.IsTrue(newGraph.Nodes[2].NeighborNodes.Count <= 2);
            Assert.IsTrue(newGraph.Nodes[3].NeighborNodes.Count <= 3);
            Assert.IsTrue(newGraph.Nodes[4].NeighborNodes.Count <= 4);
            Assert.IsTrue(newGraph.Nodes[5].NeighborNodes.Count <= 3);
            Assert.IsTrue(newGraph.Nodes[6].NeighborNodes.Count <= 2);
            Assert.IsTrue(newGraph.Nodes[7].NeighborNodes.Count <= 3);
            Assert.IsTrue(newGraph.Nodes[8].NeighborNodes.Count <= 2);
        }

    }
}
