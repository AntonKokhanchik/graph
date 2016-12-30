using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graph
{
	public partial class Form1 : Form
	{
		private Dictionary<int, int>[] graph; 

		public Form1()
		{
			InitializeComponent();
		}

		private void textBoxNum_TextChanged(object sender, EventArgs e)
		{
			if (textBoxNum.TextLength > 0)
				buttonCreateGraph.Enabled = true;
			else
				buttonCreateGraph.Enabled = false;
		}

		private void textBoxGraph_TextChanged(object sender, EventArgs e)
		{
			buttonTreversal.Enabled = false;
			buttonTree.Enabled = false;
			buttonMinWay.Enabled = false;
		}

		private void buttonUse_Click(object sender, EventArgs e)
		{
			getGraph();

			buttonTreversal.Enabled = true;
			buttonTree.Enabled = true;
			buttonMinWay.Enabled = true;
		}

		private void buttonOut_Click(object sender, EventArgs e)
		{
			textBoxGraph.Clear();
			outGraph(textBoxGraph, graph);
		}

		private void buttonCreateGraph_Click(object sender, EventArgs e)
		{
			createGraph();
			outGraph(textBoxGraph, graph);
		}

		private void buttonNonOrient_Click(object sender, EventArgs e)
		{
			getGraph();
			nonOrientGraph();
			textBoxGraph.Clear();
			outGraph(textBoxGraph, graph);
		}

		private void buttonTreversal_Click(object sender, EventArgs e)
		{
			textBoxOut.Clear();
			outGraph(textBoxOut, traversalWidth(0));
		}

		private void buttonMinWay_Click(object sender, EventArgs e)
		{
			textBoxOut.Clear();
			int v;
			if (!Int32.TryParse(textBoxV.Text, out v))
				v = 0;
			minWay(v);
		}

		private void buttonTree_Click(object sender, EventArgs e)
		{
			textBoxOut.Clear();
			minTree();
		}

		/// <summary>
		/// принимает граф из входного текстбокса
		/// </summary>
		private void getGraph()
		{
			char[] strSep = { '\n', '\r' };
			char[] wordSep = { ' ' };
			char[] numSep = new char[] { ',', '(', ')' }; // разделители

			string[] graphStr = textBoxGraph.Text.Split(strSep, StringSplitOptions.RemoveEmptyEntries);
			graph = new Dictionary<int, int>[graphStr.Length];

			foreach (string row in graphStr)
			{
				int ind = 0;
				foreach (string word in row.Split(wordSep, StringSplitOptions.RemoveEmptyEntries))
				{
					if (!word.Contains("(") && word != "->")
					{
						ind = Int32.Parse(word);
						graph[ind] = new Dictionary<int, int>();
					}
					else if (word != "->")
					{
						string[] num = word.Split(numSep, StringSplitOptions.RemoveEmptyEntries);
						graph[ind].Add(Int32.Parse(num[0]), Int32.Parse(num[1]));
					}
				}
			}
		}

		/// <summary>
		/// выводит указанный граф в указанный текстбокс
		/// </summary>
		private void outGraph(TextBox box, Dictionary<int, int>[] g)
		{
			StringBuilder outStr = new StringBuilder("");

			for (int i = 0; i < g.Length; i++)
			{
				outStr.AppendFormat("{0} -> ", i);
				if (g[i] != null && g[i].Count != 0)
				{
					foreach (var el in g[i])
						outStr.AppendFormat("({0},{1}) ", el.Key, el.Value);
					outStr.Remove(outStr.Length - 1, 1);
				}
				outStr.Append("\r\n");
			}

			box.Text = outStr.ToString(0, outStr.Length - 1);
		}

		/// <summary>
		/// создаёт случайный ориентированный граф без петель
		/// </summary>
		private void createGraph()
		{
			int num = Int32.Parse(textBoxNum.Text);
			graph = new Dictionary<int, int>[num];

			Random rand = new Random();
			for (int i = 0; i < num; i++)
			{
				graph[i] = new Dictionary<int, int>();
				int numberRibs = rand.Next(0, num - 1);

				for (int j = 0; j < numberRibs; )
					try
					{
						int rib = rand.Next(0, num - 1);
						if (rib != i)
						{
							graph[i].Add(rib, rand.Next(0, 10));
							j++;
						}
					}
					catch (ArgumentException) { }
			}
		}

		/// <summary>
		/// делает граф неориентированным
		/// </summary>
		private void nonOrientGraph()
		{
			for (int i = 0; i < graph.Length; i++)
			{
				foreach (var el in graph[i])
				{
					if (graph[el.Key].ContainsKey(i))
						graph[el.Key][i] = el.Value;
					else
						graph[el.Key].Add(i, el.Value);
				}
			}
		}

		/// <summary>
		/// производит обход графа по ширине из указанной вершины, возвращает подграф обхода
		/// </summary>
		private Dictionary<int, int>[] traversalWidth(int v)
		{
			bool[] isVisited = new bool[graph.Length];
			Dictionary<int, int>[] width = new Dictionary<int, int>[graph.Length];
			Queue<int> q = new Queue<int>();

			q.Enqueue(v);
			isVisited[v] = true;

			while (q.Count != 0)
			{
				int tmp = q.Dequeue();
				width[tmp] = new Dictionary<int, int>();
				foreach (var el in graph[tmp])
					if (!isVisited[el.Key])
					{
						q.Enqueue(el.Key);
						isVisited[el.Key] = true;
						width[tmp].Add(el.Key, el.Value);
					}
			}
			return width;
		}

		/// <summary>
		/// находит кртчайшие пути из указанной вершины, используя алгоритм Дейкстры
		/// </summary>
		private void minWay(int v)
		{
			int[] way = new int[graph.Length];
			bool[] isVisited = new bool[graph.Length];
			int[] distance = new int[graph.Length];

			for (int j = 0; j < graph.Length; j++)
			{
				int val;
				if (graph[v].TryGetValue(j, out val))
				{
					distance[j] = val;
					way[j] = v;
				}
				else
				{
					distance[j] = -1;
					way[j] = -1;
				}
			}

			way[v] = -2;
			isVisited[v] = true;
			distance[v] = -2;

			int tmp = indexOfMin(distance, isVisited);
			for (int i = 1; i < graph.Length; i++)
			{
				isVisited[tmp] = true;
				for (int j = 0; j < graph.Length; j++)
				{
					int val;
					if (graph[tmp].TryGetValue(j, out val))
						if (distance[j] == -1 || val + distance[tmp] < distance[j])
						{
							distance[j] = val + distance[tmp];
							way[j] = tmp;
						}
				}
				tmp = indexOfMin(distance, isVisited);
				if (tmp == -1)
					break;
			}
			outMinWay(distance, way, v);
		}

		/// <summary>
		/// высчитывает индекс очередного минимального пути
		/// </summary>
		private int indexOfMin(int[] a, bool[] isVisited)
		{
			int min = -1;
			for (int i = 0; i < a.Length; i++)
				if (a[i] != -1 && a[i] != -2 && !isVisited[i])
					if (min == -1)
						min = i;
					else if(a[i] < a[min])
						min = i;
			return min;
		}

		/// <summary>
		/// выводит данные о кратчайших путях
		/// </summary>
		private void outMinWay(int[] d, int[] w, int v)
		{
			textBoxOut.AppendText("Пути:\n");
			for (int i = 0; i < w.Length; i++)
				if (w[i] != -1 && w[i] != -2)
				{
					textBoxOut.AppendText(i + " <- ");
					int tmp = w[i];
					while (tmp != v)
					{
						textBoxOut.AppendText(tmp + " <- ");
						tmp = w[tmp];
					}
					textBoxOut.AppendText(v + "\n");
				}
				else if (w[i] == -1)
					textBoxOut.AppendText("нет пути в вершину " + i + "\n");
				else if (w[i] == -2)
					textBoxOut.AppendText("начинаем с вершины " + i + "\n");

			textBoxOut.AppendText("\r\nкратчайший путь от вершины " + v + ":\n");
			for (int i = 0; i < d.Length; i++)
				if (d[i] != -1 && d[i] != -2)
					textBoxOut.AppendText("в вершину " + i + ":" + d[i] + "\n");
				else if (w[i] == -1)
					textBoxOut.AppendText("в вершину " + i + ": нет пути\n");
		}

		/// <summary>
		/// находит остовное дерево минимального веса, используя алгоритм Прима
		/// </summary>
		private void minTree()
		{
			List<int> connected = new List<int>();
			Dictionary<int, int>[] tree = new Dictionary<int, int>[graph.Length];
			for (int i = 0; i < tree.Length; i++)
				tree[i] = new Dictionary<int, int>();

			connected.Add(0);

			while (true)
			{
				int[] min = { -1, -1, -1 }; // откуда, куда, сколько - ребро
				foreach (int i in connected)
					foreach (var v in graph[i])
						if (!connected.Contains(v.Key))
							if (min[2] == -1 || v.Value < min[2])
							{
								min[0] = i;
								min[1] = v.Key;
								min[2] = v.Value;
							}

				if (min[2] == -1)
					break;      // нет больше подходящих рёбер

				connected.Add(min[1]);
				tree[min[0]].Add(min[1], min[2]);
			}
			outGraph(textBoxOut, tree);
			int weight = 0;
			for (int i = 0; i < tree.Length; i++)
				foreach (var v in tree[i])
					weight += v.Value;
			textBoxOut.AppendText("\nВес дерева: " + weight.ToString());
		}
	}
}
