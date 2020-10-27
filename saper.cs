using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace poker.exe._2._0
{
    public partial class saper : Form
    {
        static int numbBombs = 10;
        int[] bombs = new int[numbBombs];
        bool game = false;
        bool demines = false;
        public saper()
        {
            InitializeComponent();
            numbbombs.Text = numbBombs.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < mine.Length; i++)
            {
                mine[i].BackColor = Color.Blue;
                mine[i].Text = "";
            }
            game = false;
            numbBombs = 10;
            infogame.Text = "";
            numbbombs.Text = numbBombs.ToString();
        }
        private void flag_Click(object sender, EventArgs e)
        {
            if (demines == false)
            {
                flag.Image = Image.FromFile ("data//demine.png");
                demines = true;
            }
            else
            {
                demines = false;
                flag.Image = Image.FromFile("data//mine.png");
            }
        }
        void leftClick()
        {
            int actBut = detBut();
            if (mine[actBut].BackColor == Color.Blue)
            {
                mine[actBut].BackColor = Color.White;
                numbBombs--;
            }            
            else if (mine[actBut].BackColor == Color.White)
            {
                mine[actBut].BackColor = Color.Blue;
                numbBombs++;
            }
            numbbombs.Text = numbBombs.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (demines == false)
                mineClick();
            else
                leftClick();
            int demin=0;
            for (int i = 0; i < mine.Length; i++)
            {
                if (mine[i].BackColor == Color.Green)
                    demin++;
                else if (mine[i].BackColor == Color.Red)
                {
                    demin = 0;
                    infogame.Text = "Поражение";
                    break;
                }              
            }
            if (demin + bombs.Length == mine.Length)
                infogame.Text = "Победа";
            
        }
        void mineClick(int actBut = -1)
        {            
            if (actBut == -1)
                actBut = detBut();
            if (game == false)
            {
                start(actBut);
                game = true;
            }
            if (mine[actBut].BackColor == Color.White)
            {
                numbBombs++;
                mine[actBut].BackColor = Color.Blue;
                numbbombs.Text = numbBombs.ToString();
            }
            else
            {
                bool boom = detboom(actBut);
                if (boom != true)
                    detaround(actBut);
            }
        }
        void start(int actBut)
        {           
            Random rnd = new Random();
            for (int i = 0; i < bombs.Length; i++)
            {
                bombs[i] = rnd.Next(0, 64);
                for (int j = 0; j < i; j++)
                {
                    while (true)
                    {                        
                        if (bombs[i] != bombs[j]&& bombs[i]!=actBut)
                            break;
                        else
                            bombs[i] = rnd.Next(0, 64);
                    }

                }
            }

        }
        int detBut()
        {
            int actBut = 0;
            for (int i = 0; i < mine.Length; i++)
            {
                if (mine[i].Focused == true)
                    actBut = i;
            }
            return actBut;
        }
        bool detboom(int actBut)
        {
            bool boom = false;
            for (int i = 0; i < bombs.Length; i++)
            {
                if (bombs[i] == actBut)
                    for (int j = 0; j < bombs.Length; j++)
                    {
                        mine[bombs[j]].BackColor = Color.Red;
                        boom = true;
                    }
            }
            return boom;
        }               
        void detaround(int actBut)
        {
            int arounds = 0;
            int x = actBut % 8, y = actBut / 8;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (x + i <= 7 && x + i >= 0 && y + j <= 7 && y + j >= 0)
                        for (int z = 0; z < bombs.Length; z++)
                        {
                            if (bombs[z] == j * 8 + i+actBut)
                                arounds++;
                        }
                }
            }
            mine[actBut].BackColor = Color.Green;
            mine[actBut].Text = arounds.ToString();
            if (arounds == 0)
            {
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        if (x + i <= 7 && x + i >= 0 && y + j <= 7 && y + j >= 0)
                        {
                            if(mine[j * 8 + i + actBut].BackColor==Color.Blue) 
                                mineClick(j * 8 + i + actBut);
                        }
                    }
                }
            }
        }
        int ToInt(string str)
        {
            int tempInt = 0;
            char[] CharStr = new char[str.Length];
            CharStr = str.ToArray();
            for (int i = 0; i < str.Length; i++)
            {
                if (CharStr[i] - 48 > 9 || CharStr[i] - 48 < 0)
                    return -999;
                tempInt += CharStr[i] - 48;
                tempInt *= 10;
            }
            tempInt /= 10;
            return tempInt;
        }
    }
}
