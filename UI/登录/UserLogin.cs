using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Model;

namespace UI
{
    public partial class UserLogin : Form
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName,userPasswd;
            userName=textBox1.Text.Trim();
            userPasswd=textBox2.Text.Trim();

            LoginBLL loginBll = new LoginBLL(userName, userPasswd);
            bool IsUserRight=loginBll.IsUserRight();
            if(IsUserRight)
            {
                UserInfo model = new UserInfo();
                DataTable da = loginBll.GetUserInfo();
                model.UserName = da.Rows[0][0].ToString().Trim();
                model.TotalAssets = double.Parse(da.Rows[0][2].ToString());
                model.AvailableFund = double.Parse(da.Rows[0][3].ToString());
                model.Address = da.Rows[0][4].ToString().Trim();
                model.Phone = da.Rows[0][5].ToString().Trim();
                LoginInfo.loginInfo = model;
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("用户名、密码错误！", "信息提示", MessageBoxButtons.OK);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserRegister userRegister = new UserRegister();

            userRegister.ShowDialog();
        }
    }
}
