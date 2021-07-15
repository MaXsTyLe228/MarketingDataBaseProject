using System;
using System.Windows.Forms;

namespace Курсач.Reports
{
    public partial class Adverticement : Form
    {
        public Adverticement()
        {
            InitializeComponent();
        }

        private void Adverticement_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.DataTable3". При необходимости она может быть перемещена или удалена.
            this.dataTable3TableAdapter.Fill(this.dataSet1.DataTable3);

            this.reportViewer1.RefreshReport();
        }
    }
}
