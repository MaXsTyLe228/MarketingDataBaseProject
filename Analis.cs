using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Курсач
{
    public partial class Analis : Form
    {
        public Analis()
        {
            InitializeComponent();
        }
        string constr;
        DataSet ds = new DataSet();
        // for Products
        SqlDataAdapter DataAdapterProd;
        SqlCommandBuilder BDProd;
        BindingSource BindingSourceProd = new BindingSource();

        private void Analis_Load(object sender, EventArgs e)
        {
            constr = Properties.Settings.Default.kurs;//all
            SqlConnection cnn = new SqlConnection(constr);//all
            cnn.Open();///////???????????

            DataTable tb = new DataTable();
            DataAdapterProd =new SqlDataAdapter("SELECT Products.Title AS[Назва товару], COUNT(Contract.Id_Cl) AS[Усього договорів] " +
            "FROM Products INNER JOIN [Con-Prod] ON Products.Id_Prod = [Con-Prod].Id_Prod INNER JOIN " +
            "Contract ON[Con-Prod].Id_Contract = Contract.Id_Contract INNER JOIN " +
            "Real_Clients ON Contract.Id_Cl = Real_Clients.Id_Cl " +
            "GROUP BY Products.Title", cnn);
            BDProd = new SqlCommandBuilder(DataAdapterProd);
            DataAdapterProd.Fill(tb);

            /*BindingSourceProd.DataSource = ds;
            BindingSourceProd.DataMember = "Products";*/
            gradientGrid1.DataSource = tb;
        }
    }
}
