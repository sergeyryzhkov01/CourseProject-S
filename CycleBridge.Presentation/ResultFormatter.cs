using System.Collections.Generic;
using System.Text;
using CycleBridge.Core;

namespace CycleBridge.Presentation
{
    public class ResultFormatter
    {
        public List<ResultItem> Format(AnalysisResult result)
        {
            List<ResultItem> items = new List<ResultItem>();

            items.Add(new ResultItem("Циклы (фундаментальные): " + result.Cycles.Count, null, null));

            foreach (List<int> cycle in result.Cycles)
            {
                items.Add(new ResultItem("   " + CycleToText(cycle), cycle, null));
            }

            items.Add(new ResultItem("Мосты: " + result.Bridges.Count, null, null));

            foreach (Edge bridge in result.Bridges)
            {
                items.Add(new ResultItem("   {" + bridge.From + ", " + bridge.To + "}", null, bridge));
            }

            return items;
        }

        private string CycleToText(List<int> cycle)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < cycle.Count; i++)
            {
                sb.Append(cycle[i]);
                sb.Append(" → ");
            }

            sb.Append(cycle[0]);
            return sb.ToString();
        }
    }
}
