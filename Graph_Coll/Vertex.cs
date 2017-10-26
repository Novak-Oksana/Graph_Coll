using System;
using System.Collections.Generic;

namespace Graph_Coll
{
    public class Vertex
    {
        private string name;
        private List<Edge> outEdges;
        private List<Edge> inEdges;

        internal Vertex(string name)
        {
            this.name = name;
            this.outEdges = new List<Edge>();
            this.inEdges = new List<Edge>();
        }

        internal void setOutEdges(List<Edge> outEdges)
        {
            this.outEdges = outEdges;
        }

        internal void setInEdges(List<Edge> inEdges)
        {
            this.inEdges = inEdges;
        }

        public string getName()
        {
            return name;
        }

        public List<Edge> getOutEdges()
        {
            return new List<Edge>(outEdges);
        }

        public List<Edge> getInEdges()
        {
            return new List<Edge>(inEdges);
        }

        public override bool Equals(object obj)
        {
            var vertex = obj as Vertex;
            return vertex != null &&
                   name == vertex.name;
        }

        public override int GetHashCode()
        {
            return 363513814 + EqualityComparer<string>.Default.GetHashCode(name);
        }
    }
}