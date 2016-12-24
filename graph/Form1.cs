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

			way[v] = -2;
			isVisited[v] = true;
			distance[v] = -2;

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
			//TODO: дописать

			int tmp = indexOfMin(distance);
			for (int i = 1; i < graph.Length; i++)
			{
				isVisited[tmp] = true;
				for (int j = 0; j < graph.Length; j++)
				{
					int val;
					if (arr[tmp].TryGetValue(j, out val) && distance[tmp] != -1 && distance[tmp] != -2 && val + distance[tmp] < distance[j])
					{
						distance[j] = val + distance[tmp];
						way[j] = tmp;
					}
				}
			}
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

		private int indexOfMin(int[] a)
		{
			int min = 0;
			for(int i = 1; i < a.Length; i++)
				if (a[i] < a[min] && a[i] != -1 && a[i] != -2)
					min = i;
			return min;
		}
	}
}
