using Autoburn.Manager;
using Autoburn.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autoburn.Ui
{
    public partial class ChooseChipFrom : Form
    {
        public const string TAG = "ChooseChipFrom";
        public ChooseChipFrom()
        {
            InitializeComponent();
             //InitlizeComPonet2();
            LoadFile2UI();
        }

        #region Events
        public event EventHandler StateChanged;
        #endregion
        private void LoadFile2UI()
        {
              this.columnHeader1.Width = 200;
            //Dictionary<string, object[]> _venderseriesDictionary =
            //    DeviceManager.Instance.ChipSupportManager.VenderseriesDictionary;

            //List<TreeNode> vendertreenodelist = new List<TreeNode>();
            //foreach (KeyValuePair<string, object[]> kvp in _venderseriesDictionary)
            //{
            //    List<TreeNode> seriesTreeNodelist = new List<TreeNode>();
            //    foreach (object series in kvp.Value)
            //    {
            //        seriesTreeNodelist.Add(new TreeNode(series.ToString()));
            //    }
            //    TreeNode tn = new TreeNode(kvp.Key, seriesTreeNodelist.ToArray());
            //    tn.Text = "999";
            //    vendertreenodelist.Add(tn);
            //}

            //ChipTreeView.Nodes.AddRange(vendertreenodelist.ToArray());

            _AllChipList = DeviceManager.Instance.ChipSupportManager.AllChipInfo;
            var venderset = new HashSet<string>();
            foreach (ChipInfo chip in _AllChipList)
            {
                venderset.Add(chip.vendor);
            }

            List<TreeNode> vendertreenodelist = new List<TreeNode>();
            foreach (string vendorstring in venderset)
            {
                List<TreeNode> seriesTreeNodelist = new List<TreeNode>();
                var seriesset = new HashSet<string>();
                foreach (ChipInfo chip in _AllChipList)
                {
                    if (vendorstring.Equals(chip.vendor))
                    {
                        seriesset.Add(chip.series);
                    }
                }
                foreach (string seriesstring in seriesset)
                {
                    seriesTreeNodelist.Add(new TreeNode(seriesstring));
                }
                TreeNode tn = new TreeNode(vendorstring, seriesTreeNodelist.ToArray<TreeNode>());
                vendertreenodelist.Add(tn);
            }
            ChipTreeView.Nodes.AddRange(vendertreenodelist.ToArray<TreeNode>());
        }

        private List<ChipInfo> _AllChipList;
        private void searchComBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProgLog.D("", "searchComBox_SelectedIndexChanged");
        }

        private void ChipTreeView_Click(object sender, EventArgs e)
        {
            Console.WriteLine(".." +  sender);
        }

        private void ChipTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView tv = sender as TreeView;
            TreeNode tn = tv.SelectedNode;
            ProgLog.D("ChipTreeView_AfterSelect.." + tn.Text +   " " + tn.Index + "--" + tn.FullPath + " " );
            if (tn.FullPath.Contains(@"\"))
            {
                //List<ChipInfo> chipinfolist = 
                //    DeviceManager.Instance.ChipSupportManager.GetChipInfo(tn.Parent.Text, tn.Text);

                var chipinfolist = new List<ChipInfo>();
                foreach(ChipInfo chip in _AllChipList)
                {
                    if (tn.Parent.Text.Equals(chip.vendor) && tn.Text.Equals(chip.series))
                    {
                        chipinfolist.Add(chip);
                    }
                }
                LoadChipList2UI(chipinfolist);
            }
        }

        private void LoadChipList2UI(List<ChipInfo> list)
        {
            this.ChipInfoListView.BeginUpdate();   
            ChipInfoListView.Items.Clear();
            foreach (ChipInfo chip in list)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = chip.name;
                lvi.SubItems.Add(chip.package);
                lvi.SubItems.Add(chip.burner);
                lvi.SubItems.Add(chip.note);
                ChipInfoListView.Items.Add(lvi);
            }
            this.ChipInfoListView.EndUpdate();  
        }

        private void searchComBox_TextChanged(object sender, EventArgs e)
        {
            ProgLog.D("", "searchComBox_TextChanged");
        }

        private void ChipInfoListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var ci = sender as ListView;
            var itm = ci.SelectedItems;
            foreach (ListViewItem lvi in itm)
            {
                ProgLog.D("", "ChipInfoListView_ItemSelectionChanged lvi " + lvi.Name + " lvi " + lvi.Text);
                searchComBox.Text = lvi.Text;
                foreach (ChipInfo chip in _AllChipList)
                {
                    if (chip.name.Equals(lvi.Text))
                    {
                        _CurrentChooseChip = chip;
                    }
                }
            }
           // ProgLog.D("", "ChipInfoListView_ItemSelectionChanged " + e.IsSelected + " " + e.Item.Name + ".." + e.Item.Text);
        }

        ChipInfo _CurrentChooseChip = null;
        public ChipInfo CurrentChooseChip {
            get
            {
                return _CurrentChooseChip;
            }
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            if (_CurrentChooseChip != null)
            {
                DeviceManager.Instance.ConfigManager.PutChooseChipHistoryItem(_CurrentChooseChip.name);
                SystemLog.I(TAG, "选择芯片" + _CurrentChooseChip.ToString());
            }

            this.Hide();
            var ChooseChipFromEventArgs = new ChooseChipFromEventArgs();
            ChooseChipFromEventArgs.ChipInfo = _CurrentChooseChip;
            StateChanged?.Invoke(this, ChooseChipFromEventArgs);
        }

        private void ChooseChipFrom_VisibleChanged(object sender, EventArgs e)
        {
            ProgLog.D("", "ChooseChipFrom_VisibleChanged  visable: " + Visible);
            if (Visible)
            {
                searchComBox.Items.Clear();
                List<string> history = DeviceManager.Instance.ConfigManager.GetSavedChooseChipHistory();

                searchComBox.Items.AddRange(history.ToArray());
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Hide();

            var ChooseChipFromEventArgs = new ChooseChipFromEventArgs();
            ChooseChipFromEventArgs.ChipInfo = _CurrentChooseChip;
            StateChanged?.Invoke(this, ChooseChipFromEventArgs);
        }

        public class ChooseChipFromEventArgs : EventArgs
        {
            public ChipInfo ChipInfo { get; set; }
        }

        #region not use 
        private void InitlizeComPonet2()
        {
            // ser
            //string[] history = { "283", ".sdks", "9238888" };
            //searchComBox.Items.AddRange(history);
            //   TreeNode[] tnarray = new TreeNode[8];
            List<TreeNode> tnarray = new List<TreeNode>();
            //for (int i = 0; i < 8; i++)
            //{
            //    TreeNode[] tnsub = new TreeNode[i];
            //    for (int j = 0; j < tnsub.Length; j++)
            //    {
            //        TreeNode tntemp = new TreeNode("sub : " + j);
            //        tnsub[j] = tntemp;
            //    }

            //    TreeNode tn = new TreeNode("" , tnsub);
            //    tn.Text = "root: " + i;
            //    tnarray.Add( tn);
            //}
            tnarray.Add(new TreeNode("999"));
            ChipTreeView.Nodes.AddRange(tnarray.ToArray<TreeNode>());
            //this.ChipInfoListView.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
            //for (int i = 0; i < 10; i++)   //添加10行数据
            //{
            //    ListViewItem lvi = new ListViewItem();
            //    lvi.Text = "item " + i;
            //    lvi.SubItems.Add("第2列,第" + i + "行");
            //    lvi.SubItems.Add("第3列,第" + i + "行");
            //    this.ChipInfoListView.Items.Add(lvi);
            //}

            //this.ChipInfoListView.EndUpdate();  //结束数据处理，UI界面一次性绘制。
        }
        #endregion
    }
}
