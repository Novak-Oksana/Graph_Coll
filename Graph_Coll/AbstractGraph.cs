using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Coll
{
    public abstract class AbstractGraph : IGraph
    {

        public abstract Vertex getVertex(string name);
        public abstract List<Vertex> getVertexes();
        public abstract Vertex addVertex(string name);
        public abstract void delVertex(string name);
        public abstract Edge addEdge(Vertex from, Vertex to, int weight);
        public abstract void delEdge(Edge edge);

        private void printPadding(int size)
        {
            for (int i = 0; i < size; i++)
                System.Console.Write(" ");
        }

        public void print()
        {
            foreach (Vertex vertex in getVertexes())
            {
                List<String> inPrint = new List<String>();
                List<String> outPrint = new List<String>();

                int maxLength = 0;
                foreach (Edge edge in vertex.getInEdges())
                {
                    string instr = "[" + edge.getFrom().getName() + "] --(" + edge.getWeight() + ")-->";
                    inPrint.Add(instr);
                    if (maxLength < instr.Length)
                        maxLength = instr.Length;
                }

                foreach (Edge edge in vertex.getOutEdges())
                    outPrint.Add("--(" + edge.getWeight() + ")--> [" + edge.getTo().getName() + "]");

                for (int i = 0; i <= Math.Max(inPrint.Count(), outPrint.Count()); i++)
                {
                    if (i < inPrint.Count())
                        System.Console.Write(inPrint[i]);
                    else
                        printPadding(maxLength);

                    if (0 == i)
                        System.Console.Write(" [" + vertex.getName() + "] ");
                    else
                        printPadding(vertex.getName().Length + 4);

                    if (i < outPrint.Count())
                        System.Console.Write(outPrint[i]);

                    System.Console.WriteLine();
                }
                
            }
           
        }
        

    }
}
