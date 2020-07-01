namespace ExcelToMySqlDatabase
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxExcelURL = new System.Windows.Forms.TextBox();
            this.textBoxServerURL = new System.Windows.Forms.TextBox();
            this.buttonExcelURL = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClearListBoxMessage = new System.Windows.Forms.Button();
            this.buttonStartingExport = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxDataBase = new System.Windows.Forms.TextBox();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.checkBoxRememberUser = new System.Windows.Forms.CheckBox();
            this.checkBoxRememberPassword = new System.Windows.Forms.CheckBox();
            this.listBox = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxDistinguish = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "表格地址:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 297);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "后端地址:";
            // 
            // textBoxExcelURL
            // 
            this.textBoxExcelURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxExcelURL.Location = new System.Drawing.Point(79, 257);
            this.textBoxExcelURL.Name = "textBoxExcelURL";
            this.textBoxExcelURL.Size = new System.Drawing.Size(367, 21);
            this.textBoxExcelURL.TabIndex = 10;
            // 
            // textBoxServerURL
            // 
            this.textBoxServerURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxServerURL.Location = new System.Drawing.Point(79, 294);
            this.textBoxServerURL.Name = "textBoxServerURL";
            this.textBoxServerURL.Size = new System.Drawing.Size(430, 21);
            this.textBoxServerURL.TabIndex = 11;
            // 
            // buttonExcelURL
            // 
            this.buttonExcelURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExcelURL.Location = new System.Drawing.Point(462, 255);
            this.buttonExcelURL.Name = "buttonExcelURL";
            this.buttonExcelURL.Size = new System.Drawing.Size(47, 23);
            this.buttonExcelURL.TabIndex = 12;
            this.buttonExcelURL.Text = "...";
            this.buttonExcelURL.UseVisualStyleBackColor = true;
            this.buttonExcelURL.Click += new System.EventHandler(this.buttonExcelURL_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(378, 486);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "Madeby:WildHierophant";
            // 
            // buttonClearListBoxMessage
            // 
            this.buttonClearListBoxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearListBoxMessage.Location = new System.Drawing.Point(421, 458);
            this.buttonClearListBoxMessage.Name = "buttonClearListBoxMessage";
            this.buttonClearListBoxMessage.Size = new System.Drawing.Size(88, 23);
            this.buttonClearListBoxMessage.TabIndex = 16;
            this.buttonClearListBoxMessage.Text = "清理消息";
            this.buttonClearListBoxMessage.UseVisualStyleBackColor = true;
            this.buttonClearListBoxMessage.Click += new System.EventHandler(this.buttonClearListBoxMessage_Click);
            // 
            // buttonStartingExport
            // 
            this.buttonStartingExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStartingExport.Location = new System.Drawing.Point(327, 458);
            this.buttonStartingExport.Name = "buttonStartingExport";
            this.buttonStartingExport.Size = new System.Drawing.Size(88, 23);
            this.buttonStartingExport.TabIndex = 15;
            this.buttonStartingExport.Text = "导出数据";
            this.buttonStartingExport.UseVisualStyleBackColor = true;
            this.buttonStartingExport.Click += new System.EventHandler(this.buttonStartingExport_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 399);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "用户名:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 434);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "密码:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 330);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "端口号:";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPort.Location = new System.Drawing.Point(79, 327);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(430, 21);
            this.textBoxPort.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 363);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 22;
            this.label7.Text = "数据库名:";
            // 
            // textBoxDataBase
            // 
            this.textBoxDataBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDataBase.Location = new System.Drawing.Point(79, 360);
            this.textBoxDataBase.Name = "textBoxDataBase";
            this.textBoxDataBase.Size = new System.Drawing.Size(430, 21);
            this.textBoxDataBase.TabIndex = 23;
            // 
            // textBoxUser
            // 
            this.textBoxUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUser.Location = new System.Drawing.Point(79, 396);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(346, 21);
            this.textBoxUser.TabIndex = 24;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPassword.Location = new System.Drawing.Point(79, 431);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(346, 21);
            this.textBoxPassword.TabIndex = 25;
            // 
            // checkBoxRememberUser
            // 
            this.checkBoxRememberUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxRememberUser.AutoSize = true;
            this.checkBoxRememberUser.Location = new System.Drawing.Point(437, 398);
            this.checkBoxRememberUser.Name = "checkBoxRememberUser";
            this.checkBoxRememberUser.Size = new System.Drawing.Size(72, 16);
            this.checkBoxRememberUser.TabIndex = 28;
            this.checkBoxRememberUser.Text = "记住账号";
            this.checkBoxRememberUser.UseVisualStyleBackColor = true;
            // 
            // checkBoxRememberPassword
            // 
            this.checkBoxRememberPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxRememberPassword.AutoSize = true;
            this.checkBoxRememberPassword.Location = new System.Drawing.Point(437, 433);
            this.checkBoxRememberPassword.Name = "checkBoxRememberPassword";
            this.checkBoxRememberPassword.Size = new System.Drawing.Size(72, 16);
            this.checkBoxRememberPassword.TabIndex = 29;
            this.checkBoxRememberPassword.Text = "记住密码";
            this.checkBoxRememberPassword.UseVisualStyleBackColor = true;
            // 
            // listBox
            // 
            this.listBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 12;
            this.listBox.Location = new System.Drawing.Point(23, 12);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(486, 232);
            this.listBox.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 463);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 31;
            this.label8.Text = "识别后缀:";
            // 
            // textBoxDistinguish
            // 
            this.textBoxDistinguish.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDistinguish.Location = new System.Drawing.Point(79, 460);
            this.textBoxDistinguish.Name = "textBoxDistinguish";
            this.textBoxDistinguish.Size = new System.Drawing.Size(242, 21);
            this.textBoxDistinguish.TabIndex = 32;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 507);
            this.Controls.Add(this.textBoxDistinguish);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.checkBoxRememberPassword);
            this.Controls.Add(this.checkBoxRememberUser);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUser);
            this.Controls.Add(this.textBoxDataBase);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonClearListBoxMessage);
            this.Controls.Add(this.buttonStartingExport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonExcelURL);
            this.Controls.Add(this.textBoxServerURL);
            this.Controls.Add(this.textBoxExcelURL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "FormMain";
            this.Text = "ExcelToMySqlDatabase工具";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxExcelURL;
        private System.Windows.Forms.TextBox textBoxServerURL;
        private System.Windows.Forms.Button buttonExcelURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClearListBoxMessage;
        private System.Windows.Forms.Button buttonStartingExport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxDataBase;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.CheckBox checkBoxRememberUser;
        private System.Windows.Forms.CheckBox checkBoxRememberPassword;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxDistinguish;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}

