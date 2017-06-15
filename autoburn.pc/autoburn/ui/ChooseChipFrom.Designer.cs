namespace Autoburn.Ui
{
    partial class ChooseChipFrom
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
            this.searchComBox = new System.Windows.Forms.ComboBox();
            this.ChipTreeView = new System.Windows.Forms.TreeView();
            this.ChipInfoListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Ok = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "搜索芯片型号:　";
            // 
            // searchComBox
            // 
            this.searchComBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.searchComBox.FormattingEnabled = true;
            this.searchComBox.Location = new System.Drawing.Point(295, 0);
            this.searchComBox.Margin = new System.Windows.Forms.Padding(0, 2, 3, 2);
            this.searchComBox.Name = "searchComBox";
            this.searchComBox.Size = new System.Drawing.Size(574, 23);
            this.searchComBox.TabIndex = 2;
            this.searchComBox.SelectedIndexChanged += new System.EventHandler(this.searchComBox_SelectedIndexChanged);
            this.searchComBox.TextChanged += new System.EventHandler(this.searchComBox_TextChanged);
            // 
            // ChipTreeView
            // 
            this.ChipTreeView.BackColor = System.Drawing.SystemColors.Info;
            this.ChipTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChipTreeView.Location = new System.Drawing.Point(13, 71);
            this.ChipTreeView.Margin = new System.Windows.Forms.Padding(3, 2, 10, 2);
            this.ChipTreeView.Name = "ChipTreeView";
            this.tableLayoutPanel1.SetRowSpan(this.ChipTreeView, 8);
            this.ChipTreeView.ShowNodeToolTips = true;
            this.ChipTreeView.Size = new System.Drawing.Size(206, 468);
            this.ChipTreeView.TabIndex = 5;
            this.ChipTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ChipTreeView_AfterSelect);
            this.ChipTreeView.Click += new System.EventHandler(this.ChipTreeView_Click);
            // 
            // ChipInfoListView
            // 
            this.ChipInfoListView.BackColor = System.Drawing.SystemColors.Info;
            this.ChipInfoListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.tableLayoutPanel1.SetColumnSpan(this.ChipInfoListView, 3);
            this.ChipInfoListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChipInfoListView.FullRowSelect = true;
            this.ChipInfoListView.GridLines = true;
            this.ChipInfoListView.Location = new System.Drawing.Point(239, 71);
            this.ChipInfoListView.Margin = new System.Windows.Forms.Padding(10, 2, 3, 2);
            this.ChipInfoListView.MultiSelect = false;
            this.ChipInfoListView.Name = "ChipInfoListView";
            this.tableLayoutPanel1.SetRowSpan(this.ChipInfoListView, 8);
            this.ChipInfoListView.Size = new System.Drawing.Size(645, 468);
            this.ChipInfoListView.TabIndex = 6;
            this.ChipInfoListView.UseCompatibleStateImageBehavior = false;
            this.ChipInfoListView.View = System.Windows.Forms.View.Details;
            this.ChipInfoListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ChipInfoListView_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "芯片型号";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "引脚";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "备注";
            this.columnHeader3.Width = 100;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Ok);
            this.panel1.Controls.Add(this.exit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(670, 543);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(214, 60);
            this.panel1.TabIndex = 7;
            // 
            // Ok
            // 
            this.Ok.Location = new System.Drawing.Point(115, 21);
            this.Ok.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(75, 38);
            this.Ok.TabIndex = 1;
            this.Ok.Text = "确定";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(0, 21);
            this.exit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 36);
            this.exit.TabIndex = 0;
            this.exit.Text = "取消";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.searchComBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(13, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(871, 53);
            this.panel2.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 3, 9);
            this.tableLayoutPanel1.Controls.Add(this.ChipTreeView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ChipInfoListView, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(897, 615);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // ChooseChipFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 615);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooseChipFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择芯片";
            this.VisibleChanged += new System.EventHandler(this.ChooseChipFrom_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox searchComBox;
        private System.Windows.Forms.TreeView ChipTreeView;
        private System.Windows.Forms.ListView ChipInfoListView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}