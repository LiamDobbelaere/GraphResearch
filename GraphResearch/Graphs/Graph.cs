using System;
using System.Collections.Generic;
using System.Text;

namespace GraphResearch.Graphs
{
    /// <summary>
    /// Facilitates creating and searching graphs.
    /// </summary>
    public class Graph
    {
        public Dictionary<string, Vertex> Vertices
        {
            get;
        }

        public Graph()
        {
            this.Vertices = new Dictionary<string, Vertex>();
        }

        public void AddEdge(string a, EdgeType type, string b)
        {
            if (!Vertices.ContainsKey(a))
            {
                Vertices[a] = new Vertex(a);
            }

            if (!Vertices.ContainsKey(b))
            {
                Vertices[b] = new Vertex(b);
            }

            Vertices[a].Connect(Vertices[b], type);
        }
    }
}
