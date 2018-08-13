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

            g.AddEdge("Human", EdgeType.CAN_BE, "Hungry");
            g.AddEdge("Human", EdgeType.CAN_HAVE, "Wallet");
            g.AddEdge("Human", EdgeType.CAN_HAVE, "Job");
            
            g.AddEdge("Food", EdgeType.HELPS_WITH, "Hungry");
            g.AddEdge("Food", EdgeType.REQUIRES, "Money");

            g.AddEdge("Wallet", EdgeType.CAN_HAVE, "Money");
            g.AddEdge("Job", EdgeType.HELPS_WITH, "Money");

            g.AddEdge("Ground", EdgeType.CAN_BE, "Grass");
            g.AddEdge("Ground", EdgeType.CAN_BE, "Concrete");
            g.AddEdge("Ground", EdgeType.CAN_HAVE, "Tree");
            g.AddEdge("Grass", EdgeType.IS_A, "Weed");

            g.AddEdge("Grass", EdgeType.CAN_BE, "Green");
            g.AddEdge("Grass", EdgeType.CAN_BE, "Brown");

            g.AddEdge("Park", EdgeType.CAN_HAVE, "Trashcan");
            g.AddEdge("Park", EdgeType.CAN_HAVE, "Swings");
            g.AddEdge("Park", EdgeType.CAN_HAVE, "Bench");

            g.AddEdge("Swings", EdgeType.IS, "Fun");

            g.AddEdge("Sky", EdgeType.CAN_HAVE, "Sun");
            g.AddEdge("Sky", EdgeType.CAN_HAVE, "Moon");
            g.AddEdge("Sky", EdgeType.CAN_HAVE, "Cloud");

            g.AddEdge("Sun", EdgeType.IS_A, "Star");
            g.AddEdge("Sun", EdgeType.IS, "Hot");

            g.AddEdge("Green", EdgeType.IS_A, "Color");
            g.AddEdge("Brown", EdgeType.IS_A, "Color");

            g.AddEdge("Orange", EdgeType.IS_A, "Fruit");
            g.AddEdge("Fruit", EdgeType.IS, "Food");

            g.AddEdge("Dog", EdgeType.CAN, "Barking");
            g.AddEdge("Barking", EdgeType.IS_A, "Sound");
            g.AddEdge("Sound", EdgeType.REQUIRES, "Ear");
            g.AddEdge("Human", EdgeType.CAN_HAVE, "Ear");

            g.AddEdge("Trashcan", EdgeType.CAN_HAVE, "Trash");

            return g;
        }
    }
}
