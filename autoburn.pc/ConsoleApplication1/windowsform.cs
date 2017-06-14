using ExpanderApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApplication1
{
    public partial class windowsform : Form
    {
        public windowsform()
        {
            InitializeComponent();
            CreateFloatingExpander1();
        }

        private void CreateFloatingExpander1()
        {
            Expander expander = new Expander();
            expander.Size = new Size(250, 400);

            ExpanderHelper.CreateLabelHeader(expander, "Header", SystemColors.ActiveBorder);
            // ExpanderHelper.CreateLabelHeader(expander, "Header", SystemColors.ActiveBorder, Pictureres.Collapse, Pictureres.Expand);
            Label labelContent = new Label();
            labelContent.Text = "This is the content part.\r\n\r\nYou can put any Controls here. You can use a Panel, a CustomControl, basically, anything you want.";
            labelContent.Size = new System.Drawing.Size(expander.Width, 80);
            expander.Content = labelContent;
            this.Controls.Add(expander);
        }
    }
}
