using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Coll
{
    public class GraphHybrid : AbstractGraph
    {
        private Vertex[] vertexes = new Vertex[0];//массив вершин

        public override Edge addEdge(Vertex from, Vertex to, int weight)
        {
            Edge edge = new Edge(from, to, weight);

            List<Edge> outEdges = from.getOutEdges();
            outEdges.Add(edge);
            from.setOutEdges(outEdges);

            List<Edge> inEdges = to.getInEdges();
            inEdges.Add(edge);
            to.setInEdges(inEdges);

            return edge;
        }

        public override Vertex addVertex(String name)
        {
            Vertex vertex = getVertex(name);
            if (vertex == null)
            {
                vertex = new Vertex(name);
                Vertex[] newMas = new Vertex[vertexes.Length + 1];
                for (int i = 0; i < vertexes.Length; i++)
                    newMas[i] = vertexes[i];

                vertexes = newMas;
                vertexes[vertexes.Length - 1] = vertex;
            }
            return vertex;
        }

        public override void delEdge(Edge edge)
        {
            List<Edge> outEdges = edge.getFrom().getOutEdges();
            outEdges.Remove(edge);
            edge.getFrom().setOutEdges(outEdges);

            List<Edge> inEdges = edge.getTo().getInEdges();
            inEdges.Remove(edge);
            edge.getFrom().setInEdges(outEdges);
        }

        public override void delVertex(String name)
        {
            Vertex vertex = getVertex(name);
            if (vertex != null)
            {
                foreach (Edge edge in vertex.getOutEdges())//удаление ребра у вершины, для которой оно есть входящим
                {
                    List<Edge> inEdges = edge.getTo().getInEdges();//список всех входящих рёбер в вершину to
                    inEdges.Remove(edge); //удаление из этого списка ребра
                    edge.getTo().setInEdges(inEdges);//в вершину to переписываем новый список рёбер без удалённого ребра
                }
                foreach (Edge edge in vertex.getInEdges())//удаление ребра у вершины, для которой оно есть исходящим
                {
                    List<Edge> outEdges = edge.getFrom().getOutEdges();//список всех исходящих рёбер из вершины from
                    outEdges.Remove(edge);//удаление из этого списка ребра
                    edge.getFrom().setOutEdges(outEdges);//в вершину from переписываем новый список рёбер без удалённого ребра
                }
                Vertex[] newMas = new Vertex[vertexes.Length - 1];//удаление вершины из массива
                for (int i = 0; i < vertexes.Length; i++)
                {
                    if (!vertexes[i].Equals(vertex))
                        newMas[i] = vertexes[i];
                }
                vertexes = newMas;
            }
        }

        public override Vertex getVertex(string name)
        {
            foreach (Vertex vertex in vertexes)
            {
                if (name.Equals(vertex.getName()))
                    return vertex;
            }
            return null;
        }

        public override List<Vertex> getVertexes()
        {
            return new List<Vertex>(vertexes);
        }
    }
}
