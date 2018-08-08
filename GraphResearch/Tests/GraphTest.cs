using GraphResearch.Graphs;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GraphResearch.Tests
{
    public class GraphTest
    {
        Graph g;

        public GraphTest()
        {
            g = Examples.GenericKnowledge();

            g.AddEdge("Folder", EdgeType.CONTAINS, "Folder");
            g.AddEdge("Folder", EdgeType.CONTAINS, "File");

            g.AddEdge("A", EdgeType.REQUIRES, "B");
            g.AddEdge("B", EdgeType.REQUIRES, "C");
            g.AddEdge("C", EdgeType.REQUIRES, "A");
        }

        [Fact]
        public void ConnectedTo()
        {
            Assert.True(g.Vertices["Person"].IsConnectedTo(g.Vertices["Wallet"]));
        }

        [Fact]
        public void ConnectedToTransitive()
        {
            Assert.True(g.Vertices["Person"].IsConnectedTo(g.Vertices["Money"]));
        }

        [Fact]
        public void ConnectedFrom()
        {
            Assert.True(g.Vertices["Hungry"].IsConnectedFrom(g.Vertices["Food"]));
        }

        [Fact]
        public void ConnectedFromTransitive()
        {
            Assert.True(g.Vertices["C"].IsConnectedFrom(g.Vertices["A"]));
        }

        [Fact]
        public void ConnectedToRecursive()
        {
            Assert.True(g.Vertices["A"].IsConnectedTo(g.Vertices["A"]));
        }

        [Fact]
        public void ConnectedFromRecursive()
        {
            Assert.True(g.Vertices["A"].IsConnectedFrom(g.Vertices["A"]));
        }
    }
}
