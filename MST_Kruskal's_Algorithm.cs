using System;
using System.Collections.Generic;
using System.Linq;

namespace MST_Kruskal_s_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating a List of Edges associated with their weights
            List<Edge> WeightedEdges = new List<Edge>() {
            new Edge {FirstVertex = 'A', SecondVertex =  'D', Weight = 6},
            new Edge {FirstVertex = 'A', SecondVertex =  'B', Weight = 5},
            new Edge {FirstVertex = 'A', SecondVertex =  'C', Weight = 4},
            new Edge {FirstVertex = 'E', SecondVertex =  'D', Weight = 1},
            new Edge {FirstVertex = 'D', SecondVertex =  'F', Weight = 2},
            new Edge {FirstVertex = 'D', SecondVertex =  'B', Weight = 2},
            new Edge {FirstVertex = 'C', SecondVertex =  'E', Weight = 3},
            new Edge {FirstVertex = 'A', SecondVertex =  'E', Weight = 2},
            new Edge {FirstVertex = 'B', SecondVertex =  'F', Weight = 3}
            };

            // Calling the Kruskal's Algorithm And printing the result (MST)

            int TotalCost = 0;

            Console.WriteLine("The Minimum Spaning Tree (MST): ");
            foreach (Edge edge in Kruskal_Algo(WeightedEdges, out TotalCost))
            {
                Console.WriteLine(edge.FirstVertex + "__" + edge.SecondVertex);
            }

            Console.WriteLine("The total cost is: {0}", TotalCost);

        }

        static List<Edge> Kruskal_Algo(List<Edge> edges, out int total_cost)
        {
            List<Edge> MST = new List<Edge>();
            HashSet<HashSet<char>> VerticesSets = new HashSet<HashSet<char>>();


            // 1.Make Sets
            HashSet<char> vertices = new HashSet<char>();
            foreach (Edge e in edges)
            {
                if (!vertices.Contains(e.FirstVertex))
                {
                    VerticesSets.Add(new HashSet<char> { e.FirstVertex });
                    vertices.Add(e.FirstVertex);
                }


                if (!vertices.Contains(e.SecondVertex))
                {
                    VerticesSets.Add(new HashSet<char> { e.SecondVertex });
                    vertices.Add(e.SecondVertex);
                }
            }

            // 2.Sort the edges by Weight in increasing order
            List<Edge> SortedEdges = edges.OrderBy(e => e.Weight).ToList();

            // 3. Compare sets and union
            total_cost = 0;
            HashSet<char> FirstSet;
            HashSet<char> SecondSet;

            foreach (Edge e in SortedEdges)
            {
                FirstSet = VerticesSets.First(v => v.Contains(e.FirstVertex));
                SecondSet = VerticesSets.First(v => v.Contains(e.SecondVertex));

                if (!FirstSet.SetEquals(SecondSet))
                {
                    MST.Add(e);
                    total_cost += e.Weight;
                    FirstSet.UnionWith(SecondSet);
                    VerticesSets.Remove(SecondSet);
                }
            }

            Console.WriteLine("Vertix Set: ");
            foreach (HashSet<char> cc in VerticesSets)
            {
                foreach (char c in cc)
                {
                    Console.Write(c + " ");
                }
            }

            Console.WriteLine();

            return MST;
        }



    }

    class Edge
    {
        public char FirstVertex { get; set; }
        public char SecondVertex { get; set; }

        public int Weight { get; set; }
    }
}
