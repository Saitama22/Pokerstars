namespace poker.exe._2._0
{
    partial class saper
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {            
            this.SuspendLayout();
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon("data//" + "saper.ico");
            // 
            // button1
            // 
            this.startBut.Location = new System.Drawing.Point(130, 10);
            this.startBut.Size = new System.Drawing.Size(50, 50);
            this.startBut.TabIndex = 0;
            this.startBut.Click += new System.EventHandler(this.button1_Click);
            this.startBut.Image = System.Drawing.Image.FromFile("data//restart.png");
            //
            //
            this.flag.Location = new System.Drawing.Point(200, 10);
            this.flag.Size = new System.Drawing.Size(50, 50);
            this.flag.Click += new System.EventHandler(this.flag_Click);
            this.flag.Image = System.Drawing.Image.FromFile("data//mine.png");
            // 
            // label1
            // 
            this.numbbombs.AutoSize = true;
            this.numbbombs.Location = new System.Drawing.Point(0, 0);
            this.numbbombs.Size = new System.Drawing.Size(38, 15);
            this.numbbombs.TabIndex = 1;
            // 
            // label2
            // 
            this.infogame.AutoSize = true;
            this.infogame.Location = new System.Drawing.Point(0, 20);
            this.infogame.Size = new System.Drawing.Size(38, 15);
            this.infogame.TabIndex = 2;
            // 
            // button2
            // 
            int j = 0;
            for (int i = 0; i < mine.Length; i++)
            {
                if (i % 8 == 0)
                    j++;
                this.mine[i] = new System.Windows.Forms.Button();
                this.mine[i].Size = new System.Drawing.Size(40, 40);
                this.mine[i].Location = new System.Drawing.Point(mine[i].Size.Width *(((i)%8)), 30+ mine[i].Size.Height* j);
                //this.mine[i].Text = i.ToString();
                this.mine[i].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.mine[i].Click += new System.EventHandler(this.button2_Click);
                this.mine[i].TabIndex = i+1;
                this.mine[i].BackColor = System.Drawing.Color.Blue;
            }            
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 390);
            for (int i = 0; i < mine.Length; i++)
            {
                this.Controls.Add(this.mine[i]);
            }
            this.Controls.Add(this.infogame);
            this.Controls.Add(this.numbbombs);
            this.Controls.Add(this.startBut);
            this.Controls.Add(this.flag);
            this.Name = "Form1";
            this.Text = "Caпeр";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startBut=new System.Windows.Forms.Button();
        private System.Windows.Forms.Label infogame = new System.Windows.Forms.Label();
        private System.Windows.Forms.Label numbbombs= new System.Windows.Forms.Label();
        private System.Windows.Forms.Button[] mine = new System.Windows.Forms.Button[64];
        System.Windows.Forms.Button flag = new System.Windows.Forms.Button();
    }
}

