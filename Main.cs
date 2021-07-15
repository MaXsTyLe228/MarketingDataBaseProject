using System;
using System.Drawing;
using System.Windows.Forms;

namespace Курсач
{
    public partial class Main : Form
    {
        public Main()
        {
            Program.m = this;
            InitializeComponent();
        }
        Color r = Color.Plum;
        Color l = Color.Transparent;

        private void button1_Click(object sender, EventArgs e)
        {
            Connect connect = new Connect();
            connect.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Archive archive = new Archive();
            archive.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Analis f = new Analis();
            f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Adv f = new Adv();
            f.ShowDialog();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = r;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = l;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = r;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = r;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = r;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = l;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = l;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = l;
        }
    }
}
