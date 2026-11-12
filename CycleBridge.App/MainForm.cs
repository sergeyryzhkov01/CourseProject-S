using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CycleBridge.Algorithms;
using CycleBridge.Core;
using CycleBridge.Presentation;

namespace CycleBridge.App
{
    public partial class MainForm : Form
    {
        private Graph graph = new Graph(8);
        private DfsAnalyzer analyzer = new DfsAnalyzer();
        private ResultFormatter formatter = new ResultFormatter();
        private int firstVertex = 0;

        public MainForm()
        {
            InitializeComponent();

            graphPanel.Model = graph;
            graphPanel.VertexClicked += graphPanel_VertexClicked;

            Analyze();
        }

        private void Analyze()
        {
            AnalysisResult result = analyzer.Analyze(graph);
            List<ResultItem> items = formatter.Format(result);

            graphPanel.Bridges = result.Bridges;
            graphPanel.HighlightCycle = null;
            graphPanel.HighlightBridge = null;

            lstResult.BeginUpdate();
            lstResult.Items.Clear();

            foreach (ResultItem item in items)
            {
                lstResult.Items.Add(item);
            }

            lstResult.EndUpdate();
        }

        private void graphPanel_VertexClicked(int v)
        {
            if (firstVertex == 0)
            {
                firstVertex = v;
            }
            else if (firstVertex == v)
            {
                firstVertex = 0;
            }
            else
            {
                graph.ToggleEdge(firstVertex, v);
                firstVertex = 0;
                Analyze();
            }

            graphPanel.SelectedVertex = firstVertex;
        }

        private void nudN_ValueChanged(object sender, EventArgs e)
        {
            graph.Resize((int)nudN.Value);
            firstVertex = 0;
            graphPanel.SelectedVertex = 0;
            Analyze();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            graph.Clear();
            firstVertex = 0;
            graphPanel.SelectedVertex = 0;
            Analyze();
        }

        private void btnExample_Click(object sender, EventArgs e)
        {
            nudN.Value = 8;
            graph.Clear();

            int[,] edges = { { 1, 2 }, { 2, 3 }, { 1, 3 }, { 3, 4 }, { 4, 5 }, { 5, 6 }, { 4, 6 }, { 6, 7 } };

            for (int i = 0; i < edges.GetLength(0); i++)
            {
                graph.ToggleEdge(edges[i, 0], edges[i, 1]);
            }

            firstVertex = 0;
            graphPanel.SelectedVertex = 0;
            Analyze();
        }

        private void lstResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResultItem item = lstResult.SelectedItem as ResultItem;

            if (item == null)
            {
                graphPanel.HighlightCycle = null;
                graphPanel.HighlightBridge = null;
            }
            else
            {
                graphPanel.HighlightCycle = item.Cycle;
                graphPanel.HighlightBridge = item.Bridge;
            }
        }
    }
}
