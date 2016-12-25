namespace graph
{
	partial class Form1
	{
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBoxGraph = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonCreateGraph = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxNum = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonTreversal = new System.Windows.Forms.Button();
			this.buttonMinWay = new System.Windows.Forms.Button();
			this.buttonTree = new System.Windows.Forms.Button();
			this.buttonIn = new System.Windows.Forms.Button();
			this.buttonOut = new System.Windows.Forms.Button();
			this.textBoxOut = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxV = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.buttonNonOrient = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBoxGraph
			// 
			this.textBoxGraph.Location = new System.Drawing.Point(29, 43);
			this.textBoxGraph.Multiline = true;
			this.textBoxGraph.Name = "textBoxGraph";
			this.textBoxGraph.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxGraph.Size = new System.Drawing.Size(535, 220);
			this.textBoxGraph.TabIndex = 0;
			this.textBoxGraph.TextChanged += new System.EventHandler(this.textBoxGraph_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.label1.Location = new System.Drawing.Point(25, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(265, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "Cписок смежности вершин графа";
			// 
			// buttonCreateGraph
			// 
			this.buttonCreateGraph.Enabled = false;
			this.buttonCreateGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.buttonCreateGraph.Location = new System.Drawing.Point(29, 307);
			this.buttonCreateGraph.Name = "buttonCreateGraph";
			this.buttonCreateGraph.Size = new System.Drawing.Size(639, 40);
			this.buttonCreateGraph.TabIndex = 2;
			this.buttonCreateGraph.Text = "Создать граф";
			this.buttonCreateGraph.UseVisualStyleBackColor = true;
			this.buttonCreateGraph.Click += new System.EventHandler(this.buttonCreateGraph_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.label2.Location = new System.Drawing.Point(25, 284);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(418, 20);
			this.label2.TabIndex = 3;
			this.label2.Text = "Или задайте случайный граф с количеством вершин ";
			// 
			// textBoxNum
			// 
			this.textBoxNum.Location = new System.Drawing.Point(449, 286);
			this.textBoxNum.Name = "textBoxNum";
			this.textBoxNum.Size = new System.Drawing.Size(49, 20);
			this.textBoxNum.TabIndex = 4;
			this.textBoxNum.TextChanged += new System.EventHandler(this.textBoxNum_TextChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.label3.Location = new System.Drawing.Point(245, 381);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(167, 24);
			this.label3.TabIndex = 5;
			this.label3.Text = "Работа с графом:";
			// 
			// buttonTreversal
			// 
			this.buttonTreversal.Enabled = false;
			this.buttonTreversal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.buttonTreversal.Location = new System.Drawing.Point(29, 431);
			this.buttonTreversal.Name = "buttonTreversal";
			this.buttonTreversal.Size = new System.Drawing.Size(639, 40);
			this.buttonTreversal.TabIndex = 6;
			this.buttonTreversal.Text = "Осуществить обход графа";
			this.buttonTreversal.UseVisualStyleBackColor = true;
			this.buttonTreversal.Click += new System.EventHandler(this.buttonTreversal_Click);
			// 
			// buttonMinWay
			// 
			this.buttonMinWay.Enabled = false;
			this.buttonMinWay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.buttonMinWay.Location = new System.Drawing.Point(29, 518);
			this.buttonMinWay.Name = "buttonMinWay";
			this.buttonMinWay.Size = new System.Drawing.Size(469, 40);
			this.buttonMinWay.TabIndex = 7;
			this.buttonMinWay.Text = "Найти кратчайший путь";
			this.buttonMinWay.UseVisualStyleBackColor = true;
			this.buttonMinWay.Click += new System.EventHandler(this.buttonMinWay_Click);
			// 
			// buttonTree
			// 
			this.buttonTree.Enabled = false;
			this.buttonTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.buttonTree.Location = new System.Drawing.Point(29, 611);
			this.buttonTree.Name = "buttonTree";
			this.buttonTree.Size = new System.Drawing.Size(639, 40);
			this.buttonTree.TabIndex = 8;
			this.buttonTree.Text = "Найти остовное дерево";
			this.buttonTree.UseVisualStyleBackColor = true;
			// 
			// buttonIn
			// 
			this.buttonIn.Location = new System.Drawing.Point(570, 42);
			this.buttonIn.Name = "buttonIn";
			this.buttonIn.Size = new System.Drawing.Size(98, 91);
			this.buttonIn.TabIndex = 9;
			this.buttonIn.Text = "Использовать";
			this.buttonIn.UseVisualStyleBackColor = true;
			this.buttonIn.Click += new System.EventHandler(this.buttonIn_Click);
			// 
			// buttonOut
			// 
			this.buttonOut.Location = new System.Drawing.Point(570, 172);
			this.buttonOut.Name = "buttonOut";
			this.buttonOut.Size = new System.Drawing.Size(98, 91);
			this.buttonOut.TabIndex = 10;
			this.buttonOut.Text = "Вывести";
			this.buttonOut.UseVisualStyleBackColor = true;
			this.buttonOut.Click += new System.EventHandler(this.buttonOut_Click);
			// 
			// textBoxOut
			// 
			this.textBoxOut.Location = new System.Drawing.Point(692, 43);
			this.textBoxOut.Multiline = true;
			this.textBoxOut.Name = "textBoxOut";
			this.textBoxOut.Size = new System.Drawing.Size(456, 607);
			this.textBoxOut.TabIndex = 11;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.label4.Location = new System.Drawing.Point(688, 20);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(89, 20);
			this.label4.TabIndex = 12;
			this.label4.Text = "Результат";
			// 
			// textBoxV
			// 
			this.textBoxV.Location = new System.Drawing.Point(527, 538);
			this.textBoxV.Name = "textBoxV";
			this.textBoxV.Size = new System.Drawing.Size(100, 20);
			this.textBoxV.TabIndex = 13;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.label5.Location = new System.Drawing.Point(524, 518);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(103, 20);
			this.label5.TabIndex = 14;
			this.label5.Text = "От вершины";
			// 
			// buttonNonOrient
			// 
			this.buttonNonOrient.Location = new System.Drawing.Point(504, 277);
			this.buttonNonOrient.Name = "buttonNonOrient";
			this.buttonNonOrient.Size = new System.Drawing.Size(164, 27);
			this.buttonNonOrient.TabIndex = 15;
			this.buttonNonOrient.Text = "сделать неориентированным";
			this.buttonNonOrient.UseVisualStyleBackColor = true;
			this.buttonNonOrient.Click += new System.EventHandler(this.buttonNonOrient_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1187, 686);
			this.Controls.Add(this.buttonNonOrient);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBoxV);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBoxOut);
			this.Controls.Add(this.buttonOut);
			this.Controls.Add(this.buttonIn);
			this.Controls.Add(this.buttonTree);
			this.Controls.Add(this.buttonMinWay);
			this.Controls.Add(this.buttonTreversal);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBoxNum);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.buttonCreateGraph);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxGraph);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxGraph;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonCreateGraph;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxNum;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button buttonTreversal;
		private System.Windows.Forms.Button buttonMinWay;
		private System.Windows.Forms.Button buttonTree;
		private System.Windows.Forms.Button buttonIn;
		private System.Windows.Forms.Button buttonOut;
		private System.Windows.Forms.TextBox textBoxOut;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBoxV;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button buttonNonOrient;
	}
}

