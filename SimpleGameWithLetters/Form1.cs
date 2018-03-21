using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleGameWithLetters
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        Stats stats = new Stats();
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // We add random letter to listBox1
            listBox1.Items.Add((Keys)random.Next(65, 90));
            if (listBox1.Items.Count > 7) // end game when in listbox we will have 8 or more letters
            {
                //ending game methods
                listBox1.Items.Clear();
                listBox1.Items.Add("Koniec gry");
                timer1.Stop();
                button1.Visible = true; //showing button which allows restart game
            }
        }

        public void VisualStatisticsRestart()
        {

            correctLabel.Text = "Prawidłowych: " + stats.Correct;
            missedLabel.Text = "Błędów: " + stats.Missed;
            totalLabel.Text = "Wszystkich: " + stats.Total;
            accuracyLabel.Text = "Dokładnośc: " + stats.Accuracy + "%";
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // If player clicked letter which is showed in listbox, then delete it
            // Difficulty ++
            if (listBox1.Items.Contains(e.KeyCode))
            {
                listBox1.Items.Remove(e.KeyCode);
                listBox1.Refresh();
                if (timer1.Interval > 400)
                    timer1.Interval -= 10;
                if (timer1.Interval > 250)
                    timer1.Interval -= 7;
                if (timer1.Interval > 100)
                    timer1.Interval -= 2;
                difficultyProgressBar.Value = 800 - timer1.Interval;

                stats.Update(true); //correctKey
            }
            else
            {
                stats.Update(false); //!correctKey
            }

            VisualStatisticsRestart();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            listBox1.Items.Clear();
            stats.Restart();
            VisualStatisticsRestart();
            difficultyProgressBar.Value = 0; //restarting progress bar
            timer1.Interval = 701; //setting timer1 interval to default
            timer1.Start(); //starting game
        }
    }
}
