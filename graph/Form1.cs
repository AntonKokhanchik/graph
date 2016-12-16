﻿using System;
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

		private void buttonCreateGraph_Click(object sender, EventArgs e)
		{
			int num = Int32.Parse(textBoxNum.Text);
			arr = new List<int>[num];

			Random rand = new Random();
			foreach(var el in arr)
				for(int i = 0; i < rand.Next(0, num); i++)
					el.Add(rand.Next(0, num-1));
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