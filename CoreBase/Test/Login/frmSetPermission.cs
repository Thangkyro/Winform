using CoreBase;
using CoreBase.DataAccessLayer;
using CoreBase.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AusNail.Login
{
    public partial class frmSetPermission : Form
    {
        private int _userID = 0;
        public DataRow zUserRow { get; set; }
        private DataTable _cmdForPermission;
        IEnumerable<DataRow> _cmdRows;

        public frmSetPermission(int userID, string userName, string fullName)
        {
            InitializeComponent();
            try
            {
                panel1.BackColor = NailApp.ColorUser;
                panel2.BackColor = NailApp.ColorUser;
            }
            catch
            {
            }
            _userID = userID;
            txtFullName.Text = fullName;
            txtUserName.Text = userName;
        }

        #region Event

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                string idDms = "";
                foreach (TreeNode node in tvwDm.Nodes)
                {
                    idDms += GetIds(node);
                }
                foreach (TreeNode node in tvwPs.Nodes)
                {
                    idDms += GetIds(node);
                }
                foreach (TreeNode node in tvwBc.Nodes)
                {
                    idDms += GetIds(node);
                }
                foreach (TreeNode node in tvwSys.Nodes)
                {
                    idDms += GetIds(node);
                }

                idDms = idDms.Length == 0 ? idDms : idDms.Substring(1);

                string sql = string.Format("update zUser set permission = '{0}' where Userid = {1}", idDms, _userID);
                int ret = MsSqlHelper.ExecuteNonQuery(ZenDatabase.ConnectionString, CommandType.Text, sql);
                MessageBox.Show("Set Permission Success.", "Information");

                DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //ErrorProcess.HandleException(ex);
                MessageBox.Show(ex.Message, "Error");
                DialogResult = DialogResult.Cancel;
            }
        }


        #endregion

        private void frmSetPermission_Load(object sender, EventArgs e)
        {
            _cmdForPermission = MsSqlHelper.ExecuteDataTable(ZenDatabase.ConnectionString, "zPermission_byUserID", _userID);

            if (_cmdForPermission == null)
                DialogResult = DialogResult.Cancel;

            _cmdRows = _cmdForPermission.AsEnumerable();
            InitTreePermission(tvwDm, "zdm");
            InitTreePermission(tvwPs, "zPs");
            InitTreePermission(tvwBc, "zbc");
            InitTreePermission(tvwSys, "zsys");
        }

        private void InitTreePermission(TreeView tvw, string keyGroup)
        {
            tvw.Nodes.Clear();

            var rootRow = _cmdRows.Where(x => x.Field<string>("parent_key") == keyGroup && x.Field<bool>("is_group")).OrderBy(x => x.Field<int>("ordinal"));
            if (rootRow == null)
                return;

            foreach (var rr in rootRow)
            {
                string rootKey = rr["cmd_key"].zToString();
                TreeNode root = tvw.Nodes.Add(rr["text"].zToString());
                root.Name = rootKey;
                root.Checked = (rr["allow"].zToInt() == 1 ? true : false);

                var rows = _cmdRows.Where(x => x.Field<string>("parent_key") == rootKey).OrderBy(x => x.Field<int>("ordinal"));

                foreach (var r in rows)
                {
                    root.Nodes.Add(
                        new TreeNode(r["text"].zToString())
                        {
                            Name = r["cmd_key"].zToString(),
                            Checked = (r["allow"].zToInt() == 1 ? true : false)
                        });
                }
            }

            tvw.ExpandAll();
            if (tvw.Nodes != null && tvw.Nodes.Count > 0)
            {
                tvw.TopNode = tvw.Nodes[0];
            }


        }
        private void CheckNode(TreeNode node, bool isChecked)
        {
            foreach (TreeNode n in node.Nodes)
            {
                n.Checked = isChecked;
                CheckNode(n, isChecked);
            }
        }
        private void CheckNode(TreeNode node)
        {
            CheckNode(node, node.Checked);
        }
        private void chkDmAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (TreeNode node in tvwDm.Nodes)
            {
                node.Checked = chkDmAll.Checked;
                CheckNode(node);
            }
        }

        private void chkPsAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (TreeNode node in tvwPs.Nodes)
            {
                node.Checked = chkPsAll.Checked;
                CheckNode(node);
            }
        }

        private void chkBcAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (TreeNode node in tvwBc.Nodes)
            {
                node.Checked = chkBcAll.Checked;
                CheckNode(node);
            }
        }

        private void chkSysAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (TreeNode node in tvwSys.Nodes)
            {
                node.Checked = chkSysAll.Checked;
                CheckNode(node);
            }
        }

        private void tvwDm_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CheckNode(e.Node);
        }

        private string GetIds(TreeNode node)
        {
            if (node.Nodes.Count == 0 && node.Checked)
                return "," + node.Name;
            else if (node.Checked == false)
            {
                string ret = "";
                foreach (TreeNode n in node.Nodes)
                    ret += GetIds(n);

                return ret;
            }
            else
            {
                string ret = "," + node.Name;
                foreach (TreeNode n in node.Nodes)
                    ret += GetIds(n);

                return ret;
            }
        }
    }
}
