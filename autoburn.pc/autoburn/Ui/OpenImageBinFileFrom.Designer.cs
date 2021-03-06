﻿namespace Autoburn.Ui
{
    partial class OpenImageBinFileFrom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenImageBinFileFrom));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.OpenFile = new System.Windows.Forms.Button();
            this.openfiletext = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.filemd5sumlab = new System.Windows.Forms.Label();
            this.chacelbutton = new System.Windows.Forms.Button();
            this.okbutton = new System.Windows.Forms.Button();
            this.CalFileMD5work = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.29573F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.638555F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.OpenFile, 9, 0);
            this.tableLayoutPanel1.Controls.Add(this.openfiletext, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.filemd5sumlab, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.chacelbutton, 7, 9);
            this.tableLayoutPanel1.Controls.Add(this.okbutton, 9, 9);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(685, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "当前文件";
            // 
            // OpenFile
            // 
            this.OpenFile.Location = new System.Drawing.Point(614, 2);
            this.OpenFile.Margin = new System.Windows.Forms.Padding(2);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(69, 32);
            this.OpenFile.TabIndex = 2;
            this.OpenFile.Text = "打开文件";
            this.OpenFile.UseVisualStyleBackColor = true;
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // openfiletext
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.openfiletext, 4);
            this.openfiletext.Location = new System.Drawing.Point(274, 2);
            this.openfiletext.Margin = new System.Windows.Forms.Padding(2);
            this.openfiletext.Name = "openfiletext";
            this.openfiletext.Size = new System.Drawing.Size(268, 21);
            this.openfiletext.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 45);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "文件校验和";
            // 
            // filemd5sumlab
            // 
            this.filemd5sumlab.AutoSize = true;
            this.filemd5sumlab.Location = new System.Drawing.Point(342, 45);
            this.filemd5sumlab.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.filemd5sumlab.Name = "filemd5sumlab";
            this.filemd5sumlab.Size = new System.Drawing.Size(23, 12);
            this.filemd5sumlab.TabIndex = 4;
            this.filemd5sumlab.Text = "000";
            // 
            // chacelbutton
            // 
            this.chacelbutton.Location = new System.Drawing.Point(478, 407);
            this.chacelbutton.Margin = new System.Windows.Forms.Padding(2);
            this.chacelbutton.Name = "chacelbutton";
            this.chacelbutton.Size = new System.Drawing.Size(56, 18);
            this.chacelbutton.TabIndex = 6;
            this.chacelbutton.Text = "取消";
            this.chacelbutton.UseVisualStyleBackColor = true;
            this.chacelbutton.Click += new System.EventHandler(this.chacelbutton_Click);
            // 
            // okbutton
            // 
            this.okbutton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.okbutton.Location = new System.Drawing.Point(614, 407);
            this.okbutton.Margin = new System.Windows.Forms.Padding(2);
            this.okbutton.Name = "okbutton";
            this.okbutton.Size = new System.Drawing.Size(69, 41);
            this.okbutton.TabIndex = 7;
            this.okbutton.Text = "确定";
            this.okbutton.UseVisualStyleBackColor = true;
            this.okbutton.Click += new System.EventHandler(this.okbutton_Click);
            // 
            // OpenImageBinFileFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "OpenImageBinFileFrom";
            this.ShowInTaskbar = false;
            this.Text = "OpenImageBinFile";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox openfiletext;
        private System.Windows.Forms.Button OpenFile;

        private System.Windows.Forms.Label filemd5sumlab;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button chacelbutton;
        private System.Windows.Forms.Button okbutton;
    }
}