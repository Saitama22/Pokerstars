using System.Drawing;

namespace poker.exe._2._0
{
    partial class Form1
    {
        const int numbEn=4;
        const int numbAll =5;
        const int numbMy = 2;        
        protected const string patch = "data\\";
        protected const string endpat = ".png";
        const int sizeButX = 170;
        const int sizeButY = 48;
        const int sizePicX = 100;
        const int sizePicY = 145;

        const int locButsX = 720;
        const int locButsY = 440;

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
            this.components = new System.ComponentModel.Container();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(patch + "KJ.ico");
            for (int i = 0; i < numbEn; i++)
            {
                this.bank[i] = new System.Windows.Forms.Label();
                this.groupBox[i] = new System.Windows.Forms.GroupBox();
                this.groupBox[i].SuspendLayout();
                this.massege[i] = new System.Windows.Forms.Label();
            }            
            for (int i = 0; i < numbAll; i++)
            {
                this.all[i] = new System.Windows.Forms.PictureBox();
            }
            for (int i = 0; i < numbEn * 2; i++)
            {
                this.en[i] = new System.Windows.Forms.PictureBox();
            }
            ((System.ComponentModel.ISupportInitialize)(this.my2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.my1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();

            for (int i = 0; i < numbAll; i++)
            {
                ((System.ComponentModel.ISupportInitialize)(this.all[i])).BeginInit();
            }
            for (int i = 0; i < numbEn * 2; i++)
            {
                ((System.ComponentModel.ISupportInitialize)(this.en[i])).BeginInit();
            }

            this.SuspendLayout();
            // my2
            {
                my2.Image = Image.FromFile(patch + "rub" + endpat);
                this.my2.Location = new System.Drawing.Point(1005, 443);
                this.my2.Size = new System.Drawing.Size(sizePicX, sizePicY);
                this.my2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                this.my2.TabStop = false;
            }
            // my1
            {
                my1.Image = Image.FromFile(patch + "rub" + endpat);
                this.my1.Location = new System.Drawing.Point(899, 443);
                this.my1.Size = new System.Drawing.Size(sizePicX, sizePicY);
                this.my1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                this.my1.TabStop = false;
            }
            //mybank
            {
                this.mybank.BackColor = System.Drawing.Color.DarkGreen;
                this.mybank.Location = new System.Drawing.Point(895, 415);
                this.mybank.Size = new System.Drawing.Size(300, 30);
                this.mybank.Font = new System.Drawing.Font("Segoe UI", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                this.mybank.Text = "Мой банк: ";
                this.mybank.Click += new System.EventHandler(this.mybank_Click);
            }
            // But_start
            {
                this.But_start.BackColor = System.Drawing.Color.ForestGreen;                             
                this.But_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.But_start.Location = new System.Drawing.Point(400, 200);
                this.But_start.Size = new System.Drawing.Size(255, 104);
                this.But_start.Text = "Начать";
                this.But_start.Click += new System.EventHandler(this.start_Click);
            }           
            // textBox1
            {
                this.textBox1.BackColor = System.Drawing.Color.Green;
                this.textBox1.Location = new System.Drawing.Point(18, 539);
                this.textBox1.Size = new System.Drawing.Size(323, 23);
            }            
            // call
            {
                this.call.BackColor = System.Drawing.Color.ForestGreen;
                this.call.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.call.Location = new System.Drawing.Point(locButsX, locButsY);                
                this.call.Size = new System.Drawing.Size(sizeButX, sizeButY); 
                this.call.Text = "Колл";
                this.call.Click += new System.EventHandler(this.call_Click);
            }
             // Pas
            {
                this.Pas.BackColor = System.Drawing.Color.ForestGreen;
                this.Pas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.Pas.Location = new System.Drawing.Point(call.Location.X, call.Location.Y+ sizeButY+2);
                this.Pas.Size = new System.Drawing.Size(sizeButX,sizeButY);
                this.Pas.Text = "Пас";
                this.Pas.Click += new System.EventHandler(this.pass_Click);
            }
            // but_lose
            {
                this.but_lose.BackColor = System.Drawing.Color.ForestGreen;
                this.but_lose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.but_lose.Location = new System.Drawing.Point(Pas.Location.X, Pas.Location.Y + sizeButY + 2);                
                this.but_lose.Size = new System.Drawing.Size(sizeButX, sizeButY);
                this.but_lose.Text = "Сдать";
                this.but_lose.Click += new System.EventHandler(this.lose_Click);
            }
            // But_rate
            {
                this.But_rate.BackColor = System.Drawing.Color.ForestGreen;
                this.But_rate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.But_rate.Location = new System.Drawing.Point(call.Location.X - sizeButX - 10, call.Location.Y);
                this.But_rate.Size = new System.Drawing.Size(sizeButX, sizeButY);
                this.But_rate.Text = "Ставка";
                this.But_rate.Click += new System.EventHandler(this.rate_Click);
            }
            //flop
            {
                this.flop.BackColor = System.Drawing.Color.ForestGreen;
                this.flop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.flop.Location = new System.Drawing.Point(But_rate.Location.X, But_rate.Location.Y + sizeButY + 2);
                this.flop.Size = new System.Drawing.Size(sizeButX/3, sizeButY);
                this.flop.Text = "Блайн";
                this.flop.Click += new System.EventHandler(this.flop_Click);
            }
            //doubflop
            {
                this.doubflop.BackColor = System.Drawing.Color.ForestGreen;
                this.doubflop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.doubflop.Location = new System.Drawing.Point(flop.Location.X +flop.Size.Width, flop.Location.Y);
                this.doubflop.Size = new System.Drawing.Size(sizeButX / 3, sizeButY);
                this.doubflop.Text = "BIG Блайнд";
                this.doubflop.Click += new System.EventHandler(this.doubflop_Click);
            }
            //max
            {
                this.maxim.BackColor = System.Drawing.Color.ForestGreen;
                this.maxim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.maxim.Location = new System.Drawing.Point(doubflop.Location.X + flop.Size.Width, flop.Location.Y);
                this.maxim.Size = new System.Drawing.Size(sizeButX / 3, sizeButY);
                this.maxim.Text = "Max";
                this.maxim.Click += new System.EventHandler(this.max_Click);
            }
            // trackBar1
            {
                this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                this.trackBar1.BackColor = System.Drawing.Color.DarkGreen;
                this.trackBar1.Location = new System.Drawing.Point(flop.Location.X-5, flop.Location.Y+sizeButY+2);
                this.trackBar1.Size = new System.Drawing.Size(180, 1);
                //this.trackBar1.
                this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
                this.trackBar1.Maximum = 100;
            }
            // myRateBox
            {
                this.myRateBox.BackColor = System.Drawing.Color.Green;
                this.myRateBox.Location = new System.Drawing.Point(flop.Location.X,flop.Location.Y+80);
                this.myRateBox.Size = new System.Drawing.Size(sizeButX, 23);
                this.myRateBox.TextChanged += new System.EventHandler(this.myRateBox_TextChanged);
            }
            //actualRate
            {
                this.actualRate.BackColor = System.Drawing.Color.DarkGreen;
                this.actualRate.Location = new System.Drawing.Point(10, 400);
                this.actualRate.Size = new System.Drawing.Size(300, 23);
                this.actualRate.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);               
                this.actualRate.Text = "Текущая ставка: 0";
            }
            // total
            {
                this.total.BackColor = System.Drawing.Color.DarkGreen;
                this.total.Location = new System.Drawing.Point(actualRate.Location.X, actualRate.Location.Y+20);
                this.total.Size = new System.Drawing.Size(300, 23);
                this.total.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                this.total.Text = "Всего на кону: 0";
            }
            // help
            {
                this.help.BackColor = System.Drawing.Color.DarkGreen;
                this.help.Size = new System.Drawing.Size(300, 23);                
                this.help.Visible = false;
            }
            // bank & groupbox & massage
            for (int i = 0; i < numbEn; i++)
            {
                this.bank[i].BackColor = System.Drawing.Color.DarkGreen;
                this.bank[i].Location = new System.Drawing.Point(5, 170);
                this.bank[i].Size = new System.Drawing.Size(200, 30);
                this.bank[i].Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                this.bank[i].Text = "Банк: ";
                //gr                
                this.groupBox[i].Controls.Add(this.bank[i]);
                this.groupBox[i].Location = new System.Drawing.Point(10+(250) * i, 12);
                this.groupBox[i].Size = new System.Drawing.Size(210, 210);
                this.groupBox[i].TabStop = false;
                //mas
                this.massege[i].BackColor = System.Drawing.Color.DarkGreen;
                this.massege[i].Location = new System.Drawing.Point(540, 250 + i * 23);
                this.massege[i].Size = new System.Drawing.Size(500, 23);
                this.massege[i].Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            }
            //all
            for (int i = 0; i < numbAll; i++)
            {
                this.all[i].Location = new System.Drawing.Point(10 + (5+sizePicX) * i, 250);
                this.all[i].Size = new System.Drawing.Size(sizePicX, sizePicY);
                this.all[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                this.all[i].TabStop = false;
            }
            //en
            for (int i = 0; i < numbEn * 2; i++)
            {
                this.groupBox[i / 2].Controls.Add(this.en[i]);
                this.groupBox[i / 2].Controls.Add(this.en[i]);
                int XLoc;
                if (i % 2 == 0)
                    XLoc = 5;
                else
                    XLoc = 105;
                this.en[i].Location = new System.Drawing.Point(XLoc, 22);
                this.en[i].Size = new System.Drawing.Size(sizePicX, sizePicY);
                this.en[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                this.en[i].TabStop = false;
            }
            //error
            {
                this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            }
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1123, 600);
            this.Text = "Poker";
            this.Controls.Add(this.But_start);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.my2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.my1)).EndInit();
            for (int i = 0; i < numbAll; i++)
            {
                ((System.ComponentModel.ISupportInitialize)(this.all[i])).EndInit();
            }
            for (int i = 0; i < numbEn * 2; i++)
            {
                ((System.ComponentModel.ISupportInitialize)(this.en[i])).EndInit();
            }
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();          
        }

