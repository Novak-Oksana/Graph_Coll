using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Coll
{
    class Program
    {
        static void Main(string[] args)
        {
        //    IGraph graph = new GraphLinked();
            IGraph graph = new GraphHybrid();
          //  IGraph graphM = new GraphMatrix();
            
            Vertex v1 = graph.addVertex("V1");
            Vertex v2 = graph.addVertex("V2");
            Vertex v3 = graph.addVertex("V3");
            Vertex v4 = graph.addVertex("V4");
            Vertex v5 = graph.addVertex("V5");
            Vertex v6 = graph.addVertex("V6");
            Vertex v7 = graph.addVertex("V7");

            graph.addEdge(v3, v1, 1);
            graph.addEdge(v1, v2, 2);
            graph.addEdge(v2, v3, 1);
            graph.addEdge(v2, v6, 7);
            graph.addEdge(v2, v7, 2);
            graph.addEdge(v7, v5, 4);
            graph.addEdge(v3, v5, 15);
            graph.addEdge(v4, v3, 3);
            graph.addEdge(v5, v4, 1);

            graph.print();

            List<Edge> route = fastestRoute(graph.getVertex("V1"), graph.getVertex("V4"), new List<Edge>());
            System.Console.WriteLine("Fastest path: " + weightOfRoute(route));
            foreach (Edge edge in route)
                System.Console.WriteLine(edge.getFrom().getName() + " --(" + edge.getWeight() + ")--> " + edge.getTo().getName());
            System.Console.ReadLine();
        }

        private static int weightOfRoute(List<Edge> route)
        {
            int weight = 0;
            foreach (Edge edge in route)
                weight += edge.getWeight();
            return weight;
        }

        private static List<Edge> fastestRoute(Vertex from, Vertex to, List<Edge> route)
        {
            List<List<Edge>> routes = new List<List<Edge>>();
            foreach (Edge edge in from.getOutEdges())
            {
                if (to.Equals(edge.getTo()))
                {
                    route.Add(edge);
                    return route;
                }
                if (!route.Contains(edge))
                {
                    List<Edge> newRoute = new List<Edge>(route);
                    newRoute.Add(edge);
                    routes.Add(fastestRoute(edge.getTo(), to, newRoute));
                }
            }
            if (routes.Count==0)
                return new List<Edge>();

            List<Edge> minRoute = new List<Edge>();
            int minWeight = Int32.MaxValue;
            foreach (List<Edge> currentRoute in routes)
            {
                int weightOfRoute2 = weightOfRoute(currentRoute);
                if (currentRoute.Count!=0 && weightOfRoute2 < minWeight)
                {
                    minWeight = weightOfRoute2;
                    minRoute = currentRoute;
                }
            }
            return minRoute;
        }
    }
}
