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
            this.SuspendLayout();
            // 
            // accordionPanel1
            // 
            this.accordionPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.accordionPanel1.Location = new System.Drawing.Point(496, 99);
            this.accordionPanel1.Name = "accordionPanel1";
            this.accordionPanel1.Size = new System.Drawing.Size(245, 473);
            this.accordionPanel1.TabIndex = 0;
            // 
            // windowsform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 598);
            this.Controls.Add(this.accordionPanel1);
            this.Name = "windowsform";
            this.Text = "windowsform";
            this.ResumeLayout(false);

        }

        #endregion

        private AccordionPanel accordionPanel1;
    }
}