using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViTPO4
{
    public partial class Form1 : Form
    {
        BaseOfWords baseWords;
        ManagerClass managerClass;
        Timer myTimer;

        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
                textBox1.Enabled = false;
            else
                textBox1.Enabled = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
                textBox2.Enabled = false;
            else
                textBox2.Enabled = true;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == false)
                textBox3.Enabled = false;
            else
                textBox3.Enabled = true;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == false)
                textBox4.Enabled = false;
            else
                textBox4.Enabled = true;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == false)
                textBox5.Enabled = false;
            else
                textBox5.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cnt_players = 0;
            foreach (CheckBox checkBox in this.Controls.OfType<CheckBox>())
                if (checkBox.Checked == true)
                    cnt_players++;
            if (cnt_players < 2)
            {
                MessageBox.Show("Игроков должно быть минимум два!");
                return;
            }

            foreach (CheckBox checkBox in this.Controls.OfType<CheckBox>())
                checkBox.Enabled = false;

            label1.Enabled = false;
            label2.Enabled = false;
            numericUpDown1.Enabled = false;

            button2.Enabled = true;
            button1.Enabled = false;

            groupBox1.Enabled = true;

            //инициализация игры
            baseWords = new BaseOfWords();
            managerClass = new ManagerClass(baseWords);
            myTimer = new Timer(managerClass, Convert.ToInt32(numericUpDown1.Value));
            foreach (TextBox textBox in this.Controls.OfType<TextBox>())
            {
                if (textBox.Enabled == true)
                {
                    if (textBox.Text == "")
                        managerClass.ListPlayers.Add(new Player(textBox.Name + " Player"));
                    else
                        managerClass.ListPlayers.Add(new Player(textBox.Text));
                }
            }
            label6.Text = managerClass.ListPlayers[0].Name;
            label3.Text = numericUpDown1.Value.ToString();
            label7.Text = "";

            string results = "";
            for (int i =0; i < managerClass.ListPlayers.Count; i++)
            {
                results += managerClass.ListPlayers[i].Name + ": " + managerClass.ListPlayers[i].points.ToString() + "\n";
            }
            label9.Text = results;
            
            timer1.Start();

            foreach (TextBox textBox in this.Controls.OfType<TextBox>())
                textBox.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (TextBox textBox in this.Controls.OfType<TextBox>())
            {
                textBox.Enabled = true;
                textBox.Text = "";
            }             
            foreach (CheckBox checkBox in this.Controls.OfType<CheckBox>())
                checkBox.Enabled = true;

            label1.Enabled = true;
            label2.Enabled = true;
            numericUpDown1.Enabled = true;

            button1.Enabled = true;
            button2.Enabled = false;

            groupBox1.Enabled = true;


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            myTimer.takeOneSecond();
            if (myTimer.Seconds == 0)
            {
                myTimer.Seconds = Convert.ToInt32(numericUpDown1.Value);
                label6.Text = managerClass.ListPlayers[managerClass.IndexPlayer].Name;
            }
            label3.Text = myTimer.Seconds.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int result = managerClass.checkWord(textBox6.Text);

            if (result == 1)
            {
                managerClass.switchPlayer();
                myTimer.Seconds = Convert.ToInt32(numericUpDown1.Value);
                managerClass.ListPlayers[managerClass.IndexPlayer].addPoint();

                label7.Text = managerClass.UsedCities[managerClass.UsedCities.Count - 1].ToString();
                textBox6.Text = "";

                string res = "";
                for (int i = 0; i < managerClass.ListPlayers.Count; i++)
                {
                    res += managerClass.ListPlayers[i].Name + ": " + managerClass.ListPlayers[i].points.ToString() + "\n";
                }
                label9.Text = res;

            }
            else if (result == 0)
            {
                MessageBox.Show("Такого города не существует!");
            }
            else if (result == -1)
            {
                MessageBox.Show("Этот город уже был назван!");
            }
            else if( result == -2)
            {
                string past_city = managerClass.UsedCities[managerClass.UsedCities.Count - 1];
                MessageBox.Show("Вам нужен город на букву " + past_city[past_city.Length - 1]);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
