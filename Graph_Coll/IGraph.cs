using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Coll
{
    public interface IGraph
    {
        Vertex getVertex(string name);//
        List<Vertex> getVertexes();//

        Vertex addVertex(string name);
        void delVertex(string name);
        
        Edge addEdge(Vertex from, Vertex to, int weight);
        void delEdge(Edge edge);

        void print();
    }
}
