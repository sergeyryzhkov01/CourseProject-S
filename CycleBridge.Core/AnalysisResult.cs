using System.Collections.Generic;

namespace CycleBridge.Core
{
    public class AnalysisResult
    {
        public List<List<int>> Cycles { get; private set; }
        public List<Edge> Bridges { get; private set; }

        public AnalysisResult()
        {
            Cycles = new List<List<int>>();
            Bridges = new List<Edge>();
        }
    }
}