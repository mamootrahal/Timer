using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NormTimer
{
    public partial class Form1 : Form
    {
        private int sec, min, hrs;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            label6.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            label6.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            label6.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                sec = String.IsNullOrWhiteSpace(textBox1.Text) ? 0 : Convert.ToInt32(textBox1.Text);
                min = String.IsNullOrWhiteSpace(textBox2.Text) ? 0 : Convert.ToInt32(textBox2.Text);
                hrs = String.IsNullOrWhiteSpace(textBox3.Text) ? 0 : Convert.ToInt32(textBox3.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),
                    "ОШИБКА",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                sec = 0;
                textBox1.Text = 0.ToString();
                min = 0;
                textBox2.Text = 0.ToString();
                hrs = 0;
                textBox3.Text = 0.ToString();
            }
            label3.Text = sec.ToString();
            label2.Text = min.ToString();
            label1.Text = hrs.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sec--;
            if (hrs < 0 || min < 0 || sec < 0)
            {
                timer1.Stop();
                sec = min = hrs = 0;
                MessageBox.Show("ВРЕМЯ ИСТЕКЛО!",
                    "СООБЩЕНИЕ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            if (sec < 0)
            {
                sec = 59;
                min--;
            }
            if (min < 0)
            {
                min = 59;
                hrs--;
            }
            label1.Text = hrs.ToString();
            label3.Text = sec.ToString();
            label2.Text = min.ToString();
        }
    }
}
