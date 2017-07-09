using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autoburn;
using Autoburn.Ui;
using Autoburn.util;

namespace Autoburn.Ui
{
    public partial class AccordionPanel : UserControl
    {
        public const string TAG = "AccordionPanel";
        public AccordionPanel()
        {
            InitializeComponent();
            InitCustomerComponet();

            this.Resize += delegate
            {
                foreach (Control c in MainflowLayoutPanel.Controls)
                {
                    c.Width = (int)(MainflowLayoutPanel.Width * 9.7 / 10);
                  //  c.Height = 0;
                }
            };
        }

        private void InitCustomerComponet()
        {
            BorderStyle = BorderStyle.FixedSingle;
            InitChipInfoComponet();
            InitFileInfoComponet();
         //   InitFileInfoComponet();

            InitProductionInfoComponet();
            InitProjectInfoComponet(); 
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

        private string _chipinfocapacity;
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
            ExpanderHelper.CreateLabelHeader(_ChipInfo, "芯片信息", SystemColors.ActiveBorder);

            Label labelContent = new Label();
            labelContent.Text = CalChipInfoString();
            labelContent.Size = new System.Drawing.Size(_ChipInfo.Width, 80);
            _ChipInfo.Content = labelContent;

            this.MainflowLayoutPanel.Controls.Add(_ChipInfo);
        }

        public void SetFileInfo(string filename, long filesize, string filemd5)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("文件名称: " + filename + Environment.NewLine);
            sb.Append("文件大小: " + filesize.ToString() + " Byte" + Environment.NewLine);
            sb.Append("文件MD5: : " + filemd5 + Environment.NewLine);

            ProgLog.D(TAG, sb.ToString());
            _FileInfo.Content.Text = sb.ToString();
        }

        private void InitFileInfoComponet()
        {
            _FileInfo = new Expander();

            ExpanderHelper.CreateLabelHeader(_FileInfo, "文件信息", SystemColors.ActiveBorder);

            Label labelContent = new Label();
            _FileInfo.Content = labelContent;
            SetFileInfo(string.Empty, 20L, string.Empty);
            labelContent.Height = 80;

          //  labelContent.Text = CalChipInfoString();

            this.MainflowLayoutPanel.Controls.Add(_FileInfo);
        }

        private void InitProductionInfoComponet()
        {
            _ProjectInfo = new Expander();
            ExpanderHelper.CreateLabelHeader(_ProjectInfo, "工程信息", SystemColors.ActiveBorder);

            Label labelContent = new Label();
            labelContent.Text = "This is the content part. You can put any Controls here. You can use a Panel, a CustomControl, basically, anything you want.";
             labelContent.Size = new System.Drawing.Size(_ProjectInfo.Width, 80);
            _ProjectInfo.Content = labelContent;

            this.MainflowLayoutPanel.Controls.Add(_ProjectInfo); 
        }

        private void InitProjectInfoComponet()
        {
            _ProductionInfo = new Expander();

            ExpanderHelper.CreateLabelHeader(_ProductionInfo, "量产信息", SystemColors.ActiveBorder);

            Label labelContent = new Label();
            labelContent.Text = "This is the content part. You can put any Controls here. You can use a Panel, a CustomControl, basically, anything you want.";
            labelContent.Size = new System.Drawing.Size(_ProductionInfo.Width, 80);
            _ProductionInfo.Content = labelContent;

            this.MainflowLayoutPanel.Controls.Add(_ProductionInfo);
        }

        private Expander _ChipInfo;
        private Expander _FileInfo;
        private Expander _FileInfo2;
        private Expander _ProjectInfo;
        private Expander _ProductionInfo;
    }
}
