using System;
using System.Collections.Generic;
using System.Text;

namespace GraphResearch.Graphs
{
    /// <summary>
    /// A certain point in the graph that can have many unique connections.
    /// </summary>
    public class Vertex
    {
        public string Name
        {
            get;
        }

        public HashSet<Edge> Connections
        {
            get;
        }

        public HashSet<Edge> ReverseConnections
        {
            get;
        }


        public Vertex(string name)
        {
            this.Name = name;
            this.Connections = new HashSet<Edge>();
            this.ReverseConnections = new HashSet<Edge>();
        }

        public void Connect(Vertex next, EdgeType type)
        {
            this.Connections.Add(new Edge(next, type));
            next.ReverseConnections.Add(new Edge(this, EdgeType.UNDEFINED));
        }

        /// <summary>
        /// Checks if this vertex is somehow connected to another.
        /// </summary>
        /// <param name="b">The other vertex</param>
        /// <returns>Boolean indicating whether the vertex is connected to the other or not.</returns>
        public bool IsConnectedTo(Vertex b)
        {
            return IsConnectedTo(b, new HashSet<Vertex>());
        }

        private bool IsConnectedTo(Vertex b, HashSet<Vertex> visited)
        {
            foreach (Edge connection in Connections)
            {
                if (visited.Contains(connection.Next)) continue;
                visited.Add(connection.Next);

                if (connection.Next.Equals(b)) return true;
                if (connection.Next.IsConnectedTo(b, visited)) return true;
            }

            visited.Add(this);

            return false;
        }


        /// <summary>
        /// Checks if this vertex is somehow connected from another.
        /// </summary>
        /// <param name="b">The other vertex</param>
        /// <returns>Boolean indicating whether the vertex is connected from the other or not.</returns>
        public bool IsConnectedFrom(Vertex b)
        {
            return IsConnectedFrom(b, new HashSet<Vertex>());
        }

        private bool IsConnectedFrom(Vertex b, HashSet<Vertex> visited)
        {
            foreach (Edge connection in ReverseConnections)
            {
                if (visited.Contains(connection.Next)) continue;
                visited.Add(connection.Next);

                if (connection.Next.Equals(b)) return true;
                if (connection.Next.IsConnectedFrom(b, visited)) return true;
            }

            visited.Add(this);

            return false;
        }

        public override bool Equals(object obj)
        {
            var vertex = obj as Vertex;
            return vertex != null &&
                   Name == vertex.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
    }
}
