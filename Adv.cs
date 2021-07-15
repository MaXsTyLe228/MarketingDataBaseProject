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
    public partial class Adv : Form
    {
        public Adv()
        {
            InitializeComponent();
        }
        string constr;
        DataSet ds = new DataSet();
        // for Products
        SqlDataAdapter DataAdapterProd;
        SqlCommandBuilder BDProd;
        BindingSource BindingSourceProd = new BindingSource();
        private void Adv_Load(object sender, EventArgs e)
        {
            constr = Properties.Settings.Default.kurs;//all
            SqlConnection cnn = new SqlConnection(constr);//all
            cnn.Open();///////???????????

            DataTable tb = new DataTable();
            DataAdapterProd = new SqlDataAdapter("SELECT Products.Title AS [Назва товару], SUM(Advertisement.Price) AS [Витрат на рекламу/грн] "+
            "FROM Advertisement INNER JOIN "+
            "ProdAdv ON Advertisement.Id_Adv = ProdAdv.Id_Adv INNER JOIN "+
            "Products ON ProdAdv.Id_Prod = Products.Id_Prod "+
            "GROUP BY Products.Title", cnn);
            BDProd = new SqlCommandBuilder(DataAdapterProd);
            DataAdapterProd.Fill(tb);

            /*BindingSourceProd.DataSource = ds;
            BindingSourceProd.DataMember = "Products";*/
            gradientGrid1.DataSource = tb;
        }
    }
}
