using System;
using System.IO;
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
    public partial class Form1 : Form
    {
        int numbNames = 168;
        Player[] player = new Player[5];
        Game game = new Game();
        int motion;

        int cycl;
        public Form1()
        {
            InitializeComponent();
            game.getflop(50);
        }
        private void mybank_Click(object sender, EventArgs e)
        {
            if (player[0].sum==0)
            {
                saper sap = new saper();
                sap.Show();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void start_Click(object sender, EventArgs e)
        {
            Deck.detDeck();
            if (textBox1.Text == "")
            {
                Random rnd = new Random();
                int[] PlBank = new int[numbEn + 1];
                for (int i = 0; i < player.Length; i++)
                {
                    PlBank[i] = rnd.Next(1, 10) * 10000;
                   // PlBank[i] = 100000;
                    player[i] = new Player(PlBank[i]);
                }
                visible();
            }
            else
            {
                for (int i = 0; i < player.Length; i++)
                {
                    player[i] = new Player(player[i].sum, player[i].loser);
                }
                But_start.Visible = false;
                textBox1.Text = "";
            }
            my1.Image = Image.FromFile(allpatch(0, 0));
            my2.Image = Image.FromFile(allpatch(0, 1));
            for (int i = 0; i < numbAll; i++)
            {
                all[i].Image = Image.FromFile(patch + "rub" + endpat);
            }
            for (int i = 0; i < numbEn * 2; i++)
            {                
                    if (player[i / 2 + 1].loser == false)
                        en[i].Image = Image.FromFile(patch + "rub" + endpat);
                    else
                        en[i].Image = Image.FromFile(patch + "loseBlod" + i % 2 + endpat);                
            }
            motion = 0;
            giveNameGroups();
            detBank();
        }
        private void pass_Click(object sender, EventArgs e)
        {
            if (game.acttualRate == 0 && motion != 0 && motion < 4)
                newMotion();
            else if (game.acttualRate != 0)
                errorProvider1.SetError(Pas, "Нельзя пасовать, когда другими игроками сделана ставка.");
            else if (motion == 0)
                errorProvider1.SetError(Pas, "В первом ходу можно только сделать минимальную ставку.");
            else if (motion > 3)
                errorProvider1.SetError(Pas, "Игра уже закончилась.");
        }
        void newMotion()
        {
            if (Rates())
            {
                if (motion == 0)
                {
                    for (int i = 0; i < 3; i++)
                        all[i].Image = Image.FromFile(allpatch(0, 2 + i));
                }
                else if (motion == 1)
                    all[3].Image = Image.FromFile(allpatch(0, 5));

                else if (motion == 2)
                    all[4].Image = Image.FromFile(allpatch(0, 6));

                else if (motion == 3)
                    finalMotion();
                motion++;
                game.acttualRate = 0; //up this      
                actualRate.Text = "Текущая ставка: " + game.acttualRate;
                for (int i = 0; i < player.Length; i++)
                {
                    player[i].contZero();
                }
                cycl = 0;
            }
        }
        void finalMotion()
        {
            for (int i = 0; i < numbEn * 2; i++)
            {
                if (player[i / 2 + 1].loser == false && player[i / 2 + 1].give == false)
                    en[i].Image = Image.FromFile(allpatch(i / 2 + 1, i % 2));
            }
            (string nameComb, int powCard1, int powCard2, char suitCard, int numbWin) winner = game.detWinner(player);
            string textFinal = winner.nameComb + " у " + nameWinner(winner.numbWin);
            if (winner.powCard2 != 0 && winner.nameComb != "Флеш")
                textFinal += " с рангом карт " + Game.namePow(winner.powCard1) + " и " + Game.namePow(winner.powCard2);
            else if (winner.powCard1 != 0)
                textFinal += " с рангом карты " + Game.namePow(winner.powCard1);
            if (winner.suitCard != '0')
                textFinal += " масти " + Game.nameSuit(winner.suitCard);
            textBox1.Text = textFinal;
            game.payment(winner.numbWin - 1, player);
            detBank();


            bool allLose = true;
            for (int i = 1; i < player.Length; i++)
            {
                if (player[i].sum < game.flop)
                {
                    player[i].surrender();
                    bank[i - 1].Text = "Проиграл";
                }
                else
                    allLose = false;
            }
            if (player[0].sum != 0 && allLose == false)
            {
                Controls.Add(But_start);
                But_start.Visible = true;
            }
            else
            {
                mybank.Location = new Point(mybank.Location.X - 50, mybank.Location.Y);
                if (player[0].sum == 0)
                    mybank.Text = "Ваш бан равен 0. Вы проиграли.";
                else
                    mybank.Text = "Вы победили с банком в " + player[0].sum;
            }
        }
        private void rate_Click(object sender, EventArgs e)
        {
            if (errorProvider1.GetError(myRateBox) == "" && myRateBox.Text != "" && motion < 4)
            {
                int newRate = Aux.ToInt(myRateBox.Text);
                player[0].rateAccept(newRate);
                game.acttualRate = newRate;
                newMotion();
            }
            else if (motion > 3)
                errorProvider1.SetError(But_rate, "Игра уже окончена!");
            else
                errorProvider1.SetError(But_rate, "Проверьте свою ставку!");
        }
        void flop_Click(object sender, EventArgs e)
        {
            myRateBox.Text = game.flop.ToString();
        }
        void doubflop_Click(object sender, EventArgs e)
        {
            myRateBox.Text = (game.flop * 2).ToString();
        }
        void max_Click(object sender, EventArgs e)
        {
            myRateBox.Text = (minBank()).ToString();
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int BarRate = trackBar1.Value;

            if (BarRate == 0)
                myRateBox.Text = "0";
            else
                myRateBox.Text = ((int)(minBank() * (BarRate * (0.01)))).ToString();
        }
        private void myRateBox_TextChanged(object sender, EventArgs e)
        {
            int newRate = Aux.ToInt(myRateBox.Text);

            if (myRateBox.Text == "")
            {
                trackBar1.Value = 0;
                errorProvider1.Clear();
            }
            else if (newRate == -999)
                errorProvider1.SetError(myRateBox, "Вы ввели не число или отрицательное значение");
            else if (newRate == 0)
                errorProvider1.SetError(myRateBox, "Вы ввели 0");
            else if (newRate < game.flop)
                errorProvider1.SetError(myRateBox, "Нельзя поставить меньше, чем блайнд");
            else if (newRate > minBank())
                errorProvider1.SetError(myRateBox, "Нельзя поставить больше, чем самый минимум из банков противников");
            else if (newRate < game.acttualRate)
                errorProvider1.SetError(myRateBox, "Нельзя поставить меньше, чем текущая ставка");
            else if (newRate <= minBank() && newRate >= game.acttualRate && newRate >= game.flop)
            {
                trackBar1.Value = (newRate * 100) / minBank();
                errorProvider1.Clear();
            }
        }
        void call_Click(object sender, EventArgs e)
        {
            if (game.acttualRate != 0 && motion! < 4)
            {
                myRateBox.Text = game.acttualRate.ToString();
                rate_Click(sender, e);
            }
            else if (game.acttualRate == 0)
                errorProvider1.SetError(call, "Нельзя прожать колл пока никто не сделал ставку!");
            else if (motion > 3)
                errorProvider1.SetError(call, "Игра уже окончена.");
        }
        void lose_Click(object sender, EventArgs e)
        {
            if (motion != 0)
            {
                my1.Image = Image.FromFile(patch + "los" + endpat);
                my2.Image = Image.FromFile(patch + "los" + endpat);
                player[0].giveCards();
                while (motion !=3)
                {
                    newMotion();
                }
                newMotion();
                newMotion();
                finalMotion();
            }
            else
                errorProvider1.SetError(but_lose, "На первом ходу нельзя сдать карты");
        }


        bool Rates()
        {
            for (int i = 1; i < player.Length; i++)
            {
                if (player[i].loser == false&& player[i].give == false)
                {
                    int BotRate = player[i].aibot(game.acttualRate, cycl, minBank(), motion);
                    massege[i - 1].Text = massegeText(BotRate, groupBox[i - 1].Text);
                    game.acttualRate = BotRate;
                }
                else massege[i - 1].Text = "-";//"Игрок"+ groupBox[i - 1].Text+"Покинул игру";
                if (player[i].give==true)
                {
                    en[i * 2 - 1].Image = Image.FromFile(patch + "los" + endpat);
                    en[i * 2 - 2].Image = Image.FromFile(patch + "los" + endpat);
                }
            }
            actualRate.Text = "Текущая ставка: "+ game.acttualRate.ToString();
            game.rate = 0;
            for (int i = 0; i < player.Length; i++)
                game.rate += player[i].getCont();
            total.Text = "Всего на кону: " + game.rate;
            detBank();
            cycl++;
            trackBar1.Value = 0;
            myRateBox.Text = "";
            return equalRates();
        }
        bool equalRates()
        {
            for (int i = 1; i < player.Length; i++)
            {
                int rate1 = player[0].cont;
                if (player[i].cont != rate1 && player[i].loser == false&& player[i].give==false)
                    return false;
            }
            return true;
        }
        string nameWinner(int numbWin)
        {
            if (numbWin == 1)
                return "вас";
            else
                return groupBox[numbWin - 2].Text;
        }
        void giveNameGroups()
        {
            if (groupBox[0].Text == "")
            {
                Random rand = new Random();
                int[] randNames = new int[4];
                for (int i = 0; i < randNames.Length; i++)
                    randNames[i] = rand.Next(1, numbNames);
                for (int j = 0; j < randNames.Length; j++)
                {
                    using (StreamReader fileNames = new StreamReader(patch + "names.txt"))
                    {
                        string nameGroup = "";
                        int newSimb = 0;
                        for (int i = 0; i < randNames[j];)
                        {
                            newSimb = fileNames.Read();
                            if (newSimb == 10)
                                i++;
                        }
                        while (true)
                        {
                            newSimb = fileNames.Read();
                            char tempsimb = (char)(newSimb);
                            //не новая строка, не пробел, не возврат каретки, не таб и не конец файла
                            if (newSimb != 10 && newSimb != 32 && newSimb != 13 && newSimb != 9 && newSimb != -1)
                                nameGroup += tempsimb;
                            else break;
                        }
                        groupBox[j].Text = nameGroup;
                    }
                }
            }
        }
        string allpatch(int numbPl, int numbCard)
        {
            Card tempC1 = player[numbPl].GetCard(numbCard);
            string midPat = tempC1.power.ToString() + tempC1.suit;
            string allpatch = patch + midPat + endpat;
            return allpatch;
        }
        int minBank()
        {
            int min = 100000;
            for (int i = 0; i < player.Length; i++)
            {
                if (min > player[i].sum && player[i].loser == false && player[i].give == false)
                    min = player[i].sum;
            }
            return min;
        }
        void visible()
        {
            Controls.Clear();
            But_start.Location = new Point(textBox1.Location.X + textBox1.Size.Width + 20, textBox1.Location.Y - 10);
            But_start.Size = new Size(sizeButX, sizeButY);
            But_start.Text = "Новая Игра";
            Controls.Add(call);
            Controls.Add(myRateBox);
            Controls.Add(trackBar1);
            Controls.Add(but_lose);
            Controls.Add(But_rate);
            Controls.Add(textBox1);
            Controls.Add(Pas);
            Controls.Add(my1);
            Controls.Add(my2);
            Controls.Add(mybank);
            Controls.Add(total);
            Controls.Add(actualRate);
            Controls.Add(flop);
            Controls.Add(doubflop);
            Controls.Add(maxim);
            Controls.Add(help);
            for (int i = 0; i < numbAll; i++)
            {
                Controls.Add(all[i]);
            }
            for (int i = 0; i < numbEn; i++)
            {
                Controls.Add(groupBox[i]);
                groupBox[i].ResumeLayout(false);
                Controls.Add(massege[i]);
            }
        }
        void detBank()
        {
            for (int i = 0; i < numbEn; i++)
            {
                if (player[i+1].give == true)
                    bank[i].Text = "Сдал карты";
                else if (player[i + 1].loser == false)
                    bank[i].Text = "Банк: " + player[i + 1].sum.ToString();
                else 
                    bank[i].Text = "Проиграл";
            }
            mybank.Text = "Банк: " + player[0].sum.ToString();
        }
        public string massegeText(int rate, string name)
        {
            if (rate == 0)
                return "Игрок " + name + " пасует";
            if (rate == game.acttualRate)
                return "Игрок " + name + " принимает ставку";
            else if (rate > game.acttualRate)
                return "Игрок " + name + " повышает ставку до " + rate.ToString();
            else
                return "Игрок " + name + " сдает карты ";
        }
    }
}
