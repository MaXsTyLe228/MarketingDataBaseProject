using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсач.Reports
{
    public partial class Contract : Form
    {
        public Contract()
        {
            InitializeComponent();
        }

        private void Contract_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.DataTable4". При необходимости она может быть перемещена или удалена.
            this.dataTable4TableAdapter.Fill(this.dataSet1.DataTable4);
            this.reportViewer1.RefreshReport();
        }
    }
}
