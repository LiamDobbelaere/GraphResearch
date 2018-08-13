using System;
using GraphResearch.Graphs;

namespace GraphPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = Examples.GenericKnowledge();

            /*Console.WriteLine("A person");
            foreach (Edge edge in g.Vertices["Person"].Connections)
            {
                Console.WriteLine(edge.Type + " " + edge.Next.Name);
            }*/

            GraphDisplay.Display(g);

            Console.ReadKey();
        }
    }
}
