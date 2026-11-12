using System;
using System.Collections.Generic;
using CycleBridge.Core;

namespace CycleBridge.Algorithms
{
    public class DfsAnalyzer
    {
        private Graph g;
        private bool[] visited;
        private bool[] onPath;
        private int[] parent;
        private int[] tin;
        private int[] low;
        private int timer;
        private AnalysisResult result;

        public AnalysisResult Analyze(Graph graph)
        {
            g = graph;
            int n = g.N;

            visited = new bool[n + 1];
            onPath = new bool[n + 1];
            parent = new int[n + 1];
            tin = new int[n + 1];
            low = new int[n + 1];
            timer = 1;
            result = new AnalysisResult();

            for (int v = 1; v <= n; v++)
            {
                if (!visited[v])
                {
                    Dfs(v);
                }
            }

            return result;
        }

        private void Dfs(int v)
        {
            visited[v] = true;
            onPath[v] = true;
            tin[v] = timer;
            low[v] = timer;
            timer++;

            for (int u = 1; u <= g.N; u++)
            {
                if (!g.HasEdge(v, u))
                {
                    continue;
                }

                if (u == parent[v])
                {
                    continue;
                }

                if (!visited[u])
                {
                    parent[u] = v;
                    Dfs(u);
                    low[v] = Math.Min(low[v], low[u]);

                    if (low[u] > tin[v])
                    {
                        result.Bridges.Add(new Edge(v, u));
                    }
                }
                else if (onPath[u])
                {
                    result.Cycles.Add(RestoreCycle(v, u));
                    low[v] = Math.Min(low[v], tin[u]);
                }
            }

            onPath[v] = false;
        }

        private List<int> RestoreCycle(int v, int u)
        {
            List<int> cycle = new List<int>();
            int x = v;

            while (x != u)
            {
                cycle.Add(x);
                x = parent[x];
            }

            cycle.Add(u);
            return cycle;
        }
    }
}