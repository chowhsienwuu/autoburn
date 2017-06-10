using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autoburn.ui
{
    public partial class ChooseChipFrom : Form
    {
        public ChooseChipFrom()
        {
            InitializeComponent();
            InitlizeComPonet2();
        }

        private void InitlizeComPonet2()
        {
            // ser
            string[] history = { "283", ".sdks", "9238888" };
            searchComBox.Items.AddRange(history);


            TreeNode[] tnarray = new TreeNode[8];
               
            for (int i = 0; i < tnarray.Length; i++)
            {
                TreeNode[] tnsub = new TreeNode[i];
                for (int j = 0; j < tnsub.Length; j++)
                {
                    TreeNode tntemp = new TreeNode("sub : " + j);
                    tnsub[j] = tntemp;
                }

                TreeNode tn = new TreeNode("" , tnsub);
                tn.Text = "root: " + i;
                tnarray[i] = tn;
            }

            ChipTreeView.Nodes.AddRange(tnarray);

            //   ColumnHeader ch = new ColumnHeader();

            //   ch.Text = "列标题1";   //设置列标题

            ////   ch.Width = 120;    //设置列宽度

            //   ch.TextAlign = HorizontalAlignment.Left;   //设置列的对齐方式
            //   ChipInfoListView.Columns.Add(ch);
            //ChipInfoListView.Columns.
            this.ChipInfoListView.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
            for (int i = 0; i < 10; i++)   //添加10行数据
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = "item " + i;
                lvi.SubItems.Add("第2列,第" + i + "行");
                lvi.SubItems.Add("第3列,第" + i + "行");

                this.ChipInfoListView.Items.Add(lvi);
            }

            this.ChipInfoListView.EndUpdate();  //结束数据处理，UI界面一次性绘制。
        }

        private void searchComBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ChipTreeView_Click(object sender, EventArgs e)
        {
            Console.WriteLine(".." +  sender);
        }

        private void ChipTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView tv = sender as TreeView;
            TreeNode tn = tv.SelectedNode;
            Console.WriteLine("ChipTreeView_AfterSelect.." + tn.Text + 
                " " + tn.Index);
        }

        private void ChipInfoListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ci = sender as ListView;
            var itm = ci.SelectedItems;
           // Console.WriteLine("ListView " + itm.ToString() + itm.);
        }
    }
}
