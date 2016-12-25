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

		private void buttonIn_Click(object sender, EventArgs e)
		{
			string[] graphStr = textBoxGraph.Text.Split('\n');
			char[] wordSep = new char[] { ' ', '\r' };
			char[] numSep = new char[] { ',', '(', ')' };
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

			buttonTreversal.Enabled = true;
			buttonTree.Enabled = true;
			buttonMinWay.Enabled = true;
		}

		private void buttonOut_Click(object sender, EventArgs e)
		{
			Out(textBoxGraph, graph);
		}

		private void buttonCreateGraph_Click(object sender, EventArgs e)
		{
			int num = Int32.Parse(textBoxNum.Text);
			graph = new Dictionary<int, int>[num];

			Random rand = new Random();
			for(int i = 0; i < num; i++)
			{
				graph[i] = new Dictionary<int, int>();
				int numberRibs = rand.Next(0, num-1);

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

		private void buttonTreversal_Click(object sender, EventArgs e)
		{
			textBoxOut.Clear();
			Out(textBoxOut, traversal(0));
		}

		private void buttonMinWay_Click(object sender, EventArgs e)
		{
			int v;
			if(!Int32.TryParse(textBoxV.Text, out v))
				v = 0;

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
					if (graph[tmp].TryGetValue(j, out val) /*&& distance[tmp] != -1 && distance[tmp] != -2*/)
						if(distance[j] == -1 || val + distance[tmp] < distance[j])
						{
							distance[j] = val + distance[tmp];
							way[j] = tmp;
						}
				}
				tmp = indexOfMin(distance, isVisited);
				if (tmp == -1)
					break;
			}

			textBoxOut.Clear();
			outMinWay(distance, way, v);
		}

		private void outMinWay(int[] d, int[] w, int v)
		{
			textBoxOut.AppendText("Пути (куда <- откуда):\n");
			for(int i=0; i<w.Length; i++)
				if(w[i] != -1 && w[i] != -2)
					textBoxOut.AppendText(i + " <- " + w[i] + "\n");
				else if (w[i] == -1)
					textBoxOut.AppendText("нет пути в вершину " + i + "\n");

			textBoxOut.AppendText("\n\nкратчайший путь от вершины " + v + ":\n");
			for (int i = 0; i < d.Length; i++)
				if (d[i] != -1 && d[i] != -2)
					textBoxOut.AppendText("в вершину " + i + ":" + d[i] + "\n");
				else if (w[i] == -1)
					textBoxOut.AppendText("в вершину " + i + ": нет пути\n");
		}

		private void Out(TextBox box, Dictionary<int, int>[] g)
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

		private Dictionary<int, int>[] traversal(int v)
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

		private void buttonNonOrient_Click(object sender, EventArgs e)
		{
			for(int i=0; i<graph.Length; i++)
			{
				foreach (var el in graph[i])
				{
					if (graph[el.Key].ContainsKey(i))
						graph[el.Key][i] = el.Value;
					else
						graph[el.Key].Add(i, el.Value);
				}
			}
			textBoxGraph.Clear();
			Out(textBoxGraph, graph);
		}
	}
}
