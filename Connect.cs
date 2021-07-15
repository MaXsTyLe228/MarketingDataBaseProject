using System;
using System.Drawing;
using System.Windows.Forms;

namespace Курсач
{
    public partial class Connect : Form
    {
        public Connect()
        {
            InitializeComponent();
        }

        Color r = Color.Plum;
        Color l = Color.Transparent;

        public string filename, connectionStr;

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                label1.Text = filename;
                button2.Visible = true;
            }

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = r;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = r;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = l;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = l;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connectionStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""" + filename + @""";Integrated Security=True;Connect Timeout=30";
            Properties.Settings.Default["kurs"] = connectionStr;
            Properties.Settings.Default.Save();
            MessageBox.Show("Підключення успішне");
            this.Close();
            Program.m.button2.Visible = true;
            Program.m.button3.Visible = true;
            Program.m.button4.Visible = true;
        }
    }
}
