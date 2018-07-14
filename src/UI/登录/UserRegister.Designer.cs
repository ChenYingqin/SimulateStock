namespace UI
{
    partial class UserRegister
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxUserPasswdOne = new System.Windows.Forms.TextBox();
            this.textBoxUserPasswdTwo = new System.Windows.Forms.TextBox();
            this.textBoxUserAddress = new System.Windows.Forms.TextBox();
            this.textBoxUserPhone = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.labStar9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labUserNameTip = new System.Windows.Forms.Label();
            this.labUserPasswdOneTip = new System.Windows.Forms.Label();
            this.labUserPasswdTwoTip = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(80, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "密码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(80, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "账号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(48, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "确认密码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(80, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "地址";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(48, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "电话号码";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxUserName.Location = new System.Drawing.Point(136, 63);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(130, 21);
            this.textBoxUserName.TabIndex = 5;
            this.textBoxUserName.Leave += new System.EventHandler(this.textBoxUserName_Leave);
            // 
            // textBoxUserPasswdOne
            // 
            this.textBoxUserPasswdOne.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxUserPasswdOne.Location = new System.Drawing.Point(136, 105);
            this.textBoxUserPasswdOne.Name = "textBoxUserPasswdOne";
            this.textBoxUserPasswdOne.Size = new System.Drawing.Size(130, 21);
            this.textBoxUserPasswdOne.TabIndex = 6;
            this.textBoxUserPasswdOne.Leave += new System.EventHandler(this.textBoxUserPasswdOne_Leave);
            // 
            // textBoxUserPasswdTwo
            // 
            this.textBoxUserPasswdTwo.Location = new System.Drawing.Point(136, 155);
            this.textBoxUserPasswdTwo.Name = "textBoxUserPasswdTwo";
            this.textBoxUserPasswdTwo.Size = new System.Drawing.Size(130, 21);
            this.textBoxUserPasswdTwo.TabIndex = 7;
            this.textBoxUserPasswdTwo.Leave += new System.EventHandler(this.textBoxUserPasswdTwo_Leave);
            // 
            // textBoxUserAddress
            // 
            this.textBoxUserAddress.Location = new System.Drawing.Point(135, 206);
            this.textBoxUserAddress.Name = "textBoxUserAddress";
            this.textBoxUserAddress.Size = new System.Drawing.Size(212, 21);
            this.textBoxUserAddress.TabIndex = 8;
            // 
            // textBoxUserPhone
            // 
            this.textBoxUserPhone.Location = new System.Drawing.Point(136, 250);
            this.textBoxUserPhone.Name = "textBoxUserPhone";
            this.textBoxUserPhone.Size = new System.Drawing.Size(212, 21);
            this.textBoxUserPhone.TabIndex = 9;
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRegister.Location = new System.Drawing.Point(149, 315);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(97, 31);
            this.btnRegister.TabIndex = 10;
            this.btnRegister.Text = "注册";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // labStar9
            // 
            this.labStar9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labStar9.ForeColor = System.Drawing.Color.Red;
            this.labStar9.Location = new System.Drawing.Point(66, 66);
            this.labStar9.Name = "labStar9";
            this.labStar9.Size = new System.Drawing.Size(17, 20);
            this.labStar9.TabIndex = 45;
            this.labStar9.Text = "*";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(66, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 20);
            this.label6.TabIndex = 46;
            this.label6.Text = "*";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(34, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 20);
            this.label7.TabIndex = 47;
            this.label7.Text = "*";
            // 
            // labUserNameTip
            // 
            this.labUserNameTip.AutoSize = true;
            this.labUserNameTip.Location = new System.Drawing.Point(283, 72);
            this.labUserNameTip.Name = "labUserNameTip";
            this.labUserNameTip.Size = new System.Drawing.Size(77, 12);
            this.labUserNameTip.TabIndex = 48;
            this.labUserNameTip.Text = "账号不能为空";
            this.labUserNameTip.Visible = false;
            // 
            // labUserPasswdOneTip
            // 
            this.labUserPasswdOneTip.AutoSize = true;
            this.labUserPasswdOneTip.Location = new System.Drawing.Point(283, 114);
            this.labUserPasswdOneTip.Name = "labUserPasswdOneTip";
            this.labUserPasswdOneTip.Size = new System.Drawing.Size(77, 12);
            this.labUserPasswdOneTip.TabIndex = 49;
            this.labUserPasswdOneTip.Text = "密码不能为空";
            this.labUserPasswdOneTip.Visible = false;
            // 
            // labUserPasswdTwoTip
            // 
            this.labUserPasswdTwoTip.AutoSize = true;
            this.labUserPasswdTwoTip.Location = new System.Drawing.Point(283, 160);
            this.labUserPasswdTwoTip.Name = "labUserPasswdTwoTip";
            this.labUserPasswdTwoTip.Size = new System.Drawing.Size(101, 12);
            this.labUserPasswdTwoTip.TabIndex = 50;
            this.labUserPasswdTwoTip.Text = "确认密码不能为空";
            this.labUserPasswdTwoTip.Visible = false;
            // 
            // UserRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 410);
            this.Controls.Add(this.labUserPasswdTwoTip);
            this.Controls.Add(this.labUserPasswdOneTip);
            this.Controls.Add(this.labUserNameTip);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labStar9);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.textBoxUserPhone);
            this.Controls.Add(this.textBoxUserAddress);
            this.Controls.Add(this.textBoxUserPasswdTwo);
            this.Controls.Add(this.textBoxUserPasswdOne);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UserRegister";
            this.Text = "注册";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxUserPasswdOne;
        private System.Windows.Forms.TextBox textBoxUserPasswdTwo;
        private System.Windows.Forms.TextBox textBoxUserAddress;
        private System.Windows.Forms.TextBox textBoxUserPhone;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label labStar9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labUserNameTip;
        private System.Windows.Forms.Label labUserPasswdOneTip;
        private System.Windows.Forms.Label labUserPasswdTwoTip;
    }
}