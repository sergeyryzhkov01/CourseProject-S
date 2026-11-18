using System;

namespace CycleBridge.Core
{
    public class Graph
    {
        private int[,] a;

        public int N { get; private set; }

        public Graph(int n)
        {
            N = n;
            a = new int[n + 1, n + 1];
        }

        public bool HasEdge(int i, int j)
        {
            return a[i, j] == 1;
        }

        public void ToggleEdge(int i, int j)
        {
            if (i == j || i < 1 || j < 1 || i > N || j > N)
            {
                return;
            }

            int value = a[i, j] == 1 ? 0 : 1;
            a[i, j] = value;
            a[j, i] = value;
        }

        public void Clear()
        {
            a = new int[N + 1, N + 1];
        }

        public void Resize(int n)
        {
            int[,] b = new int[n + 1, n + 1];
            int m = Math.Min(n, N);

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    b[i, j] = a[i, j];
                }
            }

            a = b;
            N = n;
        }
    }
}