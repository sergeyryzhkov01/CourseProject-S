using System;
using System.Drawing;

namespace CycleBridge.Layout
{
    public class CircularLayout
    {
        public const int VertexRadius = 18;
        private const int Margin = 15;

        public PointF GetPoint(int i, int n, Size size)
        {
            float cx = size.Width / 2f;
            float cy = size.Height / 2f;
            float radius = Math.Min(size.Width, size.Height) / 2f - VertexRadius - Margin;

            if (radius < 10)
            {
                radius = 10;
            }

            double angle = -Math.PI / 2 + 2 * Math.PI * (i - 1) / n;

            float x = cx + (float)(radius * Math.Cos(angle));
            float y = cy + (float)(radius * Math.Sin(angle));
            return new PointF(x, y);
        }

        public int HitTest(int x, int y, int n, Size size)
        {
            for (int i = 1; i <= n; i++)
            {
                PointF p = GetPoint(i, n, size);
                float dx = x - p.X;
                float dy = y - p.Y;

                if (dx * dx + dy * dy <= VertexRadius * VertexRadius)
                {
                    return i;
                }
            }

            return 0;
        }
    }
}