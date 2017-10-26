using System.Collections.Generic;

namespace Graph_Coll
{
    public class Edge
    {
        private int weight;
        private Vertex from;
        private Vertex to;

        internal Edge(Vertex from, Vertex to, int weight)
        {
            this.weight = weight;
            this.from = from;
            this.to = to;
        }

        public int getWeight()
        {
            return weight;
        }

        public Vertex getFrom()
        {
            return from;
        }

        public Vertex getTo()
        {
            return to;
        }

        public override bool Equals(object obj)
        {
            var edge = obj as Edge;
            return edge != null &&
                   weight == edge.weight &&
                   EqualityComparer<Vertex>.Default.Equals(from, edge.from) &&
                   EqualityComparer<Vertex>.Default.Equals(to, edge.to);
        }

        public override int GetHashCode()
        {
            var hashCode = 334813866;
            hashCode = hashCode * -1521134295 + weight.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Vertex>.Default.GetHashCode(from);
            hashCode = hashCode * -1521134295 + EqualityComparer<Vertex>.Default.GetHashCode(to);
            return hashCode;
        }
    }
}