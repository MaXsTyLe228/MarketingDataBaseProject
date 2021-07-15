using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Курсач
{
    public partial class Document : Form
    {
        public Document()
        {
            InitializeComponent();
        }

        Color r = Color.Plum;
        Color l = Color.Transparent;

        SqlConnection conn;
        SqlCommand myCommandAdd;
        //SqlCommand myCommandOrder;
        SqlTransaction trans = null;

        DataSet ds = new DataSet();
        DataSet dsord = new DataSet();

        SqlDataAdapter dacust;
        SqlCommandBuilder bdcust;
        BindingSource bd1 = new BindingSource();

        SqlDataAdapter dacust1;
        SqlCommandBuilder bdcust1;
        BindingSource bd2 = new BindingSource();

        string constr;

        public void load()
        {
            constr = Properties.Settings.Default.kurs;
            SqlConnection cnn = new SqlConnection(constr);
            cnn.Open();
            DataTable tb = new DataTable();
            dacust = new SqlDataAdapter("select *from [Real_Clients]", cnn);//for Clients
            bdcust = new SqlCommandBuilder(dacust);//for Clients
            dacust.Fill(tb);//for Clients

            bd1.DataSource = tb;//for Clients
            bd1.Sort = "Person";

            listBox2.DataSource = tb;
            listBox2.ValueMember = "Id_Cl";
            listBox2.DisplayMember = "Person";
            listBox2.SelectedIndex = -1;

            DataTable tb2 = new DataTable();
            dacust1 = new SqlDataAdapter("select *from [Potential_Clients]", cnn);//for Clients
            bdcust1 = new SqlCommandBuilder(dacust1);//for Clients
            dacust1.Fill(tb2);//for Clients

            bd2.DataSource = tb2;
            bd2.Sort = "Person";

            listBox3.DataSource = tb2;
            listBox3.ValueMember = "Id_Cl";
            listBox3.DisplayMember = "Person";
            listBox3.SelectedIndex = -1;
        }

        private void Document_Load(object sender, EventArgs e)
        {
            load();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(constr);
                int Client = Convert.ToInt32(listBox2.SelectedValue);
                int term = Convert.ToInt32(textBox1.Text);
                int summ = Convert.ToInt32(textBox2.Text);
                conn.Open();
                string sql;
                sql = "SELECT * FROM Contract Where Id_Contract=@Id_Contract";
                sql = "INSERT INTO Contract(Id_Cl, Contract_date, term, Summ)values" +
                    "(@Id_Cl,@Contract_date,@term,@Summ)";
                using (SqlCommand myCommand = new SqlCommand(sql, conn))
                {
                    myCommand.Parameters.AddWithValue("@Id_Cl", Client);
                    myCommand.Parameters.AddWithValue("@Contract_date", dateTimePicker1.Value.ToString("dd/MM/yyyy"));
                    myCommand.Parameters.AddWithValue("@term", term);
                    myCommand.Parameters.AddWithValue("@Summ", summ);
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                }
                MessageBox.Show("Доданий договір");
            }
            catch
            {
                MessageBox.Show("Виберіть дані для договору");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (conn == null)
                conn = new SqlConnection(constr);
            myCommandAdd = conn.CreateCommand();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                myCommandAdd.CommandText = "INSERT INTO Real_Clients(Firm, Ownership_type, Adress, Person, Phone)"
                    + "SELECT  Firm, Ownership_type, Adress, Person, Phone " +
                      "FROM Potential_Clients " +
                      "WHERE Id_Cl = " + listBox3.SelectedValue;
                myCommandAdd.ExecuteNonQuery();
                myCommandAdd = conn.CreateCommand();
                myCommandAdd.CommandText = "DELETE FROM Potential_Clients WHERE Id_Cl=" + listBox3.SelectedValue;
                myCommandAdd.ExecuteNonQuery();
                MessageBox.Show("Реальний кілент додан");
            }
            catch//(Exception ex)
            {
                if (trans != null)
                {
                    MessageBox.Show("помилка даних");
                }
            }
            listBox2.DataSource = null;
            listBox3.DataSource = null;
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            load();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = r;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = r;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = l;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = l;
        }
    }
}
