using System.Collections.Generic;
using CycleBridge.Core;

namespace CycleBridge.Presentation
{
    public class ResultItem
    {
        public string Text { get; private set; }
        public List<int> Cycle { get; private set; }
        public Edge Bridge { get; private set; }

        public ResultItem(string text, List<int> cycle, Edge bridge)
        {
            Text = text;
            Cycle = cycle;
            Bridge = bridge;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
