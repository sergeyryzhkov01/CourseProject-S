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
        private bool changingVertexCount = false;
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
            if (changingVertexCount)
            {
                return;
            }

            int newCount = (int)nudN.Value;

            if (newCount > 20 && graph.N <= 20)
            {
                DialogResult answer = MessageBox.Show(
                    "При большом количестве вершин изображение графа может " +
                    "стать неразборчивым, а программа может работать медленно " +
                    "или завершиться из-за нехватки памяти.\n\nПродолжить?",
                    "Предупреждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (answer == DialogResult.No)
                {
                    changingVertexCount = true;
                    nudN.Value = graph.N;
                    changingVertexCount = false;
                    return;
                }
            }

            try
            {
                graph.Resize(newCount);
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show(
                    "Недостаточно памяти для создания графа с таким количеством вершин.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                changingVertexCount = true;
                nudN.Value = graph.N;
                changingVertexCount = false;
                return;
            }

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

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
        "Программа предназначена для поиска фундаментальных циклов и мостов в неориентированном графе.\n\n" +
        "Количество вершин задаётся в поле «Число вершин».\n\n" +
        "Чтобы добавить ребро, последовательно щёлкните по двум вершинам. " +
        "Если ребро уже существует, оно будет удалено. " +
        "Повторный щелчок по выбранной вершине отменяет выбор.\n\n" +
        "Анализ выполняется автоматически после изменения графа. " +
        "Найденные циклы и мосты отображаются в списке слева.\n\n" +
        "Чтобы выделить цикл синим цветом, выберите его в списке. " +
        "Мосты отображаются красным цветом. Выбранный в списке мост " +
        "выделяется более толстой линией.\n\n" +
        "Кнопка «Очистить» удаляет все рёбра. " +
        "Кнопка «Пример» создаёт готовый граф.\n\n" +
        "При большом числе вершин изображение может стать неразборчивым, " +
        "а работа программы — замедлиться.",
        "О программе",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);
        }
    }
}
