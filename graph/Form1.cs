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
		private Dictionary<int, int>[] arr; 

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
			string[] graph = textBoxGraph.Text.Split('\n');
			char[] wordSep = new char[] { ' ', '\r' };
			char[] numSep = new char[] { ',', '(', ')' };
			arr = new Dictionary<int, int>[graph.Length];

			foreach (string row in graph)
			{
				int ind = 0;
				foreach (string word in row.Split(wordSep, StringSplitOptions.RemoveEmptyEntries))
				{
					if (!word.Contains("(") && word != "->")
					{
						ind = Int32.Parse(word);
						arr[ind] = new Dictionary<int, int>();
					}
					else if (word != "->")
					{
						string[] num = word.Split(numSep, StringSplitOptions.RemoveEmptyEntries);
						arr[ind].Add(Int32.Parse(num[0]), Int32.Parse(num[1]));
					}
				}
			}

			buttonTreversal.Enabled = true;
			buttonTree.Enabled = true;
			buttonMinWay.Enabled = true;
		}

		private void buttonOut_Click(object sender, EventArgs e)
		{
			Out(textBoxGraph, ref arr);
		}

		private void buttonCreateGraph_Click(object sender, EventArgs e)
		{
			int num = Int32.Parse(textBoxNum.Text);
			arr = new Dictionary<int, int>[num];

			Random rand = new Random();
			for(int i = 0; i < num; i++)
			{
				arr[i] = new Dictionary<int, int>();
				int tmp = rand.Next(0, num);

				for (int j = 0; j < tmp; j++)
					try
					{
						arr[i].Add(rand.Next(0, num - 1), rand.Next(0, 10));
					}
					catch (ArgumentException) { j--; }
			}
		}

		private void buttonTreversal_Click(object sender, EventArgs e)
		{
			bool[] isVisited = new bool[arr.Length];
			Dictionary<int, int>[] width = new Dictionary<int, int>[arr.Length];
			Queue<int> q = new Queue<int>();
			
			q.Enqueue(0);
			isVisited[0] = true;

			while(q.Count != 0)
			{
				int tmp = q.Dequeue();
				width[tmp] = new Dictionary<int, int>();
				foreach (var el in arr[tmp])
					if(!isVisited[el.Key])
					{
						q.Enqueue(el.Key);
						isVisited[el.Key] = true;
						width[tmp].Add(el.Key, el.Value);
					}
			}

			textBoxOut.Clear();
			Out(textBoxOut, ref width);
		}

		private void Out(TextBox box, ref Dictionary<int, int>[] g)
		{
			StringBuilder graph = new StringBuilder("");

			for (int i = 0; i < g.Length; i++)
			{
				graph.AppendFormat("{0} -> ", i);
				if (g[i] != null && g[i].Count != 0)
				{
					foreach (var el in g[i])
						graph.AppendFormat("({0},{1}) ", el.Key, el.Value);
					graph.Remove(graph.Length - 1, 1);
				}
				graph.Append("\r\n");
			}

			box.Text = graph.ToString(0, graph.Length - 1);
		}

	}
}
