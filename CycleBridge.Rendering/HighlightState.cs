using System.Collections.Generic;
using CycleBridge.Core;

namespace CycleBridge.Rendering
{
    public class HighlightState
    {
        public List<Edge> Bridges { get; set; }
        public List<int> Cycle { get; set; }
        public Edge Bridge { get; set; }
        public int SelectedVertex { get; set; }

        public HighlightState()
        {
            Bridges = new List<Edge>();
            Cycle = null;
            Bridge = null;
            SelectedVertex = 0;
        }
    }
}
