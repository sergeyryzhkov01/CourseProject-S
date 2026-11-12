using System;

namespace CycleBridge.Core
{
    public class Edge
    {
        public int From { get; private set; }
        public int To { get; private set; }

        public Edge(int x, int y)
        {
            From = Math.Min(x, y);
            To = Math.Max(x, y);
        }

        public bool Matches(int x, int y)
        {
            return (From == x && To == y) || (From == y && To == x);
        }
    }
}