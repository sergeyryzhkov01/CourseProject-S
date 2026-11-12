using System.Drawing;
using System.Drawing.Drawing2D;
using CycleBridge.Core;
using CycleBridge.Layout;

namespace CycleBridge.Rendering
{
    public class GraphRenderer
    {
        private CircularLayout layout = new CircularLayout();

        public void Draw(Graphics gr, Graph graph, HighlightState state, Size size)
        {
            gr.SmoothingMode = SmoothingMode.AntiAlias;
            DrawEdges(gr, graph, state, size);
            DrawVertices(gr, graph, state, size);
        }

        private void DrawEdges(Graphics gr, Graph graph, HighlightState state, Size size)
        {
            int n = graph.N;

            for (int i = 1; i <= n; i++)
            {
                for (int j = i + 1; j <= n; j++)
                {
                    if (!graph.HasEdge(i, j))
                    {
                        continue;
                    }

                    Color color = Color.Gray;
                    float width = 2f;

                    if (IsCycleEdge(state, i, j))
                    {
                        color = Color.RoyalBlue;
                        width = 4f;
                    }
                    else if (IsBridge(state, i, j))
                    {
                        color = Color.Red;
                        width = 3f;

                        if (state.Bridge != null && state.Bridge.Matches(i, j))
                        {
                            width = 5f;
                        }
                    }

                    using (Pen pen = new Pen(color, width))
                    {
                        gr.DrawLine(pen, layout.GetPoint(i, n, size), layout.GetPoint(j, n, size));
                    }
                }
            }
        }

        private void DrawVertices(Graphics gr, Graph graph, HighlightState state, Size size)
        {
            int n = graph.N;
            int r = CircularLayout.VertexRadius;

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            using (Font font = new Font("Times New Roman", 12f, FontStyle.Bold))
            using (Pen border = new Pen(Color.Black, 2f))
            {
                for (int i = 1; i <= n; i++)
                {
                    PointF p = layout.GetPoint(i, n, size);
                    RectangleF rect = new RectangleF(p.X - r, p.Y - r, 2 * r, 2 * r);

                    Color fill = Color.White;

                    if (state.Cycle != null && state.Cycle.Contains(i))
                    {
                        fill = Color.LightSkyBlue;
                    }

                    if (i == state.SelectedVertex)
                    {
                        fill = Color.Gold;
                    }

                    using (Brush brush = new SolidBrush(fill))
                    {
                        gr.FillEllipse(brush, rect);
                    }

                    gr.DrawEllipse(border, rect);
                    gr.DrawString(i.ToString(), font, Brushes.Black, rect, format);
                }
            }

            format.Dispose();
        }

        private bool IsBridge(HighlightState state, int i, int j)
        {
            foreach (Edge e in state.Bridges)
            {
                if (e.Matches(i, j))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsCycleEdge(HighlightState state, int i, int j)
        {
            if (state.Cycle == null)
            {
                return false;
            }

            int k = state.Cycle.Count;

            for (int t = 0; t < k; t++)
            {
                int p = state.Cycle[t];
                int q = state.Cycle[(t + 1) % k];

                if ((p == i && q == j) || (p == j && q == i))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
