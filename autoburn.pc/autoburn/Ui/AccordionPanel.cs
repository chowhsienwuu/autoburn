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
using Autoburn.Manager;

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
                }
            };
        }

        private void InitCustomerComponet()
        {
            BorderStyle = BorderStyle.FixedSingle;
            InitChipInfoComponet();
            InitFileInfoComponet();

         //   InitProductionInfoComponet();
         //   InitProjectInfoComponet(); 
        }

        private ChipInfo _CurrentChipInfo = new ChipInfo();
        public ChipInfo CurrentChipInfo
        {
            get
            {
                return _CurrentChipInfo;
            }

            set
            {
                _CurrentChipInfo = value;
                _ChipInfo.Content.Text = CalChipInfoString();
            }
        }

        private string CalChipInfoString()
        {
            string tmp = "芯片厂商:" + CurrentChipInfo.vendor + System.Environment.NewLine;
            tmp += "芯片名称:" + CurrentChipInfo.name + System.Environment.NewLine;
            tmp += "芯片封装:" + CurrentChipInfo.package + System.Environment.NewLine;
            tmp += "适配座:" + CurrentChipInfo.burner + System.Environment.NewLine;
            return tmp;
        }

        private void InitChipInfoComponet()
        {
            _ChipInfo = new Expander();
            _ChipInfo.CreateLabelHeader(_ChipInfo, "芯片信息", SystemColors.ActiveBorder);

            Label labelContent = new Label();
            labelContent.Size = new System.Drawing.Size(_ChipInfo.Width, 80);
            labelContent.Text = CalChipInfoString();
            _ChipInfo.Content = labelContent;

            this.MainflowLayoutPanel.Controls.Add(_ChipInfo);
        }

        private ImgBinFileInfo _CurrentimgBintFileInfo = new ImgBinFileInfo();
        internal ImgBinFileInfo CurrentimgBintFileInfo
        {
            get
            {
                return _CurrentimgBintFileInfo;
            }
            set
            {
                _CurrentimgBintFileInfo = value;
                _FileInfo.Content.Text = SetFileInfo();
            }
        }



        private string SetFileInfo()
        {
            string tmp = "";
            tmp += "文件名称: " + _CurrentimgBintFileInfo.ImageBinFileName + Environment.NewLine;
            tmp += "文件大小: " + _CurrentimgBintFileInfo.ImageBinFileLen.ToString() + " Byte" + Environment.NewLine;
            tmp += "文件MD5: " + _CurrentimgBintFileInfo.ImageBinFileMD5Sum + Environment.NewLine;
            return tmp;
        }

        private void InitFileInfoComponet()
        {
            _FileInfo = new Expander();
            _ChipInfo.CreateLabelHeader(_FileInfo, "文件信息", SystemColors.ActiveBorder);

            Label labelContent = new Label();
            labelContent.Size = new System.Drawing.Size(_FileInfo.Width, 80);
            _FileInfo.Content = labelContent;
            _FileInfo.Content.Text = SetFileInfo();

            this.MainflowLayoutPanel.Controls.Add(_FileInfo);
        }

        //private void InitProductionInfoComponet()
        //{
        //    _ProjectInfo = new Expander();
        //    ExpanderHelper.CreateLabelHeader(_ProjectInfo, "工程信息", SystemColors.ActiveBorder);

        //    Label labelContent = new Label();
        //    labelContent.Text = "This is the content part. You can put any Controls here. You can use a Panel, a CustomControl, basically, anything you want.";
        //     labelContent.Size = new System.Drawing.Size(_ProjectInfo.Width, 80);
        //    _ProjectInfo.Content = labelContent;

        //    this.MainflowLayoutPanel.Controls.Add(_ProjectInfo); 
        //}

        //private void InitProjectInfoComponet()
        //{
        //    _ProductionInfo = new Expander();

        //    ExpanderHelper.CreateLabelHeader(_ProductionInfo, "量产信息", SystemColors.ActiveBorder);

        //    Label labelContent = new Label();
        //    labelContent.Text = "This is the content part. You can put any Controls here. You can use a Panel, a CustomControl, basically, anything you want.";
        //    labelContent.Size = new System.Drawing.Size(_ProductionInfo.Width, 80);
        //    _ProductionInfo.Content = labelContent;

        //    this.MainflowLayoutPanel.Controls.Add(_ProductionInfo);
        //}

        private Expander _ChipInfo;
        private Expander _FileInfo;

        private Expander _ProjectInfo;
        private Expander _ProductionInfo;
    }
}
