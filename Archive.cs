using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Курсач
{
    public partial class Archive : Form
    {
        public Archive()
        {
            InitializeComponent();
        }

        Color r = Color.LightBlue;
        Color l = Color.Transparent;

        string constr;

        DataSet ds = new DataSet();
        // for Products
        SqlDataAdapter DataAdapterProd;
        SqlCommandBuilder BDProd;
        BindingSource BindingSourceProd = new BindingSource();

        // for Contracts
        SqlDataAdapter DataAdapterContracts;
        SqlCommandBuilder BDContracts;
        BindingSource BindingSourceContracts = new BindingSource();

        // for Real Clients
        SqlDataAdapter DataAdapterRealCl;
        SqlCommandBuilder BDRealCl;
        BindingSource BindingSourceRealCl = new BindingSource();

        // for Potential Clients
        SqlDataAdapter DataAdapterPotentialCl;
        SqlCommandBuilder BDPotentialCl;
        BindingSource BindingSourcePotentialCl = new BindingSource();

        // for Adv
        SqlDataAdapter DataAdapterAdv;
        SqlCommandBuilder BDAdv;
        BindingSource BindingSourceAdv = new BindingSource();


        // for Adv
        SqlDataAdapter DataAdapterOwn;
        SqlCommandBuilder BDOwn;
        BindingSource BindingSourceOwn = new BindingSource();

        DataTable tabcust = new DataTable();//Clients temp
        //DataRow rowcust;

        SqlDataAdapter daprod;
        SqlCommandBuilder bdprod;
        BindingSource bd2 = new BindingSource();

        SqlDataAdapter daadv;
        SqlCommandBuilder bdadv;
        BindingSource bd1 = new BindingSource();

        private void Archive_Load_1(object sender, EventArgs e)
        {
            constr = Properties.Settings.Default.kurs;//all
            SqlConnection cnn = new SqlConnection(constr);//all
            cnn.Open();///////???????????

            gradientGrid1.Rows.Clear();
            gradientGrid5.Rows.Clear();
            gradientGrid2.Rows.Clear();
            gradientGrid4.Rows.Clear();
            gradientGrid3.Rows.Clear();
            //////////////////////////////// Products ///////////////////////

            DataAdapterProd = new SqlDataAdapter(//Products.Id_Prod AS [Код Виробу],
            "SELECT Products.Title AS [Назва товару], Units.Unit AS [Одиниця вимірювання], Products.Price AS [Ціна/ грн], Products.Guarantee_period AS [Гарантійний період/ міс], Products.Performance AS [Характеристика]" +
            "FROM Products INNER JOIN "+
            "Units ON Products.Unit = Units.Id_Unit", cnn);
            BDProd = new SqlCommandBuilder(DataAdapterProd);
            DataAdapterProd.Fill(ds, "Products");

            BindingSourceProd.DataSource = ds;
            BindingSourceProd.DataMember = "Products";
            gradientGrid1.DataSource = BindingSourceProd;
            gradientGrid1.Columns[2].DefaultCellStyle.Format = "n2";
            //////////////////////////////// Contracts ///////////////////////

            DataAdapterContracts = new SqlDataAdapter(
            "SELECT Contract.Id_Contract AS [№ Договору], Real_Clients.Firm AS [Фірма], Real_Clients.Person AS [Контакнтне лице], Contract.Contract_date AS [Дата уключення договору], Contract.term AS [Термін/ міс], Contract.Summ AS [Сума договіру], Real_Clients.Phone AS [Телефон]" + //Products.Title,
            "FROM Contract INNER JOIN " +
            "Real_Clients ON Contract.Id_Cl = Real_Clients.Id_Cl"//+
            //" INNER JOIN [Con-Prod] ON Contract.Id_Contract = [Con-Prod].Id_Contract"// 
            //" INNER JOIN Products ON[Con-Prod].Id_Prod = Products.Id_Prod"
            , cnn);
            BDContracts = new SqlCommandBuilder(DataAdapterContracts);
            DataAdapterContracts.Fill(ds, "Contract");

            BindingSourceContracts.DataSource = ds;
            BindingSourceContracts.DataMember = "Contract";
            gradientGrid2.DataSource = BindingSourceContracts;

            //////////////////////////////// Real Clients ///////////////////////

            DataAdapterRealCl = new SqlDataAdapter(// Real_Clients.Id_Cl AS [Код кліента],
            "SELECT Real_Clients.Firm AS [Фірма], Ownership.ownership AS [Форма власності], Real_Clients.Adress AS [Адреса], Real_Clients.Person AS [Контактне лице], Real_Clients.Phone AS [Телефон]" +
            "FROM Real_Clients INNER JOIN " +
            "Ownership ON Real_Clients.Ownership_type = Ownership.Id_Own", cnn);
            BDRealCl = new SqlCommandBuilder(DataAdapterRealCl);
            DataAdapterRealCl.Fill(ds, "Real_Clients");

            BindingSourceRealCl.DataSource = ds;
            BindingSourceRealCl.DataMember = "Real_Clients";
            gradientGrid3.DataSource = BindingSourceRealCl;

            //////////////////////////////// Potential Clients ///////////////////////

            DataAdapterPotentialCl = new SqlDataAdapter(// Potential_Clients.Id_Cl AS [Код кліента],
            "SELECT Potential_Clients.Firm AS [Фірма], Ownership.ownership AS [Форма власності], Potential_Clients.Adress AS [Адреса], Potential_Clients.Person AS [Контактне лице], Potential_Clients.Phone  AS [Телефон]" +
            "FROM Potential_Clients INNER JOIN "+
            "Ownership ON Potential_Clients.Ownership_type = Ownership.Id_Own", cnn);
            BDPotentialCl = new SqlCommandBuilder(DataAdapterPotentialCl);
            DataAdapterPotentialCl.Fill(ds, "Potential_Clients");

            BindingSourcePotentialCl.DataSource = ds;
            BindingSourcePotentialCl.DataMember = "Potential_Clients";
            gradientGrid4.DataSource = BindingSourcePotentialCl;

            //////////////////////////////// Adverticement ///////////////////////

            DataAdapterAdv = new SqlDataAdapter(
            "SELECT Products.Title AS [Назва товару], Advertisement.Type AS [Тип реклами], Advertisement.Price AS Ціна, ProdAdv.Finishdate AS [Дата закінчення реклами], ProdAdv.Startdate AS [Дата початку реклами]" +
            "FROM ProdAdv INNER JOIN "+
            "Advertisement ON ProdAdv.Id_Adv = Advertisement.Id_Adv INNER JOIN "+
            "Products ON ProdAdv.Id_Prod = Products.Id_Prod", cnn);
            BDAdv = new SqlCommandBuilder(DataAdapterAdv);
            DataAdapterAdv.Fill(ds, "ProdAdv");

            BindingSourceAdv.DataSource = ds;
            BindingSourceAdv.DataMember = "ProdAdv";
            gradientGrid5.DataSource = BindingSourceAdv;

            ///////////////

            DataTable tb1 = new DataTable();
            daprod = new SqlDataAdapter("select *from [Products]", cnn);//for Clients
            bdprod = new SqlCommandBuilder(daprod);//for Clients
            daprod.Fill(tb1);//for Clients

            bd2.DataSource = tb1;
            bd2.Sort = "Title";

            listBox1.DataSource = tb1;
            listBox1.ValueMember = "Id_Prod";
            listBox1.DisplayMember = "Title";
            listBox1.SelectedIndex = -1;

            DataTable tb2 = new DataTable();
            daadv = new SqlDataAdapter("select *from [Advertisement]", cnn);//for Clients
            bdadv = new SqlCommandBuilder(daadv);//for Clients
            daadv.Fill(tb2);//for Clients

            bd1.DataSource = tb2;
            bd1.Sort = "Type";

            comboBox2.DataSource = tb2;
            comboBox2.ValueMember = "Id_Adv";
            comboBox2.DisplayMember = "Type";
            comboBox2.SelectedIndex = -1;
        }
        /// <summary>
        /// Пошук
        /// </summary>
        /// <param name="table"></param>
        /// <param name="atribute"></param>
        public void Search(string table, string atribute)
        {
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            string sql;
            int x = 0;
            sql = "select * from " + table + " where " + "Person" + " = @" + "Person";
            using (SqlCommand myCommand = new SqlCommand(sql, conn))
            {
                myCommand.Parameters.AddWithValue("@Person", textBox3.Text);
                SqlDataReader reader = myCommand.ExecuteReader();
                while (reader.Read()) x++;
                reader.Close();
            }
            if (x == 0) MessageBox.Show("Запису немає!!!");
            else BindingSourcePotentialCl.Filter = atribute + " ='" + textBox3.Text + @"'";
            gradientGrid4.DataSource = BindingSourcePotentialCl;
        }

        /// <summary>
        /// Додавання Клієнтов
        /// </summary>
        private void addCl()
        {
            DataTable tabCl = new DataTable();
            SqlDataAdapter daCl;
            SqlConnection conn = new SqlConnection(constr);
            string Firm = textBox1.Text;
            string Adress = textBox2.Text;
            string Person = textBox3.Text;
            string Phone = maskedTextBox1.Text;
            string Ownership_type = textBox5.Text;
            conn.Open();
            string sql;
            sql = "SELECT * FROM Potential_Clients ";//Where Id_Cl=@Id_Cl
            sql = "INSERT INTO Potential_Clients(Firm,Adress,Person,Phone,Ownership_type)values" +
                    "(@Firm,@Adress,@Person,@Phone,@Ownership_type)";
            using (SqlCommand myCommand = new SqlCommand(sql, conn))
            {
                myCommand.Parameters.AddWithValue("@Firm", Firm);
                myCommand.Parameters.AddWithValue("@Adress", Adress);
                myCommand.Parameters.AddWithValue("@Person", Person);
                myCommand.Parameters.AddWithValue("@Phone", Phone);
                myCommand.Parameters.AddWithValue("@Ownership_type", Ownership_type);
                myCommand.ExecuteNonQuery();

                daCl = new SqlDataAdapter("SELECT Potential_Clients.Firm AS [Фірма], Ownership.ownership AS [Форма власності], Potential_Clients.Adress AS [Адреса], Potential_Clients.Person AS [Контактне лице], Potential_Clients.Phone  AS [Телефон]" +
                "FROM Potential_Clients INNER JOIN " +
                "Ownership ON Potential_Clients.Ownership_type = Ownership.Id_Own", conn);
                BDPotentialCl = new SqlCommandBuilder(daCl);
                daCl.Fill(tabCl);
                gradientGrid4.DataSource = tabCl;
                conn.Close();
            }
            MessageBox.Show("Клієнт додан");
        }

        /// <summary>
        /// Видалення Клієнтів
        /// </summary>
        private void delCl()
        {
            DataTable tabCl = new DataTable();
            SqlDataAdapter daCl;
            SqlConnection conn = new SqlConnection(constr);
            String id = Convert.ToString(gradientGrid4.CurrentRow.Cells[3].Value);
            DialogResult result = MessageBox.Show("Видалити запис?", "Увага", MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            conn.Open();
            if (result == DialogResult.No) return;
            else
            {
                if (this.gradientGrid4.CurrentRow != null)
                {
                    using (SqlCommand myCommand = new SqlCommand("DELETE FROM Potential_Clients WHERE (Person=@Person)", conn))
                    {
                        myCommand.Parameters.AddWithValue("@Person", id);
                        myCommand.ExecuteNonQuery();

                        daCl = new SqlDataAdapter("SELECT Potential_Clients.Firm AS [Фірма], Ownership.ownership AS [Форма власності], Potential_Clients.Adress AS [Адреса], Potential_Clients.Person AS [Контактне лице], Potential_Clients.Phone  AS [Телефон]" +
                        "FROM Potential_Clients INNER JOIN " +
                        "Ownership ON Potential_Clients.Ownership_type = Ownership.Id_Own", conn);
                        BDPotentialCl = new SqlCommandBuilder(daCl);
                        daCl.Fill(tabCl);
                        gradientGrid4.DataSource = tabCl;
                        conn.Close();
                    }
                }
            }
        }
        /// <summary>
        /// Додання реклами
        /// </summary>
        private void addAdv()
        {
            DataTable tabAdv = new DataTable();
            SqlDataAdapter daAdv;
            SqlConnection conn = new SqlConnection(constr);
            int Prod = Convert.ToInt32(listBox1.SelectedValue);
            int Type = Convert.ToInt32(comboBox2.SelectedValue);
            DateTime Start = dateTimePicker1.Value;
            DateTime Finish = dateTimePicker2.Value;
            conn.Open();
            string sql;
            sql = "SELECT * FROM ProdAdv ";//Where Id_Cl=@Id_Cl
            sql = "INSERT INTO ProdAdv(Id_Prod,Id_Adv,Startdate,Finishdate)values" +
                    "(@Id_Prod,@Id_Adv,@Startdate,@Finishdate)";
            using (SqlCommand myCommand = new SqlCommand(sql, conn))
            {
                myCommand.Parameters.AddWithValue("@Id_Prod", Prod);
                myCommand.Parameters.AddWithValue("@Id_Adv", Type);
                myCommand.Parameters.AddWithValue("@Startdate", Start);
                myCommand.Parameters.AddWithValue("@Finishdate", Finish);
                myCommand.ExecuteNonQuery();

                daAdv = new SqlDataAdapter("SELECT Products.Title AS [Назва товару], Advertisement.Type AS [Тип реклами], Advertisement.Price AS Ціна, ProdAdv.Finishdate AS [Дата закінчення реклами], ProdAdv.Startdate AS [Дата початку реклами]" +
                "FROM ProdAdv INNER JOIN " +
                "Advertisement ON ProdAdv.Id_Adv = Advertisement.Id_Adv INNER JOIN " +
                "Products ON ProdAdv.Id_Prod = Products.Id_Prod", conn);
                BDAdv = new SqlCommandBuilder(DataAdapterAdv);
                daAdv.Fill(tabAdv);
                gradientGrid5.DataSource = tabAdv;
                conn.Close();
            }
            MessageBox.Show("Реклама додана!!!");
        }

        /// <summary>
        /// Редагування Клієнтів
        /// </summary>
        private void updateCl()
        {
            try
            {
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                string sql;
                sql = "Select * FROM Potential_Clients";
                for (int i = 0; i < gradientGrid4.Rows.Count - 1; i++)
                {
                    sql = "UPDATE Potential_Clients SET Firm=@Firm, Adress=@Adress,  Phone=@Phone Where Person=@Person";//Where Id_Cl=@Id_Cl Person=@Person,
                    using (SqlCommand myCommand = new SqlCommand(sql, conn))
                    {
                        myCommand.Parameters.AddWithValue("@Firm", gradientGrid4[0, i].Value);
                        myCommand.Parameters.AddWithValue("@Adress", gradientGrid4[2, i].Value);
                        myCommand.Parameters.AddWithValue("@Person", gradientGrid4[3, i].Value);
                        myCommand.Parameters.AddWithValue("@Phone", gradientGrid4[4, i].Value);
                        //myCommand.Parameters.AddWithValue("@Ownership_type", gradientGrid4[1, i].Value);
                        myCommand.ExecuteNonQuery();
                    }

                }
                MessageBox.Show("Оновлено");
            }
            catch
            {
                MessageBox.Show("Помилка");
            }
        }

        private void inflation()
        {
            try
            {
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                string sql;
                double inflation;
                sql = "Select * FROM Products WHERE Title=@Title";
                for (int i = 0; i < gradientGrid1.Rows.Count - 1; i++)
                {
                    inflation = Convert.ToDouble(gradientGrid1[2, i].Value) + (Convert.ToDouble(gradientGrid1[2, i].Value) * Convert.ToDouble(textBox4.Text) / 100);
                    gradientGrid1[2, i].Value = inflation;
                    sql = "UPDATE Products SET Price=@Price WHERE (Title=@Title)";
                    using (SqlCommand myCommand = new SqlCommand(sql, conn))
                    {
                        myCommand.Parameters.AddWithValue("@Title", gradientGrid1[0, i].Value);
                        myCommand.Parameters.AddWithValue("@Price", gradientGrid1[2, i].Value);
                        myCommand.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Оновлено");
            }
            catch
            {
                MessageBox.Show("Введіть число");
            }
        }
        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Text = tabControl1.SelectedTab.Text;
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            Reports.Adverticement f = new Reports.Adverticement();
            f.ShowDialog();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            Reports.Contract f = new Reports.Contract();
            f.dataTable4BindingSource.Filter = "[Person]='" + Convert.ToString(gradientGrid3.CurrentRow.Cells[3].Value)+"'";
            f.ShowDialog();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            inflation();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Tovars f = new Tovars();
            f.ShowDialog();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Document f = new Document();
            f.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                addCl();
            }
            catch
            {
                MessageBox.Show("Введіть дані про клієнта");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            updateCl();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                delCl();
            }
            catch
            {
                MessageBox.Show("Виберіть клієнта");
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                Search("Potential_Clients", "[Контактне лице]");
            }
            else
            {
                BindingSourcePotentialCl.Filter = null;
                gradientGrid4.DataSource = BindingSourcePotentialCl;
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            Reports.PotentialCl f = new Reports.PotentialCl();
            f.ShowDialog();
        }
        private void textBox4_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (e.KeyChar == ',')
            {
                if (this.Text.IndexOf(",") >= 0 || this.Text.Length == 0)
                {
                    e.Handled = true;
                }
            }
            else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (Convert.ToString(comboBox1.SelectedItem) == "Суспільна")
                textBox5.Text = "1";
            else textBox5.Text = "2";
        }

        private void maskedTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            maskedTextBox1.SelectionStart = 3;
        }

        private void textBox4_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            float value;
            if (!float.TryParse(textBox1.Text, out value)) { textBox1.Text = ""; }
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            button7.BackColor = r;
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            button8.BackColor = r;
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            button6.BackColor = r;
        }

        private void button10_MouseEnter(object sender, EventArgs e)
        {
            button10.BackColor = r;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = r;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = r;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = r;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.BackColor = r;
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            button9.BackColor = r;
        }

        private void button11_MouseEnter(object sender, EventArgs e)
        {
            button11.BackColor = r;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.BackColor = l;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.BackColor = l;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor = l;
        }

        private void button10_MouseLeave(object sender, EventArgs e)
        {
            button10.BackColor = l;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = l;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = l;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = l;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = l;
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            button9.BackColor = l;
        }

        private void button11_MouseLeave(object sender, EventArgs e)
        {
            button11.BackColor = l;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                addAdv();
            }
            catch
            {
                MessageBox.Show("Введіть дані для реклами");
            }
        }
    }
}
