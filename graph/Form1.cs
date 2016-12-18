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
		private List<int>[] arr; 

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
		private void buttonCreateGraph_Click(object sender, EventArgs e)
		{
			int num = Int32.Parse(textBoxNum.Text);
			arr = new List<int>[num];

			Random rand = new Random();
			for(int i = 0; i < num; i++)
			{
				arr[i] = new List<int>();
				int tmp = rand.Next(0, num);

				for (int j = 0; j < tmp; j++)
					arr[i].Add(rand.Next(0, num - 1));
			}
		}

		private void buttonTreversal_Click(object sender, EventArgs e)
		{
			bool[] isVisited = new bool[arr.Length];
			List<int>[] width = new List<int>[arr.Length];
			Queue<int> q = new Queue<int>();
			
			q.Enqueue(0);
			isVisited[0] = true;

			while(q.Count != 0)
			{
				int tmp = q.Peek();
				//width[tmp]
			}
		}



	}
}
