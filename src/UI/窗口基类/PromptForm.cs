using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{   
    /// <summary>
    /// 提示框状态：成功、失败、警告
    /// </summary>
    /// <author>宋佳恒</author>
    /// <date>2017-04-13</date>
    public enum PromptState
    {
        Success,//成功
        Fail,   //失败
        Warn    //警告
    }
    /// <summary>
    /// 提示框，失败、成功、警告
    /// add by zhengling 2017年4月13日
    /// </summary>
    public partial class PromptForm : UI.FrameForm
    {
        //private static PromptForm pf;
        ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PromptForm));
        public PromptForm(PromptState state, String message)
        {
            InitializeComponent();
            try
            {   
                /**
                 * 之前使用了3个pictureBox来展示三种图标，
                 * 实际上只需要一个pictureBox就可以展示，
                 * 另外加上了对话框状态的枚举状态，通过switch case来判断
                 * Modyfied by:sjh
                 * Modyfied time:2017-04-13
                 * */
                switch(state)
                {
                    case PromptState.Success: /*this.pictureBox_success.Visible = true;
                                              this.pictureBox_fail.Visible = false;
                                              this.pictureBox_warm.Visible = false;*/
                                              this.pictureBox.Image = global::UI.Properties.Resources.pictureBox_success_Image;
                                              break;
                    case PromptState.Fail:    /*this.pictureBox_success.Visible = false;
                                              this.pictureBox_fail.Visible = true;
                                              this.pictureBox_warm.Visible = false;*/
                                              this.pictureBox.Image = global::UI.Properties.Resources.pictureBox_fail_Image;
                                              break;
                    case PromptState.Warn:    /*this.pictureBox_success.Visible = false;
                                              this.pictureBox_fail.Visible = false;
                                              this.pictureBox_warm.Visible = true;*/

                                              this.pictureBox.Image = global::UI.Properties.Resources.pictureBox_warn_Image;
                                              break;
                    default:break;
                }         
                this.label1.Text = message;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        public static void ShowPromptForm(Form parent, PromptState state, String message)
        {
            PromptForm pf = new PromptForm(state, message);
            //pf.TopLevel = false;
            //parent.Controls.Add(pf);
            //pf.Parent = parent;
            //pf.Location = new Point((parent.Width - pf.Width) / 2, (parent.Height - pf.Height) / 2);
            pf.StartPosition = FormStartPosition.CenterScreen;
            // pf.BringToFront();
            //pf.CenterToParent();
            pf.ShowDialog();
        }     
            //pf.Dispose();

        private void iButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
