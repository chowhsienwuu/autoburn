using System.Windows.Forms;

namespace ConsoleApplication1
{
    partial class windowsform
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
            this.accordionPanel1 = new ConsoleApplication1.AccordionPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // accordionPanel1
            // 
            this.accordionPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.accordionPanel1.ChipinforBurner = null;
            this.accordionPanel1.ChipinforCapcity = null;
            this.accordionPanel1.ChipinforName = null;
            this.accordionPanel1.ChipinforPackage = null;
            this.accordionPanel1.ChipinfoVendor = null;
            this.accordionPanel1.Location = new System.Drawing.Point(372, 79);
            this.accordionPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.accordionPanel1.Name = "accordionPanel1";
            this.accordionPanel1.Size = new System.Drawing.Size(184, 379);
            this.accordionPanel1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(177, 112);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // windowsform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 478);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.accordionPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "windowsform";
            this.Text = "windowsform";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
       
        private AccordionPanel accordionPanel1;
        private TextBox textBox1;
    }
}