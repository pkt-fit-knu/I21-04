using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdmondsKarp
{
    class Program
    {
    
            class Edge
            {
                public int s, t, rev, cap, f;

                public Edge(int s, int t, int rev, int cap)
                {
                    this.s = s;
                    this.t = t;
                    this.rev = rev;
                    this.cap = cap;
                }
            }

            static  List<Edge>[] createGraph(int nodes) {
            
                List<Edge>[] graph = new List<Edge>[nodes];            
                for (int i = 0; i < nodes; i++)
                   graph[i] = new List<Edge>();
            
                return graph;
         }

            static  void addEdge(List<Edge>[] graph, int s, int t, int cap)
            {
                graph[s].Add(new Edge(s, t, graph[t].Count(), cap));
                graph[t].Add(new Edge(t, s, graph[s].Count() - 1, 0));
            }

            static int maxFlow(List<Edge>[] graph, int s, int t) {
                    int flow = 0;
                    int[] q = new int[graph.Count()];
                    while (true) {
                      int qt = 0;
                      q[qt++] = s;
                      Edge[] pred = new Edge[graph.Count() ];
                      for (int qh = 0; qh < qt && pred[t] == null; qh++) {
                        int cur = q[qh];
          
                        foreach(Edge e in graph[cur]) {
                          if (pred[e.t] == null && e.cap > e.f) {
                            pred[e.t] = e;
                            q[qt++] = e.t;
                          }
                        }
                      }
                      if (pred[t] == null)
                        break;
                      int df = int.MaxValue;
                      for (int u = t; u != s; u = pred[u].s)
                        df = Math.Min(df, pred[u].cap - pred[u].f);
                      for (int u = t; u != s; u = pred[u].s) {
                        pred[u].f += df;
                        graph[pred[u].t].ElementAt(pred[u].rev).f -= df;
                      }
                      flow += df;
                    }
                    return flow;
  }

            // Usage example
            static void Main(string[] args)
            {
    
                List<Edge>[] graph = createGraph(4);
                addEdge(graph, 0, 1, 3);
                addEdge(graph, 0, 2, 2);
                addEdge(graph, 1, 2, 2);
                addEdge(graph, 2, 1, 3);
                Console.WriteLine("MaxFow = " + maxFlow(graph, 0, 2));


                Console.ReadLine();


  }
        }

    }

