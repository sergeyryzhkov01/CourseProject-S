using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CycleBridge.Core;
using CycleBridge.Layout;
using CycleBridge.Rendering;

namespace CycleBridge.Controls
{
    public class GraphPanel : Panel
    {
        private CircularLayout layout = new CircularLayout();
        private GraphRenderer renderer = new GraphRenderer();
        private HighlightState state = new HighlightState();

        public event Action<int> VertexClicked;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Graph Model { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Edge> Bridges
        {
            get { return state.Bridges; }
            set
            {
                state.Bridges = value;
                Invalidate();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<int> HighlightCycle
        {
            get { return state.Cycle; }
            set
            {
                state.Cycle = value;
                Invalidate();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Edge HighlightBridge
        {
            get { return state.Bridge; }
            set
            {
                state.Bridge = value;
                Invalidate();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedVertex
        {
            get { return state.SelectedVertex; }
            set
            {
                state.SelectedVertex = value;
                Invalidate();
            }
        }

        public GraphPanel()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
            BackColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (Model == null)
            {
                return;
            }

            renderer.Draw(e.Graphics, Model, state, ClientSize);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (Model == null || e.Button != MouseButtons.Left)
            {
                return;
            }

            int vertex = layout.HitTest(e.X, e.Y, Model.N, ClientSize);

            if (vertex > 0 && VertexClicked != null)
            {
                VertexClicked(vertex);
            }
        }
    }
}
