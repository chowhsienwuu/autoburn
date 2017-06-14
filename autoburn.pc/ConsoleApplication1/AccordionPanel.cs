using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExpanderApp;

namespace ConsoleApplication1
{
    public partial class AccordionPanel : UserControl
    {
        public AccordionPanel()
        {
            InitializeComponent();
            InitCustomerComponet();
        }

        private void InitCustomerComponet()
        {
            BorderStyle = BorderStyle.FixedSingle;
            InitChipInfoComponet();
            InitFileInfoComponet();
            InitProjectInfoComponet();
            InitProductionInfoComponet();
        }

        private string _chipinfoVendor;
        public string ChipinfoVendor
        {
            get
            {
                return _chipinfoVendor;
            }
            set
            {
                _chipinfoVendor = value;
                _ChipInfo.Content.Text = CalChipInfoString();
            }
        }

        private string _chipinfoName;
        public string ChipinforName
        {
            get
            {
                return _chipinfoName;
            }
            set
            {
                _chipinfoName = value;
                _ChipInfo.Content.Text = CalChipInfoString();
            }
        }

        private string _chipinfopackage;
        public string ChipinforPackage
        {
            get
            {
                return _chipinfopackage;
            }
            set
            {
                _chipinfopackage = value;
                _ChipInfo.Content.Text = CalChipInfoString();
            }
        }

        private string _chipinforBurner;
        public string ChipinforBurner
        {
            get
            {
                return _chipinforBurner;
            }
            set
            {
                _chipinforBurner = value;
                _ChipInfo.Content.Text = CalChipInfoString();
            }
        }

        public string _chipinfocapacity;
        public string ChipinforCapcity
        {
            get
            {
                return _chipinfocapacity;
            }
            set
            {
                _chipinfocapacity = value;
                _ChipInfo.Content.Text = CalChipInfoString();
            }
        }
        private string CalChipInfoString()
        {
            string tmp = "芯片厂商:" + _chipinfoVendor + System.Environment.NewLine;
            tmp += "芯片名称:" + _chipinfoName + System.Environment.NewLine;
            tmp += "芯片封装:" + _chipinfopackage + System.Environment.NewLine;
            tmp += "适配座:" + _chipinforBurner + System.Environment.NewLine;
            tmp += "芯片容量:" + _chipinfocapacity + System.Environment.NewLine;
            return tmp;
        }
        private void InitChipInfoComponet()
        {
            _ChipInfo = new Expander();
             _ChipInfo.Width = (int)(Width * 8.5 / 10);
            ExpanderHelper.CreateLabelHeader(_ChipInfo, "芯片信息", SystemColors.ActiveBorder);

            Label labelContent = new Label();
            labelContent.Text = CalChipInfoString();
            labelContent.Size = new System.Drawing.Size(_ChipInfo.Width, 80);
            _ChipInfo.Content = labelContent;

            this.MainflowLayoutPanel.Controls.Add(_ChipInfo);
        }

        private void InitFileInfoComponet()
        {
            _FileInfo = new Expander();
            //expander.Size = new Size(250, 400);
            //expander.Left = 350;
            //expander.Top = 10;
            //expander.BorderStyle = BorderStyle.FixedSingle;

            ExpanderHelper.CreateLabelHeader(_FileInfo, "文件信息", SystemColors.ActiveBorder);

            Label labelContent = new Label();
            labelContent.Text = "This is the content  p, a CustomControl, basically, anything you want.";
            //labelContent.Size = new System.Drawing.Size(_FileInfo.Width, 80);
            _FileInfo.Content = labelContent;

            // this.Controls.Add(_ChipInfo);
            this.MainflowLayoutPanel.Controls.Add(_FileInfo);
        }


        private void InitProductionInfoComponet()
        {
            _ProjectInfo = new Expander();
            //expander.Size = new Size(250, 400);
            //expander.Left = 350;
            //expander.Top = 10;
            //expander.BorderStyle = BorderStyle.FixedSingle;

            ExpanderHelper.CreateLabelHeader(_ProjectInfo, "工程信息", SystemColors.ActiveBorder);

            Label labelContent = new Label();
            labelContent.Text = "This is the content part.\r\n\r\nYou can put any Controls here. You can use a Panel, a CustomControl, basically, anything you want.";
         //   labelContent.Size = new System.Drawing.Size(_ProjectInfo.Width, 80);
            _ProjectInfo.Content = labelContent;

            // this.Controls.Add(_ChipInfo);
            this.MainflowLayoutPanel.Controls.Add(_ProjectInfo);
        }

        private void InitProjectInfoComponet()
        {
            _ProductionInfo = new Expander();
            //expander.Size = new Size(250, 400);
            //expander.Left = 350;
            //expander.Top = 10;
            //expander.BorderStyle = BorderStyle.FixedSingle;

            ExpanderHelper.CreateLabelHeader(_ProductionInfo, "量产信息", SystemColors.ActiveBorder);

            Label labelContent = new Label();
            labelContent.Text = "This is the content part.\r\n\r\nYou can put any Controls here. You can use a Panel, a CustomControl, basically, anything you want.";
            labelContent.Size = new System.Drawing.Size(_ProductionInfo.Width, 80);
            _ProductionInfo.Content = labelContent;

            // this.Controls.Add(_ChipInfo);
            this.MainflowLayoutPanel.Controls.Add(_ProductionInfo);
        }

        private Expander _ChipInfo;
        private Expander _FileInfo;
        private Expander _ProjectInfo;
        private Expander _ProductionInfo;
    }
}
