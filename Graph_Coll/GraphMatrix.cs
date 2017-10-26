using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Coll
{
    public class GraphMatrix : AbstractGraph
    {
        private String[] vertexes = new String[0];
        private int[,] weights = new int[0,0];

        public override Edge addEdge(Vertex from, Vertex to, int weight)
        {
            throw new NotImplementedException();
        }

        public override Vertex addVertex(string name)
        {
            throw new NotImplementedException();
        }

        public override void delEdge(Edge edge)
        {
            throw new NotImplementedException();
        }

        public override void delVertex(string name)
        {
            throw new NotImplementedException();
        }

        public override Vertex getVertex(string name)
        {
            throw new NotImplementedException();
        }

        public override List<Vertex> getVertexes()
        {
            throw new NotImplementedException();
        }
    }
}
