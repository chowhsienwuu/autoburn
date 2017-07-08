

using Autoburn.Ui;

namespace Autoburn.Ui
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.MainmenuItem = new System.Windows.Forms.MenuStrip();
            this.FileStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.ToolStripMenuItem();
            this.ProjectStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewProjectStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenProjectStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProjecthistorytoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChipStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChooseChipMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.statusdiscovery = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusTcpStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.statustableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.accordionPanel1 = new Autoburn.Ui.AccordionPanel();
            this.mainWindowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.MainmenuItem.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.statustableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainWindowBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MainmenuItem
            // 
            this.MainmenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.MainmenuItem.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainmenuItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileStripMenuItem,
            this.ProjectStripMenuItem,
            this.ChipStripMenuItem,
            this.设置ToolStripMenuItem,
            this.HelpMenuItem});
            this.MainmenuItem.Location = new System.Drawing.Point(0, 0);
            this.MainmenuItem.Name = "MainmenuItem";
            this.MainmenuItem.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.MainmenuItem.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MainmenuItem.Size = new System.Drawing.Size(1016, 28);
            this.MainmenuItem.TabIndex = 5;
            this.MainmenuItem.Text = "menuStrip1";
            // 
            // FileStripMenuItem
            // 
            this.FileStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileDialog});
            this.FileStripMenuItem.Name = "FileStripMenuItem";
            this.FileStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.FileStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.FileStripMenuItem.Text = "文件";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Name = "openFileDialog";
            this.openFileDialog.Size = new System.Drawing.Size(181, 26);
            this.openFileDialog.Text = "打开文件";
            this.openFileDialog.Click += new System.EventHandler(this.openFileDialog_Click);
            // 
            // ProjectStripMenuItem
            // 
            this.ProjectStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewProjectStripMenuItem,
            this.OpenProjectStripMenuItem,
            this.ProjecthistorytoolStripMenuItem});
            this.ProjectStripMenuItem.Name = "ProjectStripMenuItem";
            this.ProjectStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.ProjectStripMenuItem.Text = "工程";
            // 
            // NewProjectStripMenuItem
            // 
            this.NewProjectStripMenuItem.Name = "NewProjectStripMenuItem";
            this.NewProjectStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.NewProjectStripMenuItem.Text = "新建工程";
            this.NewProjectStripMenuItem.Click += new System.EventHandler(this.NewProjectStripMenuItem_Click);
            // 
            // OpenProjectStripMenuItem
            // 
            this.OpenProjectStripMenuItem.Name = "OpenProjectStripMenuItem";
            this.OpenProjectStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.OpenProjectStripMenuItem.Text = "打开工程";
            this.OpenProjectStripMenuItem.Click += new System.EventHandler(this.OpenProjectStripMenuItem_Click);
            // 
            // ProjecthistorytoolStripMenuItem
            // 
            this.ProjecthistorytoolStripMenuItem.Name = "ProjecthistorytoolStripMenuItem";
            this.ProjecthistorytoolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.ProjecthistorytoolStripMenuItem.Text = "最近打开的工程";
            this.ProjecthistorytoolStripMenuItem.MouseHover += new System.EventHandler(this.ProjecthistorytoolStripMenuItem_MouseHover);
            // 
            // ChipStripMenuItem
            // 
            this.ChipStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChooseChipMenuItem});
            this.ChipStripMenuItem.Name = "ChipStripMenuItem";
            this.ChipStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.ChipStripMenuItem.Text = "芯片";
            // 
            // ChooseChipMenuItem
            // 
            this.ChooseChipMenuItem.Name = "ChooseChipMenuItem";
            this.ChooseChipMenuItem.Size = new System.Drawing.Size(144, 26);
            this.ChooseChipMenuItem.Text = "选择芯片";
            this.ChooseChipMenuItem.Click += new System.EventHandler(this.ChooseChipMenuItem_Click);
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
            this.AboutMenuItem.Size = new System.Drawing.Size(114, 26);
            this.AboutMenuItem.Text = "关于";
            this.AboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripSplitButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1016, 27);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton4.Text = "toolStripButton4";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton5.Text = "toolStripButton5";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(39, 24);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // StatusStrip
            // 
            this.StatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusdiscovery,
            this.statusTcpStatus});
            this.StatusStrip.Location = new System.Drawing.Point(0, 635);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.StatusStrip.Size = new System.Drawing.Size(1016, 25);
            this.StatusStrip.TabIndex = 7;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // statusdiscovery
            // 
            this.statusdiscovery.Name = "statusdiscovery";
            this.statusdiscovery.Size = new System.Drawing.Size(167, 20);
            this.statusdiscovery.Text = "toolStripStatusLabel1";
            // 
            // statusTcpStatus
            // 
            this.statusTcpStatus.Name = "statusTcpStatus";
            this.statusTcpStatus.Size = new System.Drawing.Size(167, 20);
            this.statusTcpStatus.Text = "toolStripStatusLabel1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.statustableLayoutPanel2, 8, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 55);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1016, 580);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // statustableLayoutPanel2
            // 
            this.statustableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel1.SetColumnSpan(this.statustableLayoutPanel2, 2);
            this.statustableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.statustableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.statustableLayoutPanel2.Controls.Add(this.accordionPanel1, 0, 0);
            this.statustableLayoutPanel2.Location = new System.Drawing.Point(811, 2);
            this.statustableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.statustableLayoutPanel2.Name = "statustableLayoutPanel2";
            this.statustableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel1.SetRowSpan(this.statustableLayoutPanel2, 10);
            this.statustableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.statustableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.statustableLayoutPanel2.Size = new System.Drawing.Size(200, 562);
            this.statustableLayoutPanel2.TabIndex = 0;
            // 
            // accordionPanel1
            // 
            this.accordionPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.accordionPanel1.ChipinforBurner = null;
            this.accordionPanel1.ChipinforCapcity = null;
            this.accordionPanel1.ChipinforName = null;
            this.accordionPanel1.ChipinforPackage = null;
            this.accordionPanel1.ChipinfoVendor = null;
            this.accordionPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accordionPanel1.Location = new System.Drawing.Point(3, 2);
            this.accordionPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.accordionPanel1.Name = "accordionPanel1";
            this.accordionPanel1.Size = new System.Drawing.Size(194, 558);
            this.accordionPanel1.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 660);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.MainmenuItem);
            this.MainMenuStrip = this.MainmenuItem;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainmenuItem.ResumeLayout(false);
            this.MainmenuItem.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.statustableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainWindowBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MainmenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem ProjectStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChipStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem ChooseChipMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusdiscovery;
        private System.Windows.Forms.ToolStripStatusLabel statusTcpStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel statustableLayoutPanel2;
        private AccordionPanel accordionPanel1;
        private System.Windows.Forms.ToolStripMenuItem NewProjectStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenProjectStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProjecthistorytoolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.BindingSource mainWindowBindingSource;
    }
}

