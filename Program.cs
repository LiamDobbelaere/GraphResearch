using System;
using GraphResearch.Graphs;

namespace GraphResearch
{
    class Program
    {   
        static void OldMain(string[] args)
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

            Console.WriteLine(String.Format("Person connected to Hungry? {0}", 
                g.Vertices["Person"].IsConnectedTo(g.Vertices["Hungry"])));

            

            Console.WriteLine(String.Format("Person connected to Money? {0}",
                g.Vertices["Person"].IsConnectedTo(g.Vertices["Money"])));

            Console.WriteLine(String.Format("Person connected to Food? {0}",
                g.Vertices["Person"].IsConnectedTo(g.Vertices["Food"])));

            Console.WriteLine(String.Format("Hungry connected from Food? {0}",
                g.Vertices["Hungry"].IsConnectedFrom(g.Vertices["Food"])));

            g.AddEdge("Folder", EdgeType.CONTAINS, "Folder");
            g.AddEdge("Folder", EdgeType.CONTAINS, "File");

            Console.WriteLine(String.Format("Folder connected to file? {0}",
                g.Vertices["Folder"].IsConnectedTo(g.Vertices["File"])));

            Console.WriteLine(String.Format("Folder connected to folder? {0}",
                g.Vertices["Folder"].IsConnectedTo(g.Vertices["Folder"])));

            g.AddEdge("A", EdgeType.REQUIRES, "B");
            g.AddEdge("B", EdgeType.REQUIRES, "C");
            g.AddEdge("C", EdgeType.REQUIRES, "A");

            Console.WriteLine(String.Format("A connected to B? {0}",
                g.Vertices["A"].IsConnectedTo(g.Vertices["B"])));

            Console.WriteLine(String.Format("A connected to C? {0}",
                g.Vertices["A"].IsConnectedTo(g.Vertices["C"])));

            Console.WriteLine(String.Format("A connected to A? {0}",
                g.Vertices["A"].IsConnectedTo(g.Vertices["A"])));

            Console.ReadKey();
        }
    }
}
