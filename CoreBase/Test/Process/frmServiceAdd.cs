using CoreBase.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AusNail.Process
{
    public partial class frmServiceAdd : Form
    {
        private int _branchID = 0;
        private DataTable _dtService = null;
        public frmServiceAdd()
        {
            InitializeComponent();
        }

        public frmServiceAdd(int branchId, string customerName, string phoneNumber)
        {
            InitializeComponent();
            _branchID = branchId;
            txtName.Text = customerName;
            txtPhoneNumber.Text = phoneNumber;
        }

        private void loadService()
        {
            try
            {
                _dtService = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zServiceGetList_byBranch", _branchID);
            }
            catch 
            {
            }
        }

        private void dgvService_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            else
            {
                if (e.ColumnIndex == 1) //Service 
                {
                    dgvService.Rows[e.RowIndex].Cells[1].DataGridView.DataSource = _dtService;
                }
                if (e.ColumnIndex == 2) //Price 
                {

                }
                if (e.ColumnIndex == 3) //Quantity 
                {

                }
                if (e.ColumnIndex == 5) //Delete 
                {
                    dgvService.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
    }
}
