namespace autoburn
{
    partial class MainWindow
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
            this.discovery = new System.Windows.Forms.Label();
            this.tcpstatus = new System.Windows.Forms.Label();
            this.receivemsgstring = new System.Windows.Forms.TextBox();
            this.sendmsgstring = new System.Windows.Forms.TextBox();
            this.sendtcpcmd = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ChooseChipMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // discovery
            // 
            this.discovery.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.discovery.AutoSize = true;
            this.discovery.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.discovery.Location = new System.Drawing.Point(-5, 47);
            this.discovery.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.discovery.Name = "discovery";
            this.discovery.Size = new System.Drawing.Size(129, 25);
            this.discovery.TabIndex = 0;
            this.discovery.Text = "discovery";
            // 
            // tcpstatus
            // 
            this.tcpstatus.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.tcpstatus.AutoSize = true;
            this.tcpstatus.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tcpstatus.Location = new System.Drawing.Point(17, 72);
            this.tcpstatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tcpstatus.Name = "tcpstatus";
            this.tcpstatus.Size = new System.Drawing.Size(142, 25);
            this.tcpstatus.TabIndex = 1;
            this.tcpstatus.Text = "tcpstatus ";
            // 
            // receivemsgstring
            // 
            this.receivemsgstring.Location = new System.Drawing.Point(12, 100);
            this.receivemsgstring.Multiline = true;
            this.receivemsgstring.Name = "receivemsgstring";
            this.receivemsgstring.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.receivemsgstring.Size = new System.Drawing.Size(186, 462);
            this.receivemsgstring.TabIndex = 2;
            // 
            // sendmsgstring
            // 
            this.sendmsgstring.Location = new System.Drawing.Point(227, 100);
            this.sendmsgstring.Multiline = true;
            this.sendmsgstring.Name = "sendmsgstring";
            this.sendmsgstring.Size = new System.Drawing.Size(186, 320);
            this.sendmsgstring.TabIndex = 3;
            // 
            // sendtcpcmd
            // 
            this.sendtcpcmd.Location = new System.Drawing.Point(271, 452);
            this.sendtcpcmd.Name = "sendtcpcmd";
            this.sendtcpcmd.Size = new System.Drawing.Size(123, 23);
            this.sendtcpcmd.TabIndex = 4;
            this.sendtcpcmd.Text = "sendtcpcmd";
            this.sendtcpcmd.UseVisualStyleBackColor = true;
            this.sendtcpcmd.Click += new System.EventHandler(this.sendtcpcmd_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.设置ToolStripMenuItem,
            this.HelpMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1065, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.toolStripMenuItem1.Size = new System.Drawing.Size(51, 24);
            this.toolStripMenuItem1.Text = "文件";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(120, 26);
            this.toolStripMenuItem5.Text = "1558";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem7});
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(120, 26);
            this.toolStripMenuItem6.Text = "44";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(102, 26);
            this.toolStripMenuItem7.Text = "44";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(51, 24);
            this.toolStripMenuItem2.Text = "工程";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChooseChipMenuItem});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(51, 24);
            this.toolStripMenuItem3.Text = "芯片";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // HelpMenuItem
            // 
            this.HelpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutMenuItem});
            this.HelpMenuItem.Name = "HelpMenuItem";
            this.HelpMenuItem.Size = new System.Drawing.Size(51, 24);
            this.HelpMenuItem.Text = "帮助";
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.Name = "AboutMenuItem";
            this.AboutMenuItem.Size = new System.Drawing.Size(181, 26);
            this.AboutMenuItem.Text = "关于";
            this.AboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // ChooseChipMenuItem
            // 
            this.ChooseChipMenuItem.Name = "ChooseChipMenuItem";
            this.ChooseChipMenuItem.Size = new System.Drawing.Size(181, 26);
            this.ChooseChipMenuItem.Text = "选择芯片";
            this.ChooseChipMenuItem.Click += new System.EventHandler(this.ChooseChipMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 616);
            this.Controls.Add(this.sendtcpcmd);
            this.Controls.Add(this.sendmsgstring);
            this.Controls.Add(this.receivemsgstring);
            this.Controls.Add(this.tcpstatus);
            this.Controls.Add(this.discovery);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label discovery;
        private System.Windows.Forms.Label tcpstatus;
        private System.Windows.Forms.TextBox receivemsgstring;
        private System.Windows.Forms.TextBox sendmsgstring;
        private System.Windows.Forms.Button sendtcpcmd;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem ChooseChipMenuItem;
    }
}

