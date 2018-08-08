using System;
using System.Collections.Generic;
using System.Text;

namespace GraphResearch.Graphs
{
    public class Examples
    {
        public static Graph GenericKnowledge()
        {
            Graph g = new Graph();

            g.AddEdge("Person", EdgeType.CAN_BE, "Hungry");
            g.AddEdge("Person", EdgeType.CAN_HAVE, "Wallet");
            g.AddEdge("Person", EdgeType.CAN_HAVE, "Job");
            g.AddEdge("Person", EdgeType.IS_A, "Human");

            g.AddEdge("Food", EdgeType.HELPS_WITH, "Hungry");
            g.AddEdge("Food", EdgeType.REQUIRES, "Money");

            g.AddEdge("Wallet", EdgeType.CAN_HAVE, "Money");
            g.AddEdge("Job", EdgeType.HELPS_WITH, "Money");

            return g;
        }
    }
}
