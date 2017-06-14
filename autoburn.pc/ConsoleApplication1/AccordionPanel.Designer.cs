namespace ConsoleApplication1
{
    partial class AccordionPanel
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.MainflowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // MainflowLayoutPanel
            // 
            this.MainflowLayoutPanel.AutoScroll = true;
            this.MainflowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainflowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.MainflowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainflowLayoutPanel.Name = "MainflowLayoutPanel";
            this.MainflowLayoutPanel.Size = new System.Drawing.Size(245, 289);
            this.MainflowLayoutPanel.TabIndex = 0;
            this.MainflowLayoutPanel.WrapContents = false;
            // 
            // AccordionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainflowLayoutPanel);
            this.Name = "AccordionPanel";
            this.Size = new System.Drawing.Size(245, 289);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel MainflowLayoutPanel;
    }
}