        #endregion
        private System.Windows.Forms.PictureBox my2 = new System.Windows.Forms.PictureBox();
        private System.Windows.Forms.PictureBox my1 = new System.Windows.Forms.PictureBox();
        private System.Windows.Forms.Button But_start = new System.Windows.Forms.Button();
        private System.Windows.Forms.Button Pas = new System.Windows.Forms.Button();
        private System.Windows.Forms.Label textBox1 = new System.Windows.Forms.Label();
        private System.Windows.Forms.Button But_rate = new System.Windows.Forms.Button();
        private System.Windows.Forms.Button but_lose = new System.Windows.Forms.Button();
        private System.Windows.Forms.TrackBar trackBar1 = new System.Windows.Forms.TrackBar();
        private System.Windows.Forms.TextBox myRateBox = new System.Windows.Forms.TextBox();

        private System.Windows.Forms.Label[] bank= new System.Windows.Forms.Label[numbEn];
        private System.Windows.Forms.PictureBox[] all= new System.Windows.Forms.PictureBox[numbAll];
        private System.Windows.Forms.PictureBox[] en = new System.Windows.Forms.PictureBox[2*numbEn];
        private System.Windows.Forms.PictureBox[] my = new System.Windows.Forms.PictureBox[numbMy];
        private System.Windows.Forms.GroupBox[] groupBox = new System.Windows.Forms.GroupBox[numbEn];
        private System.Windows.Forms.Label mybank = new System.Windows.Forms.Label();
        private System.Windows.Forms.Label total = new System.Windows.Forms.Label();
        private System.Windows.Forms.Label actualRate = new System.Windows.Forms.Label();
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button call = new System.Windows.Forms.Button();
        private System.Windows.Forms.Button flop = new System.Windows.Forms.Button();
        private System.Windows.Forms.Button doubflop = new System.Windows.Forms.Button();
        private System.Windows.Forms.Button maxim = new System.Windows.Forms.Button();
        private System.Windows.Forms.Label[] massege = new System.Windows.Forms.Label[numbEn];
        private System.Windows.Forms.Label help = new System.Windows.Forms.Label();
    }
}