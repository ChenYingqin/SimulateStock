using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using BLL;

namespace UI
{
    public partial class UserRegister : Form
    {
        LoginBLL loginBll = new LoginBLL();
        public UserRegister()
        {
            InitializeComponent();
        }

        private void textBoxUserName_Leave(object sender, EventArgs e)
        {
            if (textBoxUserName.Text == "")
                labUserNameTip.Visible = true;
            else
                labUserNameTip.Visible = false;
            DataTable dt = new DataTable();
            dt = loginBll.GetAllUserInfo();
            bool IsUserExist = false;
            for(int i=0;i<dt.Rows.Count;i++)
            {
                if(textBoxUserName.Text.Trim()==dt.Rows[i][0].ToString().Trim())
                {
                    IsUserExist = true;
                    break;
                }
            }
            if(IsUserExist)
            {
                MessageBox.Show("该用户名已经被注册！", "信息提示", MessageBoxButtons.OK);
            }
        }

        private void textBoxUserPasswdOne_Leave(object sender, EventArgs e)
        {
            if (textBoxUserPasswdOne.Text == "")
                labUserPasswdOneTip.Visible = true;
            else
                labUserPasswdOneTip.Visible = false;
        }

        private void textBoxUserPasswdTwo_Leave(object sender, EventArgs e)
        {
            if (textBoxUserPasswdTwo.Text == "")
                labUserPasswdTwoTip.Visible = true;
            else
                labUserPasswdTwoTip.Visible = false;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(textBoxUserName.Text=="")
            {
                MessageBox.Show("错误，注册账号为空！", "信息提示", MessageBoxButtons.OK);
                return;
            }
            if(textBoxUserPasswdOne.Text=="")
            {
                MessageBox.Show("错误，密码为空！", "信息提示", MessageBoxButtons.OK);
                return;
            }
            if(textBoxUserPasswdTwo.Text=="")
            {
                MessageBox.Show("错误，重复密码为空！", "信息提示", MessageBoxButtons.OK);
                return;
            }
            if(textBoxUserPasswdOne.Text.Trim()!=textBoxUserPasswdTwo.Text.Trim())
            {
                MessageBox.Show("错误，输入密码不一致！", "信息提示", MessageBoxButtons.OK);
                return;
            }
            UserInfo userInfo = new UserInfo();
            userInfo.UserName = textBoxUserName.Text.Trim();
            userInfo.Password = textBoxUserPasswdTwo.Text.Trim();            
            userInfo.Address = textBoxUserAddress.Text.Trim();
            userInfo.Phone = textBoxUserPhone.Text.Trim();
            userInfo.TotalAssets = 100000;
            userInfo.AvailableFund = 100000;
            loginBll.InsertUserInfo(userInfo);//将新注册用户的信息插入数据库中
            MessageBox.Show("注册成功", "信息提示", MessageBoxButtons.OK);
        }
    }
}
