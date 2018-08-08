using System;
using System.Collections.Generic;
using System.Text;

namespace GraphResearch.Graphs
{
    public enum EdgeType
    {
        IS,
        IS_A,
        CAN_BE,
        CAN_HAVE,
        HELPS_WITH,
        REQUIRES,
        CONTAINS,
        UNDEFINED
    }

    /// <summary>
    /// Represents a connection from one Vertex to another.
    /// </summary>
    public class Edge
    {
        public Vertex Next
        {
            get;
        }

        public EdgeType Type
        {
            get;
        }

        public Edge(Vertex next, EdgeType type)
        {
            this.Next = next;
            this.Type = type;
        }

        public override bool Equals(object obj)
        {
            var edge = obj as Edge;
            return edge != null &&
                   EqualityComparer<Vertex>.Default.Equals(Next, edge.Next) &&
                   Type == edge.Type;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Next, Type);
        }
    }
}
