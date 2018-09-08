using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphStrategy.Core;

namespace GraphStrategy.Test
{
    [TestClass]
    public class NodeTest
    {
        [TestMethod]
        public void TestNode()
        {
            //Arrange
            Node newNode = new Node();
            newNode.Name = "Name1";
            newNode.Owner = "Red";
            newNode.Armies = 5;
            newNode.X = 2;
            newNode.Y = 3;

            //Act

            //Assert
            Assert.IsTrue(newNode.Name != "");
            Assert.IsTrue(newNode.Owner != "");
            Assert.IsTrue(newNode.Armies > 0);
            Assert.IsTrue(newNode.X > 0);
            Assert.IsTrue(newNode.Y > 0);
            Assert.IsTrue(newNode.NeighborNodes != null);
            Assert.IsTrue(newNode.NeighborNodes.Count >= 0);
        }
    }
}
