

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
            Autoburn.Manager.ChipInfo chipInfo1 = new Autoburn.Manager.ChipInfo();
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
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.AdbStatusToollable = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.AccordionPanel = new Autoburn.Ui.AccordionPanel();
            this.palletPanelShow1 = new Autoburn.Ui.PalletPanelShow();
            this.MainmenuItem.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.MainmenuItem.Size = new System.Drawing.Size(1271, 28);
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
            this.openFileDialog.Size = new System.Drawing.Size(144, 26);
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
            // StatusStrip
            // 
            this.StatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AdbStatusToollable});
            this.StatusStrip.Location = new System.Drawing.Point(0, 713);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.StatusStrip.Size = new System.Drawing.Size(1271, 25);
            this.StatusStrip.TabIndex = 7;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // AdbStatusToollable
            // 
            this.AdbStatusToollable.Name = "AdbStatusToollable";
            this.AdbStatusToollable.Size = new System.Drawing.Size(84, 20);
            this.AdbStatusToollable.Text = "设备已断开";
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
            this.tableLayoutPanel1.Controls.Add(this.AccordionPanel, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.palletPanelShow1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1271, 685);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // AccordionPanel
            // 
            this.AccordionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.AccordionPanel, 2);
            chipInfo1.burner = null;
            chipInfo1.name = null;
            chipInfo1.note = null;
            chipInfo1.package = null;
            chipInfo1.series = null;
            chipInfo1.type = null;
            chipInfo1.vendor = null;
            this.AccordionPanel.CurrentChipInfo = chipInfo1;
            this.AccordionPanel.CurrentProjectInfoHashTable = ((System.Collections.Hashtable)(resources.GetObject("AccordionPanel.CurrentProjectInfoHashTable")));
            this.AccordionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AccordionPanel.Location = new System.Drawing.Point(1019, 2);
            this.AccordionPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AccordionPanel.Name = "AccordionPanel";
            this.tableLayoutPanel1.SetRowSpan(this.AccordionPanel, 10);
            this.AccordionPanel.Size = new System.Drawing.Size(249, 681);
            this.AccordionPanel.TabIndex = 1;
            // 
            // palletPanelShow1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.palletPanelShow1, 6);
            this.palletPanelShow1.Location = new System.Drawing.Point(3, 3);
            this.palletPanelShow1.Name = "palletPanelShow1";
            this.tableLayoutPanel1.SetRowSpan(this.palletPanelShow1, 7);
            this.palletPanelShow1.Size = new System.Drawing.Size(756, 470);
            this.palletPanelShow1.TabIndex = 2;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 738);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.MainmenuItem);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainmenuItem;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "自动烧录机";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainmenuItem.ResumeLayout(false);
            this.MainmenuItem.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
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
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel AdbStatusToollable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem NewProjectStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenProjectStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProjecthistorytoolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private AccordionPanel AccordionPanel;
        private PalletPanelShow palletPanelShow1;
    }
}

