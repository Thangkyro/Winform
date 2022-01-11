using CoreBase;
using CoreBase.DAL;
using CoreBase.DataAccessLayer;
using CoreBase.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AusNail.Login
{
    public partial class frmChangePassword : CoreBase.WinForm.Dictionary.FormCollectInfo
    {
        public frmChangePassword()
        {
            InitializeComponent();
            this.BackColor = NailApp.ColorUser.IsEmpty == true || NailApp.ColorUser.Name == "0" ? ThemeColor.ChangeColorBrightness(ColorTranslator.FromHtml("#c0ffff"), 0) : NailApp.ColorUser;
        }

        private bool ValidData()
        {
            if (txtPasswordOld.Text == "")
            {
                //ZenMessage.Show("Chưa nhập mật khẩu cũ.", ZenMessageType.Warning);
                lblMessInfomation.Text = "Please input Old Password";
                txtPasswordOld.Focus();
                return false;
            }
            //Kiem tra mat khau cu
            DataRow row = null;
            using (SecurityDAO sDao = new SecurityDAO())
                row = sDao.GetUserRow(NailApp.CurrentUserRow["user_name"].zToString(), 
                    Encryptor.MD5Hash("123456Aa") + 
                    //Encryptor.MD5Hash(NailApp.BranchID) + 
                    Encryptor.MD5Hash(NailApp.CurrentUserId.ToString()) + 
                    Encryptor.MD5Hash(txtPasswordOld.Text.Trim()));

            if (row == null)
            {
                //MessageBox.Show("Mật khẩu cũ không đúng, vui lòng nhập lại.");
                lblMessInfomation.Text = "Old Password is invalid.";
                txtPasswordOld.Focus();
                return false;
            }

            if (txtPassword.Text == "")
            {
                //ZenMessage.Show("Chưa nhập mật khẩu.", ZenMessageType.Warning);
                lblMessInfomation.Text = "Please input Password";
                txtPassword.Focus();
                return false;
            }
            if (txtRePassword.Text == "")
            {
                //ZenMessage.Show("Chưa nhập lại mật khẩu.", ZenMessageType.Warning);
                lblMessInfomation.Text = "Please input Re Password";
                txtRePassword.Focus();
                return false;
            }
            if (txtPassword.Text != txtRePassword.Text)
            {
                //ZenMessage.Show("Mật khẩu xác nhận không đúng.", ZenMessageType.Warning);
                lblMessInfomation.Text = "RePassword diferent Password";
                txtRePassword.Focus();
                return false;
            }
            return true;
        }

        private void SaveData()
        {
            //string password = Encryptor.MD5Hash("123456Aa" + NailApp.BranchID + NailApp.CurrentUserId.ToString() + txtPassword.Text);
            string password = Encryptor.MD5Hash("123456Aa") + 
                //Encryptor.MD5Hash(NailApp.BranchID) + 
                Encryptor.MD5Hash(NailApp.CurrentUserId.ToString()) + 
                Encryptor.MD5Hash(txtPassword.Text.Trim());
            using (SecurityDAO sDao = new SecurityDAO())
                sDao.SetPassword(NailApp.CurrentUserRow["Userid"].zToInt(), password);

        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (!ValidData())
            {
                MessageBox.Show("Change Password Failed");
            }
            else
            {
                SaveData();
                MessageBox.Show("Change Password Successfully");
            }

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
