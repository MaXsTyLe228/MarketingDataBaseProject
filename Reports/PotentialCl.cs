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
    public partial class PotentialCl : Form
    {
        public PotentialCl()
        {
            InitializeComponent();
        }

        private void PotentialCl_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.DataTable2". При необходимости она может быть перемещена или удалена.
            this.dataTable2TableAdapter.Fill(this.dataSet1.DataTable2);

            this.reportViewer1.RefreshReport();
        }
    }
}
